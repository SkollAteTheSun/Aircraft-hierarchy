using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VP7
{
    [Serializable]
    public class Station : Inertial
    {

        public decimal TimeОrbit { get; set; } // Длительность на орбите
        public decimal DockingNodes { get; set; } // Стыковочные узлы

        public Station(string fName, string fProducer, string fFunction, string fMaxTime, string fCirculationPeriod, decimal fTimeOrbit, decimal fDockingNodes) : base(fName, fProducer, fFunction, fMaxTime, fCirculationPeriod)
        {
            TimeОrbit = fTimeOrbit;
            DockingNodes = fDockingNodes;
        }
        public Station()
        {
        }
    }
}
