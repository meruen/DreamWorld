using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DreamWorld.Examples {
    class GenericSpriteExample : Example {
        GenericSprite genericSprite; //Declares the GenericSprite Object

        public void initialize() {
            genericSprite = new GenericSprite(); //Initialize the genericSprite Object
            genericSprite.setLocation(200, 200); //Set the location for the genericSprite Object.
        }

        public void loadContent(ContentManager contentManager) {
            initialize();
            genericSprite.loadContent(contentManager.Load<Texture2D>("Examples/indiana"), 10, 0, 50); //Load the Texture2D and set the FRAME_COUNT, CURRENT_FRAME and INTERVAL (AnimationSpeed)
        }

        public void update(GameTime gameTime) {
            genericSprite.update(gameTime); //Update the genericSprite Object
        }

        public void draw(SpriteBatch spriteBatch) {
            genericSprite.draw(spriteBatch); //Draw genericSprite Object
        }
    }
}
