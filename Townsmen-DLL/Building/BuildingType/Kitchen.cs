using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Townsmen
{
    [Serializable]
    public class Kitchen:Building
    {
        public Kitchen():base()
        {
            currentVillagers = 0;
            maxVillagers = new int[] { 5, 8, 10 };
            isPlaced = false;
            currentLevel = 0;
            buildingType = BuildingType.KITCHENHOUSE;


            BuildingPrice[0].Add(ResourseType.ROCK, 10);
            BuildingPrice[0].Add(ResourseType.WOODENDECK, 10);
            BuildingPrice[0].Add(ResourseType.GOLD, 200);


            BuildingPrice[1].Add(ResourseType.ROCK, 15);
            BuildingPrice[1].Add(ResourseType.WOODENDECK, 20);
            BuildingPrice[1].Add(ResourseType.HAMMER, 5);
            BuildingPrice[1].Add(ResourseType.GOLD, 300);

            BuildingPrice[2].Add(ResourseType.IRON, 15);
            BuildingPrice[2].Add(ResourseType.WOODENDECK, 70);
            BuildingPrice[2].Add(ResourseType.HAMMER, 15);
            BuildingPrice[2].Add(ResourseType.GOLD, 600);
        }
    }
}
