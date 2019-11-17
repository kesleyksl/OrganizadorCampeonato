using System.Collections.Generic;

namespace OrganizadorCampeonatoDominio.Entidades
{
    class Usuario : Entidade
    {
        public int UsuarioID { get; set; }
        public string Nome { get; set; }
        public char Sexo { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public ICollection<Campeonato> Campeonatos { get; set; }


    }
}
