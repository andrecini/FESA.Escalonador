using FESA.Escalonador.Domain.Escalonadores;
using FESA.Escalonador.Tests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FESA.Escalonador.Tests.Tests
{
    public class TesteSJF
    {
        [Fact]
        public void ExercicioExemplo()
        {
            // Arrange
            var dados = ExerciciosLista.ExercicioExemplo();

            // Act
            var sjf = new SJF(dados.Chegadas, dados.Tamanhos);

            var tempoExecucaoMedio = sjf.CalcularTempoDeExecucaoMedio();
            var tempoEsperaMedio = sjf.CalcularTempoDeEsperaMedio();

            // Assert
            Assert.Equal(tempoExecucaoMedio, (decimal)5.8);
            Assert.Equal(tempoEsperaMedio, (decimal)3.0);
        }

        [Fact]
        public void ExercicioUm()
        {
            // Arrange
            var dados = ExerciciosLista.ExercicioUm();

            // Act
            var sjf = new SJF(dados.Chegadas, dados.Tamanhos);
            var tempoExecucaoMedio = sjf.CalcularTempoDeExecucaoMedio();
            var tempoEsperaMedio = sjf.CalcularTempoDeEsperaMedio();

            // Assert
            Assert.Equal(tempoExecucaoMedio, (decimal)7.6);
            Assert.Equal(tempoEsperaMedio, (decimal)4.2);
        }

        [Fact]
        public void ExercicioDois()
        {
            // Arrange
            var dados = ExerciciosLista.ExercicioDois();

            // Act
            var sjf = new SJF(dados.Chegadas, dados.Tamanhos);
            var tempoExecucaoMedio = sjf.CalcularTempoDeExecucaoMedio();
            var tempoEsperaMedio = sjf.CalcularTempoDeEsperaMedio();

            // Assert
            Assert.Equal(tempoExecucaoMedio, (decimal)7.6);
            Assert.Equal(tempoEsperaMedio, (decimal)4.4);
        }
    }
}