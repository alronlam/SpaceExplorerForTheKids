using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;

namespace ReachForTheStars
{
    public abstract class Screen
    {
        protected Game1 game;
        protected Background background;
        private Screen nextScreen;
        public Screen NextScreen { get { return nextScreen; } set { nextScreen = value; } }

        public Screen(Game1 game, Background background) 
        {
            this.game = game;
            this.background = background;
            nextScreen = this;
        }

        public abstract void Update(GameTime gameTime, TouchCollection touchCollection);

        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);
 

    }
}
