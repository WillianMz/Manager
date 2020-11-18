namespace Manager.Domain.Queries.DTOs
{
    public class ProjetoUsuarioDTO
    {
        public int Id { get; set; }        
        public string Projeto { get; set; }
        public string Usuario { get; set; }
        public bool Gerente { get; set; }
    }
}
