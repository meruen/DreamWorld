using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DreamWorld.Examples {
    class JumpActionExample : Example {
        public JumpAction jumpAction;
        public Picture picture;
        public XboxInputController inputController;

        public void initialize() {
            picture = new Picture();
            jumpAction = new JumpAction();
            jumpAction.initialize(picture);
            picture.setLocation(200, 300);

            inputController = new XboxInputController();
            inputController.addKey("start_press_a", new InputXboxKey(Buttons.A, InputController.InputType.Press));
            inputController.addStickKey("left_stick", new XboxInputSticks(XboxInputSticks.InputCondition.Left));
            inputController.addStickKey("right_stick", new XboxInputSticks(XboxInputSticks.InputCondition.Right));
            
            jumpAction.finish();
        }

        public void update(GameTime gameTime) {
            inputController.update(gameTime);

            if (jumpAction.isRunning())
                jumpAction.update(gameTime);
            else if (inputController.isKeySatisfied("start_press_a")) {
                jumpAction.initialize(picture);
                jumpAction.start(-7);
            }
            

            if (inputController.isStickSatisfied("left_stick"))
                picture.incrementX(-3);
            if (inputController.isStickSatisfied("right_stick"))
                picture.incrementX(3);
                
        }

        public void loadContent(ContentManager contentManager) {
            initialize();
            picture.loadContent(contentManager.Load<Texture2D>("Examples/ironball"));
            jumpAction.initialize(picture);
        }

        public void draw(SpriteBatch spriteBatch) {
            picture.draw(spriteBatch);
        }
    }
}
