using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DLL_Townsmen
{
    [Serializable]
    public class Building
    {
        public int currentLevel;
        public int currentVillagers;
        public int []maxVillagers;
        public bool isPlaced;
        [XmlIgnore]
        public BuildingType buildingType;
        [XmlIgnore]

        public Dictionary<ResourseType, int>[] BuildingPrice = new Dictionary<ResourseType, int>[]{
        new Dictionary<ResourseType, int>(),
        new Dictionary<ResourseType, int>(),
        new Dictionary<ResourseType, int>()
        };
        public Building()
        {
            currentVillagers = 0;
            maxVillagers = new int[]{ 0,0,0};
            isPlaced = false;
            currentLevel = 0;
        }
      
    }
}
