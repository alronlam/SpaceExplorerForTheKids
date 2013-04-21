using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;

namespace ReachForTheStars
{
    class ScreenInfo: Screen
    {
         public List<Button> listButtons;
         Screen prevScreen;

        public ScreenInfo(Game1 game, Background background, List<Button> listButtons, Screen prevScreen) 
            :base(game, background)
        {
            this.prevScreen = prevScreen;
            if(listButtons == null)
                listButtons = new List<Button>();

            this.listButtons = listButtons;
            listButtons.Add(new Button(new Animation(game.textureBack, 80, 70), "back", 0, 0));
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

                    if (command.Equals("back"))
                    {

                        AnimationFixed background = new AnimationFixed(game.textureMercury, 1, 0, 800, 480, 0, 0, 0);
                        NextScreen = prevScreen;
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
