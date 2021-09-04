using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DLL_Townsmen
{
        [Serializable]
    public class Villager
    {

        public bool IsVisible;

        [XmlIgnore]
        public BuildingType WorkPlace;

        public Villager(bool isVisible, BuildingType workPlace)
        {
            IsVisible = isVisible;
            WorkPlace = workPlace;
        }
    }
  
}
