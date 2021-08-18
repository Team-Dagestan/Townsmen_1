using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using DLL_Townsmen;


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

    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        int GlobalStatus = 0;
        Rectangle rectangle;
        Texture2D background;

        Texture2D wf;
        Texture2D wf1;
        Texture2D wf2;

        Sprite ResourseMenu;
        Sprite WorkMenu;
        Sprite BuildMenu;
        Sprite Background;

        Texture2D tx;
        Texture2D col;
        SpriteFont font;
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
           
            rectangle = new Rectangle(0, 0, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
            
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            font = Content.Load<SpriteFont>("Font/DefaultFont");

            BuildMenu = new Sprite(new Rectangle(0, 732, 100, 100), null, "Textures/build");
            WorkMenu = new Sprite(new Rectangle(150, 732, 100, 100), null, "Textures/work");
            ResourseMenu = new Sprite(new Rectangle(300, 732, 100, 100),null, "Textures/res");
            Background = new Sprite(new Rectangle(0, 0, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight), null, "Textures/27");

            wf1 = Content.Load<Texture2D>("Textures/Animations/46.1");
            wf2 = Content.Load<Texture2D>("Textures/Animations/46.2");
            tx = Content.Load<Texture2D>("Textures/18");
            col = Content.Load<Texture2D>("Textures/12");

            Background.Texture = Content.Load<Texture2D>(Background.TexturePath);
            BuildMenu.Texture = Content.Load<Texture2D>(BuildMenu.TexturePath);
            WorkMenu.Texture = Content.Load<Texture2D>(WorkMenu.TexturePath);
            ResourseMenu.Texture = Content.Load<Texture2D>(ResourseMenu.TexturePath);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            if (ResourseMenu.SpriteRectangle.Contains(Mouse.GetState().Position) && Mouse.GetState().LeftButton == ButtonState.Pressed)
                ResourseMenuClick();

            if (WorkMenu.SpriteRectangle.Contains(Mouse.GetState().Position) && Mouse.GetState().LeftButton == ButtonState.Pressed)
                WorkMenuClick();

            if (BuildMenu.SpriteRectangle.Contains(Mouse.GetState().Position) && Mouse.GetState().LeftButton == ButtonState.Pressed)
                BuildMenuClick();

            WaterfallAnimation(gameTime);
            DayCounter(gameTime);

            base.Update(gameTime);
        }

        private void BuildMenuClick()
        {
            GlobalStatus = 1;
        }
        private void WorkMenuClick()
        {
            GlobalStatus = 2;
        }
        private void ResourseMenuClick()
        {
            GlobalStatus = 3;
        }
        private void DayCounter(GameTime gameTime)
        {
            if (gameTime.TotalGameTime.Seconds % 30 == 0 && gameTime.TotalGameTime.Milliseconds==0)
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

            if (GlobalStatus == 0)
            {
                _spriteBatch.Draw(Background.Texture, new Vector2(Background.SpriteRectangle.X, Background.SpriteRectangle.Y), Color.White);
                _spriteBatch.Draw(wf,new Vector2(436,240),Color.White);
                _spriteBatch.Draw(tx, new Vector2(280, 510), Color.White);
                _spriteBatch.Draw(col, new Vector2(335, 450), Color.White);


                _spriteBatch.Draw(BuildMenu.Texture, new Vector2(BuildMenu.SpriteRectangle.X, BuildMenu.SpriteRectangle.Y), Color.White);
                _spriteBatch.Draw(WorkMenu.Texture, new Vector2(WorkMenu.SpriteRectangle.X, WorkMenu.SpriteRectangle.Y), Color.White);
                _spriteBatch.Draw(ResourseMenu.Texture, new Vector2(ResourseMenu.SpriteRectangle.X, ResourseMenu.SpriteRectangle.Y), Color.White);

                _spriteBatch.DrawString(font, $"Day  {CurrentDay}", new Vector2(3, 3), Color.Black);
                _spriteBatch.DrawString(font, $"Day  {CurrentDay}", Vector2.Zero, Color.White);
            }
            else
                _spriteBatch.Draw(Background.Texture, new Vector2(Background.SpriteRectangle.X, Background.SpriteRectangle.Y), Color.Black);






            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
