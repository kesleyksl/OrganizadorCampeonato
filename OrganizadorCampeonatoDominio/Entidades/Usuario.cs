using System.Collections.Generic;

namespace OrganizadorCampeonatoDominio.Entidades
{
    public class Usuario : Entidade
    {
        public int UsuarioID { get; set; }
        public string Nome { get; set; }
        public char Sexo { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public ICollection<Campeonato> Campeonatos { get; set; }

        public override void Validate()
        {
            LimparMensagensValidacao();

            if (string.IsNullOrEmpty(Nome))
            {
                AdicionarMensagem("O usuario deve ter um nome");
            }
            if (string.IsNullOrEmpty(Email))
            {
                AdicionarMensagem("O Email deve ser fornecido");
            }
            if (string.IsNullOrEmpty(Telefone))
            {
                AdicionarMensagem("O telefone deve ser fornecido");
            }
        }
    }
}
