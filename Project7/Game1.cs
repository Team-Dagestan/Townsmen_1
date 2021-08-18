using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using DLL_Townsmen;


namespace Project7
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        
        Rectangle rectangle;
        Texture2D background;

        Texture2D wf;
        Texture2D wf1;
        Texture2D wf2;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here


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
            
            background = Content.Load<Texture2D>("Textures/27");
            wf1 = Content.Load<Texture2D>("Textures/Animations/46.1");
            wf2 = Content.Load<Texture2D>("Textures/Animations/46.2");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //if(rectangle.Contains(Mouse.GetState().Position) && Mouse.GetState().LeftButton == ButtonState.Pressed)
            //    Exit();

            if (background.Bounds.Contains(Mouse.GetState().Position) && Mouse.GetState().LeftButton == ButtonState.Pressed)
                Exit();
            
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
                Exit();
            // TODO: Add your update logic her

            if (gameTime.TotalGameTime.Milliseconds % 500 == 0)
                if(wf==wf1)
                wf = wf2;
            else
                wf = wf1;

            base.Update(gameTime);
        }

        
       
        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            _spriteBatch.Begin();
            _spriteBatch.Draw(background, rectangle, Color.White);
            _spriteBatch.Draw(wf,new Vector2(436,240),Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
