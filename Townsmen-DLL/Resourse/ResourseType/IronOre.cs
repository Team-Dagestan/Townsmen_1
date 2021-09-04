using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Townsmen
{
    [Serializable]
    public class IronOre:Resourse
    {
        public IronOre():base()
        {
           
            count = 0;
            price = 4;
            resourseType = ResourseType.IRONORE;
        }
    }
}
