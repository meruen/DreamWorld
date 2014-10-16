using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace DreamWorld.Examples {
    class MoveActionExample : Example {
        MoveAction moveAction; //Declares a MoveAction Object.
        Picture picture; //Declares a Picture that will be moved.
        XboxInputController inputController; //Declares a XboxInputController Object that will verify the current status of the controller and start the movement.

        public void initialize() {
            inputController = new XboxInputController(); //Initializes the inputController.
            inputController.addKey("rt_press", new InputXboxKey(Buttons.RightTrigger, InputController.InputType.Press)); //Add the RT key to the inputController.
            inputController.addKey("lt_press", new InputXboxKey(Buttons.LeftTrigger, InputController.InputType.Press)); //Add the LT key to the inputController.

            picture = new Picture(); //Initializes the picture.
            picture.setLocation(200, 200); //Set the picture's location.
            moveAction = new MoveAction(); //Initialize the moveAction Object.
            moveAction.setRunning(false); //Set the running attribute to false.
        }

        public void loadContent(ContentManager contentManager) {
            initialize();
            picture.loadContent(contentManager.Load<Texture2D>("Examples/ironball")); //Load de resource picture.
        }

        public void update(GameTime gameTime) {
            inputController.update(gameTime); //Update the inputController.

            if (moveAction.isRunning()) //If the moveAction is running...
                moveAction.update(gameTime); //Update the moveAction.
            else { //If not...
                if (inputController.isKeySatisfied("rt_press")) //If RT are being pressed...
                    moveAction.initialize(picture, new Vector2(picture.getX() + 30, 0), new Vector2(2, 0), 20); //Initialize the movement for 30 pixels on speed 2 for the right.
                else if (inputController.isKeySatisfied("lt_press")) //Else... If LT are being pressed...
                    moveAction.initialize(picture, new Vector2(picture.getX() - 30, 0), new Vector2(-2, 0), 20); //Initialize the movement for 30 pixels on speed -2 for the left.
            }
        }

        public void draw(SpriteBatch spriteBatch) {
            picture.draw(spriteBatch); //Draw the picture on screen.
        }
    }
}
