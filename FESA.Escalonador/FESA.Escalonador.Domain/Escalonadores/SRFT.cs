using FESA.Escalonador.Domain.Escalonadores.Comparadores;
using FESA.Escalonador.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FESA.Escalonador.Domain.Escalonadores
{
    public class SRTF : EscalonadorBase
    {
        public SRTF(List<int> chegadas, List<int> tamanhos, List<int> prioridades)
        {
            PreencherProcessos(chegadas, tamanhos, prioridades);
            OrdenarProcessos();
            CalcularQuantidadeDeProcessos();
            PreencherExecucoes();
        }

        private void OrdenarProcessos()
        {
            _processos.Sort(new ComparadorSRTF(0));
        }

        private void OrdenarProcessos(int tempo)
        {
            _processos.Sort(new ComparadorSRTF(tempo));
        }

        private void PreencherExecucoes()
        {
            var execucoesOrdenadas = new List<Execucao>();
            Execucao ultimaExecucao = null;
            var tempo = 0;
            var contador = 1;

            while (_processos.Count() > 0)
            {
                var processoEmExecucao = _processos.FirstOrDefault();

                if (ultimaExecucao == null || ultimaExecucao.IdProcesso != processoEmExecucao.Id)
                {
                    var execucao = RetornarNovaExecução(contador, processoEmExecucao, tempo, ultimaExecucao, execucoesOrdenadas);

                    execucoesOrdenadas.Add(execucao);
                    contador++;
                    ultimaExecucao = execucao;
                }
                else if (ultimaExecucao.IdProcesso == processoEmExecucao.Id)
                {
                    var execucao = RetomarExecucaoExistente(contador, processoEmExecucao, tempo, ultimaExecucao, execucoesOrdenadas);

                    var index = execucoesOrdenadas.IndexOf(execucoesOrdenadas.LastOrDefault());
                    execucoesOrdenadas[index] = execucao;
                    ultimaExecucao = execucao;
                }

                tempo++;
                OrdenarProcessos(tempo);
            }

            _execucoes = execucoesOrdenadas;
        }

        private Execucao RetornarNovaExecução(int contador, Processo processoEmExecucao,
            int tempo, Execucao ultimaExecucao, List<Execucao> execucoesOrdenadas)
        {
            var execucao = new Execucao()
            {
                Id = contador,
                IdProcesso = processoEmExecucao.Id,
                Comeco = tempo,
            };

            if (execucoesOrdenadas.Exists(x => x.IdProcesso == processoEmExecucao.Id))
            {
                processoEmExecucao.Chegada = execucoesOrdenadas.Where(e => e.IdProcesso == execucao.IdProcesso).LastOrDefault().Fim;
            }

            execucao.Espera = execucao.Comeco - processoEmExecucao.Chegada;
            execucao.Fim += tempo + 1;

            if ((processoEmExecucao.Tamanho - 1) == 0)
            {
                _processos.RemoveAt(0);
            }
            else
            {
                _processos[0].Chegada = tempo;
                _processos[0].Tamanho -= 1;
            }

            return execucao;
        }

        private Execucao RetomarExecucaoExistente(int contador, Processo processoEmExecucao,
            int tempo, Execucao ultimaExecucao, List<Execucao> execucoesOrdenadas)
        {
            var execucao = ultimaExecucao;

            execucao.Fim += 1;

            if ((processoEmExecucao.Tamanho - 1) == 0)
            {
                _processos[0].Chegada = tempo;
                _processos[0].Tamanho -= 1;
                _processos.RemoveAt(0);
            }
            else
            {
                _processos[0].Chegada = tempo;
                _processos[0].Tamanho -= 1;
            }

            return execucao;
        }
    }
}