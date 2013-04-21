using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;

namespace ReachForTheStars
{
    public class ScreenMercury: ScreenPlanet
    {

        public Texture2D textureButton;

        public ScreenMercury(Game1 game, Background background, List<Button> listButtons) 
            :base (game, background, listButtons)
        {
            
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
                    else if (command.Equals("button"))
                    {

                        AnimationFixed background = new AnimationFixed(game.textureBackground, 1, 0, 800, 480, 0, 0, 0);
                        NextScreen = new ScreenInfo(game, new Background(background, null), null, this);
                    }
                    else if (command.Equals("button2"))
                    {

                        AnimationFixed background = new AnimationFixed(game.textureBackground2, 1, 0, 800, 480, 0, 0, 0);
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
