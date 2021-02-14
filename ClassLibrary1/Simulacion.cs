using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace CoreBolillero
{
    class Simulacion
    {
        Bolillero bolillero = new Bolillero();

        
        public bool jugar (List<byte> jugadas, Bolillero bolillero)
        {
            var comparar = 0;
            bolillero.Reingresar();
            foreach (var bolillaJugada in jugadas)
            {
                comparar = bolillero.SacarBolilla();

                if (comparar != bolillaJugada)
                {
                    return false;
                }
            }

            return true;
        }
        public long jugarNveces(List<byte> jugadas, long cantJugar, Bolillero bolillero)
        {
            long cantGanados = 0;

            for (long i = 0; i < cantJugar; i++)
            {
                if (this.jugar(jugadas, bolillero) ==  true)
                {
                    cantGanados++;
                }
            }

            return cantGanados;
        }
        public long simularSinHilos(List<byte> jugadas, long cantJugar, Bolillero bolillero)
        {
            return jugarNveces(jugadas, cantJugar, bolillero);
        }
        public long simularConHilos(List<byte> jugadas, long cantJugar, int cantHilos, Bolillero bolillero)
        {
            var vectorTarea = new Task<long>[cantHilos];
            long resto = cantJugar % cantHilos;

            for (int i = 1; i < cantHilos; i++)
            {
                Bolillero clon = (Bolillero)bolillero.Clone();

                vectorTarea[i] = Task.Run(() => jugarNveces(jugadas, cantJugar/cantHilos, clon));
            }
            Bolillero clon1 = (Bolillero)bolillero.Clone();

            vectorTarea[0] = Task.Run(() => jugarNveces(jugadas, cantJugar / cantHilos + resto, clon1));

            Task.WaitAll(vectorTarea);
            return vectorTarea.Sum(T => T.Result);
           
        }
        public async Task<int> simularConHilosAsync(Bolillero bolillero, List<byte> jugadas, long cantJugar, int cantHilos)
        {
            var vectorTarea = new Task<long>[cantHilos];
            var resto = new byte[cantidadHilos];
            int simResto = cantidadSimulaciones % cantidadHilos;
            int simulacionesPorHilo = Convert.ToInt32(cantJugar / cantHilos);
            long resto = cantJugar % cantHilos;

            for (int i = 0; i < simResto; i++)
            {
                resto[i] = 1;
            }

            for (int i = simResto; i < cantHilos; i++)
            {
                resto[i] = 0;
            }

            for (int i = 0; i < cantHilos; i++)
            {
                Bolillero clon = (Bolillero)bolillero.Clone();
                var simPorHilo = cantJugar / cantHilos + simResto[i];
                tareas[i] = Task.Run(() => clon.jugarNVeces(jugada, simulacionesXHiloConResto));
            }

            await Task.WhenAll(vectorTarea);

            return vectorTarea.Sum(t => t.Result);

        }
    }
}
