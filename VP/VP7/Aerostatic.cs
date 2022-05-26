using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VP7
{
    [Serializable]
    abstract public class Aerostatic : Aircraft
    {
        public string ShellType { get; set; } // Тип оболочки
        public decimal ShellVolume { get; set; } // Объем оболочки
        public Aerostatic(string fName, string fProducer, string fFunction, string fMaxTime, string fShellType, decimal fShellVolume) : base(fName, fProducer, fFunction, fMaxTime)
        {
            ShellType = fShellType;
            ShellVolume = fShellVolume;
        }
        public Aerostatic()
        {
        }
    }
}
