using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project7
{
    public class Sprite
    {
        
        public Rectangle SpriteRectangle;
        public Texture2D Texture;
        public string TexturePath;

        public Sprite(Rectangle spriteRectangle, Texture2D texture, string texturePath)
        {
            
            SpriteRectangle = spriteRectangle;
            Texture = texture;
            TexturePath = texturePath;
        }
    }
}
