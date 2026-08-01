using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaGestaoDeConcessionaria.Domain.Entities
{
    public class ImagensAutomovel
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string PublicId { get; set; } 
        public int idAutomovel { get; set; }
        public Automovel Automovel { get; set; }
    }
}
