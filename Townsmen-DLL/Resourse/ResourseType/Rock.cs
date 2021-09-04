using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Townsmen
{
    [Serializable]
    public class Rock:Resourse
    {
        public Rock():base()
        {
            
            count = 0;
            price = 7;
            resourseType = ResourseType.ROCK;
        }
    }
}
