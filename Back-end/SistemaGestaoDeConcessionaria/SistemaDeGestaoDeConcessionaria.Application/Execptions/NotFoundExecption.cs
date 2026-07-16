namespace SistemaGestaoDeConcessionaria.Application.Execptions
{
    public class NotFoundExecption : Exception
    {
        public NotFoundExecption(string message) : base(message)
        {
        }
    }
}
