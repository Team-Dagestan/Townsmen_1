using System;
using System.IO;
using System.Xml.Serialization;
using DLL_Townsmen;


namespace Project7
{
    [Serializable]
    public class GameInfo
    {
        public Resourse resourse { get; set; }
        public Food food { get; set; }
        public Gold gold { get; set; }
        public Hammer hammer { get; set; }
        public Iron iron { get; set; }
        public IronOre ironOre { get; set; }
        public Rock rock { get; set; }
        public Wood wood { get; set; }
        public WoodenDeck woodenDeck { get; set; }

        public Building building { get; set; }
        public Collector collector { get; set; }
        public Farmer farmer { get; set; }
        public Fisher fisher { get; set; }
        public Forge forge { get; set; }
        public Kitchen kitchen { get; set; }
        public LumberJack lumberJack { get; set; }
        public Miner miner { get; set; }
        public Sawmill sawmill { get; set; }
        public Town town { get; set; }

        public Villager villager { get; set; }

        public XmlSerializer formatter = new XmlSerializer(typeof(GameInfo));
        public GameInfo() { }

        public void Save(GameInfo obj)
        {
            formatter = new XmlSerializer(typeof(GameInfo));
            using (FileStream fs = new FileStream("GameInfo.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, obj);
            }
        }

        public GameInfo Load()
        {
            if(File.Exists("GameInfo.xml"))
            {
                using (FileStream fs = new FileStream("GameInfo.xml", FileMode.OpenOrCreate))
                {
                    GameInfo info = (GameInfo)formatter.Deserialize(fs);
                    return info;
                }
            }
            return new GameInfo();
        }
    }
}
