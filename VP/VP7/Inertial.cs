using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VP7
{
    [Serializable]
    abstract public class Inertial :Aircraft
    {
        public string CirculationPeriod { get; set; } // Период обращения

        public Inertial(string fName, string fProducer, string fFunction, string fMaxTime, string fCirculationPeriod) : base(fName, fProducer, fFunction, fMaxTime)
        {
            CirculationPeriod = fCirculationPeriod;

        }
        public Inertial()
        {
        }
    }
}
