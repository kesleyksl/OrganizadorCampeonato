using System.Collections.Generic;
using System.Linq;

namespace OrganizadorCampeonatoDominio.Entidades
{
    public class Campeonato : Entidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int UsuarioId { get; set; }
        //public virtual Usuario Usuario { get; set; }
        //public int RegulamentoID { get; set; }
        public string NomeArquivo { get; set; }

        public virtual ICollection<Fase> Fases { get; set; }

        public override void Validate()
        {
            LimparMensagensValidacao();

            if (string.IsNullOrEmpty(Nome))
            {
                AdicionarMensagem("O campeonato deve ter um nome");
            }
            //if (!Fases.Any())
            //{
            //    AdicionarMensagem("O campeonato deve ter pelo menos uma fase");
            //}
        }
    }
}
