namespace FESA.Escalonador.Web.Models.Result
{
    public class DadosExecucao
    {
        public int IdProcesso { get; set; }
        public string Processo { get; set; }
        public int Termino { get; set; }
        public int Ativo { get; set; }
        public int Espera { get; set; }
    }
}
