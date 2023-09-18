using FESA.Escalonador.Domain.Escalonadores;
using FESA.Escalonador.Domain.Models;
using FESA.Escalonador.Domain.Models.Enums;
using FESA.Escalonador.Web.Models.Result;

namespace FESA.Escalonador.Web.Helpers
{
    public static class EscalonadorHelper
    {
        public static Resultado RetornarResultadoDasExecucoes(List<int> chegadas, List<int> tamanhos, List<int> prioridades, int tipo)
        {
            var escalonador = new EscalonadorBase();
            
            if ((Tipos)tipo == Tipos.FCFS)
            {
                escalonador = new FCFS(chegadas, tamanhos);
                return CriarResultado(escalonador);
            }
            else if ((Tipos)tipo == Tipos.SJF)
            {
                escalonador = new SJF(chegadas, tamanhos);
                return CriarResultado(escalonador);
            }
            else if ((Tipos)tipo == Tipos.RR)
            {
                escalonador = new RR(chegadas, tamanhos);
                return CriarResultado(escalonador);
            }
            else if ((Tipos)tipo == Tipos.SRTF)
            {
                escalonador = new SRTF(chegadas, tamanhos, prioridades);
                return CriarResultado(escalonador);
            }
            else if ((Tipos)tipo == Tipos.PRIOc)
            {
                escalonador = new PRIOc(chegadas, tamanhos, prioridades);
                return CriarResultado(escalonador);
            }
            else if ((Tipos)tipo == Tipos.PRIOp)
            {
                escalonador = new PRIOp(chegadas, tamanhos, prioridades);
                return CriarResultado(escalonador);
            }
            else
            {
                return null;
            }
        }

        private static Resultado CriarResultado(EscalonadorBase escalonador)
        {
            return new Resultado()
            {
                Execucoes = escalonador.RetornarExecucoes(),
                TempoMedioExecucao = escalonador.CalcularTempoDeExecucaoMedio(),
                TempoMedioEspera = escalonador.CalcularTempoDeEsperaMedio()
            };
        }
    }
}
