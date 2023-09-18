using FESA.Escalonador.Domain.Models;

namespace FESA.Escalonador.Web.Models.Result.Graphic
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
            ValorTempoEmPorcentagem = 100 / Quantidade;
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
}
