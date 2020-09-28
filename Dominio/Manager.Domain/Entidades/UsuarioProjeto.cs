namespace Manager.Domain.Entidades
{
    public class UsuarioProjeto
    {
        //representa relacionamento Muitos para Muitos
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }

        public int ProjetoId { get; set; }
        public virtual Projeto Projeto { get; set; }
    }
}