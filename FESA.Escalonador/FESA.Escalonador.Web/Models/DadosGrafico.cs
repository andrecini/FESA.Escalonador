using FESA.Escalonador.Domain.Models;

namespace FESA.Escalonador.Web.Models
{
    public class DadosGrafico
    {
        public DadosGrafico(List<Execucao> execucoes)
        {
            _execucoes = execucoes;
            DefinirValorTempoEmPorcentagem();
            DefinirExecucoesAlinhadas();
            OrdenarParaTabela();
        }

        public List<ExecucaoAlinhada> ExecucoesAlinhadas { get; set; }
        private List<Execucao> _execucoes;
        public double ValorTempoEmPorcentagem;
        public double Quantidade;

        public void DefinirValorTempoEmPorcentagem()
        {
            Quantidade = _execucoes.LastOrDefault().Fim;
            ValorTempoEmPorcentagem = (double)100 / Quantidade;
        }

        public void DefinirExecucoesAlinhadas()
        {
            ExecucoesAlinhadas = new List<ExecucaoAlinhada>();

            while (_execucoes.Count() > 0)
            {
                var idProcesso = _execucoes.FirstOrDefault().IdProcesso;
                var execucoesDoProcesso = _execucoes.Where(x => x.IdProcesso == idProcesso).ToList();
                var execucaoAlinhada = new ExecucaoAlinhada(execucoesDoProcesso, ValorTempoEmPorcentagem);
                ExecucoesAlinhadas.Add(execucaoAlinhada);
                _execucoes = _execucoes.Where(x => x.IdProcesso != idProcesso).ToList();
            }
        }

        public void OrdenarParaTabela()
        {
            var ordenadas = new List<ExecucaoAlinhada>();
            var contadorRegressivo = ExecucoesAlinhadas.Count(); ;

            while (contadorRegressivo >= 1)
            {
                foreach (var e in ExecucoesAlinhadas)
                {
                    if (e.ExecucaoGrafico.IdProcesso == contadorRegressivo)
                    {
                        ordenadas.Add(e);
                    }
                }

                contadorRegressivo--;
            }

            ExecucoesAlinhadas = ordenadas;
        }
    }

    public class ExecucaoAlinhada
    {
        public ExecucaoAlinhada(List<Execucao> execucoes, double valorTempoEmPorcentagem)
        {
            _execucoes = execucoes;
            _valorTempoEmPorcentagem = valorTempoEmPorcentagem;
            DefinirExecucaoGrafico();
        }

        public ExecucaoGrafico ExecucaoGrafico { get; set;}

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

    public class ExecucaoGrafico
    {
        public int IdProcesso { get; set; }
        public double PorcentagemInatividade {  get; set; }
        public List<double> PorcentagensEspera { get; set; }
        public List<double> PorcentagensExecucoes { get; set; }
    }
}
