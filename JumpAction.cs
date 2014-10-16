using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DreamWorld {
    class JumpAction : GenericAction {
        protected bool jumping;
        protected BaseObject baseObject;
        protected float startY, jumpSpeed;

        public JumpAction() {
        }

        public void start(float jumpSpeed) {
            base.start();
            setJumpSpeed(jumpSpeed);
            jumping = true;
        }

        public void initialize(BaseObject parent) {
            base.initialize(parent);
            this.baseObject = parent;

            jumping = false;
            startY = parent.getY();

            jumpSpeed = 0;
        }

        public override void update(GameTime gameTime) {
            if (jumping) {
                baseObject.setY(baseObject.getY() + jumpSpeed);
                jumpSpeed += 0.25f;

                if (baseObject.getY() >= startY) {
                    baseObject.setY(startY);
                    jumping = false;
                    finish();
                }
            }
        }

        public void setJumpSpeed(float jumpSpeed) {
            this.jumpSpeed = jumpSpeed;
        }

        public float getJumpSpeed() {
            return jumpSpeed;
        }

        public void setJumping(bool jumping) {
            this.jumping = jumping;
        }

        public bool isJumping() {
            return jumping;
        }

        public bool isFalling() {
            if (jumpSpeed > 0)
                return true;
            return false;
        }

        public float getStartY() {
            return startY;
        }

        public void setStartY(float startY) {
            this.startY = startY;
        }
    }
}
