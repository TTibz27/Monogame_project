using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;


namespace monogame.gameAssets
{
    /// <summary>
    ///  Scene basically will handle the worldspace of a game. it will also handle the backgrounds of a level, but will require the camera to draw
    /// </summary>
    class Scene 
    {
        public double WorldHeight;
        public double WorldWidth;

        public Texture2D mainBackground;
        public Texture2D [] ParallaxBackgrounds;

        public Scene(double Height, double Width) {
            this.WorldHeight = Height;
            this.WorldWidth = Width;
        }

        public int setMainBackground(Texture2D bgTexture) {
            this.mainBackground = bgTexture;
            return 0;
        }

        public int SetBackgroundParallax()
        {
            return 0;
        }

      
    }
}
