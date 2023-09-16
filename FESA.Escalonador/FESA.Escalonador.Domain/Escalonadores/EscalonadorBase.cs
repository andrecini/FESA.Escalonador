using FESA.Escalonador.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FESA.Escalonador.Domain.Escalonadores
{
    public class EscalonadorBase
    {
        public List<Processo> _processos = new List<Processo>();
        public List<Execucao> _execucoes = new List<Execucao>();
        public List<Execucao> _prioridade = new List<Execucao>();
        public int _quantidadeDeProcessos = 0;

        public void PreencherProcessos(List<int> chegadas, List<int> tamanhos)
        {
            for (int i = 1; i <= chegadas.Count(); i++)
            {
                _processos.Add(new Processo(i, chegadas[i - 1], tamanhos[i - 1]));
            }
        }

        public void PreencherProcessos(List<int> chegadas, List<int> tamanhos, List<int> prioridades)
        {
            for (int i = 1; i <= chegadas.Count(); i++)
            {
                _processos.Add(new Processo(i, chegadas[i - 1], tamanhos[i - 1], prioridades[i - 1]));
            }
        }

        public void CalcularQuantidadeDeProcessos()
        {
            _quantidadeDeProcessos = _processos.Count();
        }

        public decimal CalcularTempoDeExecucaoMedio()
        {
            var total = 0;

            foreach (var e in _execucoes)
            {
                var tempoExecucao = (e.Fim - e.Comeco) + e.Espera;
                total += tempoExecucao;
            }

            return (decimal)total / _quantidadeDeProcessos;
        }

        public decimal CalcularTempoDeEsperaMedio()
        {
            var total = 0;

            foreach (var e in _execucoes)
            {
                total += e.Espera;
            }

            return (decimal)total / _quantidadeDeProcessos;
        }

        public List<Execucao> RetornarExecucoes()
        {
            return _execucoes;
        }
    }
}
