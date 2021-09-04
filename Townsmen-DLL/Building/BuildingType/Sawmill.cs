using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Townsmen
{
    [Serializable]
    public class Sawmill : Building
    {
        public Sawmill() : base()
        {
            currentVillagers = 0;
            maxVillagers = new int[] { 3, 5, 7 };
            isPlaced = false;
            currentLevel = 0;
            buildingType = BuildingType.SAWMILLHOUSE;

            BuildingPrice[0].Add(ResourseType.ROCK, 2);
            BuildingPrice[0].Add(ResourseType.WOOD, 10);
            BuildingPrice[0].Add(ResourseType.GOLD, 150);

            BuildingPrice[1].Add(ResourseType.ROCK, 10);
            BuildingPrice[1].Add(ResourseType.WOODENDECK, 20);
            BuildingPrice[1].Add(ResourseType.HAMMER, 10);
            BuildingPrice[1].Add(ResourseType.GOLD, 300);

            BuildingPrice[2].Add(ResourseType.IRON, 10);
            BuildingPrice[2].Add(ResourseType.WOODENDECK, 20);
            BuildingPrice[2].Add(ResourseType.HAMMER, 15);
            BuildingPrice[2].Add(ResourseType.GOLD, 500);

        }
    }
}
