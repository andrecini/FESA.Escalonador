using FESA.Escalonador.Domain.Escalonadores.Comparadores;
using FESA.Escalonador.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FESA.Escalonador.Domain.Escalonadores
{
    public class SJF : EscalonadorBase
    {
        public SJF(List<int> chegadas, List<int> tamanhos)
        {
            PreencherProcessos(chegadas, tamanhos);
            CalcularQuantidadeDeProcessos();
            OrdenarProcessos();
            PreencherExecucoes();
        }

        private void OrdenarProcessos()
        {
            var tempo = 0;
            _processos.Sort(new ComparadorSJF(0));

            var ordenada = new List<Processo>();

            while (_processos.Count > 0)
            {
                _processos.Sort(new ComparadorSJF(tempo));
                tempo += _processos.ElementAt(0).Tamanho;
                ordenada.Add(_processos[0]);
                _processos.RemoveAt(0);
            }

            _processos = ordenada;
        }

        private void PreencherExecucoes()
        {
            var contador = 1;
            var tempoInicial = 0;

            foreach (var p in _processos)
            {
                var execucao = new Execucao()
                {
                    Id = contador,
                    IdProcesso = p.Id,
                    Comeco = tempoInicial,
                    Fim = tempoInicial + p.Tamanho,
                    Espera = tempoInicial - p.Chegada
                };

                _execucoes.Add(execucao);
                contador++;
                tempoInicial += p.Tamanho;
            }
        }
    }
}