using Manager.Domain.Enums;

namespace Manager.Domain.Entidades
{
    public class TipoUsuario
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public bool Administrador { get { return Id == (int)UsuarioEnum.Administrador; }}
        public bool Gerente { get { return Id == (int)UsuarioEnum.Gerente; }}
        public bool MembroEquipe { get { return Id == (int)UsuarioEnum.MembroEquipe; }}
        public bool Cliente { get { return Id == (int)UsuarioEnum.Cliente; }}
    }
}