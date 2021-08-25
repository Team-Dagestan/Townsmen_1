using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using DLL_Townsmen;

namespace Project7
{
    public class SpriteBuilding
    {
        public Building BuildingType;
        public Rectangle IconRectangle;
        public Rectangle SpriteRectangle;
        public Texture2D[] Texture;
        public Texture2D[] Icon;
        public string[] IconPath;
        public string[] TexturePath;
        

        public SpriteBuilding(Building buildingType, Rectangle iconRectangle, Rectangle spriteRactangle, Texture2D[] texture, Texture2D[] icon, string[] iconPath, string[] texturePath)
        {
            BuildingType = buildingType;
            IconRectangle = iconRectangle;
            SpriteRectangle = spriteRactangle;
            Texture = texture;
            Icon = icon;
            IconPath = iconPath;
            TexturePath = texturePath;
          
        }
    }
}
