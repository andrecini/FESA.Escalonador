using FESA.Escalonador.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FESA.Escalonador.Domain.Escalonadores.Comparadores
{
    public class ComparadorSRTF : IComparer<Processo>
    {
        private int tempo;
        public ComparadorSRTF(int tempo)
        {
            this.tempo = tempo;
        }

        public int Compare(Processo x, Processo y)
        {
            if (x.Chegada <= tempo && y.Chegada <= tempo)
            {
                return x.Tamanho.CompareTo(y.Tamanho);
            }
            else
            {
                return x.Chegada.CompareTo(y.Chegada);
            }
        }

    }
}