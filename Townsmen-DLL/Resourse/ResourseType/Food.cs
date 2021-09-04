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
           
            count = 0;
            price = 3;
            resourseType = ResourseType.FOOD;
        }
    }
}
