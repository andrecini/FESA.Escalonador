using FESA.Escalonador.Domain.Escalonadores;
using FESA.Escalonador.Tests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FESA.Escalonador.Tests.Tests
{
    public class TestePRIOc
    {
        [Fact]
        public void ExercicioExemplo()
        {
            // Arrange
            var dados = ExerciciosLista.ExercicioExemplo();

            // Act
            var prioc = new PRIOc(dados.Chegadas, dados.Tamanhos, dados.Prioridades);
            var tempoExecucaoMedio = prioc.CalcularTempoDeExecucaoMedio();
            var tempoEsperaMedio = prioc.CalcularTempoDeEsperaMedio();

            // Assert
            Assert.Equal(tempoExecucaoMedio, (decimal)6.6);
            Assert.Equal(tempoEsperaMedio, (decimal)3.8);
        }

        [Fact]
        public void ExercicioUm()
        {
            // Arrange
            var dados = ExerciciosLista.ExercicioUm();

            // Act
            var prioc = new PRIOc(dados.Chegadas, dados.Tamanhos, dados.Prioridades);
            var tempoExecucaoMedio = prioc.CalcularTempoDeExecucaoMedio();
            var tempoEsperaMedio = prioc.CalcularTempoDeEsperaMedio();

            // Assert
            Assert.Equal(tempoExecucaoMedio, (decimal)8.0);
            Assert.Equal(tempoEsperaMedio, (decimal)4.6);
        }

        [Fact]
        public void ExercicioDois()
        {
            // Arrange
            var dados = ExerciciosLista.ExercicioDois();

            dados.Prioridades = new List<int> { 1, 1, 3, 5, 4 };

            // Act
            var prioc = new PRIOc(dados.Chegadas, dados.Tamanhos, dados.Prioridades);
            var tempoExecucaoMedio = prioc.CalcularTempoDeExecucaoMedio();
            var tempoEsperaMedio = prioc.CalcularTempoDeEsperaMedio();

            // Assert
            Assert.Equal(tempoExecucaoMedio, (decimal)8.4);
            Assert.Equal(tempoEsperaMedio, (decimal)5.2);
        }
    }
}
