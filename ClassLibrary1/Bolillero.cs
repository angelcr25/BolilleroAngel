using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreBolillero
{
    public class Bolillero : ICloneable
    {
        
        public List<byte> adentro { get; set; }
        public List<byte> afuera { get; set; }

        private Random r { get; set; }

        
        public Bolillero()
        {
             r = new Random(DateTime.Now.Millisecond);

        }
        private Bolillero(Bolillero original) : this()
        {
            adentro = new List<byte>(original.adentro);
            afuera = new List<byte>(original.afuera);
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

        public object Clone()
        {
            return new Bolillero(this);
        }
    }
}
