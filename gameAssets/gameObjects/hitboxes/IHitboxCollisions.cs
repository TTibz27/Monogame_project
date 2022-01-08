using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace monogame.gameAssets.gameObjects.hitboxes
{
    interface IHitboxCollisions
    {
        public bool CheckCollision(CircularHitbox circle);
        public bool CheckCollision(RectHitbox box);

        public bool CheckCollision(PointHitbox point);

        public void DrawHitbox(SpriteBatch spriteBatch, Color outline, Color fill);
    }
}
