using FESA.Escalonador.Domain.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FESA.Escalonador.Domain.Escalonadores.Comparadores
{
    public class ComparadorPRIOc : IComparer<Processo>
    {
        private int _tempo;

        public ComparadorPRIOc(int tempo)
        {
            _tempo = tempo;
        }

        public int Compare(Processo x, Processo y)
        {
            if (x.Chegada <= _tempo && y.Chegada <= _tempo)
            {
                return x.Prioridade.CompareTo(y.Prioridade);
            }
            else
            {
                return x.Chegada.CompareTo(y.Chegada);
            }
        }
    }
}