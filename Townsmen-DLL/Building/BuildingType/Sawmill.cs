using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Townsmen
{
    public class Sawmill : Building
    {
        public Sawmill() : base()
        {
            currentVillagers =0;
            maxVillagers =0;
            isPlace =true;
            pathIMG = string.Empty;
            coord_X = 0;
            coord_Y = 0;
            buildingType = BuildingType.SAWMILLHOUSE;
            BuildingPrice.Add(ResourseType.WOOD, 15);

        }
    }
}
