using Manager.Domain.Enums;

namespace Manager.Domain.Entidades
{
    public class Prioridade
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public bool Baixo { get { return Id == (int)PrioridadeEnum.Baixo; }}
        public bool Normal { get { return Id == (int)PrioridadeEnum.Normal; }}
        public bool Alto { get { return Id == (int)PrioridadeEnum.Alto; }}
        public bool Urgente { get { return Id == (int)PrioridadeEnum.Urgente; }}
    }
}