using Manager.Domain.Enums;

namespace Manager.Domain.Entidades
{
    public class Status
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public bool Aberto { get { return Id == (int)StatusEnum.Aberto; }}
        public bool EmAndamento { get { return Id == (int)StatusEnum.EmAndamento; }}
        public bool Concluido { get { return Id == (int)StatusEnum.Concluido; }}
        public bool Cancelado { get { return Id == (int)StatusEnum.Cancelado; }}
    }
}