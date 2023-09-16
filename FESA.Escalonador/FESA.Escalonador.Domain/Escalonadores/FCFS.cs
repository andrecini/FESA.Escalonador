using FESA.Escalonador.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FESA.Escalonador.Domain.Escalonadores
{
    public class FCFS : EscalonadorBase
    {
        public FCFS(List<int> chegadas, List<int> tamanhos)
        {
            PreencherProcessos(chegadas, tamanhos);
            CalcularQuantidadeDeProcessos();
            OrdenarProcessos();
            PreencherExecucoes();
        }

        private void OrdenarProcessos()
        {
            _processos.Sort((x, y) => x.Chegada.CompareTo(y.Chegada));
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
