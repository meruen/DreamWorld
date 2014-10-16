using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace DreamWorld {
    class GenericSprite : Picture {
        protected int frameCount, currentFrame;
        protected Rectangle mask;
        protected GenericTimeout timer;
        protected bool stopAtEnd = false, ended = false;

        public GenericSprite() {
            mask = new Rectangle();
            timer = new GenericTimeout(.0f);
        }

        public void setFrameCount(int frameCount) {
            this.frameCount = frameCount;
        }

        public int getFrameCount() {
            return frameCount;
        }

        public void setCurrentFrame(int currentFrame) {
            this.currentFrame = currentFrame;
        }

        public int getCurrentFrame()
        {
            return currentFrame;
        }

        public Rectangle getMask() {
            return mask;
        }

        public void setStopAtEnd(bool stopAtEnd) {
            this.stopAtEnd = stopAtEnd;
        }

        public bool isStopAtEnd() {
            return stopAtEnd;
        }

        public bool isEnded()
        {
            return ended;
        }

        public Rectangle getRect()
        {
            return new Rectangle((int)getX(), (int)getY(), getMask().Width, getMask().Height);

        }
      
        public void loadContent(Texture2D texture, int frameCount, int currentFrame, double interval) {
            base.loadContent(texture);
            setFrameCount(frameCount);
            setCurrentFrame(currentFrame);
            timer.setInterval(interval);
            mask.Y = 0;
            mask.Width = texture.Width / frameCount;
            mask.Height = texture.Height;
            updateRect();
        }

        private void updateRect() {
            mask.X = currentFrame * mask.Width;
        }

        public virtual void update(GameTime gameTime) {
            if (stopAtEnd && ended)
                return;

            timer.update(gameTime);

            if (timer.isTimeOuted()) {
                if (currentFrame == frameCount) {
                    currentFrame = 0;
                    ended = true;
                    updateRect();
                } else
                    ended = false;
                
                updateRect();
                currentFrame++;
                return;
            }
        }

        public override void draw(SpriteBatch spriteBatch) {
            if (visible)
                if (inverted)
                    spriteBatch.Draw(texture, location, mask, color, .0f, Vector2.Zero, 1.0f, SpriteEffects.FlipHorizontally, 0);
                else
                    spriteBatch.Draw(texture, location, mask, color, .0f, Vector2.Zero, 1.0f, SpriteEffects.None, 0);
        }
    }
}
