namespace NavegacionDinamica.Models
{
    public class Campo
    {
        public int IdCampo { get; set; }
        public string NombreCampo { get; set; }
        public string TipoCampo { get; set; }
        public int IdFormulario { get; set; }
        public Formulario Formulario { get; set; }
    }
}
