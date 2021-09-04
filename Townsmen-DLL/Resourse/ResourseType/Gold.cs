using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Townsmen
{
    [Serializable]
    public class Gold:Resourse
    {
        public Gold():base()
        {
            
            count = 0;
            price = 0;
            resourseType = ResourseType.GOLD;
        }
    }
}
