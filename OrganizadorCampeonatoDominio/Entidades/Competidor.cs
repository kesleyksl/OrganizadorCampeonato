﻿using OrganizadorCampeonatoDominio.ObjetoDeValor;

namespace OrganizadorCampeonatoDominio.Entidades
{
    public class Competidor
    {
        public int Id { get; set; }
        public int CampeonatoId { get; set; }
        public virtual Campeonato Campeonato { get; set; }
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        //public int FaseId { get; set; }
        //public virtual Fase Fase { get; set; }

        public int StatusInscricaoId { get; set; }
        public virtual StatusInscricao StatusInscricao { get; set; }


    }

}
