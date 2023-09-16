using FESA.Escalonador.Domain.Escalonadores;
using FESA.Escalonador.Tests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FESA.Escalonador.Tests.Tests
{
    public class TestePRIOp
    {
        [Fact]
        public void ExercicioExemplo()
        {
            // Arrange
            var dados = ExerciciosLista.ExercicioExemplo();

            // Act
            var priop = new PRIOp(dados.Chegadas, dados.Tamanhos, dados.Prioridades);
            var tempoExecucaoMedio = priop.CalcularTempoDeExecucaoMedio();
            var tempoEsperaMedio = priop.CalcularTempoDeEsperaMedio();

            // Assert
            Assert.Equal(tempoExecucaoMedio, (decimal)5.6);
            Assert.Equal(tempoEsperaMedio, (decimal)2.8);
        }

        [Fact]
        public void ExercicioUm()
        {
            // Arrange
            var dados = ExerciciosLista.ExercicioUm();

            // Act
            var priop = new PRIOp(dados.Chegadas, dados.Tamanhos, dados.Prioridades);
            var tempoExecucaoMedio = priop.CalcularTempoDeExecucaoMedio();
            var tempoEsperaMedio = priop.CalcularTempoDeEsperaMedio();

            // Assert
            Assert.Equal(tempoExecucaoMedio, (decimal)8.6);
            Assert.Equal(tempoEsperaMedio, (decimal)5.2);
        }

        [Fact]
        public void ExercicioDois()
        {
            // Arrange
            var dados = ExerciciosLista.ExercicioDois();

            dados.Prioridades = new List<int> { 1, 1, 3, 5, 4 };

            // Act
            var priop = new PRIOp(dados.Chegadas, dados.Tamanhos, dados.Prioridades);
            var tempoExecucaoMedio = priop.CalcularTempoDeExecucaoMedio();
            var tempoEsperaMedio = priop.CalcularTempoDeEsperaMedio();

            // Assert
            Assert.Equal(tempoExecucaoMedio, (decimal)8.6);
            Assert.Equal(tempoEsperaMedio, (decimal)5.4);
        }
    }
}
