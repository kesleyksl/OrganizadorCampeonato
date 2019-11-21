using OrganizadorCampeonatoDominio.Enums;

namespace OrganizadorCampeonatoDominio.ObjetoDeValor
{
    public class TipoFase
    {
        public int TipoFaseId { get; set; }
        public string Nome { get; set; }

        public bool ehJackAndJill
        {
            get { return TipoFaseId == (int)FormatoCampeonatoEnum.JackAndJill; }

        }
        public bool ehImproviso
        {
            get { return TipoFaseId == (int)FormatoCampeonatoEnum.Improviso; }

        }
        public bool ehCoreografia
        {
            get { return TipoFaseId == (int)FormatoCampeonatoEnum.Coreografia; }

        }

    }
}
