using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VP7
{
    [Serializable]
    public class Airship : Aerostatic
    {

        public string Form { get; set; } // Форма(сигарообразные, дисковые, эллипсоидные, V-образные)
        
        public Airship(string fName, string fProducer, string fFunction, string fMaxTime, string fShellType, decimal ShellVolume, string fForm) : base(fName, fProducer, fFunction, fMaxTime, fShellType, ShellVolume)
        {  
            Form = fForm;

        }
        public Airship()
        {
        }
    }
}
