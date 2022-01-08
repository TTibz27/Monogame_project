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
        private double CameraPositionX;
        private double CameraPositionY;
        //world units
        public double ViewPortHeight;
        public double ViewPortWidth;

        readonly public double  ViewportMinSize = 10;


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
            int bgWidthPx = (int)(_scene.WorldWidth * Game1.screenWidth / this.ViewPortWidth);

            //move camera origin to correct point
            int positionOffsetY = (int)((_scene.WorldHeight - CameraPositionY) * Game1.screenHeight / this.ViewPortHeight)* -1;
            int positionOffsetX = (int)(CameraPositionX * Game1.screenWidth / this.ViewPortWidth) * -1;

            //center camera on correct point
            positionOffsetX += (Game1.screenWidth / 2);
            positionOffsetY += (Game1.screenHeight / 2);

            if (_scene.mainBackground != null) {
                spriteBatch.Draw(_scene.mainBackground,
                    new Rectangle(positionOffsetX, positionOffsetY, bgWidthPx, bgHeightPx),
                    Color.White);

            }
           
        }

        public void changeZoom(double viewportAdjust)
        {
            ViewPortHeight += viewportAdjust;
            if (ViewPortHeight < ViewportMinSize) {
                ViewPortHeight = ViewportMinSize;
            }
            ViewPortWidth = (ViewPortHeight * Game1.screenWidth) / Game1.screenHeight; // match screen's aspect ratio
        }

        public void changeCenter(double worldX, double worldY)
        {
            this.CameraPositionX = worldX;
            this.CameraPositionY = worldY;
        }
        public void moveCamera(double x, double y) {
            this.CameraPositionY += y;
            this.CameraPositionX += x;
        }
    }
}
