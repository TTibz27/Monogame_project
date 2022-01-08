using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace monogame.gameAssets.gameObjects.hitboxes
{
    class RectHitbox : IHitboxCollisions
    {
        public bool CheckCollision(CircularHitbox circle)
        {
            throw new NotImplementedException();
        }

        public bool CheckCollision(RectHitbox box)
        {
            throw new NotImplementedException();
        }

        public bool CheckCollision(PointHitbox point)
        {
            throw new NotImplementedException();
        }

        public void DrawHitbox(SpriteBatch spriteBatch, Color outline, Color fill)
        {
            throw new NotImplementedException();
        }
    }
}
