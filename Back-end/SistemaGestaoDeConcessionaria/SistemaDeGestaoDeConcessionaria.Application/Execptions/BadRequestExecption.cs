namespace SistemaGestaoDeConcessionaria.Application.Execptions
{
    public class BadRequestExecption : Exception
    {
        public BadRequestExecption(string message) : base(message)
        {
        }
    }
}
