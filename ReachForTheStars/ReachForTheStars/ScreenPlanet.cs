using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;

namespace ReachForTheStars
{
    public abstract class ScreenPlanet: Screen
    {
        public static Rectangle rocketRectangle = new Rectangle(700, 100, 50, 200); 
        public List<Button> listButtons;

        public ScreenPlanet(Game1 game, Background background, List<Button> listButtons) 
            :base(game, background)
        {
            this.listButtons = listButtons;
            if(this.listButtons == null)
                this.listButtons = new List<Button>() ;

            int x = rocketRectangle.X;
            int y = rocketRectangle.Y;
            int displayWidth = rocketRectangle.Width;
            int displayHeight = rocketRectangle.Height;
            Texture2D rocketTexture = game.textureRocket;
            this.listButtons.Add(new Button(new Animation(rocketTexture, displayWidth, displayHeight), null,  "returnToSolarSystem", x, y, "Return to Solar System", game.arialFont,Button.STRING_CENTER, Color.White));

            AddButtons();
            SetRocket(this.listButtons.Count-1);
        }

        public void DrawButtons(GameTime gameTime, SpriteBatch spriteBatch) 
        {
            //System.Diagnostics.Debug.WriteLine()
            foreach (Button button in listButtons)
            {
                button.Draw(gameTime, spriteBatch);
            }
        }

        public abstract void AddButtons();
        public abstract void SetRocket(int listButtonIndexOfRocket);
        public override abstract void Update(GameTime gameTime, TouchCollection touchCollection);
        public override abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);
    }
}
