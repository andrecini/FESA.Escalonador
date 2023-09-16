using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FESA.Escalonador.Tests.Models
{
    public class Exercicio
    {
        public List<int> Chegadas { get; set; }
        public List<int> Tamanhos { get; set; }
        public List<int> Prioridades { get; set; }
    }
}
