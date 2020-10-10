namespace Manager.Application.DTOs
{
    public class DocumentoDTO
    {
        public int? Id { get; set; }
        public string Titulo { get; set; }
        public string URL { get; set; }
        public int ProjetoId { get; set; }
        public ProjetoDTO Projeto { get; set; }
    }
}
