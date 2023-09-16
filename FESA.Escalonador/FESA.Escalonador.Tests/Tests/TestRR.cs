using FESA.Escalonador.Domain.Escalonadores;
using FESA.Escalonador.Tests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FESA.Escalonador.Tests.Tests
{
    public class TestRR
    {
        [Fact]
        public void ExercicioExemplo()
        {
            // Arrange
            var dados = ExerciciosLista.ExercicioExemplo();

            // Act
            var rr = new RR(dados.Chegadas, dados.Tamanhos);
            var tempoExecucaoMedio = rr.CalcularTempoDeExecucaoMedio();
            var tempoEsperaMedio = rr.CalcularTempoDeEsperaMedio();

            // Assert
            Assert.Equal(tempoExecucaoMedio, (decimal)8.4);
            Assert.Equal(tempoEsperaMedio, (decimal)5.6);
        }

        [Fact]
        public void ExercicioUm()
        {
            // Arrange
            var dados = ExerciciosLista.ExercicioUm();

            // Act
            var rr = new RR(dados.Chegadas, dados.Tamanhos);
            var tempoExecucaoMedio = rr.CalcularTempoDeExecucaoMedio();
            var tempoEsperaMedio = rr.CalcularTempoDeEsperaMedio();

            // Assert
            Assert.Equal(tempoExecucaoMedio, (decimal)11.6);
            Assert.Equal(tempoEsperaMedio, (decimal)8.2);
        }

        [Fact]
        public void ExercicioDois()
        {
            // Arrange
            var dados = ExerciciosLista.ExercicioDois();

            // Act
            var rr = new RR(dados.Chegadas, dados.Tamanhos);
            var tempoExecucaoMedio = rr.CalcularTempoDeExecucaoMedio();
            var tempoEsperaMedio = rr.CalcularTempoDeEsperaMedio();

            // Assert
            Assert.Equal(tempoExecucaoMedio, (decimal)10);
            Assert.Equal(tempoEsperaMedio, (decimal)6.8);
        }
    }
}