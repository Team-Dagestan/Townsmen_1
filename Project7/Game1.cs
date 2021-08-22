using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using DLL_Townsmen;
using System.Collections.Generic;
using System.Linq;

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

    public class SpriteVillager
    {
        public Rectangle SpriteRectangle;
        public int AnimationFrame;
        public Texture2D[] Texture;
        public string[] TexturePath;
        public Villager VillagerType;
        public Point DestinationPoint;

        public SpriteVillager(Villager villagerType, Rectangle spriteRectangle, int animationFrame, Texture2D[] texture, string[] texturePath)
        {
            VillagerType = villagerType;
            SpriteRectangle = spriteRectangle;
            AnimationFrame = animationFrame;
            Texture = texture;
            TexturePath = texturePath;
        }
    }
    
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        int GlobalStatus = 0;
        bool ButtonSelected = false;

        List<SpriteResourse> Resourse = new List<SpriteResourse>();
       
        List<SpriteBuilding> Building = new List<SpriteBuilding>();

        List<SpriteVillager> Villager = new List<SpriteVillager>();
        
        Texture2D wf;
        Texture2D wf1;
        Texture2D wf2;

        Sprite ResourseMenu;
        Sprite WorkMenu;
        Sprite BuildMenu;
        Sprite Background;
        Sprite Selection;
        Sprite Selection2;

        Sprite Yes;
        Sprite No;

        Sprite Up;
        Sprite Down;

        SpriteFont font;
        SpriteFont fontS;

        SpriteFont UnsafeRes;
        SpriteFont UnsafeGold;

       
        int IntUnsafeRes;
        int IntUnsafeGold;

        bool ButtonPressed = false;
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

            font = Content.Load<SpriteFont>("Font/DefaultFont");
            fontS = Content.Load<SpriteFont>("Font/smol");
            UnsafeRes = Content.Load<SpriteFont>("Font/DefaultFont");
            UnsafeGold = Content.Load<SpriteFont>("Font/DefaultFont");

            

            Up = new Sprite(new Rectangle(350, 370, 28, 32), null, "Textures/34");
            Down = new Sprite(new Rectangle(350, 420, 28, 32), null, "Textures/35");
            Yes = new Sprite(new Rectangle(0, 788, 52, 44), null, "Textures/32");
            No = new Sprite(new Rectangle(652, 780, 52, 52), null, "Textures/33");
            Selection = new Sprite(new Rectangle(0,0,110,110), null, "Textures/selection");
            Selection2 = new Sprite(new Rectangle(0, 0, 90, 90), null, "Textures/selection2");
            BuildMenu = new Sprite(new Rectangle(155, 727, 100, 100), null, "Textures/build");
            WorkMenu = new Sprite(new Rectangle(305, 727, 100, 100), null, "Textures/work");
            ResourseMenu = new Sprite(new Rectangle(455, 727, 100, 100),null, "Textures/res");
            Background = new Sprite(new Rectangle(0, 0, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight), null, "Textures/27");

            wf1 = Content.Load<Texture2D>("Textures/Animations/46.1");
            wf2 = Content.Load<Texture2D>("Textures/Animations/46.2");
           

            Up.Texture = Content.Load<Texture2D>(Up.TexturePath);
            Down.Texture = Content.Load<Texture2D>(Down.TexturePath);
            Yes.Texture = Content.Load<Texture2D>(Yes.TexturePath);
            No.Texture = Content.Load<Texture2D>(No.TexturePath);
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

            Villager.Add(new SpriteVillager(new Villager(false, BuildingType.TOWNHALL), new Rectangle(Building[7].SpriteRectangle.X+60, Building[7].SpriteRectangle.Y + 20, 32, 40), 0, testV, testT));
            Villager.Add(new SpriteVillager(new Villager(false, BuildingType.TOWNHALL), new Rectangle(Building[7].SpriteRectangle.X + 60, Building[7].SpriteRectangle.Y + 20, 32, 40), 0, testV, testT));
            Villager.Add(new SpriteVillager(new Villager(false, BuildingType.TOWNHALL), new Rectangle(Building[7].SpriteRectangle.X + 60, Building[7].SpriteRectangle.Y + 20, 32, 40), 0, testV, testT));
            Villager.Add(new SpriteVillager(new Villager(false, BuildingType.COLLECTORHOUSE), new Rectangle(Building[0].SpriteRectangle.X + 60, Building[0].SpriteRectangle.Y + 20, 32, 40), 0, testV, testT));
           


            for (int i = 0; i < Villager.Count; i++)
            {
                for (int j = 0; j < testV.Length; j++)
                {
                    Villager[i].Texture[j] = Content.Load<Texture2D>(Villager[i].TexturePath[j]);
                }
                Villager[i].DestinationPoint.X = Villager[i].SpriteRectangle.X;
                Villager[i].DestinationPoint.Y = Villager[i].SpriteRectangle.Y;
            }

            
           
        }

        Texture2D[] testV = new Texture2D[] { null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null};
        string[] testT = new string[] { "Textures/Animations/1", "Textures/Animations/2", "Textures/Animations/3", "Textures/Animations/4", "Textures/Animations/5",
        "Textures/Animations/6","Textures/Animations/7","Textures/Animations/8","Textures/Animations/9","Textures/Animations/10","Textures/Animations/11","Textures/Animations/12",
        "Textures/Animations/13","Textures/Animations/14","Textures/Animations/15","Textures/Animations/16","Textures/Animations/44","Textures/Animations/47","Textures/Animations/49.1","Textures/Animations/49.2"};

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

        public void GetVillagerFrameList(int n)
        {
            if (Villager[n].DestinationPoint.X > Villager[n].SpriteRectangle.X)
                FrameList[n] = new int[] { 0, 1, 2, 3 };
            else
                FrameList[n] = new int[] { 4, 5, 6, 7 };

            if (Villager[n].DestinationPoint.Y < Villager[n].SpriteRectangle.Y)
                FrameList[n] = new int[] {FrameList.ElementAt(n)[0] + 8, FrameList.ElementAt(n)[1] + 8, FrameList.ElementAt(n)[2] + 8, FrameList.ElementAt(n)[3] + 8 };
            
         
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
                            Villager[n].SpriteRectangle.X -= VillagerStep;
                        else
                            Villager[n].SpriteRectangle.X += VillagerStep;
                    }


                    if (Villager[n].SpriteRectangle.Y != Villager[n].DestinationPoint.Y)
                    {
                        if (Villager[n].SpriteRectangle.Y > Villager[n].DestinationPoint.Y)
                            Villager[n].SpriteRectangle.Y -= VillagerStep;
                        else
                            Villager[n].SpriteRectangle.Y += VillagerStep;
                    }

                    Villager[n].AnimationFrame = FrameList.ElementAt(n)[tessst[n]];
                    if (tessst[n] == 3)
                        tessst[n] = 0;
                    else
                        tessst[n]++;
                }
                else
                {
                    Villager[n].VillagerType.IsVisible = false;
                }
            }
        }
        List<int> tessst = new List<int>() { 0, 0, 0, 0 };
        int VillagerStep = 5;

        List<int[]> FrameList = new List<int[]>
        {
            new int[] { 1, 2, 3, 4 },
            new int[] { 1, 2, 3, 4 },
            new int[] { 1, 2, 3, 4 },
            new int[] { 1, 2, 3, 4 },
            new int[] { 1, 2, 3, 4 },
            new int[] { 1, 2, 3, 4 },
            new int[] { 1, 2, 3, 4 }
        };
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            for (int i = 0; i < Villager.Count; i++)
            {
               Walk(gameTime,i);
            }

            VillagersChangeBuilding();

            Cheats();

            ButtonSelected = false;
         
            if (GlobalStatus == 0)
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

            if(GlobalStatus==3)
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

                if (No.SpriteRectangle.Contains(Mouse.GetState().Position))
                {
                    if (Mouse.GetState().LeftButton == ButtonState.Pressed && ButtonPressed == false)
                        NoButtonClick();
                }
            }

            if(GlobalStatus == 30)
            {
                Up.SpriteRectangle = new Rectangle(350, 390, 28, 32);
                Down.SpriteRectangle = new Rectangle(350, 440, 28, 32);

                if (Mouse.GetState().LeftButton == ButtonState.Released)
                    ButtonPressed = false;

                if (No.SpriteRectangle.Contains(Mouse.GetState().Position) )
                {
                    if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                    {
                        ButtonPressed = true;
                        NoButtonClick();
                    }
                }
                if (Yes.SpriteRectangle.Contains(Mouse.GetState().Position))
                {
                    if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                        YesButtonClick();
                }
                if (Up.SpriteRectangle.Contains(Mouse.GetState().Position) && ButtonPressed == false)
                {
                    if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                    {
                        ButtonPressed = true;
                        UpButtonClick(SelectedItemID);
                    }
                }
                if (Down.SpriteRectangle.Contains(Mouse.GetState().Position) && ButtonPressed == false)
                {
                    if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                    {
                        ButtonPressed = true;
                        DownButtonClick(SelectedItemID);
                    }
                }
            }

            if(GlobalStatus==1)
            {
                if (Mouse.GetState().LeftButton == ButtonState.Released)
                    ButtonPressed = false;

                if (No.SpriteRectangle.Contains(Mouse.GetState().Position))
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

            if(GlobalStatus == 10)
            {
                if (Mouse.GetState().LeftButton == ButtonState.Released)
                    ButtonPressed = false;

                Up.SpriteRectangle = new Rectangle(350, 390, 28, 32);
                Down.SpriteRectangle = new Rectangle(350, 440, 28, 32);

                if (No.SpriteRectangle.Contains(Mouse.GetState().Position))
                {
                    if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                    {
                        ButtonPressed = true;
                        NoButtonClick();
                    }
                }
                if (Yes.SpriteRectangle.Contains(Mouse.GetState().Position))
                {
                    if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                        YesButtonClick();
                }
            }

            if (GlobalStatus == 2)
            {
                if (Mouse.GetState().LeftButton == ButtonState.Released)
                    ButtonPressed2 = false;

                if (No.SpriteRectangle.Contains(Mouse.GetState().Position))
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
                            Up.SpriteRectangle = new Rectangle(Building[i].IconRectangle.X - 40, Building[i].IconRectangle.Y, 28, 32);
                            Down.SpriteRectangle = new Rectangle(Building[i].IconRectangle.X - 40, Building[i].IconRectangle.Y +50, 28, 32);
                            ButtonPressed = true;
                        }
                    }
                }

                if (Up.SpriteRectangle.Contains(Mouse.GetState().Position) && ButtonPressed2 == false )
                {
                    if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                    {
                        ButtonPressed2 = true;
                        UpButtonClick(SelectedBuildingID);
                    }
                }
                if (Down.SpriteRectangle.Contains(Mouse.GetState().Position) && ButtonPressed2 == false)
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
        bool ButtonPressed2 = false;
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
            GlobalStatus = 10;
            ButtonSelected = false;
        }
      
        private void UpButtonClick(int test2)/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        {
            if (GlobalStatus == 30)
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
                            Villager[i].DestinationPoint = new Point(Building[test2].SpriteRectangle.X+20,Building[test2].SpriteRectangle.Y + 20);
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
            if (GlobalStatus == 30)
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
                            Villager[i].DestinationPoint = new Point(Building[7].SpriteRectangle.X + 20, Building[7].SpriteRectangle.Y + 20);
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
            if (GlobalStatus == 30)
            {
                Resourse[7].ResourseType.count = IntUnsafeGold;
                Resourse[SelectedItemID].ResourseType.count = IntUnsafeRes;
                GlobalStatus = 3;
            }
            else if(GlobalStatus ==10)
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

                    GlobalStatus = 1;
                }

                
            }
            ButtonSelected = false;
        }
        private void NoButtonClick()
        {
            if (GlobalStatus == 30)
                GlobalStatus = 3;
            else if (GlobalStatus == 3)
                GlobalStatus = 0;
            else if (GlobalStatus == 10)
                GlobalStatus = 1;
            else if (GlobalStatus == 1)
                GlobalStatus = 0;
            else if (GlobalStatus == 2)
            {
                GlobalStatus = 0;
                ButtonPressed = false;
            }

            ButtonSelected = false;
        }
        private void BuildMenuClick()
        {
            GlobalStatus = 1;
            ButtonSelected = false;
        }
        private void WorkMenuClick()
        {
            GlobalStatus = 2;
            ButtonSelected = false;
        }
        private void ResourseMenuClick()
        {
            GlobalStatus = 3;
            ButtonSelected = false;
        }
        int SelectedItemID = 0;
        int SelectedBuildingID = 0;
        private void ResourseClick()
        {
            IntUnsafeRes= Resourse[SelectedItemID].ResourseType.count;
            IntUnsafeGold = Resourse[7].ResourseType.count;

            GlobalStatus = 30;
            ButtonSelected = false;
        }
        private void DayCounter(GameTime gameTime)
        {
            if (gameTime.TotalGameTime.Seconds % 15 == 0 && gameTime.TotalGameTime.Milliseconds==0)
                CurrentDay++;
        }
        private void WaterfallAnimation(GameTime gameTime)
        {
            if (gameTime.TotalGameTime.Milliseconds % 500 == 0)
                if (wf == wf1)
                    wf = wf2;
                else
                    wf = wf1;
        }

        int CurrentDay = 0;
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            _spriteBatch.Begin();


            _spriteBatch.Draw(Background.Texture, new Vector2(Background.SpriteRectangle.X, Background.SpriteRectangle.Y), Color.White);


            if (ButtonSelected == true)
                _spriteBatch.Draw(Selection.Texture, new Vector2(Selection.SpriteRectangle.X, Selection.SpriteRectangle.Y), Color.White);

            if (GlobalStatus == 0)
            {
                _spriteBatch.Draw(wf,new Vector2(436,240),Color.White);
               
                _spriteBatch.Draw(BuildMenu.Texture, new Vector2(BuildMenu.SpriteRectangle.X, BuildMenu.SpriteRectangle.Y), Color.White);
                _spriteBatch.Draw(WorkMenu.Texture, new Vector2(WorkMenu.SpriteRectangle.X, WorkMenu.SpriteRectangle.Y), Color.White);
                _spriteBatch.Draw(ResourseMenu.Texture, new Vector2(ResourseMenu.SpriteRectangle.X, ResourseMenu.SpriteRectangle.Y), Color.White);

                _spriteBatch.DrawString(font, $"Day  {CurrentDay}", new Vector2(3, 3), Color.Black);
                _spriteBatch.DrawString(font, $"Day  {CurrentDay}", Vector2.Zero, Color.White);

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
                
            }
            else
                _spriteBatch.Draw(Background.Texture, new Vector2(Background.SpriteRectangle.X, Background.SpriteRectangle.Y), Color.Black);

            if(GlobalStatus == 3)
            {
               
                _spriteBatch.Draw(No.Texture, new Vector2(No.SpriteRectangle.X, No.SpriteRectangle.Y), Color.White);

                if (ButtonSelected == true)
                    _spriteBatch.Draw(Selection2.Texture, new Vector2(Selection2.SpriteRectangle.X, Selection2.SpriteRectangle.Y), Color.White);
                for (int i = 0; i < Resourse.Count; i++)
                {
                    _spriteBatch.Draw(Resourse[i].Texture, new Vector2(Resourse[i].SpriteRectangle.X, Resourse[i].SpriteRectangle.Y), Color.White);
                    _spriteBatch.DrawString(font, Resourse[i].ResourseType.count.ToString(), new Vector2(Resourse[i].SpriteRectangle.X + 140, Resourse[i].SpriteRectangle.Y), Color.White);
                }
            }

            if(GlobalStatus == 30)
            {
                _spriteBatch.Draw(Resourse[SelectedItemID].Texture, new Vector2(220,270), Color.White);
                _spriteBatch.Draw(Resourse[7].Texture, new Vector2(220, 480), Color.White);
                _spriteBatch.Draw(No.Texture, new Vector2(No.SpriteRectangle.X, No.SpriteRectangle.Y), Color.White);
                _spriteBatch.Draw(Yes.Texture, new Vector2(Yes.SpriteRectangle.X, Yes.SpriteRectangle.Y), Color.White);
                _spriteBatch.Draw(Up.Texture, new Vector2(Up.SpriteRectangle.X, Up.SpriteRectangle.Y), Color.White);
                _spriteBatch.Draw(Down.Texture, new Vector2(Down.SpriteRectangle.X, Down.SpriteRectangle.Y), Color.White);

                _spriteBatch.DrawString(UnsafeRes, IntUnsafeRes.ToString(), new Vector2(320,270), Color.White);
                _spriteBatch.DrawString(UnsafeGold, IntUnsafeGold.ToString(), new Vector2(320,480), Color.White);
            }

            if(GlobalStatus == 1)
            {
                _spriteBatch.Draw(No.Texture, new Vector2(No.SpriteRectangle.X, No.SpriteRectangle.Y), Color.White);

                if (ButtonSelected == true)
                    _spriteBatch.Draw(Selection2.Texture, new Vector2(Selection2.SpriteRectangle.X, Selection2.SpriteRectangle.Y), Color.White);
                for (int i = 0; i < Building.Count; i++)
                {
                    _spriteBatch.Draw(Building[i].Icon[0], new Vector2(Building[i].IconRectangle.X, Building[i].IconRectangle.Y), Color.White);
                    
                }
            }

            if(GlobalStatus==10)
            {
                _spriteBatch.Draw(No.Texture, new Vector2(No.SpriteRectangle.X, No.SpriteRectangle.Y), Color.White);
                _spriteBatch.Draw(Yes.Texture, new Vector2(Yes.SpriteRectangle.X, Yes.SpriteRectangle.Y), Color.White);

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

                    _spriteBatch.DrawString(font, "Maxed out!", new Vector2(160, 320), Color.White);
                }

                if (Building[SelectedBuildingID].BuildingType.currentLevel != 2)
                {
                    for (int i = 0; i < Building[SelectedBuildingID].BuildingType.BuildingPrice[Building[SelectedBuildingID].BuildingType.currentLevel].Count; i++)
                    {
                        _spriteBatch.Draw(Resourse[(int)Building[SelectedBuildingID].BuildingType.BuildingPrice[Building[SelectedBuildingID].BuildingType.currentLevel].ElementAt(i).Key].Texture, new Vector2(200, 300 + i * 100), Color.White);

                        _spriteBatch.DrawString(font, $"{Resourse[(int)Building[SelectedBuildingID].BuildingType.BuildingPrice[Building[SelectedBuildingID].BuildingType.currentLevel].ElementAt(i).Key].ResourseType.count}" +
                            $"/{Building[SelectedBuildingID].BuildingType.BuildingPrice[Building[SelectedBuildingID].BuildingType.currentLevel].ElementAt(i).Value}  ", new Vector2(320, 300 + i * 100),
                            Resourse[(int)Building[SelectedBuildingID].BuildingType.BuildingPrice[Building[SelectedBuildingID].BuildingType.currentLevel].ElementAt(i).Key].ResourseType.count >= Building[SelectedBuildingID].BuildingType.BuildingPrice[Building[SelectedBuildingID].BuildingType.currentLevel].ElementAt(i).Value ? Color.Green : Color.Red);

                    }
                }
            }

            if(GlobalStatus == 2)
            {
                _spriteBatch.Draw(No.Texture, new Vector2(No.SpriteRectangle.X, No.SpriteRectangle.Y), Color.White);

                if (ButtonSelected == true)
                {
                    _spriteBatch.Draw(Selection2.Texture, new Vector2(Selection2.SpriteRectangle.X, Selection2.SpriteRectangle.Y), Color.White);
                }

                if(ButtonPressed == true)
                {
                    _spriteBatch.Draw(Up.Texture, new Vector2(Up.SpriteRectangle.X, Up.SpriteRectangle.Y), Color.White);
                    _spriteBatch.Draw(Down.Texture, new Vector2(Down.SpriteRectangle.X, Down.SpriteRectangle.Y), Color.White);
                }

                for (int i = 0; i < Building.Count; i++)
                {
                    _spriteBatch.Draw(Building[i].BuildingType.isPlaced == true?Building[i].Icon[0]: Building[i].Icon[1], new Vector2(Building[i].IconRectangle.X, Building[i].IconRectangle.Y), Color.White);
                    _spriteBatch.DrawString(fontS, $"{Building[i].BuildingType.currentVillagers}/{Building[i].BuildingType.maxVillagers[Building[i].BuildingType.currentLevel]}", new Vector2(Building[i].IconRectangle.X, Building[i].IconRectangle.Y+90), Building[i].BuildingType.isPlaced == true ? Color.White : Color.Black);
                }
            }


            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
