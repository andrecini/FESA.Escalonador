using FESA.Escalonador.Domain.Escalonadores;
using FESA.Escalonador.Tests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FESA.Escalonador.Tests.Tests
{
    public class TesteFCFS
    {
        [Fact]
        public void ExercicioExemplo()
        {
            // Arrange
            var dados = ExerciciosLista.ExercicioExemplo();

            // Act
            var fcfs = new FCFS(dados.Chegadas, dados.Tamanhos);
            var tempoExecucaoMedio = fcfs.CalcularTempoDeExecucaoMedio();
            var tempoEsperaMedio = fcfs.CalcularTempoDeEsperaMedio();

            // Assert
            Assert.Equal(tempoExecucaoMedio, (decimal)8);
            Assert.Equal(tempoEsperaMedio, (decimal)5.2);
        }

        [Fact]
        public void ExercicioUm()
        {
            // Arrange
            var dados = ExerciciosLista.ExercicioUm();

            // Act
            var fcfs = new FCFS(dados.Chegadas, dados.Tamanhos);
            var tempoExecucaoMedio = fcfs.CalcularTempoDeExecucaoMedio();
            var tempoEsperaMedio = fcfs.CalcularTempoDeEsperaMedio();

            // Assert
            Assert.Equal(tempoExecucaoMedio, (decimal)9.4);
            Assert.Equal(tempoEsperaMedio, 6);
        }

        [Fact]
        public void ExercicioDois()
        {
            // Arrange
            var dados = ExerciciosLista.ExercicioDois();

            // Act
            var fcfs = new FCFS(dados.Chegadas, dados.Tamanhos);
            var tempoExecucaoMedio = fcfs.CalcularTempoDeExecucaoMedio();
            var tempoEsperaMedio = fcfs.CalcularTempoDeEsperaMedio();

            // Assert
            Assert.Equal(tempoExecucaoMedio, (decimal)8.4);
            Assert.Equal(tempoEsperaMedio, (decimal)5.2);
        }
    }
}