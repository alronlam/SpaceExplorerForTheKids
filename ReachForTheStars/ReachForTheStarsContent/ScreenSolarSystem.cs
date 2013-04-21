using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;

namespace ReachForTheStars
{
    public class ScreenSolarSystem: Screen
    {        
        Rocket rocket;
        List<Planet> listPlanets;

        public ScreenSolarSystem(Game1 game, BackgroundScrollable background)
            :base(game, background)
        {
            rocket = new Rocket(game, new Animation(game.textureRocket, 68, 126), background.bgAnimation.displayWidth/2, background.bgAnimation.displayHeight/2);
            listPlanets = new List<Planet>();
            InitPlanets();
        }

        public void InitPlanets()
        {
            listPlanets.Add(new Planet("Mercury", new Animation(game.textureMiniMercury, 80, 80), 600, 180));
        }

        private void ProcessTouch(GameTime gameTime, TouchCollection touchCollection) 
        {
            if (touchCollection.Count > 0)
            {
                TouchLocation touch = touchCollection[0];


                Vector2 position = touch.Position;
                int changeX = 0;
                int changeY = 0;

                if (rocket.centerX < position.X)
                    changeX = Rocket.SPEED;
                else if (rocket.centerX > position.X)
                    changeX = -1 * Rocket.SPEED;

                if (rocket.centerY < position.Y)
                    changeY = Rocket.SPEED;
                else if (rocket.centerY > position.Y)
                    changeY = -1 * Rocket.SPEED;

                //System.Diagnostics.Debug.WriteLine(changeX + " " + changeY);
                ((BackgroundScrollable)background).Scroll(changeX, changeY);

                rocket.Update(gameTime, touchCollection);

            }
        }

        public override void Update(GameTime gameTime, TouchCollection touchCollection)
        {
            ProcessTouch(gameTime, touchCollection);

            foreach (Planet planet in listPlanets)
            {
                if (planet.Intersects(rocket, ((BackgroundScrollable)background).scale))
                {
                    if (planet.name.Equals("Mercury"))
                        NextScreen = game.GetNewScreenMercury();
                }
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            BackgroundScrollable backgroundScrollable = (BackgroundScrollable)this.background;
            backgroundScrollable.Draw(gameTime, spriteBatch);
            rocket.Draw(gameTime, spriteBatch);

            Rectangle currRectangle;
            Animation animation;
            Point topLeftBG = backgroundScrollable.GetTopLeftCoordinate();
            foreach (Planet planet in listPlanets) 
            {
                animation = planet.animation;
                currRectangle = new Rectangle(planet.centerX-animation.displayWidth/2, planet.centerY - animation.displayHeight/2, animation.displayWidth, animation.displayHeight);
                if (backgroundScrollable.IsRectangleWithinVisibility(currRectangle))
                {
                    planet.Draw(gameTime, spriteBatch, (int)topLeftBG.X, (int)topLeftBG.Y, backgroundScrollable.scale);
                }
            }
        }

    }
}
