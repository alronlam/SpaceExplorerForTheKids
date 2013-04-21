using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ReachForTheStars
{
    public class Planet
    {
        public String name;
        public Animation animation;
        public int centerX;
        public int centerY;
        public bool isVisited;

        public Planet(String name, Animation animation, int initialCenterX, int initialCenterY ) 
        {
            this.name = name;
            this.animation = animation;
            this.centerX = initialCenterX;
            this.centerY = initialCenterY;
            isVisited = false;
        }

        public bool Intersects(Rocket rocket, int bgScrollableLeftX, int bgScrollableTopY, int scale)
        {
            int leftX = rocket.centerX-rocket.animation.displayWidth/2;
            int topY = rocket.centerY-rocket.animation.displayHeight/2;
            int width = rocket.animation.displayWidth;
            int height = rocket.animation.displayHeight;
            Rectangle rocketRect = new Rectangle(leftX, topY,width, height);

            leftX = (centerX - bgScrollableLeftX)*scale - animation.displayWidth/2;
            topY = (centerY - bgScrollableTopY)*scale - animation.displayHeight/2;
            width = animation.displayWidth;
            height = animation.displayHeight;

            Rectangle thisRect = new Rectangle(leftX, topY, width, height);
            //System.Diagnostics.Debug.WriteLine(rocketRect+" intersects with "+thisRect+"="+rocketRect.Intersects(thisRect));
            return rocketRect.Intersects(thisRect);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch, int bgScrollableLeftX, int bgScrollableTopY, int scale)
        {
            /*
            Vector2 v1 = new Vector2(centerX, centerY);
            Vector2 v2 = new Vector2(bgScrollableLeftX, bgScrollableTopY);
            Vector2 result = v1 - v2;
            result.Normalize();*/
            animation.DrawFromCenter(gameTime, spriteBatch, (centerX - bgScrollableLeftX)*scale, (centerY - bgScrollableTopY)*scale);
            //animation.DrawFromCenter(gameTime, spriteBatch, centerX, centerY);
        }

        public Point GetActualDrawnCoordinate(Point topLeft, int scale) 
        {
            return new Point((centerX - topLeft.X)*scale, (centerY - topLeft.Y)*scale);
        }

    }
}
