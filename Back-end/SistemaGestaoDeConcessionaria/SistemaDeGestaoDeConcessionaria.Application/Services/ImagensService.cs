using CloudinaryDotNet;
using Microsoft.AspNetCore.Http;
using SistemaDeGestaoDeConcessionaria.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;
using Microsoft.Extensions.Configuration;
using CloudinaryDotNet.Actions;

namespace SistemaDeGestaoDeConcessionaria.Application.Services
{
    public class ImagensService : IImagensService
    {
        private readonly Cloudinary _cloudinary;

        public ImagensService(IConfiguration config)
        {
            var account = new Account(
                config["CloudinarySettings:CloudName"],
                config["CloudinarySettings:ApiKey"],
                config["CloudinarySettings:ApiSecret"]
            );
            _cloudinary = new Cloudinary(account);
        }

        public async Task<(string Url, string PublicId)> UploadImageAsync(IFormFile file)
        {
            if (file.Length > 0)
            {
                using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    Folder = "concessionaria/automoveis"
                };

                var uploadResult = await _cloudinary.UploadAsync(uploadParams);

                if (uploadResult.Error != null)
                {
                    throw new Exception(uploadResult.Error.Message);
                }

                return (uploadResult.SecureUrl.ToString(), uploadResult.PublicId);
            }
            return (null, null);
        }

        public async Task<bool> DeleteImageAsync(string publicId)
        {
            var deleteParams = new DeletionParams(publicId);
            var result = await _cloudinary.DestroyAsync(deleteParams);
            return result.Result == "ok";
        }
    }
}
