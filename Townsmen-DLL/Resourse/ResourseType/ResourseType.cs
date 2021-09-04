using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Townsmen
{
    [Serializable]
    public enum ResourseType : byte
    {
        ROCK = 0,
        IRONORE = 1,
        WOOD =2,
        IRON = 3,
        WOODENDECK = 4,
        HAMMER = 5,
        FOOD = 6,
        GOLD = 7
    }
}
