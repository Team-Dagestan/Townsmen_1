using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Townsmen
{
    [Serializable]
    public class Farmer:Building
    {
        public Farmer():base()
        {
            currentVillagers = 0;
            maxVillagers = new int[] { 5, 10, 15 };
            isPlaced = false;
            currentLevel = 0;
            buildingType = BuildingType.FARMERHOUSE;

            BuildingPrice[0].Add(ResourseType.ROCK, 25);
            BuildingPrice[0].Add(ResourseType.WOOD, 30);
            BuildingPrice[0].Add(ResourseType.GOLD, 350);

            BuildingPrice[1].Add(ResourseType.ROCK, 40);
            BuildingPrice[1].Add(ResourseType.WOODENDECK, 30);
            BuildingPrice[1].Add(ResourseType.WOOD, 50);
            BuildingPrice[1].Add(ResourseType.GOLD, 700);

            BuildingPrice[2].Add(ResourseType.IRON, 40);
            BuildingPrice[2].Add(ResourseType.WOODENDECK, 50);
            BuildingPrice[2].Add(ResourseType.HAMMER, 40);
            BuildingPrice[2].Add(ResourseType.GOLD, 900);
        }
    }
}
