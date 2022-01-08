using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace monogame.gameAssets.gameObjects.hitboxes
{
    class CircularHitbox : IHitboxCollisions
    {
        // X and Y for boxes should be in world units
        public double x, y;
        public double radius;

        public CircularHitbox(double x, double y, double radius) {
            this.x = x;
            this.y = y;
            this.radius = radius;
        }

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
