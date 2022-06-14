using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace monogame.gameObjects
{
    class PlayerGameObject : gameObjects.gameObject
    {

        private Rectangle currentFrame;
        private SpriteEffects currentSpriteFlip = SpriteEffects.None;

        private Rectangle fwdFrame = new Rectangle(232, 0, 79, 45);
        private Rectangle turnFrame1 = new Rectangle(470, 0, 80, 46);
        private Rectangle turnFrame2 = new Rectangle(714, 0, 80, 45);



        public PlayerGameObject(double x, double y, int heightPx, int widthPx, Texture2D texture) 
            : base( x,  y,  heightPx,  widthPx,  texture, drawModeType.Animated)
        {
            currentFrame = fwdFrame;

        }
        public override void Update()
        {
            GamePadState padState = GamePad.GetState(PlayerIndex.One);

            if (padState.ThumbSticks.Left.X > .1 || padState.ThumbSticks.Left.X < -.1)
            {
                this.x += padState.ThumbSticks.Left.X * 10;
                this.currentFrame = turnFrame1;
                if (padState.ThumbSticks.Left.X < 0)
                {
                    this.currentSpriteFlip = SpriteEffects.FlipHorizontally;
                }
                else {
                    this.currentSpriteFlip = SpriteEffects.None;
                }
            }
            else
            {
                this.currentFrame = fwdFrame;
            }

            if (padState.ThumbSticks.Left.X > .8 || padState.ThumbSticks.Left.X < -.8) {
                this.currentFrame = turnFrame2;
            }
         


                if (padState.ThumbSticks.Left.Y > .1 || padState.ThumbSticks.Left.Y < -.1)
            {
                this.y += padState.ThumbSticks.Left.Y * 10;
            }

           



        }
        public override Rectangle getCurrentSprite()
        {
          //  return turnFrame1;
           // return turnFrame2;
            return currentFrame;
        }
        public override SpriteEffects GetSpriteEffects()
        {
            return currentSpriteFlip;
        }
    }
}
