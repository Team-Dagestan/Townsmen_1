using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using DLL_Townsmen;

namespace Project7
{
    public class SpriteVillager
    {
        public Rectangle SpriteRectangle;
        public int AnimationFrame;
        public Texture2D[] Texture;
        public string[] TexturePath;
        public Villager VillagerType;
        public Point DestinationPoint;
        public int VillagerStep;
        public int CurrentFrame;
        public int[] FrameList;
        public int WorkTime;
        public int JobStatus;
        public int TimeWorked = 0;
        public SpriteVillager(Villager villagerType, Rectangle spriteRectangle, int animationFrame, Texture2D[] texture, string[] texturePath)
        {
            VillagerType = villagerType;
            SpriteRectangle = spriteRectangle;
            AnimationFrame = animationFrame;
            Texture = texture;
            TexturePath = texturePath;

            VillagerStep = 5;
            WorkTime = 0;
            JobStatus = 0;
            TimeWorked = 0;
        }
    }
}
