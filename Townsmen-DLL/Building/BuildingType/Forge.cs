using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Townsmen
{
    [Serializable]
    public class Forge:Building
    {
        public Forge():base()
        {
            currentVillagers = 0;
            maxVillagers = new int[] { 3, 6, 10 };
            isPlaced = false;
            currentLevel = 0;
            buildingType = BuildingType.FORGEHOUSE;


            BuildingPrice[0].Add(ResourseType.ROCK, 10);
            BuildingPrice[0].Add(ResourseType.WOODENDECK, 10);
            BuildingPrice[0].Add(ResourseType.GOLD, 200);

            BuildingPrice[1].Add(ResourseType.IRONORE, 10);
            BuildingPrice[1].Add(ResourseType.WOODENDECK, 10);
            BuildingPrice[1].Add(ResourseType.GOLD, 250);

            BuildingPrice[2].Add(ResourseType.IRON, 20);
            BuildingPrice[2].Add(ResourseType.WOODENDECK, 50);
            BuildingPrice[2].Add(ResourseType.HAMMER, 25);
            BuildingPrice[2].Add(ResourseType.GOLD, 300);

        }
    }
}
