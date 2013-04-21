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
    public class ScreenSolarSystem : Screen
    {
        const double SCALE_DIAMETER_MERCURY = 0.383;
        const double SCALE_DIAMETER_VENUS = 0.949;
        const double SCALE_DIAMETER_EARTH = 1;
        const double SCALE_DIAMETER_MARS = 0.532;
        const double SCALE_DIAMETER_JUPITER = 11.21;
        const double SCALE_DIAMETER_SATURN = 9.45;
        const double SCALE_DIAMETER_URANUS = 4.01;
        const double SCALE_DIAMETER_NEPTUNE = 3.88;

        Rocket rocket;
        List<Planet> listPlanets;
        Accelerometer accelerometer;
        Vector3 lastAccReading;
        float threshold;
        SensorReadingEventArgs<AccelerometerReading> accelState;
        int visited;
        Button buttonEnterPlanet;

        public ScreenSolarSystem(Game1 game, BackgroundScrollable background)
            : base(game, background)
        {
            int rocketWidth = (int)(0.5 * 80);
            rocket = new Rocket(game, new Animation(game.textureRocket, rocketWidth, rocketWidth*126/68), background.bgAnimation.displayWidth / 2, background.bgAnimation.displayHeight / 2);
            listPlanets = new List<Planet>();
            InitPlanets();
            accelerometer = new Accelerometer();
            buttonEnterPlanet = new Button(new Animation(game.textureButtonEnterPlanet, 100, 50), "enterPlanet", 10, 10);
        }

        void Accelerometer_ReadingChanged(object sender, AccelerometerReadingEventArgs e)
        {
            Vector3 accelerationInfo = accelState == null ? Vector3.Zero :
            new Vector3((float)accelState.SensorReading.Acceleration.X, (float)accelState.SensorReading.Acceleration.Y, (float)accelState.SensorReading.Acceleration.Z);
        }

        public void InitPlanets()
        {
            int earthWidth = 80;
            int earthHeight = 80;
            listPlanets.Add(new Planet("Mercury", new Animation(game.textureMiniMercury,(int)( earthWidth*SCALE_DIAMETER_MERCURY), (int)(earthHeight*SCALE_DIAMETER_MERCURY)), 200, 200));
            listPlanets.Add(new Planet("Venus", new Animation(game.textureMiniVenus, (int)(earthWidth * SCALE_DIAMETER_VENUS), (int)(earthHeight * SCALE_DIAMETER_VENUS)), 400, 200));
            //listPlanets.Add(new Planet("Earth", new Animation(game.textureMiniEarth, (int)(earthWidth * SCALE_DIAMETER_EARTH), (int)(earthHeight * SCALE_DIAMETER_EARTH)), 600, 200));
            listPlanets.Add(new Planet("Mars", new Animation(game.textureMiniMars, (int)(earthWidth * SCALE_DIAMETER_MARS), (int)(earthHeight * SCALE_DIAMETER_MARS)), 800, 200));
            listPlanets.Add(new Planet("Jupiter", new Animation(game.textureMiniJupiter, (int)(earthWidth * SCALE_DIAMETER_JUPITER), (int)(earthHeight * SCALE_DIAMETER_JUPITER)), 1000, 200));
            listPlanets.Add(new Planet("Saturn", new Animation(game.textureMiniSaturn, (int)(earthWidth * SCALE_DIAMETER_SATURN), (int)(earthHeight * SCALE_DIAMETER_SATURN)), 200, 800));
            listPlanets.Add(new Planet("Uranus", new Animation(game.textureMiniUranus, (int)(earthWidth * SCALE_DIAMETER_URANUS), (int)(earthHeight * SCALE_DIAMETER_URANUS)), 600, 800));
            listPlanets.Add(new Planet("Neptune", new Animation(game.textureMiniNeptune, (int)(earthWidth * SCALE_DIAMETER_NEPTUNE), (int)(earthHeight * SCALE_DIAMETER_NEPTUNE)), 1000, 800));
            
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

            foreach (Planet planet in listPlanets)
            {
                if (planet.Intersects(rocket, (int)topLeftBG.X, (int)topLeftBG.Y, bgs.scale))
                {
                    if (touchCollection.Count > 0) 
                    {
                        TouchLocation touch = touchCollection[0];
                        if (touch.State == TouchLocationState.Pressed)
                        {
                            if(buttonEnterPlanet.IsPressed((int)touch.Position.X, (int)touch.Position.Y))
                            {
                                if (!planet.isVisited)
                                {
                                    visited++;
                                    planet.isVisited = true;
                                }
                                if (planet.name.Equals("Mercury"))
                                    NextScreen = game.GetNewScreenMercury();
                                else if (planet.name.Equals("Venus"))
                                    NextScreen = game.GetNewScreenVenus();
                                else if (planet.name.Equals("Earth"))
                                    NextScreen = game.GetNewScreenEarth();
                                else if (planet.name.Equals("Mars"))
                                    NextScreen = game.GetNewScreenMars();
                                else if (planet.name.Equals("Jupiter"))
                                    NextScreen = game.GetNewScreenJupiter();
                                else if (planet.name.Equals("Saturn"))
                                    NextScreen = game.GetNewScreenSaturn();
                                else if (planet.name.Equals("Uranus"))
                                    NextScreen = game.GetNewScreenUranus();
                                else if (planet.name.Equals("Neptune"))
                                    NextScreen = game.GetNewScreenNeptune();
                            }
                        }
                    }
                }
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            BackgroundScrollable backgroundScrollable = (BackgroundScrollable)this.background;
            backgroundScrollable.Draw(gameTime, spriteBatch);
            
            spriteBatch.DrawString(game.arialFont, "Visited:" + visited / listPlanets.Count, Vector2.Zero, Color.Red);

            Rectangle currRectangle;
            Animation animation;
            Point topLeftBG = backgroundScrollable.GetTopLeftCoordinate();
            foreach (Planet planet in listPlanets)
            {
                animation = planet.animation;
                currRectangle = new Rectangle(planet.centerX - animation.displayWidth / 2, planet.centerY - animation.displayHeight / 2, animation.displayWidth, animation.displayHeight);
                if (backgroundScrollable.IsRectangleWithinVisibility(currRectangle))
                {
                    planet.Draw(gameTime, spriteBatch, (int)topLeftBG.X, (int)topLeftBG.Y, backgroundScrollable.scale);
                    if (planet.Intersects(rocket, topLeftBG.X, topLeftBG.Y, backgroundScrollable.scale))
                        buttonEnterPlanet.Draw(gameTime, spriteBatch);
                }
            }

            rocket.Draw(gameTime, spriteBatch);
        }
    }
}
