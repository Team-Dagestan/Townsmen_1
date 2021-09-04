using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Townsmen
{
    [Serializable]
    public class WoodenDeck:Resourse
    {
        public WoodenDeck():base()
        {
           
            count = 0;
            price = 8;
            resourseType = ResourseType.WOODENDECK;
        }
    }
}
