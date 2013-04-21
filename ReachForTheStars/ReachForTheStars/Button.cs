using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;

namespace ReachForTheStars
{
    public class Button
    {

        public Animation animation;
        public Animation highlightAnimation;
        public String commandText;
        public Text displayText;
        public Rectangle spot;
        public SoundEffect pressSound;
        public bool isPressed;
        public const int STRING_TOP = 0;
        public const int STRING_RIGHT = 1;
        public const int STRING_BOTTOM = 2;
        public const int STRING_LEFT = 3;
        public const int STRING_CENTER = 4;

        public Button(Animation animation, String commandText, int x, int y)
            : this(animation, null, commandText, x, y, "", null, 0, Color.White, null)
        { }

        public Button(Animation animation, Animation highlightAnimation, String commandText, int x, int y)
            :this(animation, highlightAnimation, commandText, x, y, null, null, 0, Color.White, null){}
        
        public Button(Animation animation, Animation highlightAnimation, String commandText, int x, int y, String dispText, SpriteFont font, int stringPos, Color color) 
            :this(animation, highlightAnimation, commandText, x, y, dispText, font, stringPos, color, null){ }

        public Button(Animation animation, Animation highlightAnimation, String commandText, int x, int y, String dispText, SpriteFont font, int stringPos, Color color, SoundEffect pressSound) 
        {
            isPressed = false;
            this.animation = animation;
            this.highlightAnimation = highlightAnimation;
            this.commandText = commandText;
            this.pressSound = pressSound;
            spot = new Rectangle(x, y, animation.displayWidth, animation.displayHeight);

            if (font != null)
                SetText(font, color, dispText, stringPos, x, y );
        }

        public void SetText(SpriteFont font, Color color, String dispText,  int stringPos, int x, int y) 
        {
            if (dispText != null)
            {
                int xOffset = 0;
                int yOffset = 0;

                Vector2 stringDimensions = font.MeasureString(new StringBuilder(dispText));

                if (stringPos == Button.STRING_TOP)
                {
                    xOffset = (animation.displayWidth - (int)stringDimensions.X) / 2;
                    yOffset = -1 * (int)stringDimensions.Y ;
                }
                else if (stringPos == Button.STRING_RIGHT)
                {
                    xOffset = animation.displayWidth;
                    yOffset = animation.displayHeight / 2 - (int)stringDimensions.Y / 2;
                }
                else if (stringPos == Button.STRING_BOTTOM)
                {
                    xOffset = (animation.displayWidth - (int)stringDimensions.X) / 2;
                    yOffset = animation.displayHeight;
                }
                else if (stringPos == Button.STRING_LEFT)
                {
                    xOffset = -(int)stringDimensions.X;
                    yOffset = animation.displayHeight / 2 - (int)stringDimensions.Y / 2;
                }
                else if (stringPos == Button.STRING_CENTER)
                {
                    xOffset = (animation.displayWidth - (int)stringDimensions.X) / 2;
                    yOffset = animation.displayHeight / 2 - (int)stringDimensions.Y / 2;
                }

                this.displayText = new Text(dispText, font, new Vector2(x + xOffset, y + yOffset), color);
            }
        }
      
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch) 
        {
            /*
            if (highlightAnimation != null)
                if (isPressed)
                    highlightAnimation.Draw(gameTime, spriteBatch, spot.X, spot.Y);    

            if (animation != null)
                animation.Draw(gameTime, spriteBatch, spot.X, spot.Y);
            */

            if (isPressed && highlightAnimation!=null)
                highlightAnimation.Draw(gameTime, spriteBatch, spot.X, spot.Y);
            //else
                animation.Draw(gameTime, spriteBatch, spot.X, spot.Y);

            if (displayText != null)
                displayText.Draw(gameTime, spriteBatch);
        }

        public bool IsPressed(int x, int y) 
        {
            isPressed = spot.Contains(x, y);

            if ( isPressed && pressSound!=null)
                pressSound.Play();
        
            return isPressed;
        }

    }
}
