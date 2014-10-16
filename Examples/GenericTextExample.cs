using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace DreamWorld.Examples {
    class GenericTextExample : Example {
        GenericText genericText; //Declares the GenericText Object

        public void initialize() {
            genericText = new GenericText("GenericText Example"); //Initialize the GenericText Objet setting her text
            genericText.setColor(Color.White); //Set the Color of text
            genericText.setLocation(200, 200); //Set location for the text
        }

        public void loadContent(ContentManager contentManager) {
            initialize();
            genericText.loadContent(contentManager.Load<SpriteFont>("Examples/font")); //Load the resource font      
        }

        public void update(GameTime gameTime) {
            // Do Nothing or implement your code here
        }

        public void draw(SpriteBatch spriteBatch) {
            genericText.draw(spriteBatch); //Draw the text
        }
    }
}
