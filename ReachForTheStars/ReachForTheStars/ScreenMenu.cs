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
    public class ScreenMenu : Screen
    {
         public List<Button> listButtons;
         Screen prevScreen;

        public ScreenMenu(Game1 game, Background background) 
            :base(game, background)
        {
            if(listButtons == null)
                listButtons = new List<Button>();

            this.listButtons.Add(new Button(new Animation(game.texturePlay, 216, 66), "play", 289, 191));
            this.listButtons.Add(new Button(new Animation(game.textureAbout, 216, 66), "about", 289, 266));
        }

        public override void Update(GameTime gameTime, TouchCollection touchCollection)
        {
            if (touchCollection.Count() > 0)
            {
                //get the first touch
                TouchLocation touch = touchCollection.ElementAt(0);
                if(touch.State == TouchLocationState.Pressed)
                {

                    String command = Helper.GetFirstButtonPressCommand(listButtons, (int)touch.Position.X, (int)touch.Position.Y);

                    if (command.Equals("play"))
                    {

                        AnimationFixed background = new AnimationFixed(game.textureMercury, 1, 0, 800, 480, 0, 0, 0);
                        NextScreen = game.GetNewScreenSolarSystem();
                    }
                        
                    else if (command.Equals("about"))
                    {

                        AnimationFixed background = new AnimationFixed(game.textureAboutBackground, 1, 0, 800, 480, 0, 0, 0);
                        NextScreen = new ScreenInfo(game, new Background(background, null), null, this);
                    }
                }
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch) 
        {
            background.Draw(gameTime, spriteBatch);
            DrawButtons(gameTime, spriteBatch);
        }

        public void DrawButtons(GameTime gameTime, SpriteBatch spriteBatch) 
        {
            foreach (Button button in listButtons)
            {
                button.Draw(gameTime, spriteBatch);
            }
        }

    }
}
