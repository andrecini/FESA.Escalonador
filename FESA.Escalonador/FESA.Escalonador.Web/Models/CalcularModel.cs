namespace FESA.Escalonador.Web.Models
{
    public class CalcularModel
    {
        public List<int> Chegadas { get; set; }
        public List<int> Tamanhos { get; set; }
        public List<int> Prioridades {  get; set; }
        public int Tipo { get; set; }
    }
}
