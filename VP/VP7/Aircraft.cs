using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VP7
{
    [Serializable]
    public abstract class Aircraft : IComparable<Aircraft>
    {
        public string Name { get; set; }                //Наименование
        public string Producer { get; set; }            //Производитель
        public string Function { get; set; }            //Назначение
        public string MaxTime { get; set; }            //Максимальная длительность полета
        public Aircraft(string fName, string fProducer, string fFunction, string fMaxTime)
        {
            Name = fName;
            Producer = fProducer;
            Function = fFunction;
            MaxTime = fMaxTime;
        }
        public Aircraft()
        {

        }
 
        public int CompareTo(Aircraft other)
        {
            for (int i = 0; i < (this.Name.Length > other.Name.Length ? other.Name.Length : this.Name.Length); i++)
            {
                if (this.Name.ToCharArray()[i] < other.Name.ToCharArray()[i]) return -1;
                if (this.Name.ToCharArray()[i] > other.Name.ToCharArray()[i]) return 1;
            }
            return -1;
        }

    }
}
