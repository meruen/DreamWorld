using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DreamWorld.Examples {
    class PictureExample : Example {

        Picture picture; //Declares a Picture Object

        public void initialize() {
            picture = new Picture(); //Create the Object
            picture.setLocation(200, 200); //Set the location for the Picture
            picture.setColor(Color.White); //Set the main Color for picture
            picture.setInverted(false); //Set inversion parameter for picture
        }

        public void loadContent(ContentManager contentManager) {
            initialize();
            picture.loadContent(contentManager.Load<Texture2D>("Examples/ironball")); //Load the resource picture
        }

        public void update(GameTime gameTime) {
            // Do Nothing or implement your code here
        }

        public void draw(SpriteBatch spriteBatch) {
            picture.draw(spriteBatch); //Draw the Picture
        }
    }
}
