using FESA.Escalonador.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FESA.Escalonador.Domain.Escalonadores
{
    public class PRIOp : EscalonadorBase
    {
        public PRIOp(List<int> chegadas, List<int> tamanhos, List<int> prioridades)
        {
            PreencherProcessos(chegadas, tamanhos, prioridades);
            OrdenarProcessos();
            CalcularQuantidadeDeProcessos();
            PreencherExecucoes();
        }

        private int _contadorExecucoes = 1;

        private void OrdenarProcessos()
        {
            _processos = _processos.OrderBy(p => p.Chegada).ThenByDescending(p => p.Prioridade).ToList();
        }

        private void CalcularQuantidadeDeProcessos()
        {
            _quantidadeDeProcessos = _processos.Count();
        }

        private void PreencherExecucoes()
        {
            var fila = PreencherFila(_processos);
            var execucoes = new List<Execucao>();
            Processo ultimoProcesso = new Processo();
            var tempo = 0;
            var contador = 1;

            while (true)
            {
                var processoAtual = fila.First();

                if (ultimoProcesso.Id == 0 || processoAtual.Id != ultimoProcesso.Id)
                {
                    fila = AdicionarNovaExecucao(fila, processoAtual, tempo);
                }
                else
                {
                    var ultimaExecucao = _execucoes.LastOrDefault();
                    fila = RetomarExecucao(fila, ultimaExecucao, processoAtual, tempo);
                }

                if (fila.Count() == 0)
                {
                    break;
                }

                tempo++;
                fila = OrdenarFila(fila, tempo);
                ultimoProcesso = processoAtual;
            }
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

        private Queue<Processo> OrdenarFila(Queue<Processo> fila, int tempo)
        {
            var filaOrdenada = new Queue<Processo>();

            var processos = fila.ToList();
            var processosFiltrados = processos.Where(p => p.Chegada <= tempo).ToList();
            var processosNaoFiltrados = processos.Where(p => p.Chegada > tempo).ToList();

            processosFiltrados.Sort((x, y) => y.Prioridade.CompareTo(x.Prioridade));
            processosFiltrados.AddRange(processosNaoFiltrados);

            foreach (var processo in processosFiltrados)
            {
                filaOrdenada.Enqueue(processo);
            }

            return filaOrdenada;
        }

        private Queue<Processo> AlterarFila(Queue<Processo> fila, Processo processo, int tempo)
        {
            var processos = fila.ToList();
            var index = 0;

            foreach (var p in fila)
            {
                if (p.Id == processo.Id)
                {
                    processo.Tamanho -= 1;
                    processo.Chegada = tempo + 1;

                    processos[index] = processo;
                }

                index++;
            }

            return PreencherFila(processos);
        }

        private Queue<Processo> AdicionarNovaExecucao(Queue<Processo> fila, Processo processo, int tempo)
        {
            AdicionarExecucaoNaLista(processo, tempo);

            if (processo.Tamanho - 1 == 0)
            {
                fila = RemoverProcessoDaFila(fila, processo.Id);
            }
            else
            {
                fila = AlterarFila(fila, processo, tempo);
                fila.Enqueue(fila.Dequeue());
            }

            return fila;
        }

        private Queue<Processo> RetomarExecucao(Queue<Processo> fila, Execucao execucao, Processo processo, int tempo)
        {
            AlterarExecucaoNaLista(execucao, tempo);

            if (processo.Tamanho - 1 == 0)
            {
                fila = RemoverProcessoDaFila(fila, processo.Id);
            }
            else
            {
                fila = AlterarFila(fila, processo, tempo);
                fila.Enqueue(fila.Dequeue());
            }

            return fila;
        }

        private void AdicionarExecucaoNaLista(Processo processo, int tempo)
        {
            _execucoes.Add(new Execucao()
            {
                Id = _contadorExecucoes,
                IdProcesso = processo.Id,
                Comeco = tempo,
                Fim = tempo + 1,
                Espera = tempo - processo.Chegada
            });

            _contadorExecucoes++;
        }

        private void AlterarExecucaoNaLista(Execucao execucao, int tempo)
        {
            var contador = 0;
            foreach (var e in _execucoes)
            {
                if (e.Id == execucao.Id)
                {
                    _execucoes[contador].Fim += 1;
                }

                contador++;
            }
        }
    }
}
