using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace ReachForTheStars
{
    public class AnimationFixed : Animation
    {
        int x;
        int y;

        public AnimationFixed(Texture2D texture, int numFrames, int animationDelay, int displayWidth, int displayHeight, float rotation, int x, int y)
            : base(texture,  numFrames,  animationDelay,  displayWidth,  displayHeight,  rotation)
        {
            this.x = x;
            this.y = y;
        }


        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch, x, y);
        }

    }
}
