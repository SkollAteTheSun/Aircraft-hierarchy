using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VP7
{
    [Serializable]
    public class Plane : Aerodynamic
    {
        public decimal Wingspan { get; set; } // Размах крыла

        public Plane(string fName, string fProducer, string fFunction, string fMaxTime, decimal fCrew, decimal fWingspan) : base(fName, fProducer, fFunction, fMaxTime, fCrew)
        {   
            Wingspan = fWingspan;

        }
        public Plane()
        {
        }
    }
}
