using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Townsmen
{
    [Serializable]
    public class Town:Building
    {
        public Town():base()
        {
            currentVillagers = 0;
            maxVillagers =new int[]{20,40,60};
            isPlaced = true;
            currentLevel = 0;
            buildingType = BuildingType.TOWNHALL;

           // BuildingPrice[0].Add(ResourseType.GOLD, 0);
          
            BuildingPrice[0].Add(ResourseType.ROCK, 40);
            BuildingPrice[0].Add(ResourseType.WOODENDECK, 40);
            BuildingPrice[0].Add(ResourseType.HAMMER, 20);
            BuildingPrice[0].Add(ResourseType.GOLD, 500);

            BuildingPrice[1].Add(ResourseType.WOODENDECK, 80);
            BuildingPrice[1].Add(ResourseType.HAMMER, 50);
            BuildingPrice[1].Add(ResourseType.IRON, 50);
            BuildingPrice[1].Add(ResourseType.GOLD, 900);
        }
    }
}
