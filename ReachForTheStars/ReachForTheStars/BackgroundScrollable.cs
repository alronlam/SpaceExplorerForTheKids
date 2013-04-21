using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ReachForTheStars
{
    public class BackgroundScrollable : Background
    {
        Game1 game;
        public int centerX;
        public int centerY;
        int cropWidth;
        int cropHeight;
        public int max_X;
        public int max_Y;
        public int scale;

        public BackgroundScrollable(AnimationFixed bgAnimation, List<AnimationFixed> extraAnimations, Game1 game, int initialCenterX, int initialCenterY, int scaleMultiplier) 
            :base(bgAnimation, extraAnimations)
        {
            this.game = game;
            this.centerX = initialCenterX;
            this.centerY = initialCenterY;
            this.cropWidth =  game.screenRectangle.Width/scaleMultiplier;
            this.cropHeight = game.screenRectangle.Height/scaleMultiplier;
            max_X = bgAnimation.texture.Width; //*scaleMultiplier;
            max_Y = bgAnimation.texture.Height; // *scaleMultiplier;
            scale = scaleMultiplier;
         }

        public void Scroll(int changeX, int changeY) 
        {
            int screenWidth = game.screenRectangle.Width;
            int screenHeight = game.screenRectangle.Height;

            int newX = centerX + changeX;
            int newY = centerY + changeY;

            int halfWidth = cropWidth/2;
            int halfHeight = cropHeight/2;

            if (newX - halfWidth >= 0 && newX + halfWidth <= max_X)
                centerX = newX;
            if (newY - halfHeight >= 0 && newY + halfHeight <= max_Y)
                centerY = newY;
        }

        public new void Draw(GameTime gameTime, SpriteBatch spriteBatch) 
        {
            int bgHalfWidth = bgAnimation.displayWidth/2;
            int bgHalfHeight = bgAnimation.displayHeight/2;
            spriteBatch.Draw(bgAnimation.texture, game.screenRectangle, new Rectangle(centerX-cropWidth/2, centerY-cropHeight/2, cropWidth, cropHeight ),  Color.White);
        }

        public bool IsRectangleWithinVisibility(Rectangle rectangle) 
        {
            Rectangle visibleRectangle = new Rectangle(centerX - cropWidth / 2, centerY - cropHeight / 2, cropWidth, cropHeight);
            
            return visibleRectangle.Intersects(rectangle);
        }

        public Point GetTopLeftCoordinate() 
        {
            int leftX = centerX - cropWidth / 2;
            int topY = centerY - cropHeight / 2;
            return new Point(leftX, topY);
        }

    }

}
