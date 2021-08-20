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
        public Rectangle SpriteRectangle;
        public Texture2D[] Texture;
        public Texture2D[] Icon;
        public string[] IconPath;
        public string[] TexturePath;

        public SpriteBuilding(Building buildingType, Rectangle spriteRectangle, Texture2D[] texture, Texture2D[] icon, string[] iconPath, string[] texturePath)
        {
            BuildingType = buildingType;
            SpriteRectangle = spriteRectangle;
            Texture = texture;
            Icon = icon;
            IconPath = iconPath;
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
        List<SpriteFont> ResourseAmount = new List<SpriteFont>();

        List<SpriteBuilding> Building = new List<SpriteBuilding>();
        
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

        SpriteFont UnsafeRes;
        SpriteFont UnsafeGold;

        //SpriteFont Green;
        //SpriteFont Red;

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

            //Green = Content.Load<SpriteFont>("Font/Green");
           // Red = Content.Load<SpriteFont>("Font/DefaultFont");
            font = Content.Load<SpriteFont>("Font/DefaultFont");
            UnsafeRes = Content.Load<SpriteFont>("Font/DefaultFont");
            UnsafeGold = Content.Load<SpriteFont>("Font/DefaultFont");
            for (int i = 0; i < ResourseAmount.Count; i++)
            {
                ResourseAmount[i] = Content.Load<SpriteFont>("Font/DefaultFont");
            }

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

            Building.Add(new SpriteBuilding(new Sawmill(),    new Rectangle(150, 200, 80, 80), null, new Texture2D[] { null, null }, new string[] { "Textures/saw", "Textures/sawB" }, new string[] { null, null, null }));
            Building.Add(new SpriteBuilding(new LumberJack(), new Rectangle(300, 200, 80, 80),null, new Texture2D[] { null, null },  new string[] { "Textures/lumberjack", "Textures/lumberjackB" }, new string[] { null, null, null }));
            Building.Add(new SpriteBuilding(new Forge(),      new Rectangle(450, 200, 80, 80), null, new Texture2D[] { null, null }, new string[] { "Textures/anvil", "Textures/anvilB" }, new string[] { null, null, null }));
            Building.Add(new SpriteBuilding(new Fisher(),     new Rectangle(150, 350, 80, 80), null, new Texture2D[] { null, null }, new string[] { "Textures/fish", "Textures/fishB" }, new string[] { null, null, null }));
            Building.Add(new SpriteBuilding(new Collector(),  new Rectangle(300, 350, 80, 80), null, new Texture2D[] { null, null }, new string[] { "Textures/bag", "Textures/bagB" }, new string[] { null, null, null }));
            Building.Add(new SpriteBuilding(new Kitchen(),    new Rectangle(450, 350, 80, 80), null, new Texture2D[] { null, null }, new string[] { "Textures/kitchen", "Textures/kitchenB" }, new string[] { null, null, null }));
            Building.Add(new SpriteBuilding(new Town(),       new Rectangle(150, 500, 80, 80), null, new Texture2D []{ null, null }, new string[] { "Textures/bed", "Textures/bedB" }, new string[] { null, null, null }));
            Building.Add(new SpriteBuilding(new Farmer(),     new Rectangle(300, 500, 80, 80), null, new Texture2D[] { null, null }, new string[] { "Textures/farm", "Textures/farmB" }, new string[] { null, null, null }));
            Building.Add(new SpriteBuilding(new Miner(),      new Rectangle(450, 500, 80, 80), null, new Texture2D[] { null, null }, new string[] { "Textures/mine", "Textures/mineB" }, new string[] { null, null, null }));

            for (int i = 0; i < Building.Count; i++)
            {
                Building[i].Icon[0] = Content.Load<Texture2D>(Building[i].IconPath[0]);
                Building[i].Icon[1] = Content.Load<Texture2D>(Building[i].IconPath[1]);
            }
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

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
                    if (Building[i].SpriteRectangle.Contains(Mouse.GetState().Position))
                    {
                        ButtonSelected = true;
                        Selection2.SpriteRectangle = new Rectangle(Building[i].SpriteRectangle.X - 5, Building[i].SpriteRectangle.Y - 5, 90, 90);
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

            WaterfallAnimation(gameTime);
            DayCounter(gameTime);

            base.Update(gameTime);
        }
        private void BuildingClick()
        {
            GlobalStatus = 10;
            ButtonSelected = false;
        }
        private void UpButtonClick(int test2)
        {
            if (IntUnsafeGold >= Resourse[SelectedItemID].ResourseType.price)
            {
                IntUnsafeRes++;
                IntUnsafeGold -= Resourse[SelectedItemID].ResourseType.price;
            }
        }
        private void DownButtonClick(int test2)
        {
            if (IntUnsafeRes >= 1)
            {
                IntUnsafeRes--;
                IntUnsafeGold += Resourse[SelectedItemID].ResourseType.price;
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
                    GlobalStatus = 1;
                    Building[SelectedBuildingID].BuildingType.currentLevel++;
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
                    _spriteBatch.Draw(Building[i].Icon[0], new Vector2(Building[i].SpriteRectangle.X, Building[i].SpriteRectangle.Y), Color.White);
                    
                }
            }

            if(GlobalStatus==10)
            {
                _spriteBatch.Draw(No.Texture, new Vector2(No.SpriteRectangle.X, No.SpriteRectangle.Y), Color.White);
                _spriteBatch.Draw(Yes.Texture, new Vector2(Yes.SpriteRectangle.X, Yes.SpriteRectangle.Y), Color.White);

                if(Building[SelectedBuildingID].BuildingType.currentLevel == 0)
                {
                    _spriteBatch.Draw(Selection2.Texture, new Vector2(195,195), Color.White);
                    _spriteBatch.Draw(Building[SelectedBuildingID].Icon[1], new Vector2(200, 200), Color.White);
                    _spriteBatch.Draw(Building[SelectedBuildingID].Icon[1], new Vector2(300, 200), Color.White);
                    _spriteBatch.Draw(Building[SelectedBuildingID].Icon[1], new Vector2(400, 200), Color.White);
                }
                else if (Building[SelectedBuildingID].BuildingType.currentLevel == 1)
                {
                    _spriteBatch.Draw(Selection2.Texture, new Vector2(295, 195), Color.White);
                    _spriteBatch.Draw(Building[SelectedBuildingID].Icon[0], new Vector2(200, 200), Color.White);
                    _spriteBatch.Draw(Building[SelectedBuildingID].Icon[1], new Vector2(300, 200), Color.White);
                    _spriteBatch.Draw(Building[SelectedBuildingID].Icon[1], new Vector2(400, 200), Color.White);
                }
                else if (Building[SelectedBuildingID].BuildingType.currentLevel == 2)
                {
                    _spriteBatch.Draw(Selection2.Texture, new Vector2(395, 195), Color.White);
                    _spriteBatch.Draw(Building[SelectedBuildingID].Icon[0], new Vector2(200, 200), Color.White);
                    _spriteBatch.Draw(Building[SelectedBuildingID].Icon[0], new Vector2(300, 200), Color.White);
                    _spriteBatch.Draw(Building[SelectedBuildingID].Icon[1], new Vector2(400, 200), Color.White);
                }

                for (int i = 0; i < Building[SelectedBuildingID].BuildingType.BuildingPrice[Building[SelectedBuildingID].BuildingType.currentLevel].Count; i++)
                {
                   _spriteBatch.Draw(Resourse[(int)Building[SelectedBuildingID].BuildingType.BuildingPrice[Building[SelectedBuildingID].BuildingType.currentLevel].ElementAt(i).Key].Texture , new Vector2(200 , 300 + i * 100), Color.White);

                    _spriteBatch.DrawString(font,$"{Resourse[(int)Building[SelectedBuildingID].BuildingType.BuildingPrice[Building[SelectedBuildingID].BuildingType.currentLevel].ElementAt(i).Key].ResourseType.count}" +
                        $"/{Building[SelectedBuildingID].BuildingType.BuildingPrice[Building[SelectedBuildingID].BuildingType.currentLevel].ElementAt(i).Value}  ", new Vector2(320, 300+i*100), 
                        Resourse[(int)Building[SelectedBuildingID].BuildingType.BuildingPrice[Building[SelectedBuildingID].BuildingType.currentLevel].ElementAt(i).Key].ResourseType.count >= Building[SelectedBuildingID].BuildingType.BuildingPrice[Building[SelectedBuildingID].BuildingType.currentLevel].ElementAt(i).Value ? Color.Green:Color.Red);

                }

            }


            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
