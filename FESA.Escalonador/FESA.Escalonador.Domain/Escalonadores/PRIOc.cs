using FESA.Escalonador.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FESA.Escalonador.Domain.Escalonadores
{
    public class PRIOc : EscalonadorBase
    {
        public PRIOc(List<int> chegadas, List<int> tamanhos, List<int> prioridades)
        {
            PreencherProcessos(chegadas, tamanhos, prioridades);
            OrdenarProcessos();
            CalcularQuantidadeDeProcessos();
            PreencherExecucoes();
        }

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
            Processo ultimoProcesso = new Processo();
            var execucoes = new List<Execucao>();
            var tempo = 0;
            var contador = 1;

            while (true)
            {
                var processoAtual = fila.First();

                if (processoAtual.Chegada <= tempo)
                {
                    execucoes.Add(new Execucao
                    {
                        Id = contador,
                        IdProcesso = processoAtual.Id,
                        Comeco = tempo,
                        Fim = tempo + processoAtual.Tamanho,
                        Espera = tempo - processoAtual.Chegada
                    });
                    fila = RemoverProcessoDaFila(fila, processoAtual.Id);
                    tempo += processoAtual.Tamanho;
                }

                if (fila.Count() == 0)
                {
                    break;
                }

                fila = OrdenarFila(fila, tempo);
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
    }
}