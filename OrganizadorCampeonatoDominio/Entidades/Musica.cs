namespace OrganizadorCampeonatoDominio.Entidades
{
    public class Musica : Entidade
    {
        public int MusicaID { get; set; }
        public string Nome { get; set; }
        public string Cantor { get; set; }

        public override void Validate()
        {
            LimparMensagensValidacao();

            if (string.IsNullOrEmpty(Nome))
            {
                AdicionarMensagem("A musica deve ter um nome");

            }
            if (string.IsNullOrEmpty(Cantor))
            {
                AdicionarMensagem("Nome do cantor é obrigatório");
            }
        }
    }
}
