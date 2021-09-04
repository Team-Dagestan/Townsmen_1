using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DLL_Townsmen
{
    [Serializable]
    public class Resourse
    {
        public string pathIMG;
        public int count;
        public int price;
        [XmlIgnore]
        public ResourseType resourseType;
        public Resourse()
        {
            pathIMG = string.Empty;
            count = 0;
            price = 0;
        }
    }
}
