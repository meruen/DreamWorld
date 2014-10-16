using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DreamWorld.Examples {
    class LetterTextExample : Example {
        LetterText letterText; //Declares the LetterText object
        const double textSpeed = 100.0; //Declares a constant speed for the text

        public void initialize() {
            letterText = new LetterText("LetterText Example"); //Initialize the letterText object setting the text
            letterText.setColor(Color.White); //Set the Color of the text
            letterText.setLocation(200, 200); //Set location for the text
            letterText.setTimeout(new GenericTimeout(textSpeed)); //Set the TextSpeed for the text
        }

        public void loadContent(ContentManager contentManager) {
            initialize();
            letterText.loadContent(contentManager.Load<SpriteFont>("Examples/font")); //Load the resource font
        }

        public void update(GameTime gameTime) {
            letterText.update(gameTime); //Update the letterText object
        }

        public void draw(SpriteBatch spriteBatch) {
            letterText.draw(spriteBatch); //Draw the text on screen
        }
    }
}
