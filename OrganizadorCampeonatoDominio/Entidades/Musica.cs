namespace OrganizadorCampeonatoDominio.Entidades
{
    public class Musica : Entidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cantor { get; set; }
        public int FaseId { get; set; }
        public virtual Fase Fase { get; set; }

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
