using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Townsmen
{
    [Serializable]
    public class Miner:Building
    {
        public Miner():base()
        {
            currentVillagers = 0;
            maxVillagers = new int[] { 2, 4, 6 };
            isPlaced = false;
            currentLevel = 0;
            buildingType = BuildingType.MINERHOUSE;


            BuildingPrice[0].Add(ResourseType.WOOD, 20);
            BuildingPrice[0].Add(ResourseType.GOLD, 200);

            BuildingPrice[1].Add(ResourseType.WOOD, 40);
            BuildingPrice[1].Add(ResourseType.ROCK, 30);
            BuildingPrice[1].Add(ResourseType.IRONORE, 30);
            BuildingPrice[1].Add(ResourseType.GOLD, 400);

            BuildingPrice[2].Add(ResourseType.HAMMER, 40);
            BuildingPrice[2].Add(ResourseType.ROCK, 30);
            BuildingPrice[2].Add(ResourseType.WOODENDECK, 30);
            BuildingPrice[2].Add(ResourseType.GOLD, 600);
        }
    }
}
