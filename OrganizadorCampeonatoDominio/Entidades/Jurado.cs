using OrganizadorCampeonatoDominio.ObjetoDeValor;

namespace OrganizadorCampeonatoDominio.Entidades
{
    public class Jurado
    {
        public int Id { get; set; }
        public int FaseId { get; set; }
        public virtual Fase Fase { get; set; }
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
   



    }

}
