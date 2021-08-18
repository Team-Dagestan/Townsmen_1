using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Townsmen
{
    public class Hammer:Resourse
    {
        public Hammer():base()
        {
            pathIMG = string.Empty;
            count = 0;
            price = 0;
            resourseType = ResourseType.HAMMER;
        }
    }
}
