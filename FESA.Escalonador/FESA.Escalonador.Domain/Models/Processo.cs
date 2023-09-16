using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FESA.Escalonador.Domain.Models
{
    public class Processo
    {
        public Processo() { }
        public Processo(int id, int chegada, int tamanho)
        {
            Id = id;
            Chegada = chegada;
            Tamanho = tamanho;
        }
        public Processo(int id, int chegada, int tamanho, int prioridade)
        {
            Id = id;
            Chegada = chegada;
            Tamanho = tamanho;
            Prioridade = prioridade;
        }

        public int Id { get; set; }
        public int Chegada { get; set; }
        public int Tamanho { get; set; }
        public int Prioridade { get; set; }
    }
}
