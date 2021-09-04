using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Townsmen
{
    [Serializable]
    public class Hammer:Resourse
    {
        public Hammer():base()
        {
            
            count = 0;
            price = 15;
            resourseType = ResourseType.HAMMER;
        }
    }
}
