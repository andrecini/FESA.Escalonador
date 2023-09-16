using FESA.Escalonador.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FESA.Escalonador.Domain.Escalonadores
{
    public class RR : EscalonadorBase
    {
        public RR(List<int> chegadas, List<int> tamanhos)
        {
            PreencherProcessos(chegadas, tamanhos);
            CalcularQuantidadeDeProcessos();
            OrdenarProcessos();
            PreencherExecucoes();
        }

        private int contadorExecucao = 0;

        private void OrdenarProcessos()
        {
            _processos = _processos.OrderBy(p => p.Chegada).ThenBy(p => p.Id).ToList();
        }

        private void PreencherExecucoes()
        {
            var fila = PreencherFila(_processos);
            var execucoes = new List<Execucao>();
            var tempo = 0;

            while (true)
            {
                var processoAtual = fila.First();
                var index = fila.ToList().IndexOf(processoAtual);

                if (processoAtual.Chegada <= tempo)
                {
                    if (processoAtual.Tamanho - 2 >= 1)
                    {
                        execucoes.Add(RetonarNovaExecucao(processoAtual, tempo, 2));
                        fila = AlterarFila(fila, processoAtual, tempo, index);
                        tempo += 2;
                        fila.Enqueue(fila.Dequeue());
                    }
                    else if (processoAtual.Tamanho - 2 == 0)
                    {
                        execucoes.Add(RetonarNovaExecucao(processoAtual, tempo, 2));
                        fila = RemoverProcessoDaFila(fila, processoAtual.Id);
                        tempo += 2;
                    }
                    else if (processoAtual.Tamanho - 2 == -1)
                    {
                        execucoes.Add(RetonarNovaExecucao(processoAtual, tempo, 1));
                        fila = RemoverProcessoDaFila(fila, processoAtual.Id);
                        tempo += 1;
                    }

                    if (fila.Count == 0)
                    {
                        break;
                    }
                }

                fila = OrdenarFila(fila);
            }

            _execucoes = execucoes;
        }

        private Queue<Processo> PreencherFila(List<Processo> processos)
        {
            var fila = new Queue<Processo>();

            foreach (var p in processos.ToList())
            {
                fila.Enqueue(p);
            }

            return fila;
        }

        private Execucao RetonarNovaExecucao(Processo processo, int tempo, int tamanho)
        {
            contadorExecucao++;

            var execucao = new Execucao()
            {
                Id = contadorExecucao,
                IdProcesso = processo.Id,
                Comeco = tempo,
                Fim = tempo + tamanho,
                Espera = tempo - processo.Chegada
            };

            return execucao;
        }

        private Queue<Processo> AlterarFila(Queue<Processo> fila, Processo processo, int tempo, int index)
        {
            var processos = fila.ToList();

            foreach (var p in fila)
            {
                if (p.Id == processo.Id)
                {
                    processo.Tamanho -= 2;
                    processo.Chegada = tempo + 2;

                    processos[index] = processo;
                }
            }

            return PreencherFila(processos);
        }

        private Queue<Processo> RemoverProcessoDaFila(Queue<Processo> fila, int id)
        {
            var novafila = new Queue<Processo>();

            foreach (var processo in fila)
            {
                if (processo.Id != id && fila.Count() > 0)
                {
                    novafila.Enqueue(processo);
                }
            }

            return novafila;
        }

        private Queue<Processo> OrdenarFila(Queue<Processo> fila)
        {
            var processos = fila.ToList();
            processos.Sort((x, y) => x.Chegada.CompareTo(y.Chegada));

            var filaOrdenada = new Queue<Processo>();

            foreach (var processo in processos)
            {
                filaOrdenada.Enqueue(processo);
            }

            return filaOrdenada;
        }
    }
}