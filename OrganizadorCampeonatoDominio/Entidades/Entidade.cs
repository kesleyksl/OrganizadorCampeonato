using System.Collections.Generic;
using System.Linq;

namespace OrganizadorCampeonatoDominio.Entidades
{
    public abstract class Entidade
    {
        private List<string> _mensagensValidacao { get; set; }

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
        public string ObterMensagemValidacao()
        {
            return string.Join(". ", mensagemValidacao);
        }
        public abstract void Validate();
        public bool EhValido
        {
            get { return !mensagemValidacao.Any(); }
        }
    }
}
