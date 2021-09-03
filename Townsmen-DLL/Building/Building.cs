using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Townsmen
{
    [Serializable]
    public class Building
    {
        public int currentVillagers;
        public int maxVillagers;
        public bool isPlace;
        public string pathIMG;
        public int coord_X;
        public int coord_Y;
        public BuildingType buildingType;
        public Dictionary<ResourseType, int> BuildingPrice;
        public Building()
        {
            currentVillagers = 0;
            maxVillagers = 0;
            isPlace = false;
            pathIMG = string.Empty;
            coord_X = 0;
            coord_Y = 0;
           
        }
      
    }
}
