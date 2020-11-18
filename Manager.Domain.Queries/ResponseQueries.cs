namespace Manager.Domain.Queries
{
    public class ResponseQueries
    {
       // public ResponseQueries() { }

        public ResponseQueries(bool sucesso, string mensagem, object dados)
        {
            Sucesso = sucesso;
            Mensagem = mensagem;
            Dados = dados;
        }

        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public object Dados { get; set; }
    }
}
