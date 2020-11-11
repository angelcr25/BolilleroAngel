using System;
using System.Collections.Generic;
using System.Text;

namespace CoreBolillero
{
    class Simulacion
    {
        Bolillero bolillero = new Bolillero();

        
        public bool jugar (List<byte> jugadas)
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
        public long jugarNveces(List<byte> jugadas, long cantJugar)
        {
            long cantGanados = 0;

            for (long i = 0; i < cantJugar; i++)
            {
                if (this.jugar(jugadas) ==  true)
                {
                    cantGanados++;
                }
            }

            return cantGanados;
        }
    }
}
