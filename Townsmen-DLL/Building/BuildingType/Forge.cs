using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Townsmen
{
    public class Forge:Building
    {
        public Forge():base()
        {
            currentVillagers = 0;
            maxVillagers = 0;
            isPlace = true;
            pathIMG = string.Empty;
            coord_X = 0;
            coord_Y = 0;
            buildingType = BuildingType.FORGEHOUSE;
            BuildingPrice.Add(ResourseType.WOODENDECK, 15);
        }
    }
}
