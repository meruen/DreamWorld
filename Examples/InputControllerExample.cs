using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DreamWorld.Examples {
    class InputControllerExample : Example {
        Picture picture; //Declares the Picture Object that will be used to example for the InputController
        InputController inputController; //Declares the InputController Object
        const float speed = 1; //Object Speed

        public void initialize() {
            picture = new Picture(); //Initializes the Picture Object
            inputController = new InputController(); //Initializes InputController

            //Add's the used Key's to the Dictionary of input's of InputKey's
            inputController.addKey("pressing_left", new InputKey(Keys.Left, InputController.InputType.Pressing));
            inputController.addKey("pressing_right", new InputKey(Keys.Right, InputController.InputType.Pressing));
            inputController.addKey("pressing_up", new InputKey(Keys.Up, InputController.InputType.Pressing));
            inputController.addKey("pressing_down", new InputKey(Keys.Down, InputController.InputType.Pressing));
        }

        public void loadContent(ContentManager contentManager) {
            picture.loadContent(contentManager.Load<Texture2D>("Examples/ironball")); //Load the resource Picture
        }

        public void update(GameTime gameTime) {
            if (inputController.isKeySatisfied("pressing_left")) //If Key LEFT is pressed
                picture.incrementX(-speed); //Move to LEFT
            if (inputController.isKeySatisfied("pressing_right")) //If Key RIGHT is pressed
                picture.incrementX(speed); //Move to RIGHT
            if (inputController.isKeySatisfied("pressing_up")) //If Key UP is pressed
                picture.incrementY(-speed); //Move to UP
            if (inputController.isKeySatisfied("pressing_down")) //If Key DOWN is pressed
                picture.incrementY(speed); //Move to DOWN
        }

        public void draw(SpriteBatch spriteBatch) {
            picture.draw(spriteBatch); //Draw the picture on Screen
        }
    }
}
