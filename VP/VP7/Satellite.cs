using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VP7
{
    public class Satellite : Inertial
    {
        public decimal TimeОrbit { get; set; } // Длительность на орбите

        public Satellite(string fName, string fProducer, string fFunction, string fMaxTime, string fCirculationPeriod, decimal fTimeOrbit) : base(fName, fProducer, fFunction, fMaxTime, fCirculationPeriod)
        {
            TimeОrbit = fTimeOrbit;

        }
        public Satellite()
        {
        }
    }
}
