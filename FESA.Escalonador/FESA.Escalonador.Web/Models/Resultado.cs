using FESA.Escalonador.Domain.Models;

namespace FESA.Escalonador.Web.Models
{
    public class Resultado
    {
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public List<DadosExecucao> DadosExecucoes { get; set; }
        public ResumoExecucao Resumo { get; set; }
        public DadosGrafico DadosGrafico { get; set; }
        public decimal TempoMedioExecucao { get; set; }
        public decimal TempoMedioEspera { get; set; }  
        public List<Execucao> Execucoes { get; set; }

        public void PreencherDados()
        {
            PreencherDadosExecucao();
            PreencherResumoExecucao();
            PreencherDadosGrafico();
            OrdenarParaTabela();
        }

        private void PreencherDadosExecucao()
        {
            var backup = Execucoes.ToArray();
            DadosExecucoes = new List<DadosExecucao>();
            var execucoesRelacionadas = Execucoes;

            while (Execucoes.Count > 0)
            {
                var dados = new DadosExecucao();
                var execucaoAtual = Execucoes.FirstOrDefault();
                execucoesRelacionadas = Execucoes.Where(x => x.IdProcesso == execucaoAtual.IdProcesso).ToList();

                dados.IdProcesso = execucaoAtual.IdProcesso;
                dados.Processo = $"P{execucaoAtual.IdProcesso}";
                dados.Termino = execucoesRelacionadas.LastOrDefault().Fim;
                dados.Ativo = execucoesRelacionadas.LastOrDefault().Fim - (execucoesRelacionadas.FirstOrDefault().Comeco - execucoesRelacionadas.FirstOrDefault().Espera);
                dados.Espera = execucoesRelacionadas.Sum(x => x.Espera);

                Execucoes = Execucoes.Where(x => x.IdProcesso != execucaoAtual.IdProcesso).ToList();

                DadosExecucoes.Add(dados);

            }

            DadosExecucoes.OrderBy(x => x.IdProcesso);
            Execucoes.AddRange(backup);
        }

        public void OrdenarParaTabela()
        {
            var ordenadas = new List<DadosExecucao>();
            var contadorRegressivo = DadosExecucoes.Count(); ;

            while (contadorRegressivo >= 1)
            {
                foreach (var e in DadosExecucoes)
                {
                    if (e.IdProcesso == contadorRegressivo)
                    {
                        ordenadas.Add(e);
                    }
                }

                contadorRegressivo--;
            }

            ordenadas.Reverse();
            DadosExecucoes = ordenadas;
        }


        private void PreencherResumoExecucao()
        {
            ResumoExecucao resumo = new ResumoExecucao();
            resumo.Tempos = new List<int>();
            resumo.Processos = new List<string>();
            resumo.Tempos.Add(Execucoes.FirstOrDefault().Comeco);

            foreach (var e in Execucoes)
            {
                resumo.Processos.Add($"P{e.IdProcesso}");
                resumo.Tempos.Add(e.Fim);
            }

            Resumo = resumo;
        }

        private void PreencherDadosGrafico()
        {
            DadosGrafico = new DadosGrafico(Execucoes);
        }
    }
}
