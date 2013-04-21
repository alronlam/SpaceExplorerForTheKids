using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace ReachForTheStars
{
    public class Animation
    {
        public int animationCounter; // time elapsed since last "frame update"
        public int animationDelay; // delay before switching to the next frame
        public int frameNum; // current frame number

        public int displayWidth;
        public int displayHeight;

        public float rotation;

        public int numFrames;
        public int frameWidth;
        public int frameHeight;
        public Texture2D texture;

        public Animation(Texture2D texture, int numFrames, int animationDelay, int displayWidth, int displayHeight)
            : this(texture, numFrames, animationDelay, displayWidth, displayHeight, 0)
        {
        }

        public Animation(Texture2D texture, int displayWidth, int displayHeight)
            : this(texture, 1, 0, displayWidth, displayHeight, 0) { }
        

        public Animation(Texture2D texture, int numFrames, int animationDelay, int displayWidth, int displayHeight, float rotation)
        {
            this.texture = texture;
            this.displayWidth = displayWidth;
            this.displayHeight = displayHeight;
            this.animationDelay = animationDelay;
            this.numFrames = numFrames;
            this.rotation = rotation;

            if (numFrames == 0)
                numFrames = 1;

            frameWidth = texture.Width / numFrames;
            frameHeight = texture.Height;
            animationCounter = 0;
            frameNum = 0;
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch) 
        {
            
        }

        public  void Draw(GameTime gameTime, SpriteBatch spriteBatch, int x, int y)
        {
            Draw(gameTime, spriteBatch, x, y, displayWidth, displayHeight);
        }

        public void DrawFlippedFromCenter(GameTime gameTime, SpriteBatch spriteBatch, int x, int y) 
        {
            spriteBatch.Draw(texture, new Rectangle(x, y, displayWidth, displayHeight), new Rectangle(frameWidth * frameNum, 0, frameWidth, frameHeight), Color.White, rotation, new Vector2(frameWidth/2, frameHeight/2), SpriteEffects.FlipHorizontally, 0);

            if (numFrames > 1)
                if ((animationCounter += gameTime.ElapsedGameTime.Milliseconds) >= animationDelay)
                {
                    animationCounter = 0;
                    if (++(frameNum) == numFrames)
                        frameNum = 0;
                }
        }

        public void Draw(SpriteBatch spriteBatch, int x, int y, int frameNum) 
        {
            spriteBatch.Draw(texture, new Rectangle(x, y, displayWidth, displayHeight), new Rectangle(frameWidth * frameNum, 0, frameWidth, frameHeight), Color.White, rotation, new Vector2(0,0), SpriteEffects.None, 0);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch, int x, int y, int dispWidth, int dispHeight)
        {
            spriteBatch.Draw(texture, new Rectangle(x, y, dispWidth, dispHeight), new Rectangle(frameWidth * frameNum, 0, frameWidth, frameHeight), Color.White, rotation, new Vector2(0,0), SpriteEffects.None, 0);

            if(numFrames>1)
                if ((animationCounter += gameTime.ElapsedGameTime.Milliseconds) >= animationDelay)
                {
                    animationCounter = 0;
                    if (++(frameNum) == numFrames)
                        frameNum = 0;
                }
        }

        public void DrawFromCenter(GameTime gameTime, SpriteBatch spriteBatch, int centerX, int centerY) 
        {
            DrawFromCenter(gameTime, spriteBatch, centerX, centerY, Color.White, 1);
        }

        public void DrawFromCenter(GameTime gameTime, SpriteBatch spriteBatch, int centerX, int centerY, Color color, float transparency)
        {
            spriteBatch.Draw(texture, new Rectangle(centerX, centerY, displayWidth, displayHeight), new Rectangle(frameWidth * frameNum, 0, frameWidth, frameHeight), color * transparency, rotation, new Vector2(frameWidth / 2, frameHeight / 2), SpriteEffects.None, 0);
            if ((animationCounter += gameTime.ElapsedGameTime.Milliseconds) >= animationDelay)
            {
                animationCounter = 0;
                if (++(frameNum) == numFrames)
                    frameNum = 0;
            }
        }

        public void DrawFromCenter(GameTime gameTime, SpriteBatch spriteBatch, int centerX, int centerY, Color color, float transparency, float scale)
        {
            spriteBatch.Draw(texture, new Rectangle(centerX, centerY, (int) (displayWidth *scale) , (int) (displayHeight*scale)), new Rectangle(frameWidth * frameNum, 0, frameWidth, frameHeight), color * transparency, rotation, new Vector2(frameWidth / 2, frameHeight / 2), SpriteEffects.None, 0);
            if ((animationCounter += gameTime.ElapsedGameTime.Milliseconds) >= animationDelay)
            {
                animationCounter = 0;
                if (++(frameNum) == numFrames)
                    frameNum = 0;
            }
        }

        public Animation GetCopy()
        {
            return GetCopy(displayWidth, displayHeight);
        }

        public Animation GetCopy(int newWidth, int newHeight) 
        {
            return new Animation(texture, numFrames, animationDelay, newWidth, newHeight);
        }

        public virtual bool IsExpired() 
        {
            System.Diagnostics.Debug.WriteLine("hereeeE");
            return false;
        }
    }
}
