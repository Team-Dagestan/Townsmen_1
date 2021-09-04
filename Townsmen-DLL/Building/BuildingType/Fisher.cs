using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Townsmen
{
    [Serializable]
    public class Fisher:Building
    {
        public Fisher():base()
        {
            currentVillagers = 0;
            maxVillagers = new int[] { 2, 4, 6 };
            isPlaced = false;
            currentLevel = 0;
            buildingType = BuildingType.FISHERMANHOUSE;


            BuildingPrice[0].Add(ResourseType.WOOD, 5);
            BuildingPrice[0].Add(ResourseType.GOLD, 50);

            BuildingPrice[1].Add(ResourseType.WOOD, 10);
            BuildingPrice[1].Add(ResourseType.ROCK, 10);
            BuildingPrice[1].Add(ResourseType.GOLD, 150);

            BuildingPrice[2].Add(ResourseType.IRONORE, 10);
            BuildingPrice[2].Add(ResourseType.WOODENDECK, 10);
            BuildingPrice[2].Add(ResourseType.GOLD, 250);
        }
    }
}
