using OrganizadorCampeonatoDominio.Enums;

namespace OrganizadorCampeonatoDominio.ObjetoDeValor
{
    public class StatusInscricao
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public bool ehConfirmado
        {
            get { return Id == (int)StatusCompetidorEnum.Confirmado; }

        }
        public bool ehPendente
        {
            get { return Id == (int)StatusCompetidorEnum.Pendente; }

        }
        public bool ehCancelado
        {
            get { return Id == (int)StatusCompetidorEnum.Cancelado; }

        }

    }
}
