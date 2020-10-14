namespace Manager.Domain.Core.Comandos.Projetos.Modelos
{
    public abstract class DocumentoBase
    {
        public string Titulo { get; set; }
        public string URL { get; set; }
        public int ProjetoId { get; set; }
    }
}
