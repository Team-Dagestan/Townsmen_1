using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Townsmen
{
    [Serializable]
    public class Collector:Building
    {
        public Collector():base()
        {
            currentVillagers = 0;
            maxVillagers = new int[] { 5, 7, 10 };
            isPlaced = true;
            currentLevel = 0;
            buildingType = BuildingType.COLLECTORHOUSE;

           
           // BuildingPrice[0].Add(ResourseType.GOLD, 0);

            BuildingPrice[0].Add(ResourseType.ROCK, 15);
            BuildingPrice[0].Add(ResourseType.WOODENDECK, 25);
            BuildingPrice[0].Add(ResourseType.HAMMER, 5);
            BuildingPrice[0].Add(ResourseType.GOLD, 300);

            BuildingPrice[1].Add(ResourseType.ROCK, 30);
            BuildingPrice[1].Add(ResourseType.WOODENDECK, 50);
            BuildingPrice[1].Add(ResourseType.HAMMER, 15);
            BuildingPrice[1].Add(ResourseType.GOLD, 500);
        }
    }
}
