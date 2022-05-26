using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VP7
{
    [Serializable]
    public class Helicopter : Aerodynamic
    {

        public decimal СountBlades { get; set; } // Число лопастей 

        public Helicopter(string fName, string fProducer, string fFunction, string fMaxTime, decimal fCrew, decimal fCountBlades) : base(fName, fProducer, fFunction, fMaxTime, fCrew)
        {
            СountBlades = fCountBlades;

        }
        public Helicopter()
        {
        }
    }
}
