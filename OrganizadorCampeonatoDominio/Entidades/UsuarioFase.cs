namespace OrganizadorCampeonatoDominio.Entidades
{
    class UsuarioFase : Entidade
    {
        public int FaseID { get; set; }
        public int UsuarioID { get; set; }
        public int MusicaID { get; set; }
        public double Nota { get; set; }
    }
}
