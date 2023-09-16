using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FESA.Escalonador.Domain.Models
{
    public class Execucao
    {
        public int Id { get; set; }
        public int IdProcesso { get; set; }
        public int Comeco { get; set; }
        public int Fim { get; set; }
        public int Espera { get; set; }
    }
}
