using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Townsmen
{
    [Serializable]
    public class Food:Resourse
    {
        public Food():base()
        {
            pathIMG = string.Empty;
            count = 0;
            price = 0;
            resourseType = ResourseType.FOOD;
        }
    }
}
