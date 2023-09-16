using FESA.Escalonador.Domain.Escalonadores;
using FESA.Escalonador.Tests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FESA.Escalonador.Tests.Tests
{
    public class TesteSRTF
    {
        [Fact]
        public void ExercicioExemplo()
        {
            // Arrange
            var dados = ExerciciosLista.ExercicioExemplo();

            // Act
            var srtf = new SRTF(dados.Chegadas, dados.Tamanhos, dados.Prioridades);
            var tempoExecucaoMedio = srtf.CalcularTempoDeExecucaoMedio();
            var tempoEsperaMedio = srtf.CalcularTempoDeEsperaMedio();

            // Assert
            Assert.Equal(tempoExecucaoMedio, (decimal)5.4);
            Assert.Equal(tempoEsperaMedio, (decimal)2.6);
        }

        [Fact]
        public void ExercicioUm()
        {
            // Arrange
            var dados = ExerciciosLista.ExercicioUm();

            // Act
            var srtf = new SRTF(dados.Chegadas, dados.Tamanhos, dados.Prioridades);
            var tempoExecucaoMedio = srtf.CalcularTempoDeExecucaoMedio();
            var tempoEsperaMedio = srtf.CalcularTempoDeEsperaMedio();

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
            var srtf = new SRTF(dados.Chegadas, dados.Tamanhos, dados.Prioridades);
            var tempoExecucaoMedio = srtf.CalcularTempoDeExecucaoMedio();
            var tempoEsperaMedio = srtf.CalcularTempoDeEsperaMedio();

            // Assert
            Assert.Equal(tempoExecucaoMedio, (decimal)6.8);
            Assert.Equal(tempoEsperaMedio, (decimal)3.6);
        }
    }
}
