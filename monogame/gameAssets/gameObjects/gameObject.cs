using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using monogame.gameAssets.gameObjects.hitboxes;

namespace monogame.gameObjects
{
    /// <summary>
    /// A game object is something that exists in the worldspace. all coordinates will be in world coordinates, not viewport coordinates.
    /// this does not mean that it is drawable nessisarily, as there could be a need for invisible walls, borders, background tiles etc.
    /// 
    /// each game object is a box. x and y are center coordinates of the box, height and width are self explainitory.
    /// if a point is needed, that sould likely be handled seperately.
    /// </summary>
    class gameObject
    {
        public double x; // world , midpoint
        public double y; // world
        public double height; // world
        public double width; //world

        public int SpriteSheetHeightPx; // px, not world
        public int SpriteSheetWidthPx;  // px

        public float roatation;


        private Texture2D spriteTexture;

        public enum drawModeType { 
            None,
            FullSpriteSheet,
            Animated
        }

        public drawModeType drawMode;

       // public IHitboxCollisions[] pushBoxes; // physics collisions
       // public IHitboxCollisions[] hurtBoxes;  // game collision detection
       // public IHitboxCollisions[] hitBoxes;
       

        public gameObject(double x, double y, int heightPx, int widthPx) {
            //world positions
            this.x = x;
            this.y = y;
            this.SpriteSheetHeightPx = heightPx;
            this.SpriteSheetWidthPx = widthPx;

            this.height = this.SpriteSheetHeightPx;
            this.width = this.SpriteSheetWidthPx;

            this.spriteTexture = null;
            this.drawMode = drawModeType.None;

            this.roatation = 0;

        }

        public gameObject(double x, double y, int heightPx, int widthPx, Texture2D texture)
        {
            //world positions
            this.x = x;
            this.y = y;
            this.SpriteSheetHeightPx = heightPx;
            this.SpriteSheetWidthPx = widthPx;

            this.height = this.SpriteSheetHeightPx;
            this.width = this.SpriteSheetWidthPx;

            this.spriteTexture = texture;
            this.drawMode = drawModeType.FullSpriteSheet;

            this.roatation = 0;
        }
        public gameObject(double x, double y, int heightPx, int widthPx, Texture2D texture, drawModeType drawmode)
        {
            //world positions
            this.x = x;
            this.y = y;
            this.SpriteSheetHeightPx = heightPx;
            this.SpriteSheetWidthPx = widthPx;
            this.spriteTexture = texture;
            this.drawMode = drawmode;
            this.roatation = 0;
        }

        // This should be called every phyisics update
        public virtual void Update () { 

        }

        public bool CheckCollisionBoxes(gameObject obj2)
        {
            throw new NotImplementedException();
        }
        public bool CheckHurtBoxes(gameObject obj2)
        {
            throw new NotImplementedException();
        }
        public bool CheckHitBoxes(gameObject obj2) 
        {
            throw new NotImplementedException();
        }

        public void setSpriteSheet(Texture2D texture) {
            this.spriteTexture = texture;
        }

        public Texture2D getFullTexture() {
            return spriteTexture;
        }

        public virtual Rectangle getCurrentSprite() {

            return new Rectangle(0, 0, 1, 1);
        }

        public virtual SpriteEffects GetSpriteEffects() {

            return SpriteEffects.None;
        }

        public void getSpriteSizeRect() { 
        
        }

        public void Move(double xIn, double yIn) {
            this.x += xIn;
            this.y += yIn;
        }


    // Draw the entire sprite.
    //spriteBatch.Draw(charaset, new Vector2(100, 100), Color.White);
    //// Create a sourceRectangle.
    //Rectangle sourceRectangle = new Rectangle(0, 0, 48, 64);
    //    // Only draw the area contained within the sourceRectangle.
    //    spriteBatch.Draw(charaset, new Vector2(300, 100), sourceRectangle, Color.White);


    }
}
