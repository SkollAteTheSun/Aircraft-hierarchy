using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VP7
{
    [Serializable]
    abstract public class Aerodynamic : Aircraft
    {
        public decimal Crew { get; set; } // Экипаж
        public Aerodynamic(string fName, string fProducer, string fFunction, string fMaxTime, decimal fCrew) : base(fName, fProducer, fFunction, fMaxTime)
        {
            Crew = fCrew;
            
        }
        public Aerodynamic()
        {
        }
    }
}
