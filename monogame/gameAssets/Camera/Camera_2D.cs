using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using monogame.gameObjects;

namespace monogame.gameAssets
{
    class Camera_2D
    {
        private GraphicsDeviceManager _graphics;
        private Scene _scene;

        //world units, midpoint of screen
        private double CameraPositionX;
        private double CameraPositionY;
        //world units
        public double ViewPortHeight;
        public double ViewPortWidth;

        readonly public double ViewportMinSize = 10;

        //public enum bgType {
        //TopDown,
        //Isometric /// technically its orthographic but like, who cares
        //};

        //   public bgType MainBgType;
        public Camera_2D(ref GraphicsDeviceManager graphics, ref Scene scene)
        {

            // this.MainBgType = bgType.Isometric;

            this._graphics = graphics;
            this._scene = scene;

            this.CameraPositionX = _scene.WorldWidth / 2;
            this.CameraPositionY = _scene.WorldHeight / 2;

            ViewPortHeight = 100;

            // converting
            Debug.WriteLine("WorldHeight : " + _scene.WorldHeight);
            Debug.WriteLine("Screen H : " + Game1.screenHeight + "Screen W : " + Game1.screenWidth);
            ViewPortHeight = 224;
            ViewPortWidth = (ViewPortHeight * Game1.screenWidth) / Game1.screenHeight; // match screen's aspect ratio
            Debug.WriteLine("ViewHeight : " + ViewPortHeight);

        }

        public void Draw(ref SpriteBatch spriteBatch)
        {


            // Draw static Background

            if (_scene.staticBackground != null)
            {
                spriteBatch.Draw(_scene.staticBackground,
                    new Rectangle(0, 0, Game1.screenWidth, Game1.screenHeight),
                    Color.White);

            }


            // Draw Main Background
            // convert world units to pixels

            // TODO - Change this to add BgType enum check


            //if (this.MainBgType == bgType.Isometric) {

            //}

            //else if (this.MainBgType == bgType.TopDown) {

            //viewport is  = screen height width
            int bgHeightPx = (int)((_scene.WorldHeight * Game1.screenHeight / this.ViewPortHeight));
            int bgWidthPx = (int)((_scene.WorldWidth * Game1.screenWidth / this.ViewPortWidth));



            //move camera origin to correct point
            int positionOffsetY = (int)((_scene.WorldHeight - CameraPositionY) * Game1.screenHeight / this.ViewPortHeight) * -1;
            int positionOffsetX = (int)(CameraPositionX * Game1.screenWidth / this.ViewPortWidth) * -1;

            //center camera on correct point
            positionOffsetX += (Game1.screenWidth / 2);
            positionOffsetY += (Game1.screenHeight / 2);

            if (_scene.mainBackground != null)
            {
                spriteBatch.Draw(_scene.mainBackground,
                    new Rectangle(positionOffsetX, positionOffsetY, bgWidthPx, bgHeightPx),
                    Color.White);
            }

            //draw game objects
            List<gameObject> objs = _scene.objects;
            if (objs.Count > 0)
            {
                for (int i = 0; i < objs.Count; i++)
                {
                    gameObject obj = objs[i];
                    if (obj.drawMode == gameObject.drawModeType.FullSpriteSheet)
                    {
                        // TODO - This whole section could be replaced or updated to use the draw function
                        // baased off an X.Y vector instead of drawing a rectangle scaled and shifted.
                        // Oops!


                        double objWidth = (objs[i].width);
                        double objHeight = (objs[i].height);

                        // Screen/Viewport, PX units
                        int scaledWidth = (int)(objWidth * Game1.screenHeight / this.ViewPortHeight);
                        int scaledHeight = (int)(objHeight * Game1.screenHeight / this.ViewPortHeight);

                        // this is the difference between camera and center of objects in world units
                        double worldX = objs[i].x - CameraPositionX;
                        double worldY = objs[i].y - CameraPositionY;
                        // Debug.WriteLine("Camera Pos : ( " +CameraPositionX + " , " + CameraPositionY+ ")");
                        // Debug.WriteLine("world Pos dif : ( " + worldX + " , " + worldY + ")");



                        //transform world units to viewport x y coords, PX
                        int ScreenX = (int)(worldX * Game1.screenHeight / this.ViewPortHeight);
                        int ScreenY = (int)(worldY * Game1.screenHeight / this.ViewPortHeight) * -1;


                        // add position offset
                        ScreenX += (int)(Game1.screenWidth / 2);
                        ScreenY += (int)(Game1.screenHeight / 2);

                        //todo add trivial ignore draw cases
                        if ((ScreenX + (scaledWidth)) < 0 || ScreenX > (Game1.screenWidth) ||
                             ScreenY + scaledHeight < 0 || (ScreenY > Game1.screenHeight)
                            //todo the y axis isnt working for some reason   (ScreenY  > scaledHeight /2) // || (ScreenY <  -1 * Game1.screenHeight)
                            )

                        {
                            // TODO need to invert this statement and remove else
                        }

                        //draw
                        else
                        {
                            spriteBatch.Draw(
                            objs[i].getFullTexture(),
                            new Rectangle(ScreenX, ScreenY, scaledWidth, scaledHeight),
                            Color.White);
                        }
                    }
                    else if (obj.drawMode == gameObject.drawModeType.Animated)
                    {
                        double worldX = objs[i].x - CameraPositionX;
                        double worldY = objs[i].y - CameraPositionY;
                        //transform world units to viewport x y coords, PX
                        int ScreenX = (int)(worldX * Game1.screenHeight / this.ViewPortHeight);
                        int ScreenY = (int)(worldY * Game1.screenHeight / this.ViewPortHeight) * -1;

                        //offset
                        ScreenX += (int)(Game1.screenWidth / 2);
                        ScreenY += (int)(Game1.screenHeight / 2);


                        //Debug.WriteLine("Obj    - ( " + worldX + ", " + worldY + ") ");
                        //Debug.WriteLine("Viewpt - (" + CameraPositionX + ", " + CameraPositionY + ") ");
                        //Debug.WriteLine("Obj S  - (" + ScreenX + ", " + ScreenY + ") ");


                        Rectangle spriteRect = obj.getCurrentSprite();

                        int scaledWidth = (int)(spriteRect.Width * Game1.screenHeight / this.ViewPortHeight);
                        int scaledHeight = (int)(spriteRect.Height * Game1.screenHeight / this.ViewPortHeight);
                      

                        //public void Draw(
                        //Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color, float rotation,
                        //Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
                        spriteBatch.Draw(
                            obj.getFullTexture(), //Texture2D texture
                            new Vector2(ScreenX, ScreenY),// Vector2 position
                            obj.getCurrentSprite(), // Rectangle ? sourceRectangle
                            Color.White, // Color color
                            obj.roatation, //roatation
                            new Vector2((float)obj.width / 2, (float)obj.height / 2), // origin of rotation
                            new Vector2((float)scaledHeight / spriteRect.Height, (float)scaledWidth / spriteRect.Width), // scale vector
                            obj.GetSpriteEffects(), // can be flipped etc here
                            1
                            ); ;
                    }
                    else {
                        Debug.WriteLine("Draw mode disabled");
                    }
                }

            }
        }

        public void changeZoom(double viewportAdjust)
        {
            //ZoomScale += viewportAdjust;
            ViewPortHeight += viewportAdjust;
            if (ViewPortHeight < ViewportMinSize)
            {
                ViewPortHeight = ViewportMinSize;
            }
            ViewPortWidth = (ViewPortHeight * Game1.screenWidth) / Game1.screenHeight; // match screen's aspect ratio
        }

        public void changeCenter(double worldX, double worldY)
        {
            this.CameraPositionX = worldX;
            this.CameraPositionY = worldY;
        }
        public void moveCamera(double x, double y)
        {
            this.CameraPositionY += y;
            this.CameraPositionX += x;
        }

    }

}
