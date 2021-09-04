using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Townsmen
{
    [Serializable]
    public class Iron:Resourse
    {
        public Iron():base()
        {
           
            count = 0;
            price = 7;
            resourseType = ResourseType.IRON;
        }
    }
}
