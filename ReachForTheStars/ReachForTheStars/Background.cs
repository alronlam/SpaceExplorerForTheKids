using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ReachForTheStars
{
    public class Background
    {
        public AnimationFixed bgAnimation;
        public List<AnimationFixed> extraAnimations;

        public Background(AnimationFixed bgAnimation, List<AnimationFixed> extraAnimations) 
        {
            this.bgAnimation = bgAnimation;
            this.extraAnimations = extraAnimations;
        }


        public void Draw(GameTime gameTime, SpriteBatch spriteBatch) 
        {
            bgAnimation.Draw(gameTime, spriteBatch);
            if (extraAnimations != null)
            {
                foreach (AnimationFixed animation in extraAnimations)
                {
                    animation.Draw(gameTime, spriteBatch);
                }
            }
        }

    }
}
