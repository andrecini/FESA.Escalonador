using FESA.Escalonador.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FESA.Escalonador.Domain.Escalonadores.Comparadores
{
    public class ComparadorSJF : IComparer<Processo>
    {
        private int _tempo;

        public ComparadorSJF(int tempo)
        {
            _tempo = tempo;
        }

        public int Compare(Processo x, Processo y)
        {
            if (x.Chegada <= _tempo && y.Chegada <= _tempo)
            {
                if (x.Tamanho != y.Tamanho)
                {
                    return x.Tamanho.CompareTo(y.Tamanho);
                }

                return x.Id.CompareTo(y.Id);
            }
            else
            {
                return x.Chegada.CompareTo(y.Chegada);
            }
        }
    }
}
