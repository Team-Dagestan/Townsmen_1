using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Townsmen
{
    public class WoodenDeck:Resourse
    {
        public WoodenDeck():base()
        {
            pathIMG = string.Empty;
            count = 0;
            price = 0;
            resourseType = ResourseType.WOODENDECK;
        }
    }
}
