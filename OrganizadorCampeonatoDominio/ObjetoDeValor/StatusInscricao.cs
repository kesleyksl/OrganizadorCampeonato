using OrganizadorCampeonatoDominio.Enums;

namespace OrganizadorCampeonatoDominio.ObjetoDeValor
{
    public class StatusInscricao
    {
        public int StatusCompetIdorId { get; set; }
        public string Nome { get; set; }

        public bool ehConfirmado
        {
            get { return StatusCompetIdorId == (int)StatusCompetidorEnum.Confirmado; }

        }
        public bool ehPendente
        {
            get { return StatusCompetIdorId == (int)StatusCompetidorEnum.Pendente; }

        }
        public bool ehCancelado
        {
            get { return StatusCompetIdorId == (int)StatusCompetidorEnum.Cancelado; }

        }

    }
}
