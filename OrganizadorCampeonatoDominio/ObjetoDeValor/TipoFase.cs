using OrganizadorCampeonatoDominio.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrganizadorCampeonatoDominio.ObjetoDeValor
{
    public class TipoFase
    {
        public int TipoFaseID { get; set; }
        public string Nome { get; set; }

        public bool ehJackAndJill
        {
            get { return TipoFaseID == (int)FormatoCampeonatoEnum.JackAndJill; }

        }
        public bool ehImproviso
        {
            get { return TipoFaseID == (int)FormatoCampeonatoEnum.Improviso; }

        }
        public bool ehCoreografia
        {
            get { return TipoFaseID == (int)FormatoCampeonatoEnum.Coreografia; }

        }

    }
}
