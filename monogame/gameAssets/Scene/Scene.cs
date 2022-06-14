using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using monogame.gameObjects;


namespace monogame.gameAssets
{
    /// <summary>
    ///  Scene basically will handle the worldspace of a game. it will also handle the backgrounds of a level, but will require the camera to draw
    /// </summary>
    class Scene 
    {
        public double WorldHeight;
        public double WorldWidth;

        public Texture2D staticBackground; // furthest from foreground
        public List <Texture2D> ParallaxBackgrounds  = new List<Texture2D>(); // ordered from furthest back of camera to front, low z-index to high
        public Texture2D mainBackground; // closest to foreground

        public List <gameObject> objects = new List<gameObject>();


        public Scene(double Height, double Width) {
            this.WorldHeight = Height;
            this.WorldWidth = Width;
            this.staticBackground = null;
            this.mainBackground = null;

        }

        public int setMainBackground(Texture2D bgTexture) {
            this.mainBackground = bgTexture;
            return 0;
        }

        public void setStaticBackground(Texture2D bgTexture)
        {
            this.staticBackground = bgTexture;
        }

        public void SetBackgroundParallax(Texture2D bgTexture)
        {
            this.ParallaxBackgrounds.Add(bgTexture);
        }

    }
}
