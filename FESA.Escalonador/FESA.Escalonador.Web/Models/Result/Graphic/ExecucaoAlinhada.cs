using FESA.Escalonador.Domain.Models;

namespace FESA.Escalonador.Web.Models.Result.Graphic
{
    public class ExecucaoAlinhada
    {
        public ExecucaoAlinhada(List<Execucao> execucoes, double valorTempoEmPorcentagem)
        {
            _execucoes = execucoes;
            _valorTempoEmPorcentagem = valorTempoEmPorcentagem;
            DefinirExecucaoGrafico();
        }

        public ExecucaoGrafico ExecucaoGrafico { get; set; }

        private List<Execucao> _execucoes;
        private double _valorTempoEmPorcentagem;

        public void DefinirExecucaoGrafico()
        {
            ExecucaoGrafico = new ExecucaoGrafico();
            ExecucaoGrafico.IdProcesso = _execucoes.FirstOrDefault().IdProcesso;
            ExecucaoGrafico.PorcentagemInatividade = (_execucoes.FirstOrDefault().Comeco - _execucoes.FirstOrDefault().Espera) * _valorTempoEmPorcentagem;
            ExecucaoGrafico.PorcentagensExecucoes = new List<double>();
            ExecucaoGrafico.PorcentagensEspera = new List<double>();

            foreach (var e in _execucoes)
            {
                ExecucaoGrafico.PorcentagensEspera.Add(e.Espera * _valorTempoEmPorcentagem);
                ExecucaoGrafico.PorcentagensExecucoes.Add((e.Fim - e.Comeco) * _valorTempoEmPorcentagem);
            }
        }
    }
}
