using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace ReachForTheStars
{
    public class Text
    {
        public String text;
        public SpriteFont font;
        public Vector2 vector;
        public Color color;

        public Text(String text, SpriteFont font, Vector2 vector, Color color) 
        {
            this.text = text;
            this.font = font;
            this.vector = vector;
            this.color = color;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch) 
        {
            if(font!=null && vector!= null)
                spriteBatch.DrawString(font, text, vector, color);
        }
    }
}
