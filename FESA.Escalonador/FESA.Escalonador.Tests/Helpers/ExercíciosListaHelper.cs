using FESA.Escalonador.Tests.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FESA.Escalonador.Tests.Helpers
{
    public static class ExerciciosLista
    {
        public static Exercicio ExercicioExemplo()
        {
            return new Exercicio()
            {
                Chegadas = new List<int>() { 0, 0, 1, 3, 5 },
                Tamanhos = new List<int>() { 5, 2, 4, 1, 2 },
                Prioridades = new List<int>() { 2, 3, 1, 4, 5 }
            };
        }

        public static Exercicio ExercicioUm()
        {
            return new Exercicio()
            {
                Chegadas = new List<int>() { 0, 2, 2, 4, 4 },
                Tamanhos = new List<int>() { 5, 4, 3, 4, 1 },
                Prioridades = new List<int>() { 3, 2, 1, 4, 5 }
            };
        }

        public static Exercicio ExercicioDois()
        {
            return new Exercicio()
            {
                Chegadas = new List<int>() { 0, 1, 2, 3, 5 },
                Tamanhos = new List<int>() { 5, 2, 4, 3, 2 },
                Prioridades = new List<int>() { 3, 2, 1, 4, 5 }
            };
        }
    }
}
