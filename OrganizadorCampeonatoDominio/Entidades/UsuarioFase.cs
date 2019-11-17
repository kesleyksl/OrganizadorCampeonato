namespace OrganizadorCampeonatoDominio.Entidades
{
    public class UsuarioFase : Entidade
    {
        public int FaseID { get; set; }
        public int UsuarioID { get; set; }
        public int MusicaID { get; set; }
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
