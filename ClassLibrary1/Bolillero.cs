using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreBolillero
{
    public class Bolillero
    {
        public List<byte> adentro { get; set; }
        public List<byte> afuera { get; set; }

        private Random r { get; set; }

        
        public Bolillero()
        {
            var r = new Random();

        }

        private void cargarBolillero(byte inicio, byte fin)
        {
            for (byte i = inicio; i < fin; i++)
            {
                adentro.Add(i);
            }
        }

        public byte SacarBolilla()
        {
            var indice = 0;
            indice = r.Next(0, adentro.Count);
            var bolilla = adentro[indice];
            return bolilla;
        }
        public void Reingresar()
        {
            adentro.AddRange(afuera);
            afuera.Clear();
        }
    }
}
