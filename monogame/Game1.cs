using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using monogame.gameAssets;
using System.Diagnostics;
using System;

namespace monogame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch spriteBatch;

        private Texture2D background;
        private Texture2D shuttle;
        private Texture2D earth;
        private Texture2D outrunCar;
        private bool FULLSCREEN;
        private bool RES_1080;

        private Scene scene;
        private Camera_2D camera;
        private gameObjects.gameObject object1;
        private gameObjects.gameObject object2;

        public static int screenHeight;
        public static int screenWidth;

        public Game1()
        {
            FULLSCREEN = true;
            RES_1080 = true;
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
           
        }

        protected override void Initialize()
        {
            if (FULLSCREEN)
            {
                Debug.WriteLine("display mode h : " + GraphicsDevice.DisplayMode.Height);
                Debug.WriteLine("display mode w : " + GraphicsDevice.DisplayMode.Width);

                Game1.screenHeight = GraphicsDevice.DisplayMode.Height;
                Game1.screenWidth = GraphicsDevice.DisplayMode.Width;

                // Force a 16:9 aspect ratio
                //if (Game1.screenHeight * 16.0 > Game1.screenWidth * 9.0 ) {
                //    // trim vertical
                //    Debug.WriteLine("Trim Vert");

                //  Game1.screenHeight = (int)Math.Round( Game1.screenWidth * (9.0 / 16.0));
                //}
                //else if (Game1.screenHeight * 16.0 < Game1.screenWidth * 9.0) {
                //    //trim horiz
                //    Debug.WriteLine("Trim Horiz");
                //    Game1.screenWidth = (int) Math.Round( Game1.screenHeight * ( 16.0 / 9.0 ));
                //}


                _graphics.IsFullScreen = true;
            }
            // windowed mode
            else if (RES_1080)
            {
                Game1.screenHeight = 1080;
                Game1.screenWidth = 1920;
            }
            else 
            {
                Game1.screenHeight = 720;
                Game1.screenWidth = 1280;
            }

            Debug.WriteLine("G1 ScreenWidth : " + Game1.screenWidth);
            Debug.WriteLine("G1 ScreenHeight :" + Game1.screenHeight);

            _graphics.PreferredBackBufferHeight = Game1.screenHeight;
            _graphics.PreferredBackBufferWidth = Game1.screenWidth;

            _graphics.ApplyChanges();

            // Add Scene and Camera
            scene = new Scene(244, 950);
            camera = new Camera_2D(ref _graphics, ref scene);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // load your game content here
            Texture2D staticBG = Content.Load<Texture2D>("sky");
            Texture2D mainBG = Content.Load<Texture2D>("Full-Field");
            background = Content.Load<Texture2D>("test_bg"); // change these names to the names of your images
            shuttle = Content.Load<Texture2D>("shuttle");  // if you are using your own images.
            earth = Content.Load<Texture2D>("earth");
            outrunCar = Content.Load<Texture2D>("outrun");

            object1 = new gameObjects.gameObject(122, 475, 993, 773, outrunCar);
            object2 = new gameObjects.PlayerGameObject(122, 475, 993, 773, outrunCar);

            scene.setStaticBackground(staticBG);
            scene.setMainBackground(mainBG);
            //scene.objects.Add(object1);
            scene.objects.Add(object2);
            camera.moveCamera(0, -50);
            //scene.setMainBackground(background);

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


                // TODO: Add your update logic here

         // This is basically just debug for the camera atm
        KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Right))
                    camera.moveCamera(10,0);
            if (state.IsKeyDown(Keys.Left))
                camera.moveCamera(-10, 0);
            if (state.IsKeyDown(Keys.Up))
                camera.moveCamera(0,10);
            if (state.IsKeyDown(Keys.Down))
                camera.moveCamera(0,-10);

            if (state.IsKeyDown(Keys.OemComma))
                camera.changeZoom(10);
            if (state.IsKeyDown(Keys.OemPeriod))
                camera.changeZoom(-10);



            if (state.IsKeyDown(Keys.W))
                object2.Move(0,10);
            if (state.IsKeyDown(Keys.S))
                object2.Move(0, -10);
            if (state.IsKeyDown(Keys.A))
                object2.Move(-10, 0);
            if (state.IsKeyDown(Keys.D))
                object2.Move(10, 0);


            foreach (gameObjects.gameObject obj in scene.objects) {
                obj.Update();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {

            

            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            camera.Draw(ref spriteBatch);
            
              //  spriteBatch.Draw(background, new Rectangle(0, 0, _graphics.PreferredBackBufferWidth * 2, _graphics.PreferredBackBufferHeight * 2), Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
