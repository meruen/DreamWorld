using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace DreamWorld {
    class GenericActor : BaseObject {
        private State state;
        private Direction direction;
        public JumpAction jumpAction;
        private float moveSpeed, baseGravityY = 0f, baseJumpSpeed = -7;

        public enum State {
            Stand, 
            Jumping,
            Falling, 
            Moving
        }

        public enum Direction {
            Left, 
            Right
        }

        public GenericActor(State state, Direction direction, Vector2 location, float moveSpeed, float baseJumpSpeed) {
            this.state = state;
            this.direction = direction;
            this.moveSpeed = moveSpeed;
            this.baseJumpSpeed = baseJumpSpeed;
            jumpAction = new JumpAction();
            setLocation(location);
        }

        public void setState(State state) {
            this.state = state;
        }

        public State getState() {
            return state;
        }

        public void setDirection(Direction direction) {
            this.direction = direction;
        }

        public Direction getDirection() {
            return direction;
        }

        public void setMoveSpeed(float moveSpeed) {
            this.moveSpeed = moveSpeed;
        }

        public float getMoveSpeed() {
            return moveSpeed;
        }

        public void setBaseGravityY(float baseGravityY) {
            this.baseGravityY = baseGravityY;
        }

        public float getBaseGravityY() {
            return baseGravityY;
        }

        public void setBaseJumpSpeed(float baseJumpSpeed) {
            this.baseJumpSpeed = baseJumpSpeed;
        }

        public float getBaseJumpSpeed() {
            return baseJumpSpeed;
        }

        public void jump(float jumpSpeed) {
            if (jumpSpeed == 0)
                return;
            if (jumpSpeed <= 0) {
                state = State.Jumping;
                jumpAction.start(-getBaseJumpSpeed());
            } else {
                state = State.Falling;
                jumpAction.start(getBaseJumpSpeed());
            }           
        }
    }
}
