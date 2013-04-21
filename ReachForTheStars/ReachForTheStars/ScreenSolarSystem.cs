using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Phone.Shell;
using Microsoft.Devices.Sensors;

namespace ReachForTheStars
{
    public class ScreenSolarSystem: Screen
    {        
        Rocket rocket;
        List<Planet> listPlanets;
        Accelerometer accelerometer;
        Vector3 lastAccReading;
        float threshold;
        SensorReadingEventArgs<AccelerometerReading> accelState;
        int visited;
        bool justReturned;

        public ScreenSolarSystem(Game1 game, BackgroundScrollable background)
            :base(game, background)
        {
            rocket = new Rocket(game, new Animation(game.textureRocket, 68, 126), background.bgAnimation.displayWidth/2, background.bgAnimation.displayHeight/2);
            listPlanets = new List<Planet>();
            InitPlanets();
            accelerometer = new Accelerometer();
            justReturned = false;

        }

        void Accelerometer_ReadingChanged(object sender, AccelerometerReadingEventArgs e) 
        {
            Vector3 accelerationInfo = accelState == null ? Vector3.Zero :
            new Vector3((float)accelState.SensorReading.Acceleration.X, (float)accelState.SensorReading.Acceleration.Y, (float)accelState.SensorReading.Acceleration.Z);
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

                if (touch.State != TouchLocationState.Released)
                {
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
        }

        public override void Update(GameTime gameTime, TouchCollection touchCollection)
        {
            ProcessTouch(gameTime, touchCollection);
            BackgroundScrollable bgs = (BackgroundScrollable)this.background;
            Point topLeftBG = bgs.GetTopLeftCoordinate();

            if (justReturned)
            {
                bool found = false;
                foreach (Planet planet in listPlanets)
                {
                    if (planet.Intersects(rocket, (int)topLeftBG.X, (int)topLeftBG.Y, bgs.scale))
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                    justReturned = false;
            }
            else
            {
                foreach (Planet planet in listPlanets)
                {
                    if (planet.Intersects(rocket, (int)topLeftBG.X, (int)topLeftBG.Y, bgs.scale))
                    {
                        if (!planet.isVisited)
                        {
                            visited++;
                            planet.isVisited = true;
                        }
                        if (planet.name.Equals("Mercury"))
                            NextScreen = game.GetNewScreenMercury();
                    }
                }
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            BackgroundScrollable backgroundScrollable = (BackgroundScrollable)this.background;
            backgroundScrollable.Draw(gameTime, spriteBatch);
            rocket.Draw(gameTime, spriteBatch);

            spriteBatch.DrawString(game.arialFont, "Visited:"+visited/listPlanets.Count, Vector2.Zero, Color.Red);

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

        public void ReturnHereFrom(Screen prevScreen) 
        {
            BackgroundScrollable bgs = (BackgroundScrollable)this.background;
            //bgs.Scroll(20, 20);

            justReturned = true;
            prevScreen.NextScreen = this;
        }
    }
}
