using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;

namespace ReachForTheStars
{
    public class Rocket
    {
        Game1 game;
        public Animation animation;
        public int centerX;
        public int centerY;
        public const int SPEED = 2;
        public double rotation;


        public Rocket(Game1 game, Animation animation, int x, int y) 
        {
            this.game = game;
            this.animation = animation;
            this.centerX = x;
            this.centerY = y;
        }

        public void Update(GameTime gameTime, TouchCollection touchCollection) 
        {
            if (touchCollection.Count > 0) 
            {
                TouchLocation touch = touchCollection.ElementAt(0);
                animation.rotation = (float)Helper.GetRotation(-1*Math.PI/2, centerX, centerY, (int)touch.Position.X, (int)touch.Position.Y);
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch) 
        {
            animation.DrawFromCenter(gameTime, spriteBatch, 400, 240);
        }
    
    }
}
