using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VP7
{
    [Serializable]
    public class Balloon : Aerostatic
    {

        public string Color { get; set; } // Цвет

        public Balloon(string fName, string fProducer, string fFunction, string fMaxTime, string fShellType, decimal ShellVolume, string fColor) : base(fName, fProducer, fFunction, fMaxTime, fShellType, ShellVolume)
        {
            Color = fColor;

        }
        public Balloon()
        {
        }
    }
}
