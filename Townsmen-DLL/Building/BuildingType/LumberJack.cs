using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Townsmen
{
    [Serializable]
    public class LumberJack:Building
    {
        public LumberJack():base()
        {
            currentVillagers = 0;
            maxVillagers = new int[] { 4, 8, 12 };
            isPlaced = false;
            currentLevel = 0;
            buildingType = BuildingType.LUMBERJACKHOUSE;


            BuildingPrice[0].Add(ResourseType.GOLD, 200);

            BuildingPrice[1].Add(ResourseType.ROCK, 15);
            BuildingPrice[1].Add(ResourseType.WOOD, 20);
            BuildingPrice[1].Add(ResourseType.HAMMER, 10);
            BuildingPrice[1].Add(ResourseType.GOLD, 200);

            BuildingPrice[2].Add(ResourseType.WOODENDECK, 40);
            BuildingPrice[2].Add(ResourseType.IRON, 30);
            BuildingPrice[2].Add(ResourseType.HAMMER, 30);
            BuildingPrice[2].Add(ResourseType.GOLD, 600);
        }
    }
}
