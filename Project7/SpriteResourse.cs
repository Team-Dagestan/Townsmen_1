using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using DLL_Townsmen;

namespace Project7
{
    public class SpriteResourse
    {
        public Resourse ResourseType;
        public Rectangle SpriteRectangle;
        public Texture2D Texture;
        public string TexturePath;

        public SpriteResourse(Resourse resourseType, Rectangle spriteRectangle, Texture2D texture, string texturePath)
        {
            ResourseType = resourseType;
            SpriteRectangle = spriteRectangle;
            Texture = texture;
            TexturePath = texturePath;
        }
    }
}
