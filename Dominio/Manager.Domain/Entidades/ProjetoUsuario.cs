namespace Manager.Domain.Entidades
{
    public class ProjetoUsuario
    {
        public int ProjetoId { get; private set; }
        public int UsuarioId { get; private set; }

        public virtual Projeto Projeto { get; private set; }
        public virtual Usuario Usuario { get; private set; }
    }
}
