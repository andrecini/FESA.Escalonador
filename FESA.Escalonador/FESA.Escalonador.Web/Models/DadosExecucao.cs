namespace FESA.Escalonador.Web.Models
{
    public class DadosExecucao
    {
        public string Processo { get; set; }
        public int Termino { get; set; }
        public int Ativo { get; set; }
        public int Espera { get; set; }
    }
}
