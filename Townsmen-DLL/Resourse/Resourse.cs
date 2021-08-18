using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Townsmen
{
    public class Resourse
    {
        public string pathIMG;
        public int count;
        public int price;
        public ResourseType resourseType;
        public Resourse()
        {
            pathIMG = string.Empty;
            count = 0;
            price = 0;
        }
    }
}
