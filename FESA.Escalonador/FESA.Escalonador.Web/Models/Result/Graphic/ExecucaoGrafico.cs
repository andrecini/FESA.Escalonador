namespace FESA.Escalonador.Web.Models.Result.Graphic
{
    public class ExecucaoGrafico
    {
        public int IdProcesso { get; set; }
        public double PorcentagemInatividade { get; set; }
        public List<double> PorcentagensEspera { get; set; }
        public List<double> PorcentagensExecucoes { get; set; }
    }
}
