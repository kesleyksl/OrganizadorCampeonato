namespace OrganizadorCampeonatoDominio.Entidades
{
    public class UsuarioFase : Entidade
    {
        public int Id { get; set; }
        public int FaseId { get; set; }
        public int CompetidorId { get; set; }
        public int MusicaId { get; set; }
        public double Nota { get; set; }

        public override void Validate()
        {
            LimparMensagensValidacao();

            if (Nota < 0)
            {
                AdicionarMensagem("A nota não pode ser negativa");
            }
        }
    }
}
