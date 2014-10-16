using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DreamWorld.Examples {
    class XboxInputControllerExample : Example {
        XboxInputController inputController; 
        Picture picture;
        const float speed = 3;

        public void initialize() {
            picture = new Picture();
            picture.setLocation(200, 200);

            inputController = new XboxInputController();

            inputController.addKey("pressing_left", new InputXboxKey(Buttons.DPadLeft, InputController.InputType.Pressing));
            inputController.addKey("pressing_right", new InputXboxKey(Buttons.DPadRight, InputController.InputType.Pressing));
            inputController.addKey("pressing_up", new InputXboxKey(Buttons.DPadUp, InputController.InputType.Pressing));
            inputController.addKey("pressing_down", new InputXboxKey(Buttons.DPadDown, InputController.InputType.Pressing));

            inputController.addStickKey("pressing_stick_left", new XboxInputSticks(XboxInputSticks.InputCondition.Left));
            inputController.addStickKey("pressing_stick_right", new XboxInputSticks(XboxInputSticks.InputCondition.Right));
            inputController.addStickKey("pressing_stick_up", new XboxInputSticks(XboxInputSticks.InputCondition.Up));
            inputController.addStickKey("pressing_stick_down", new XboxInputSticks(XboxInputSticks.InputCondition.Down));
        }

        public void loadContent(ContentManager contentManager) {
            initialize();
            picture.loadContent(contentManager.Load<Texture2D>("Examples/ironball"));
        }

        public void update(GameTime gameTime) {
            inputController.update(gameTime);

            if (inputController.isKeySatisfied("pressing_left") || inputController.isStickSatisfied("pressing_stick_left"))
                picture.incrementX(-speed);
            if (inputController.isKeySatisfied("pressing_right") || inputController.isStickSatisfied("pressing_stick_right"))
                picture.incrementX(speed);
            if (inputController.isKeySatisfied("pressing_up") || inputController.isStickSatisfied("pressing_stick_up"))
                picture.incrementY(-speed);
            if (inputController.isKeySatisfied("pressing_down") || inputController.isStickSatisfied("pressing_stick_down"))
                picture.incrementY(speed);
        }

        public void draw(SpriteBatch spriteBatch) {
            picture.draw(spriteBatch);
        }
    }
}
