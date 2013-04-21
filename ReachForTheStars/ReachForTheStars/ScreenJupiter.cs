using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Input.Touch;


namespace ReachForTheStars
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class ScreenJupiter : ScreenPlanet
    {
        public ScreenJupiter(Game1 game, Background background, List<Button> listButtons) 
            :base (game, background, listButtons)
        {
            // TODO: Construct any child components here
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            background.Draw(gameTime, spriteBatch);
            DrawButtons(gameTime, spriteBatch);

        }



        public override void Update(GameTime gameTime, TouchCollection touchCollection)
        {
            if (touchCollection.Count() > 0)
            {
                //get the first touch
                TouchLocation touch = touchCollection.ElementAt(0);
                if (touch.State == TouchLocationState.Pressed)
                {

                    String command = Helper.GetFirstButtonPressCommand(listButtons, (int)touch.Position.X, (int)touch.Position.Y);

                    if (command.Equals("returnToSolarSystem"))
                    {
                        NextScreen = game.screenSolarSystem;
                    }
                    else if (command.Equals("nasa"))
                    {

                        AnimationFixed background = new AnimationFixed(game.textureJupiterNASAInfo, 1, 0, 800, 480, 0, 0, 0);
                        NextScreen = new ScreenInfo(game, new Background(background, null), null, this);
                    }
                    else if (command.Equals("redspot"))
                    {

                        AnimationFixed background = new AnimationFixed(game.textureJupiterRedSpotInfo, 1, 0, 800, 480, 0, 0, 0);
                        NextScreen = new ScreenInfo(game, new Background(background, null), null, this);
                    }
                    else if (command.Equals("moon"))
                    {

                        AnimationFixed background = new AnimationFixed(game.textureJupiterMoonInfo, 1, 0, 800, 480, 0, 0, 0);
                        NextScreen = new ScreenInfo(game, new Background(background, null), null, this);
                    }
                }
            }
        }

        public override void AddButtons()
        {
            //Add your custom buttons to listButtons
            //Sample: listButtons.Add(new Button());
            this.listButtons.Add(new Button(new Animation(game.textureButton, 102, 74), "button", 12, 150));
            this.listButtons.Add(new Button(new Animation(game.textureButton, 102, 74), "button2", 159, 150));

        }

        public override void SetRocket(int listButtonIndexOfRocket)
        {
            //
        }


    }
}
