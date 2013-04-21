using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;

namespace ReachForTheStars
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        GraphicsDevice device;
        SpriteBatch spriteBatch;

        public Rectangle screenRectangle;

        public Screen currScreen;

        public SpriteFont arialFont;

        //GAME STUFF
        public Texture2D textureRocket;
        public Texture2D textureBack;
        public Texture2D texturePlay;
        public Texture2D textureAbout;
        public Texture2D textureMenu;
        public Texture2D textureAboutBackground;

        public Texture2D textureMercury;
        public Texture2D textureMercurySun;
        public Texture2D textureMercuryThermometer;
        public Texture2D textureMercuryCrater;
        public Texture2D textureMercurySunInfo;
        public Texture2D textureMercuryThermometerInfo;
        public Texture2D textureMercuryCraterInfo;

        public Texture2D textureVenus;
        public Texture2D textureVenusVolcano;
        public Texture2D textureVenusRotate;
        public Texture2D textureVenusEarth;
        public Texture2D textureVenusNASA;
        public Texture2D textureVenusVolcanoInfo;
        public Texture2D textureVenusRotateInfo;
        public Texture2D textureVenusEarthInfo;
        public Texture2D textureVenusNASAInfo;

        public Texture2D textureEarth;
        public Texture2D textureEarthPeople;
        public Texture2D textureEarthWater;
        public Texture2D textureEarthMoon;
        public Texture2D textureEarthPeopleInfo;
        public Texture2D textureEarthWaterInfo;
        public Texture2D textureEarthMoonInfo;

        public Texture2D textureMars;
        public Texture2D textureMarsNASA;
        public Texture2D textureMarsMoon;
        public Texture2D textureMarsStorm;
        public Texture2D textureMarsNASAInfo;
        public Texture2D textureMarsMoonInfo;
        public Texture2D textureMarsStormInfo;

        public Texture2D textureJupiter;
        public Texture2D textureJupiterNASA;
        public Texture2D textureJupiterRedSpot;
        public Texture2D textureJupiterMoon;
        public Texture2D textureJupiterNASAInfo;
        public Texture2D textureJupiterRedSpotInfo;
        public Texture2D textureJupiterMoonInfo;

        public Texture2D textureSaturn;
        public Texture2D textureSaturnMoon;
        public Texture2D textureSaturnRing;
        public Texture2D textureSaturnClock;
        public Texture2D textureSaturnMoonInfo;
        public Texture2D textureSaturnRingInfo;
        public Texture2D textureSaturnClockInfo;

        public Texture2D textureUranus;
        public Texture2D textureUranusMoon;
        public Texture2D textureUranusWind;
        public Texture2D textureUranusRing;
        public Texture2D textureUranusOcean;
        public Texture2D textureUranusNASA;
        public Texture2D textureUranusMoonInfo;
        public Texture2D textureUranusWindInfo;
        public Texture2D textureUranusRingInfo;
        public Texture2D textureUranusOceanInfo;
        public Texture2D textureUranusNASAInfo;

        public Texture2D textureNeptune;
        public Texture2D textureNeptuneMoon;
        public Texture2D textureNeptuneNASA;
        public Texture2D textureNeptuneMoonInfo;
        public Texture2D textureNeptuneNASAInfo;

        public Texture2D textureGalaxy;

        //Mini planets
        public Texture2D textureMiniMercury;
        public Texture2D textureMiniVenus;
        public Texture2D textureMiniEarth;
        public Texture2D textureMiniMars;
        public Texture2D textureMiniJupiter;
        public Texture2D textureMiniSaturn;
        public Texture2D textureMiniUranus;
        public Texture2D textureMiniNeptune;

        public Texture2D textureButtonEnterPlanet;

        //TEST
        public Texture2D textureButton;
        public Texture2D textureBackground;
        public Texture2D textureBackground2;

        public ScreenSolarSystem screenSolarSystem;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // Frame rate is 30 fps by default for Windows Phone.
            TargetElapsedTime = TimeSpan.FromTicks(333333);

            // Extend battery life under lock.
            InactiveSleepTime = TimeSpan.FromSeconds(1);

            graphics.IsFullScreen = true;

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            device = graphics.GraphicsDevice;
            device.PresentationParameters.IsFullScreen = true;

            screenRectangle = new Rectangle(0, 0, device.PresentationParameters.BackBufferWidth, device.PresentationParameters.BackBufferHeight);


            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            arialFont = Content.Load<SpriteFont>("arial");

            // TODO: use this.Content to load your game content here
            textureRocket = Content.Load<Texture2D>("rocket");
            textureMercury = Content.Load<Texture2D>("mercury");
            textureBack = Content.Load<Texture2D>("back");
            texturePlay = Content.Load<Texture2D>("button_play");
            textureAbout = Content.Load<Texture2D>("button_about");
            textureMenu = Content.Load<Texture2D>("background_main");
            textureAboutBackground = Content.Load<Texture2D>("background_about");
            textureGalaxy = Content.Load<Texture2D>("galaxy");
            textureMiniMercury = Content.Load<Texture2D>("mercury");
            textureMiniVenus = Content.Load<Texture2D>("venus");
            //textureMiniEarth = Content.Load<Texture2D>("earth");
            textureMiniMars = Content.Load<Texture2D>("mars");
            textureMiniJupiter = Content.Load<Texture2D>("jupiter");
            textureMiniSaturn = Content.Load<Texture2D>("saturn");
            textureMiniUranus = Content.Load<Texture2D>("uranus");
            textureMiniNeptune = Content.Load<Texture2D>("neptune");

            textureButtonEnterPlanet = Content.Load<Texture2D>("bomb");

            textureMercury = Content.Load<Texture2D>("background_mercury");
            textureVenus = Content.Load<Texture2D>("background_venus");
            textureEarth = Content.Load<Texture2D>("background_earth");
            textureMars = Content.Load<Texture2D>("background_mars");
            textureJupiter = Content.Load<Texture2D>("background_jupiter");
            textureSaturn = Content.Load<Texture2D>("background_saturn");
            textureUranus = Content.Load<Texture2D>("background_uranus");
            textureNeptune = Content.Load<Texture2D>("background_neptune");


            //TEST
            textureButton = Content.Load<Texture2D>("haha");
            textureBackground = Content.Load<Texture2D>("bg");
            textureBackground2 = Content.Load<Texture2D>("bg2");

            //AnimationFixed background = new AnimationFixed(textureMercury, 1, 0, 800, 480, 0, 0, 0);
            //currScreen = new ScreenMercury(this, new Background(background,null), null);


            AnimationFixed background = new AnimationFixed(textureMenu, 1, 0, 800, 480, 0, 0, 0);
            currScreen = new ScreenMenu(this, new Background(background,null));
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here

            if (currScreen != currScreen.NextScreen)
            {
                Screen prevscreen = currScreen;
                currScreen = currScreen.NextScreen;
                prevscreen.NextScreen = prevscreen;
            }

            currScreen.Update(gameTime, TouchPanel.GetState());

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            // TODO: Add your drawing code here
            currScreen.Draw(gameTime, spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public ScreenMercury GetNewScreenMercury()
        {
            AnimationFixed background = new AnimationFixed(textureMercury, 1, 0, 800, 480, 0, 0, 0);
            return new ScreenMercury(this, new Background(background, null), null);
        }

        public ScreenVenus GetNewScreenVenus()
        {
            AnimationFixed background = new AnimationFixed(textureVenus, 1, 0, 800, 480, 0, 0, 0);
            return new ScreenVenus(this, new Background(background, null), null);
        }

        public ScreenEarth GetNewScreenEarth()
        {
            AnimationFixed background = new AnimationFixed(textureEarth, 1, 0, 800, 480, 0, 0, 0);
            return new ScreenEarth(this, new Background(background, null), null);
        }

        public ScreenMars GetNewScreenMars()
        {
            AnimationFixed background = new AnimationFixed(textureMars, 1, 0, 800, 480, 0, 0, 0);
            return new ScreenMars(this, new Background(background, null), null);
        }

        public ScreenJupiter GetNewScreenJupiter()
        {
            AnimationFixed background = new AnimationFixed(textureJupiter, 1, 0, 800, 480, 0, 0, 0);
            return new ScreenJupiter(this, new Background(background, null), null);
        }

        public ScreenSaturn GetNewScreenSaturn()
        {
            AnimationFixed background = new AnimationFixed(textureSaturn, 1, 0, 800, 480, 0, 0, 0);
            return new ScreenSaturn(this, new Background(background, null), null);
        }

        public ScreenUranus GetNewScreenUranus()
        {
            AnimationFixed background = new AnimationFixed(textureUranus, 1, 0, 800, 480, 0, 0, 0);
            return new ScreenUranus(this, new Background(background, null), null);
        }

        public ScreenNeptune GetNewScreenNeptune()
        {
            AnimationFixed background = new AnimationFixed(textureNeptune, 1, 0, 800, 480, 0, 0, 0);
            return new ScreenNeptune(this, new Background(background, null), null);
        }

        public ScreenSolarSystem GetNewScreenSolarSystem()
        {
            AnimationFixed background = new AnimationFixed(textureGalaxy, 1, 0, 800, 480, 0, 0, 0);
            //currScreen = new ScreenMercury(this, new Background(background,null), null);
            int scaleMultiplier = 2;
            int centerX = screenRectangle.Width / 2 * scaleMultiplier;
            int centerY = screenRectangle.Height / 2 * scaleMultiplier;
            screenSolarSystem = new ScreenSolarSystem(this, new BackgroundScrollable(background, null, this, 400, 240, scaleMultiplier));
            return screenSolarSystem;
        }
    
    }
}
