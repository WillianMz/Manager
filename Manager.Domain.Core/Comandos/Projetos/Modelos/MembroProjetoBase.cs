namespace Manager.Domain.Core.Comandos.Projetos.Modelos
{
    public abstract class MembroProjetoBase
    {
        public int ProjetoId { get; set; }
        public int UsuarioId { get; set; }
        public bool Gerente { get; set; }
    }
}
