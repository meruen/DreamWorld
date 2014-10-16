using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DreamWorld.Try3
{
    class Character : CharAvatar
    {
        public InputController input, lastInput;
        public bool canMove = true;

        public override void initialize(Vector2 startLocation, int speed) {
            base.initialize(startLocation, speed);
            input = new InputController();

            input.addKey("press-down", new InputKey(Keys.S, InputController.InputType.Press));
            input.addKey("press-up", new InputKey(Keys.W, InputController.InputType.Press));
            input.addKey("pressing-up", new InputKey(Keys.W, InputController.InputType.Pressing));
            input.addKey("pressing-down", new InputKey(Keys.S, InputController.InputType.Pressing));
            input.addKey("hold-up", new InputKey(Keys.W, InputController.InputType.Hold));
            input.addKey("hold-down", new InputKey(Keys.S, InputController.InputType.Hold));
            input.addKey("press-left", new InputKey(Keys.A, InputController.InputType.Press));
            input.addKey("press-right", new InputKey(Keys.D, InputController.InputType.Press));
            input.addKey("pressing-left", new InputKey(Keys.A, InputController.InputType.Pressing));
            input.addKey("pressing-right", new InputKey(Keys.D, InputController.InputType.Pressing));
            input.addKey("hold-left", new InputKey(Keys.A, InputController.InputType.Hold));
            input.addKey("hold-right", new InputKey(Keys.D, InputController.InputType.Hold));
            input.addKey("pressing-ctrl", new InputKey(Keys.LeftControl, InputController.InputType.Press));

            lastInput = input;
        }

        public override void loadContent(ContentManager contentManager) {
            base.loadContent(contentManager);
        }

        public override void update(GameTime gameTime) {
            base.update(gameTime);
            input.update(gameTime);

            if (input.isKeySatisfied("press-down")) {
                position = Position.DOWN;
                sprWalkingDown.setCurrentFrame(0);
            }

            if (input.isKeySatisfied("press-left")) {
                position = Position.LEFT;
                sprWalkingLeft.setCurrentFrame(0);
            }

            if (input.isKeySatisfied("press-right")) {
                position = Position.RIGHT;
                sprWalkingRight.setCurrentFrame(0);
            }

            if (input.isKeySatisfied("pressing-left") && input.isKeySatisfied("pressing-down")) {
                position = Position.LEFT_DOWN;
                state = State.MOVING;
                spriteToDraw = sprDiagonalEsquerdaBaixo;
                speedY = speed;
                speedX = -speed;
            } else if (input.isKeySatisfied("pressing-left") && input.isKeySatisfied("pressing-up")) {
                position = Position.LEFT_UP;
                state = State.MOVING;
                spriteToDraw = sprDiagonalEsquerdaCima;
                speedY = -speed;
                speedX = -speed;
            } else if (input.isKeySatisfied("pressing-right") && input.isKeySatisfied("pressing-up")) {
                position = Position.RIGHT_UP;
                state = State.MOVING;
                spriteToDraw = sprDiagonalDireitaCima;
                speedY = -speed;
                speedX = speed;
            } else if (input.isKeySatisfied("pressing-right") && input.isKeySatisfied("pressing-down")) {
                position = Position.RIGHT_DOWN;
                state = State.MOVING;
                spriteToDraw = sprDiagonalDireitaBaixo;
                speedY = speed;
                speedX = speed;
            } else if (input.isKeySatisfied("pressing-down")) {
                position = Position.DOWN;
                state = State.MOVING;
                spriteToDraw = sprWalkingDown;
                speedY = speed;
            } else if (input.isKeySatisfied("pressing-left")) {
                position = Position.LEFT;
                state = State.MOVING;
                spriteToDraw = sprWalkingLeft;
                speedX = -speed;
            } else if (input.isKeySatisfied("pressing-right")) {
                position = Position.RIGHT;
                state = State.MOVING;
                spriteToDraw = sprWalkingRight;
                speedX = speed;
            } else if (input.isKeySatisfied("press-up")) {
                position = Position.UP;
                sprWalkingUp.setCurrentFrame(0);
            } else if (input.isKeySatisfied("pressing-up")) {
                position = Position.UP;
                state = State.MOVING;
                spriteToDraw = sprWalkingUp;
                speedY = -speed;
            }

            if ((input.isKeySatisfied("hold-down") && input.isKeySatisfied("hold-left"))
                || (input.isKeySatisfied("hold-down") && lastInput.isKeySatisfied("hold-left"))
                || (input.isKeySatisfied("hold-left") && lastInput.isKeySatisfied("hold-down"))) {
                position = Position.LEFT_DOWN;
                state = State.STOPED;
            } else if ((input.isKeySatisfied("hold-down") && input.isKeySatisfied("hold-right"))
                || (input.isKeySatisfied("hold-down") && lastInput.isKeySatisfied("hold-right"))
                || (input.isKeySatisfied("hold-right") && lastInput.isKeySatisfied("hold-down"))) {
                position = Position.RIGHT_DOWN;
                state = State.STOPED;
            } else if (input.isKeySatisfied("hold-up")) {
                position = Position.UP;
                state = State.STOPED;
            } else if (input.isKeySatisfied("hold-down")) {
                if (lastPosition != Position.LEFT_DOWN)
                    position = Position.DOWN;
                state = State.STOPED;
            } else if (input.isKeySatisfied("hold-left")) {
                if (lastPosition != Position.LEFT_DOWN)
                    position = Position.LEFT;
                state = State.STOPED;
            } else if (input.isKeySatisfied("hold-right")) {
                if (lastPosition != Position.RIGHT_DOWN)
                    position = Position.RIGHT;
                state = State.STOPED;
            }

            if (state == State.STOPED)
                speedX = speedY = 0;

            x += speedX;
            y += speedY;
            lastInput = input;
        }

        public override void draw(SpriteBatch spriteBatch) {
            base.draw(spriteBatch);
        }
    }
}
