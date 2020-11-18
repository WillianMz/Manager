namespace Manager.Domain.Queries.DTOs
{
    public class ReleaseDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Versao { get; set; }
        public string DataCriacao { get; set; }
        public string DataLiberacao { get; set; }
        public string Usuario { get; set; }

    }
}
