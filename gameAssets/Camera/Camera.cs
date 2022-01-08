using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;


namespace monogame.gameAssets
{
    class Camera
    {
        private  GraphicsDeviceManager _graphics;
        private  Scene _scene;
        
        //world units
        public double CameraPositionX;
        public double CameraPositionY;
        //world units
        public double ViewPortHeight;
        public double ViewPortWidth;


        public Camera( ref GraphicsDeviceManager graphics, ref Scene scene) {

            this._graphics = graphics;
            this._scene = scene;

            this.CameraPositionX = _scene.WorldWidth / 2;
            this.CameraPositionY = _scene.WorldHeight / 2;

            ViewPortHeight = 100;

            // converting
            Debug.WriteLine("WorldHeight : " + _scene.WorldHeight);
            Debug.WriteLine("Screen H : " + Game1.screenHeight + "Screen W : " + Game1.screenWidth);
            ViewPortHeight = 5000; 
            ViewPortWidth = (ViewPortHeight * Game1.screenWidth) / Game1.screenHeight; // match screen's aspect ratio
            Debug.WriteLine("ViewHeight : " + ViewPortHeight);
      
        }

        public void Draw(ref SpriteBatch spriteBatch) {

            // convert world units to pixels

            //viewport is  = screen height width

            int bgHeightPx = (int) (_scene.WorldHeight * Game1.screenHeight / this.ViewPortHeight);
            int bgWidthPx = (int)(_scene.WorldHeight * Game1.screenHeight / this.ViewPortHeight);

            if (_scene.mainBackground != null) {
                spriteBatch.Draw(_scene.mainBackground,
                    new Rectangle(0, 0, bgWidthPx, bgHeightPx),
                    Color.White);

            }
           
        }
    }
}
