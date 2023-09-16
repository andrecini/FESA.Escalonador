using FESA.Escalonador.Domain.Models;

namespace FESA.Escalonador.Web.Models
{
    public class Resultado
    {
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public List<DadosExecucao> DadosExecucoes { get; set; }
        public ResumoExecucao Resumo { get; set; }
        public decimal TempoMedioExecucao { get; set; }
        public decimal TempoMedioEspera { get; set; }  
        public List<Execucao> Execucoes { get; set; }

        public void PreencherDados()
        {
            PreencherDadosExecucao();
            PreencherResumoExecucao();
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

                dados.Processo = $"P{execucaoAtual.IdProcesso}";
                dados.Termino = execucoesRelacionadas.LastOrDefault().Fim;
                dados.Ativo = execucoesRelacionadas.LastOrDefault().Fim - (execucoesRelacionadas.FirstOrDefault().Comeco - execucoesRelacionadas.FirstOrDefault().Espera);
                dados.Espera = execucoesRelacionadas.Sum(x => x.Espera);

                Execucoes = Execucoes.Where(x => x.IdProcesso != execucaoAtual.IdProcesso).ToList();

                DadosExecucoes.Add(dados);

            }

            Execucoes.AddRange(backup);
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
    }
}
