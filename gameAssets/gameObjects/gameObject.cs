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
        public double x;
        public double y;
        public double height;
        public double width;

        public IHitboxCollisions[] collisionBoxes; // physics collisions
       // public IHitboxCollisions[] hurtBoxes;  // game collision detection
       // public IHitboxCollisions[] hitBoxes;
       
        public gameObject(double x, double y, double height, double width) {
            this.x = x;
            this.y = y;
            this.height = height;
            this.width = width;
        }
        // This should be called every phyisics update
        public void Update (SpriteBatch spriteBatch) { 
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
    }
}
