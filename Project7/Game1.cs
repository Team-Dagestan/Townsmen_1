using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using DLL_Townsmen;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Project7
{

    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;


        EnumGlobalStatus GlobalStatus = EnumGlobalStatus.GAME;

        Random rnd = new Random();

        List<SpriteResourse> Resourse = new List<SpriteResourse>();
        List<SpriteBuilding> Building = new List<SpriteBuilding>();
        List<SpriteVillager> Villager = new List<SpriteVillager>();

        Sprite ResourseMenu;
        Sprite WorkMenu;
        Sprite BuildMenu;
        Sprite Background;
        Sprite Selection;
        Sprite Selection2;
        Sprite Confirm;
        Sprite Decline;
        Sprite ArrowUp;
        Sprite ArrowDown;
        SpriteFont Font;
        SpriteFont SmallFont;
        SpriteFont UnsafeRes;
        SpriteFont UnsafeGold;
        Sprite RodA;
        Sprite RodB;
        Sprite Rod;
        Sprite Wood;
        Sprite Fish;
        Sprite Food;
        Sprite Stone;
        Sprite IronOre;

        Texture2D[] VillagerTextures = new Texture2D[] { null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null };
        Texture2D Waterfall;
        Texture2D WaterfallA;
        Texture2D WaterfallB;

        string[] VillagerTexturePaths = new string[] { "Textures/Animations/1", "Textures/Animations/2", "Textures/Animations/3", "Textures/Animations/4", "Textures/Animations/5",
        "Textures/Animations/6","Textures/Animations/7","Textures/Animations/8","Textures/Animations/9","Textures/Animations/10","Textures/Animations/11","Textures/Animations/12",
        "Textures/Animations/13","Textures/Animations/14","Textures/Animations/15","Textures/Animations/16","Textures/Animations/44","Textures/Animations/47","Textures/Animations/49.1","Textures/Animations/49.2"};

        int IntUnsafeRes;
        int IntUnsafeGold;
        int CurrentDay = 0;
        int SelectedItemID = 0;
        int SelectedBuildingID = 0;

        bool DrawIconWood=false;
        bool DrawIconFish = false;
        bool DrawIconFood=false;
        bool DrawIconStone=false;
        bool DrawIconIronOre=false;
        bool ButtonSelected = false;
        bool ButtonPressed = false;
        bool DrawRod = false;
        bool ButtonPressed2 = false;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {

            base.Initialize();

            _graphics.PreferredBackBufferWidth = 704;
            _graphics.PreferredBackBufferHeight = 832;
            _graphics.ApplyChanges();

            Window.Title = "Townsmen 1";

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);


            Font = Content.Load<SpriteFont>("Font/DefaultFont");
            SmallFont = Content.Load<SpriteFont>("Font/smol");
            UnsafeRes = Content.Load<SpriteFont>("Font/DefaultFont");
            UnsafeGold = Content.Load<SpriteFont>("Font/DefaultFont");

            IronOre = new Sprite(new Rectangle(140, 565, 36, 48), null, "Textures/41.1");
            Fish = new Sprite(new Rectangle(140, 565, 36, 48), null, "Textures/41.2");
            Food = new Sprite(new Rectangle(140, 565, 36, 48), null, "Textures/41.3");
            Stone = new Sprite(new Rectangle(140, 565, 36, 48), null, "Textures/41.4");
            Wood = new Sprite(new Rectangle(140, 565, 36, 48), null, "Textures/41.5");

            RodA = new Sprite(new Rectangle(140, 565, 28, 32), null, "Textures/Animations/48.1");
            RodB = new Sprite(new Rectangle(140, 565, 28, 32), null, "Textures/Animations/48.2");
            ArrowUp = new Sprite(new Rectangle(350, 370, 28, 32), null, "Textures/34");
            ArrowDown = new Sprite(new Rectangle(350, 420, 28, 32), null, "Textures/35");
            Confirm = new Sprite(new Rectangle(0, 788, 52, 44), null, "Textures/32");
            Decline = new Sprite(new Rectangle(652, 780, 52, 52), null, "Textures/33");
            Selection = new Sprite(new Rectangle(0,0,110,110), null, "Textures/selection");
            Selection2 = new Sprite(new Rectangle(0, 0, 90, 90), null, "Textures/selection2");
            BuildMenu = new Sprite(new Rectangle(155, 727, 100, 100), null, "Textures/build");
            WorkMenu = new Sprite(new Rectangle(305, 727, 100, 100), null, "Textures/work");
            ResourseMenu = new Sprite(new Rectangle(455, 727, 100, 100),null, "Textures/res");
            Background = new Sprite(new Rectangle(0, 0, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight), null, "Textures/27");

            WaterfallA = Content.Load<Texture2D>("Textures/Animations/46.1");
            WaterfallB = Content.Load<Texture2D>("Textures/Animations/46.2");

            IronOre.Texture = Content.Load<Texture2D>(IronOre.TexturePath);
            Fish.Texture = Content.Load<Texture2D>(Fish.TexturePath);
            Food.Texture = Content.Load<Texture2D>(Food.TexturePath);
            Stone.Texture = Content.Load<Texture2D>(Stone.TexturePath);
            Wood.Texture = Content.Load<Texture2D>(Wood.TexturePath);

            RodA.Texture = Content.Load<Texture2D>(RodA.TexturePath);
            RodB.Texture = Content.Load<Texture2D>(RodB.TexturePath);
            ArrowUp.Texture = Content.Load<Texture2D>(ArrowUp.TexturePath);
            ArrowDown.Texture = Content.Load<Texture2D>(ArrowDown.TexturePath);
            Confirm.Texture = Content.Load<Texture2D>(Confirm.TexturePath);
            Decline.Texture = Content.Load<Texture2D>(Decline.TexturePath);
            Selection.Texture = Content.Load<Texture2D>(Selection.TexturePath);
            Selection2.Texture = Content.Load<Texture2D>(Selection2.TexturePath);
            Background.Texture = Content.Load<Texture2D>(Background.TexturePath);
            BuildMenu.Texture = Content.Load<Texture2D>(BuildMenu.TexturePath);
            WorkMenu.Texture = Content.Load<Texture2D>(WorkMenu.TexturePath);
            ResourseMenu.Texture = Content.Load<Texture2D>(ResourseMenu.TexturePath); 

            Resourse.Add(new SpriteResourse(new Rock(),       new Rectangle(100, 140, 80, 80), null, "Textures/stone"));
            Resourse.Add(new SpriteResourse(new IronOre(),    new Rectangle(400, 140, 80, 80), null, "Textures/iron ore"));
            Resourse.Add(new SpriteResourse(new Wood(),       new Rectangle(100, 260, 80, 80), null, "Textures/wood"));
            Resourse.Add(new SpriteResourse(new Iron(),       new Rectangle(400, 260, 80, 80), null, "Textures/iron"));
            Resourse.Add(new SpriteResourse(new WoodenDeck(), new Rectangle(100, 380, 80, 80), null, "Textures/logs"));
            Resourse.Add(new SpriteResourse(new Hammer(),     new Rectangle(400, 380, 80, 80), null, "Textures/hammer"));
            Resourse.Add(new SpriteResourse(new Food(),       new Rectangle(100, 500, 80, 80), null, "Textures/food"));
            Resourse.Add(new SpriteResourse(new Gold(),       new Rectangle(400, 500, 80, 80), null, "Textures/gold"));

            Resourse.Where(x => x.ResourseType.resourseType == ResourseType.GOLD).ToList().ForEach(y => y.ResourseType.count = 500);

            for (int i = 0; i < Resourse.Count; i++)
            {
                Resourse[i].Texture = Content.Load<Texture2D>(Resourse[i].TexturePath);
            }

            Building.Add(new SpriteBuilding(new Collector(),  new Rectangle(300, 350, 80, 80), new Rectangle(340, 450, 80, 80), new Texture2D[] { null, null, null }, new Texture2D[] { null, null }, new string[] { "Textures/bag", "Textures/bagB" },               new string[] { "Textures/12", "Textures/13", "Textures/14" }));
            Building.Add(new SpriteBuilding(new Kitchen(),    new Rectangle(480, 350, 80, 80), new Rectangle(270, 340, 80, 80), new Texture2D[] { null, null, null }, new Texture2D[] { null, null }, new string[] { "Textures/kitchen", "Textures/kitchenB" },       new string[] { "Textures/6", "Textures/7", "Textures/8" }));
            Building.Add(new SpriteBuilding(new LumberJack(), new Rectangle(300, 170, 80, 80), new Rectangle(160, 380, 80, 80), new Texture2D[] { null, null, null }, new Texture2D[] { null, null }, new string[] { "Textures/lumberjack", "Textures/lumberjackB" }, new string[] { "Textures/3", "Textures/4", "Textures/5" }));
            Building.Add(new SpriteBuilding(new Forge(),      new Rectangle(480, 170, 80, 80), new Rectangle(380, 360, 80, 80), new Texture2D[] { null, null, null }, new Texture2D[] { null, null }, new string[] { "Textures/anvil", "Textures/anvilB" },           new string[] { "Textures/15", "Textures/16", "Textures/17" }));
            Building.Add(new SpriteBuilding(new Miner(),      new Rectangle(480, 530, 80, 80), new Rectangle(500, 460, 80, 80), new Texture2D[] { null, null, null }, new Texture2D[] { null, null }, new string[] { "Textures/mine", "Textures/mineB" },             new string[] { "Textures/24", "Textures/25", "Textures/26" }));
            Building.Add(new SpriteBuilding(new Sawmill(),    new Rectangle(120, 170, 80, 80), new Rectangle(395, 450, 80, 80), new Texture2D[] { null, null, null }, new Texture2D[] { null, null }, new string[] { "Textures/saw", "Textures/sawB" },               new string[] { "Textures/0", "Textures/1", "Textures/2" }));
            Building.Add(new SpriteBuilding(new Fisher(),     new Rectangle(120, 350, 80, 80), new Rectangle(180, 500, 80, 80), new Texture2D[] { null, null, null }, new Texture2D[] { null, null }, new string[] { "Textures/fish", "Textures/fishB" },             new string[] { "Textures/9", "Textures/10", "Textures/11" }));
            Building.Add(new SpriteBuilding(new Town(),       new Rectangle(120, 530, 80, 80), new Rectangle(320, 530, 80, 80), new Texture2D[] { null, null, null }, new Texture2D[] { null, null }, new string[] { "Textures/bed", "Textures/bedB" },               new string[] { "Textures/18", "Textures/19", "Textures/20" }));
            Building.Add(new SpriteBuilding(new Farmer(),     new Rectangle(300, 530, 80, 80), new Rectangle(390, 590, 80, 80), new Texture2D[] { null, null, null }, new Texture2D[] { null, null }, new string[] { "Textures/farm", "Textures/farmB" },             new string[] { "Textures/21", "Textures/22", "Textures/23" }));

            for (int i = 0; i < Building.Count; i++)
            {
                Building[i].Icon[0] = Content.Load<Texture2D>(Building[i].IconPath[0]);
                Building[i].Icon[1] = Content.Load<Texture2D>(Building[i].IconPath[1]);

                Building[i].Texture[0] = Content.Load<Texture2D>(Building[i].TexturePath[0]);
                Building[i].Texture[1] = Content.Load<Texture2D>(Building[i].TexturePath[1]);
                Building[i].Texture[2] = Content.Load<Texture2D>(Building[i].TexturePath[2]);
            }

            Villager.Add(new SpriteVillager(new Villager(false, BuildingType.TOWNHALL), new Rectangle(Building[7].SpriteRectangle.X+100, Building[7].SpriteRectangle.Y + 20, 32, 40), 0, VillagerTextures, VillagerTexturePaths));
            Villager.Add(new SpriteVillager(new Villager(false, BuildingType.TOWNHALL), new Rectangle(Building[7].SpriteRectangle.X + 100, Building[7].SpriteRectangle.Y + 20, 32, 40), 0, VillagerTextures, VillagerTexturePaths));
            Villager.Add(new SpriteVillager(new Villager(false, BuildingType.TOWNHALL), new Rectangle(Building[7].SpriteRectangle.X + 100, Building[7].SpriteRectangle.Y + 20, 32, 40), 0, VillagerTextures, VillagerTexturePaths));
            Villager.Add(new SpriteVillager(new Villager(false, BuildingType.COLLECTORHOUSE), new Rectangle(Building[0].SpriteRectangle.X + 20, Building[0].SpriteRectangle.Y + 20, 32, 40), 0, VillagerTextures, VillagerTexturePaths));
           
            for (int i = 0; i < Villager.Count; i++)
            {
                for (int j = 0; j < VillagerTextures.Length; j++)
                {
                    Villager[i].Texture[j] = Content.Load<Texture2D>(Villager[i].TexturePath[j]);
                }
                Villager[i].DestinationPoint = new Point( Villager[i].SpriteRectangle.X, Villager[i].SpriteRectangle.Y);
            }
        }

        public void VillagersChangeBuilding()
        {
            for (int i = 0; i < Building.Count; i++)
            {
                int count = 0;
                for (int j = 0; j < Villager.Count; j++)
                {

                    if (Building[i].BuildingType.buildingType == Villager[j].VillagerType.WorkPlace)
                        count++;
                }
                        Building[i].BuildingType.currentVillagers=count;
            }
        }

        public void WorkAnimation(GameTime gameTime, int n)
        {
            if (Villager[n].VillagerType.WorkPlace == BuildingType.MINERHOUSE)
            {
                if (Villager[n].DestinationPoint.X == Villager[n].SpriteRectangle.X && Villager[n].DestinationPoint.Y == Villager[n].SpriteRectangle.Y && Villager[n].JobStatus != 2)
                {
                    Villager[n].JobStatus = 1;
                    Villager[n].VillagerType.IsVisible = true;
                    if (gameTime.TotalGameTime.Seconds != Villager[n].TimeWorked)
                    {

                        Villager[n].AnimationFrame = Villager[n].AnimationFrame == 18 ? Villager[n].AnimationFrame = 19 : Villager[n].AnimationFrame = 18;
                        Villager[n].WorkTime++;
                    }

                    Villager[n].TimeWorked = gameTime.TotalGameTime.Seconds;


                    if (Villager[n].WorkTime == 10)
                    {
                        Villager[n].DestinationPoint = new Point(Building[7].SpriteRectangle.X+100, Building[7].SpriteRectangle.Y + 20);

                        if( rnd.Next(0, 2)==1)
                            DrawIconStone = true;
                        else
                            DrawIconIronOre = true;

                        Villager[n].WorkTime = 0;
                        GetVillagerFrameList(n);
                        Villager[n].JobStatus = 2;
                    }
                }
                
                if (Villager[n].JobStatus == 2)
                {
                    if(DrawIconStone==true)
                      Stone.SpriteRectangle = new Rectangle(Villager[n].SpriteRectangle.X, Villager[n].SpriteRectangle.Y-48, 36, 48);
                    else
                      IronOre.SpriteRectangle = new Rectangle(Villager[n].SpriteRectangle.X, Villager[n].SpriteRectangle.Y - 48, 36, 48);

                    if (Villager[n].DestinationPoint.X == Villager[n].SpriteRectangle.X && Villager[n].DestinationPoint.Y == Villager[n].SpriteRectangle.Y)
                    {
                        DrawIconStone = false;
                        DrawIconIronOre = false;

                        Villager[n].VillagerType.IsVisible=false;
                        if (gameTime.TotalGameTime.Seconds != Villager[n].TimeWorked)
                        {
                            Villager[n].WorkTime++;
                        }

                        Villager[n].TimeWorked = gameTime.TotalGameTime.Seconds;

                        if (Villager[n].WorkTime == 2)
                        {
                            
                            Villager[n].JobStatus = 0;
                            Villager[n].DestinationPoint =new Point( Building[4].SpriteRectangle.X+30, Building[4].SpriteRectangle.Y + 20);
                            Villager[n].VillagerType.IsVisible = true;
                            GetVillagerFrameList(n);
                        }
                    }
                }
            }

            if(Villager[n].VillagerType.WorkPlace == BuildingType.FISHERMANHOUSE)
            {
                if (Villager[n].DestinationPoint.X == Villager[n].SpriteRectangle.X && Villager[n].DestinationPoint.Y == Villager[n].SpriteRectangle.Y && Villager[n].JobStatus != 2)
                {
                    Villager[n].SpriteRectangle.X = 170;
                    Villager[n].SpriteRectangle.Y = 565;
                    Villager[n].DestinationPoint =new Point( 170,565);

                    Villager[n].JobStatus = 1;
                    Villager[n].VillagerType.IsVisible = true;
                    Villager[n].AnimationFrame = 17;
                    DrawRod = true;
                    if (gameTime.TotalGameTime.Seconds != Villager[n].TimeWorked)
                    {
                        Rod = Rod == RodA ? RodB : RodA;
                        Villager[n].WorkTime++;
                    }

                    Villager[n].TimeWorked = gameTime.TotalGameTime.Seconds;


                    if (Villager[n].WorkTime == 10)
                    {
                        DrawIconFish = true;
                        
                        Villager[n].DestinationPoint =new Point( Building[7].SpriteRectangle.X + 100, Building[7].SpriteRectangle.Y + 20);
                        Villager[n].WorkTime = 0;
                        GetVillagerFrameList(n);
                        Villager[n].JobStatus = 2;
                        DrawRod = false;
                    }
                }

                if (Villager[n].JobStatus == 2)
                {
                    Fish.SpriteRectangle = new Rectangle(Villager[n].SpriteRectangle.X, Villager[n].SpriteRectangle.Y - 48, 36, 48);

                    if (Villager[n].DestinationPoint.X == Villager[n].SpriteRectangle.X && Villager[n].DestinationPoint.Y == Villager[n].SpriteRectangle.Y)
                    {
                        DrawIconFish = false;
                        Villager[n].VillagerType.IsVisible = false;
                        if (gameTime.TotalGameTime.Seconds != Villager[n].TimeWorked)
                        {
                            Villager[n].WorkTime++;
                        }

                        Villager[n].TimeWorked = gameTime.TotalGameTime.Seconds;

                        if (Villager[n].WorkTime == 2)
                        {
                            Villager[n].JobStatus = 0;
                            Villager[n].DestinationPoint = new Point(Building[6].SpriteRectangle.X + 30, Building[6].SpriteRectangle.Y + 20);
                            Villager[n].VillagerType.IsVisible = true;
                            GetVillagerFrameList(n);
                        }
                    }
                }
            }

            if (Villager[n].VillagerType.WorkPlace == BuildingType.LUMBERJACKHOUSE)
            {
                if (Villager[n].DestinationPoint.X == Villager[n].SpriteRectangle.X && Villager[n].DestinationPoint.Y == Villager[n].SpriteRectangle.Y && Villager[n].JobStatus != 2)
                {
                    Villager[n].JobStatus = 1;
                    
                    if (gameTime.TotalGameTime.Seconds != Villager[n].TimeWorked)
                    {

                        Villager[n].VillagerType.IsVisible = false;
                        Villager[n].WorkTime++;
                    }

                    Villager[n].TimeWorked = gameTime.TotalGameTime.Seconds;


                    if (Villager[n].WorkTime == 10)
                    {
                        DrawIconWood = true;

                        Villager[n].DestinationPoint = new Point(Building[2].SpriteRectangle.X + 100, Building[2].SpriteRectangle.Y + 20);
                        Villager[n].WorkTime = 0;
                        GetVillagerFrameList(n);
                        Villager[n].JobStatus = 2;
                        Villager[n].VillagerType.IsVisible = true;
                    }
                }

                if (Villager[n].JobStatus == 2)
                {
                    Wood.SpriteRectangle = new Rectangle(Villager[n].SpriteRectangle.X, Villager[n].SpriteRectangle.Y - 48, 36, 48);

                    if (Villager[n].DestinationPoint.X == Villager[n].SpriteRectangle.X && Villager[n].DestinationPoint.Y == Villager[n].SpriteRectangle.Y)
                    {
                        DrawIconWood = false;

                        Villager[n].VillagerType.IsVisible = false;
                        if (gameTime.TotalGameTime.Seconds != Villager[n].TimeWorked)
                        {
                            Villager[n].WorkTime++;
                        }

                        Villager[n].TimeWorked = gameTime.TotalGameTime.Seconds;

                        if (Villager[n].WorkTime == 2)
                        {
                            Villager[n].JobStatus = 0;
                            Villager[n].DestinationPoint = new Point(170,300);
                            Villager[n].VillagerType.IsVisible = true;
                            GetVillagerFrameList(n);
                        }
                    }
                }
            }

            if (Villager[n].VillagerType.WorkPlace == BuildingType.FARMERHOUSE)
            {
                if (Villager[n].DestinationPoint.X == Villager[n].SpriteRectangle.X && Villager[n].DestinationPoint.Y == Villager[n].SpriteRectangle.Y && Villager[n].JobStatus != 2)
                {
                    Villager[n].JobStatus = 1;

                    if (gameTime.TotalGameTime.Seconds != Villager[n].TimeWorked)
                    {

                        Villager[n].VillagerType.IsVisible = false;
                        Villager[n].WorkTime++;
                    }

                    Villager[n].TimeWorked = gameTime.TotalGameTime.Seconds;


                    if (Villager[n].WorkTime == 10)
                    {
                        DrawIconFood = true;

                        Villager[n].DestinationPoint = new Point(Building[8].SpriteRectangle.X + 100, Building[8].SpriteRectangle.Y + 20);
                        Villager[n].WorkTime = 0;
                        GetVillagerFrameList(n);
                        Villager[n].JobStatus = 2;
                        Villager[n].VillagerType.IsVisible = true;
                    }
                }

                if (Villager[n].JobStatus == 2)
                {
                    Food.SpriteRectangle = new Rectangle(Villager[n].SpriteRectangle.X, Villager[n].SpriteRectangle.Y - 48, 36, 48);

                    if (Villager[n].DestinationPoint.X == Villager[n].SpriteRectangle.X && Villager[n].DestinationPoint.Y == Villager[n].SpriteRectangle.Y)
                    {
                        DrawIconFood = false;

                        Villager[n].VillagerType.IsVisible = false;
                        if (gameTime.TotalGameTime.Seconds != Villager[n].TimeWorked)
                        {
                            Villager[n].WorkTime++;
                        }

                        Villager[n].TimeWorked = gameTime.TotalGameTime.Seconds;

                        if (Villager[n].WorkTime == 2)
                        {
                            Villager[n].JobStatus = 0;
                            Villager[n].DestinationPoint = new Point(550, 550);
                            Villager[n].VillagerType.IsVisible = true;
                            GetVillagerFrameList(n);
                        }
                    }
                }
            }

        }
       
       
        public void GetVillagerFrameList(int n)
        {
            if (Villager[n].DestinationPoint.X > Villager[n].SpriteRectangle.X)
                Villager[n].FrameList = new int[] { 0, 1, 2, 3 };
            else
                Villager[n].FrameList = new int[] { 4, 5, 6, 7 };

            if (Villager[n].DestinationPoint.Y < Villager[n].SpriteRectangle.Y)
                Villager[n].FrameList = new int[] { Villager[n].FrameList[0] + 8, Villager[n].FrameList[1] + 8, Villager[n].FrameList[2] + 8, Villager[n].FrameList[3] + 8 };
            
         
        }
        public void Walk(GameTime gameTime, int n)////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        {
            if (gameTime.TotalGameTime.Milliseconds % 200 == 0)
            {
                if (Villager[n].SpriteRectangle.X != Villager[n].DestinationPoint.X || Villager[n].SpriteRectangle.Y != Villager[n].DestinationPoint.Y)
                {
                    if(Villager[n].SpriteRectangle.X != Villager[n].DestinationPoint.X)
                    {
                        if(Villager[n].SpriteRectangle.X > Villager[n].DestinationPoint.X)
                           Villager[n].SpriteRectangle.X -= Villager[n].VillagerStep;
                        else
                            Villager[n].SpriteRectangle.X += Villager[n].VillagerStep;
                    }


                    if (Villager[n].SpriteRectangle.Y != Villager[n].DestinationPoint.Y)
                    {
                        if (Villager[n].SpriteRectangle.Y > Villager[n].DestinationPoint.Y)
                            Villager[n].SpriteRectangle.Y -= Villager[n].VillagerStep;
                        else
                            Villager[n].SpriteRectangle.Y += Villager[n].VillagerStep;
                    }

                    Villager[n].AnimationFrame = Villager[n].FrameList[Villager[n].CurrentFrame];
                    if (Villager[n].CurrentFrame == 3)
                        Villager[n].CurrentFrame = 0;
                    else
                        Villager[n].CurrentFrame++;
                }
                else
                {
                    Villager[n].VillagerType.IsVisible = false;
                }
            }

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            for (int i = 0; i < Villager.Count; i++)
            {
               Walk(gameTime,i);
                WorkAnimation(gameTime, i);
            }

            VillagersChangeBuilding();

            Cheats();

            ButtonSelected = false;
         
            if (GlobalStatus == EnumGlobalStatus.GAME)
            {
                if (ResourseMenu.SpriteRectangle.Contains(Mouse.GetState().Position))
                {
                    ButtonSelected = true;
                    Selection.SpriteRectangle = new Rectangle(ResourseMenu.SpriteRectangle.X - 5, ResourseMenu.SpriteRectangle.Y - 5, 110, 110);
                    if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                        ResourseMenuClick();
                }

                if (WorkMenu.SpriteRectangle.Contains(Mouse.GetState().Position))
                {
                    ButtonSelected = true;
                    Selection.SpriteRectangle = new Rectangle(WorkMenu.SpriteRectangle.X - 5, WorkMenu.SpriteRectangle.Y - 5, 110, 110);
                    if (Mouse.GetState().LeftButton == ButtonState.Pressed )
                        WorkMenuClick();
                }

                if (BuildMenu.SpriteRectangle.Contains(Mouse.GetState().Position))
                {
                    ButtonSelected = true;
                    Selection.SpriteRectangle = new Rectangle(BuildMenu.SpriteRectangle.X - 5, BuildMenu.SpriteRectangle.Y - 5, 110, 110);
                    if (Mouse.GetState().LeftButton == ButtonState.Pressed )
                        BuildMenuClick();
                }
            }

            if(GlobalStatus==EnumGlobalStatus.RESOURSE_MENU)
            {
                for (int i = 0; i < Resourse.Count-1; i++)
                {
                    if (Resourse[i].SpriteRectangle.Contains(Mouse.GetState().Position) )
                    {
                        ButtonSelected = true;
                        Selection2.SpriteRectangle = new Rectangle(Resourse[i].SpriteRectangle.X - 5, Resourse[i].SpriteRectangle.Y - 5, 90, 90);
                        if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                        {
                            SelectedItemID = i;
                            ResourseClick();
                        }
                    }
                }
                if (Mouse.GetState().LeftButton == ButtonState.Released)
                    ButtonPressed = false;

                if (Decline.SpriteRectangle.Contains(Mouse.GetState().Position))
                {
                    if (Mouse.GetState().LeftButton == ButtonState.Pressed && ButtonPressed == false)
                        NoButtonClick();
                }
            }

            if(GlobalStatus == EnumGlobalStatus.RESOURSE_MENU_SELECT)
            {
                ArrowUp.SpriteRectangle = new Rectangle(350, 390, 28, 32);
                ArrowDown.SpriteRectangle = new Rectangle(350, 440, 28, 32);

                if (Mouse.GetState().LeftButton == ButtonState.Released)
                    ButtonPressed = false;

                if (Decline.SpriteRectangle.Contains(Mouse.GetState().Position) )
                {
                    if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                    {
                        ButtonPressed = true;
                        NoButtonClick();
                    }
                }
                if (Confirm.SpriteRectangle.Contains(Mouse.GetState().Position))
                {
                    if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                        YesButtonClick();
                }
                if (ArrowUp.SpriteRectangle.Contains(Mouse.GetState().Position) && ButtonPressed == false)
                {
                    if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                    {
                        ButtonPressed = true;
                        UpButtonClick(SelectedItemID);
                    }
                }
                if (ArrowDown.SpriteRectangle.Contains(Mouse.GetState().Position) && ButtonPressed == false)
                {
                    if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                    {
                        ButtonPressed = true;
                        DownButtonClick(SelectedItemID);
                    }
                }
            }

            if(GlobalStatus==EnumGlobalStatus.BUILDING_MENU)
            {
                if (Mouse.GetState().LeftButton == ButtonState.Released)
                    ButtonPressed = false;

                if (Decline.SpriteRectangle.Contains(Mouse.GetState().Position))
                {
                    if (Mouse.GetState().LeftButton == ButtonState.Pressed && ButtonPressed == false)
                        NoButtonClick();
                }

                for (int i = 0; i < Building.Count; i++)
                {
                    if (Building[i].IconRectangle.Contains(Mouse.GetState().Position))
                    {
                        
                            ButtonSelected = true;
                            Selection2.SpriteRectangle = new Rectangle(Building[i].IconRectangle.X - 5, Building[i].IconRectangle.Y - 5, 90, 90);
                            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                            {
                                SelectedBuildingID = i;
                                BuildingClick();
                            }
                        
                    }
                }
            }

            if(GlobalStatus == EnumGlobalStatus.BUILDING_MENU_SELECT)
            {
                if (Mouse.GetState().LeftButton == ButtonState.Released)
                    ButtonPressed = false;

                ArrowUp.SpriteRectangle = new Rectangle(350, 390, 28, 32);
                ArrowDown.SpriteRectangle = new Rectangle(350, 440, 28, 32);

                if (Decline.SpriteRectangle.Contains(Mouse.GetState().Position))
                {
                    if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                    {
                        ButtonPressed = true;
                        NoButtonClick();
                    }
                }
                if (Confirm.SpriteRectangle.Contains(Mouse.GetState().Position))
                {
                    if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                        YesButtonClick();
                }
            }

            if (GlobalStatus == EnumGlobalStatus.VILLAGER_JOB_MENU)
            {
                if (Mouse.GetState().LeftButton == ButtonState.Released)
                    ButtonPressed2 = false;

                if (Decline.SpriteRectangle.Contains(Mouse.GetState().Position))
                {
                    if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                    {
                        ButtonPressed = true;
                        NoButtonClick();
                    }
                }

                for (int i = 0; i < Building.Count; i++)
                {

                    if (Building[i].IconRectangle.Contains(Mouse.GetState().Position) && Building[i].BuildingType.isPlaced==true && Building[i].BuildingType.buildingType != BuildingType.TOWNHALL)
                    {
                        ButtonSelected = true;
                        Selection2.SpriteRectangle = new Rectangle(Building[i].IconRectangle.X - 5, Building[i].IconRectangle.Y - 5, 90, 90);
                        if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                        {
                            SelectedBuildingID = i;
                            ArrowUp.SpriteRectangle = new Rectangle(Building[i].IconRectangle.X - 40, Building[i].IconRectangle.Y, 28, 32);
                            ArrowDown.SpriteRectangle = new Rectangle(Building[i].IconRectangle.X - 40, Building[i].IconRectangle.Y +50, 28, 32);
                            ButtonPressed = true;
                        }
                    }
                }

                if (ArrowUp.SpriteRectangle.Contains(Mouse.GetState().Position) && ButtonPressed2 == false )
                {
                    if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                    {
                        ButtonPressed2 = true;
                        UpButtonClick(SelectedBuildingID);
                    }
                }
                if (ArrowDown.SpriteRectangle.Contains(Mouse.GetState().Position) && ButtonPressed2 == false)
                {
                    if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                    {
                        ButtonPressed2 = true;
                        DownButtonClick(SelectedBuildingID);
                    }
                }
            }

            WaterfallAnimation(gameTime);
            DayCounter(gameTime);

            base.Update(gameTime);
        }

        private void Cheats()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Z) && Keyboard.GetState().IsKeyDown(Keys.X) && Keyboard.GetState().IsKeyDown(Keys.C))
                for (int i = 0; i < Resourse.Count; i++)
                {
                    Resourse[i].ResourseType.count = 9999;
                }
        }

        private void BuildingClick()
        {
            GlobalStatus = EnumGlobalStatus.BUILDING_MENU_SELECT;
            ButtonSelected = false;
        }
      
        private void UpButtonClick(int test2)/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        {
            if (GlobalStatus == EnumGlobalStatus.RESOURSE_MENU_SELECT)
            {
                if (IntUnsafeGold >= Resourse[SelectedItemID].ResourseType.price)
                {
                    IntUnsafeRes++;
                    IntUnsafeGold -= Resourse[SelectedItemID].ResourseType.price;
                }
            }
            else
            {
                if (Building[7].BuildingType.currentVillagers > 0 && Building[test2].BuildingType.currentVillagers < Building[test2].BuildingType.maxVillagers[Building[test2].BuildingType.currentLevel])
                {
                    for (int i = 0; i < Villager.Count; i++)
                    {
                        if (Villager[i].VillagerType.WorkPlace == BuildingType.TOWNHALL)
                        {
                            Villager[i].VillagerType.WorkPlace = Building[test2].BuildingType.buildingType;
                            Villager[i].DestinationPoint = new Point(Building[test2].SpriteRectangle.X + 30, Building[test2].SpriteRectangle.Y + 20);
                            if(test2 == 2)
                                Villager[i].DestinationPoint = new Point(170,300);
                            if (test2 == 8)
                                Villager[i].DestinationPoint = new Point(550,550);

                            Villager[i].VillagerType.IsVisible = true;
                            GetVillagerFrameList(i);

                            break;
                        }
                    }
                }
            }
        }
        private void DownButtonClick(int test2)
        {
            if (GlobalStatus == EnumGlobalStatus.RESOURSE_MENU_SELECT)
            {
                if (IntUnsafeRes >= 1)
                {
                    IntUnsafeRes--;
                    IntUnsafeGold += Resourse[SelectedItemID].ResourseType.price;
                }
            }
            else
            {
                if(Building[test2].BuildingType.currentVillagers > 0 && Building[7].BuildingType.currentVillagers <  Building[7].BuildingType.maxVillagers[Building[7].BuildingType.currentLevel])
                {
                    for (int i = 0; i < Villager.Count; i++)
                    {
                        if (Villager[i].VillagerType.WorkPlace == Building[test2].BuildingType.buildingType)
                        {
                            Villager[i].VillagerType.WorkPlace = BuildingType.TOWNHALL;
                            Villager[i].DestinationPoint = new Point(Building[7].SpriteRectangle.X + 100, Building[7].SpriteRectangle.Y + 20);
                            Villager[i].VillagerType.IsVisible = true;
                            GetVillagerFrameList(i);
                            break;
                        }
                    }
                }

            }
        }
        private void YesButtonClick()
        {
            if (GlobalStatus == EnumGlobalStatus.RESOURSE_MENU_SELECT)
            {
                Resourse[7].ResourseType.count = IntUnsafeGold;
                Resourse[SelectedItemID].ResourseType.count = IntUnsafeRes;
                GlobalStatus = EnumGlobalStatus.RESOURSE_MENU;
            }
            else if(GlobalStatus ==EnumGlobalStatus.BUILDING_MENU_SELECT)
            {
                int count = 0;
                for (int i = 0; i < Building[SelectedBuildingID].BuildingType.BuildingPrice[Building[SelectedBuildingID].BuildingType.currentLevel].Count; i++)
                {
                    if (Resourse[(int)Building[SelectedBuildingID].BuildingType.BuildingPrice[Building[SelectedBuildingID].BuildingType.currentLevel].ElementAt(i).Key].ResourseType.count >= Building[SelectedBuildingID].BuildingType.BuildingPrice[Building[SelectedBuildingID].BuildingType.currentLevel].ElementAt(i).Value)
                        count++;
                }
                if (count == Building[SelectedBuildingID].BuildingType.BuildingPrice[Building[SelectedBuildingID].BuildingType.currentLevel].Count)
                {
                    for (int i = 0; i < Building[SelectedBuildingID].BuildingType.BuildingPrice[Building[SelectedBuildingID].BuildingType.currentLevel].Count; i++)
                    {
                        Resourse[(int)Building[SelectedBuildingID].BuildingType.BuildingPrice[Building[SelectedBuildingID].BuildingType.currentLevel].ElementAt(i).Key].ResourseType.count = Resourse[(int)Building[SelectedBuildingID].BuildingType.BuildingPrice[Building[SelectedBuildingID].BuildingType.currentLevel].ElementAt(i).Key].ResourseType.count - Building[SelectedBuildingID].BuildingType.BuildingPrice[Building[SelectedBuildingID].BuildingType.currentLevel].ElementAt(i).Value;
                    }
                    if (Building[SelectedBuildingID].BuildingType.isPlaced == false)
                        Building[SelectedBuildingID].BuildingType.isPlaced = true;
                    else
                        if(Building[SelectedBuildingID].BuildingType.currentLevel!=2)
                    Building[SelectedBuildingID].BuildingType.currentLevel++;

                    GlobalStatus = EnumGlobalStatus.BUILDING_MENU;
                }

                
            }
            ButtonSelected = false;
        }
        private void NoButtonClick()
        {
            if (GlobalStatus == EnumGlobalStatus.RESOURSE_MENU_SELECT)
                GlobalStatus = EnumGlobalStatus.RESOURSE_MENU;
            else if (GlobalStatus == EnumGlobalStatus.RESOURSE_MENU)
                GlobalStatus = EnumGlobalStatus.GAME;
            else if (GlobalStatus == EnumGlobalStatus.BUILDING_MENU_SELECT)
                GlobalStatus = EnumGlobalStatus.BUILDING_MENU;
            else if (GlobalStatus == EnumGlobalStatus.BUILDING_MENU)
                GlobalStatus = EnumGlobalStatus.GAME;
            else if (GlobalStatus == EnumGlobalStatus.VILLAGER_JOB_MENU)
            {
                GlobalStatus = EnumGlobalStatus.GAME;
                ButtonPressed = false;
            }

            ButtonSelected = false;
        }
        private void BuildMenuClick()
        {
            GlobalStatus = EnumGlobalStatus.BUILDING_MENU;
            ButtonSelected = false;
        }
        private void WorkMenuClick()
        {
            GlobalStatus = EnumGlobalStatus.VILLAGER_JOB_MENU;
            ButtonSelected = false;
        }
        private void ResourseMenuClick()
        {
            GlobalStatus = EnumGlobalStatus.RESOURSE_MENU;
            ButtonSelected = false;
        }

        private void ResourseClick()
        {
            IntUnsafeRes= Resourse[SelectedItemID].ResourseType.count;
            IntUnsafeGold = Resourse[7].ResourseType.count;

            GlobalStatus = EnumGlobalStatus.RESOURSE_MENU_SELECT;
            ButtonSelected = false;
        }

        private void DayCounter(GameTime gameTime)
        {
            if (gameTime.TotalGameTime.Seconds % 15 == 0 && gameTime.TotalGameTime.Milliseconds == 0)
            {
                CurrentDay++;

                for (int i = 0; i < Villager.Count; i++)
                {
                    if (Villager[i].VillagerType.WorkPlace == BuildingType.COLLECTORHOUSE)
                    {
                        Resourse[6].ResourseType.count += 5 * Building[0].BuildingType.currentLevel+1;
                        Resourse[7].ResourseType.count += 10 * Building[0].BuildingType.currentLevel + 1;
                    }

                    if (Villager[i].VillagerType.WorkPlace == BuildingType.FARMERHOUSE)
                        Resourse[6].ResourseType.count += 40 * Building[8].BuildingType.currentLevel + 1;

                    if (Villager[i].VillagerType.WorkPlace == BuildingType.FISHERMANHOUSE)
                        Resourse[6].ResourseType.count += 10 * Building[6].BuildingType.currentLevel + 1;

                    if (Villager[i].VillagerType.WorkPlace == BuildingType.FORGEHOUSE)
                        Resourse[3].ResourseType.count += 5 * Building[3].BuildingType.currentLevel + 1;

                    if (Villager[i].VillagerType.WorkPlace == BuildingType.KITCHENHOUSE)
                        Resourse[6].ResourseType.count += 5 * Building[1].BuildingType.currentLevel + 1;

                    if (Villager[i].VillagerType.WorkPlace == BuildingType.LUMBERJACKHOUSE)
                        Resourse[2].ResourseType.count += 5 * Building[2].BuildingType.currentLevel + 1;

                    if (Villager[i].VillagerType.WorkPlace == BuildingType.MINERHOUSE)
                    {
                        Resourse[1].ResourseType.count += 5 * Building[4].BuildingType.currentLevel + 1;
                        Resourse[0].ResourseType.count += 5 * Building[4].BuildingType.currentLevel + 1;
                    }

                    if (Villager[i].VillagerType.WorkPlace == BuildingType.SAWMILLHOUSE)
                        Resourse[4].ResourseType.count += 5 * Building[5].BuildingType.currentLevel + 1;
                }
            }


            if (gameTime.TotalGameTime.Seconds % 30 == 0 && gameTime.TotalGameTime.Milliseconds == 0 && Villager.Count < Building[7].BuildingType.maxVillagers[Building[7].BuildingType.currentLevel] 
                && Building[7].BuildingType.currentVillagers < Building[7].BuildingType.maxVillagers[Building[7].BuildingType.currentLevel] && Villager.Count*2 < Resourse[6].ResourseType.count)
            {
                Villager.Add(new SpriteVillager(new Villager(false, BuildingType.TOWNHALL), new Rectangle(Building[7].SpriteRectangle.X + 100, Building[7].SpriteRectangle.Y + 20, 32, 40), 0, VillagerTextures, VillagerTexturePaths));

                    for (int j = 0; j < VillagerTextures.Length; j++)
                    {
                        Villager[Villager.Count-1].Texture[j] = Content.Load<Texture2D>(Villager[Villager.Count - 1].TexturePath[j]);
                    }
                    Villager[Villager.Count - 1].DestinationPoint = new Point(Villager[Villager.Count - 1].SpriteRectangle.X, Villager[Villager.Count - 1].SpriteRectangle.Y);

                Resourse[6].ResourseType.count = Resourse[6].ResourseType.count - Villager.Count * 2;
            }
        }
        private void WaterfallAnimation(GameTime gameTime)
        {
            if (gameTime.TotalGameTime.Milliseconds % 500 == 0)
                if (Waterfall == WaterfallA)
                    Waterfall = WaterfallB;
                else
                    Waterfall = WaterfallA;
        }


        protected override void Draw(GameTime gameTime)
        {
        
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            _spriteBatch.Begin();


            _spriteBatch.Draw(Background.Texture, new Vector2(Background.SpriteRectangle.X, Background.SpriteRectangle.Y), Color.White);


            if (ButtonSelected == true)
                _spriteBatch.Draw(Selection.Texture, new Vector2(Selection.SpriteRectangle.X, Selection.SpriteRectangle.Y), Color.White);

            if (GlobalStatus == EnumGlobalStatus.GAME)
            {
                _spriteBatch.Draw(Waterfall,new Vector2(436,240),Color.White);
               
                _spriteBatch.Draw(BuildMenu.Texture, new Vector2(BuildMenu.SpriteRectangle.X, BuildMenu.SpriteRectangle.Y), Color.White);
                _spriteBatch.Draw(WorkMenu.Texture, new Vector2(WorkMenu.SpriteRectangle.X, WorkMenu.SpriteRectangle.Y), Color.White);
                _spriteBatch.Draw(ResourseMenu.Texture, new Vector2(ResourseMenu.SpriteRectangle.X, ResourseMenu.SpriteRectangle.Y), Color.White);

                _spriteBatch.DrawString(Font, $"Day  {CurrentDay}", new Vector2(3, 3), Color.Black);
                _spriteBatch.DrawString(Font, $"Day  {CurrentDay}", Vector2.Zero, Color.White);

                for (int i = 0; i < Building.Count; i++)
                {
                    if(Building[i].BuildingType.isPlaced == true)
                    _spriteBatch.Draw(Building[i].Texture[Building[i].BuildingType.currentLevel], new Vector2(Building[i].SpriteRectangle.X, Building[i].SpriteRectangle.Y), Color.White);
                }

                for (int i = 0; i < Villager.Count; i++)
                {
                    if (Villager[i].VillagerType.IsVisible == true)
                        _spriteBatch.Draw(Villager[i].Texture[Villager[i].AnimationFrame], new Vector2(Villager[i].SpriteRectangle.X, Villager[i].SpriteRectangle.Y), Color.White);
                }

                if (DrawRod == true)
                    _spriteBatch.Draw(Rod.Texture, new Vector2(Rod.SpriteRectangle.X, Rod.SpriteRectangle.Y), Color.White);

                if(DrawIconIronOre==true)
                    _spriteBatch.Draw(IronOre.Texture, new Vector2(IronOre.SpriteRectangle.X, IronOre.SpriteRectangle.Y), Color.White);
                if (DrawIconFood == true)
                    _spriteBatch.Draw(Food.Texture, new Vector2(Food.SpriteRectangle.X, Food.SpriteRectangle.Y), Color.White);
                if (DrawIconFish == true)
                    _spriteBatch.Draw(Fish.Texture, new Vector2(Fish.SpriteRectangle.X, Fish.SpriteRectangle.Y), Color.White);
                if (DrawIconStone == true)
                    _spriteBatch.Draw(Stone.Texture, new Vector2(Stone.SpriteRectangle.X, Stone.SpriteRectangle.Y), Color.White);
                if (DrawIconWood == true)
                    _spriteBatch.Draw(Wood.Texture, new Vector2(Wood.SpriteRectangle.X, Wood.SpriteRectangle.Y), Color.White);

            }
            else
                _spriteBatch.Draw(Background.Texture, new Vector2(Background.SpriteRectangle.X, Background.SpriteRectangle.Y), Color.Black);

            if(GlobalStatus == EnumGlobalStatus.RESOURSE_MENU)
            {
               
                _spriteBatch.Draw(Decline.Texture, new Vector2(Decline.SpriteRectangle.X, Decline.SpriteRectangle.Y), Color.White);

                if (ButtonSelected == true)
                    _spriteBatch.Draw(Selection2.Texture, new Vector2(Selection2.SpriteRectangle.X, Selection2.SpriteRectangle.Y), Color.White);
                for (int i = 0; i < Resourse.Count; i++)
                {
                    _spriteBatch.Draw(Resourse[i].Texture, new Vector2(Resourse[i].SpriteRectangle.X, Resourse[i].SpriteRectangle.Y), Color.White);
                    _spriteBatch.DrawString(Font, Resourse[i].ResourseType.count.ToString(), new Vector2(Resourse[i].SpriteRectangle.X + 140, Resourse[i].SpriteRectangle.Y), Color.White);
                }
            }

            if(GlobalStatus == EnumGlobalStatus.RESOURSE_MENU_SELECT)
            {
                _spriteBatch.Draw(Resourse[SelectedItemID].Texture, new Vector2(220,270), Color.White);
                _spriteBatch.Draw(Resourse[7].Texture, new Vector2(220, 480), Color.White);
                _spriteBatch.Draw(Decline.Texture, new Vector2(Decline.SpriteRectangle.X, Decline.SpriteRectangle.Y), Color.White);
                _spriteBatch.Draw(Confirm.Texture, new Vector2(Confirm.SpriteRectangle.X, Confirm.SpriteRectangle.Y), Color.White);
                _spriteBatch.Draw(ArrowUp.Texture, new Vector2(ArrowUp.SpriteRectangle.X, ArrowUp.SpriteRectangle.Y), Color.White);
                _spriteBatch.Draw(ArrowDown.Texture, new Vector2(ArrowDown.SpriteRectangle.X, ArrowDown.SpriteRectangle.Y), Color.White);

                _spriteBatch.DrawString(UnsafeRes, IntUnsafeRes.ToString(), new Vector2(320,270), Color.White);
                _spriteBatch.DrawString(UnsafeGold, IntUnsafeGold.ToString(), new Vector2(320,480), Color.White);
            }

            if(GlobalStatus == EnumGlobalStatus.BUILDING_MENU)
            {
                _spriteBatch.Draw(Decline.Texture, new Vector2(Decline.SpriteRectangle.X, Decline.SpriteRectangle.Y), Color.White);

                if (ButtonSelected == true)
                    _spriteBatch.Draw(Selection2.Texture, new Vector2(Selection2.SpriteRectangle.X, Selection2.SpriteRectangle.Y), Color.White);
                for (int i = 0; i < Building.Count; i++)
                {
                    _spriteBatch.Draw(Building[i].Icon[0], new Vector2(Building[i].IconRectangle.X, Building[i].IconRectangle.Y), Color.White);
                    
                }
            }

            if(GlobalStatus== EnumGlobalStatus.BUILDING_MENU_SELECT)
            {
                _spriteBatch.Draw(Decline.Texture, new Vector2(Decline.SpriteRectangle.X, Decline.SpriteRectangle.Y), Color.White);
                _spriteBatch.Draw(Confirm.Texture, new Vector2(Confirm.SpriteRectangle.X, Confirm.SpriteRectangle.Y), Color.White);

                if(Building[SelectedBuildingID].BuildingType.currentLevel == 0 && Building[SelectedBuildingID].BuildingType.isPlaced == false)
                {
                    _spriteBatch.Draw(Selection2.Texture, new Vector2(195,195), Color.White);
                    _spriteBatch.Draw(Building[SelectedBuildingID].Icon[1], new Vector2(200, 200), Color.White);
                    _spriteBatch.Draw(Building[SelectedBuildingID].Icon[1], new Vector2(300, 200), Color.White);
                    _spriteBatch.Draw(Building[SelectedBuildingID].Icon[1], new Vector2(400, 200), Color.White);
                }
                else if (Building[SelectedBuildingID].BuildingType.currentLevel == 0)
                {
                    _spriteBatch.Draw(Selection2.Texture, new Vector2(295, 195), Color.White);
                    _spriteBatch.Draw(Building[SelectedBuildingID].Icon[0], new Vector2(200, 200), Color.White);
                    _spriteBatch.Draw(Building[SelectedBuildingID].Icon[1], new Vector2(300, 200), Color.White);
                    _spriteBatch.Draw(Building[SelectedBuildingID].Icon[1], new Vector2(400, 200), Color.White);
                }
                else if (Building[SelectedBuildingID].BuildingType.currentLevel == 1)
                {
                    _spriteBatch.Draw(Selection2.Texture, new Vector2(395, 195), Color.White);
                    _spriteBatch.Draw(Building[SelectedBuildingID].Icon[0], new Vector2(200, 200), Color.White);
                    _spriteBatch.Draw(Building[SelectedBuildingID].Icon[0], new Vector2(300, 200), Color.White);
                    _spriteBatch.Draw(Building[SelectedBuildingID].Icon[1], new Vector2(400, 200), Color.White);
                }
                else if (Building[SelectedBuildingID].BuildingType.currentLevel == 2)
                {
                    _spriteBatch.Draw(Building[SelectedBuildingID].Icon[0], new Vector2(200, 200), Color.White);
                    _spriteBatch.Draw(Building[SelectedBuildingID].Icon[0], new Vector2(300, 200), Color.White);
                    _spriteBatch.Draw(Building[SelectedBuildingID].Icon[0], new Vector2(400, 200), Color.White);

                    _spriteBatch.DrawString(Font, "Maxed out!", new Vector2(160, 320), Color.White);
                }

                if (Building[SelectedBuildingID].BuildingType.currentLevel != 2)
                {
                    for (int i = 0; i < Building[SelectedBuildingID].BuildingType.BuildingPrice[Building[SelectedBuildingID].BuildingType.currentLevel].Count; i++)
                    {
                        _spriteBatch.Draw(Resourse[(int)Building[SelectedBuildingID].BuildingType.BuildingPrice[Building[SelectedBuildingID].BuildingType.currentLevel].ElementAt(i).Key].Texture, new Vector2(200, 300 + i * 100), Color.White);

                        _spriteBatch.DrawString(Font, $"{Resourse[(int)Building[SelectedBuildingID].BuildingType.BuildingPrice[Building[SelectedBuildingID].BuildingType.currentLevel].ElementAt(i).Key].ResourseType.count}" +
                            $"/{Building[SelectedBuildingID].BuildingType.BuildingPrice[Building[SelectedBuildingID].BuildingType.currentLevel].ElementAt(i).Value}  ", new Vector2(320, 300 + i * 100),
                            Resourse[(int)Building[SelectedBuildingID].BuildingType.BuildingPrice[Building[SelectedBuildingID].BuildingType.currentLevel].ElementAt(i).Key].ResourseType.count >= Building[SelectedBuildingID].BuildingType.BuildingPrice[Building[SelectedBuildingID].BuildingType.currentLevel].ElementAt(i).Value ? Color.Green : Color.Red);

                    }
                }
            }

            if(GlobalStatus == EnumGlobalStatus.VILLAGER_JOB_MENU)
            {
                _spriteBatch.Draw(Decline.Texture, new Vector2(Decline.SpriteRectangle.X, Decline.SpriteRectangle.Y), Color.White);

                if (ButtonSelected == true)
                {
                    _spriteBatch.Draw(Selection2.Texture, new Vector2(Selection2.SpriteRectangle.X, Selection2.SpriteRectangle.Y), Color.White);
                }

                if(ButtonPressed == true)
                {
                    _spriteBatch.Draw(ArrowUp.Texture, new Vector2(ArrowUp.SpriteRectangle.X, ArrowUp.SpriteRectangle.Y), Color.White);
                    _spriteBatch.Draw(ArrowDown.Texture, new Vector2(ArrowDown.SpriteRectangle.X, ArrowDown.SpriteRectangle.Y), Color.White);
                }

                for (int i = 0; i < Building.Count; i++)
                {
                    _spriteBatch.Draw(Building[i].BuildingType.isPlaced == true?Building[i].Icon[0]: Building[i].Icon[1], new Vector2(Building[i].IconRectangle.X, Building[i].IconRectangle.Y), Color.White);
                    _spriteBatch.DrawString(SmallFont, $"{Building[i].BuildingType.currentVillagers}/{Building[i].BuildingType.maxVillagers[Building[i].BuildingType.currentLevel]}", new Vector2(Building[i].IconRectangle.X, Building[i].IconRectangle.Y+90), Building[i].BuildingType.isPlaced == true ? Color.White : Color.Black);
                }
            }



            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
