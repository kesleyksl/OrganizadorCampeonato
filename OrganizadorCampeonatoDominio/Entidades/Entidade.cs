using System.Collections.Generic;
using System.Linq;

namespace OrganizadorCampeonatoDominio.Entidades
{
    public abstract class Entidade
    {
        public List<string> _mensagensValidacao { get; set; }

        protected void LimparMensagensValidacao()
        {
            mensagemValidacao.Clear();
        }

        protected void AdicionarMensagem(string mensagem)
        {
            mensagemValidacao.Add(mensagem);
        }
        private List<string> mensagemValidacao
        {
            get
            {
                return _mensagensValidacao ?? (_mensagensValidacao = new List<string>());
            }
        }

        public abstract void Validate();
        protected bool ehValido
        {
            get { return !mensagemValidacao.Any(); }
        }
    }
}
