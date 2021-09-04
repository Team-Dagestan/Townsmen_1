using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Townsmen
{
    [Serializable]
    public class Wood:Resourse
    {
        public Wood():base()
        {
           
            count = 0;
            price = 5;
            resourseType = ResourseType.WOOD;
        }
    }
}
