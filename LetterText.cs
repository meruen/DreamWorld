using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DreamWorld {
    class LetterText : GenericText {
        protected String currentText = "";
        protected int charPosition = 0;
        protected bool ended = false;
        protected GenericTimeout timeout;

        public LetterText(String text)
            : base(text) {
                timeout = new GenericTimeout();
        }

        public LetterText(String text, GenericTimeout timeOut)
            : base(text) {
                timeout = timeOut;
        }

        public String getCurrentText() {
            return currentText;
        }

        public int getCharPosition() {
            return charPosition;
        }

        public bool isEnded() {
            return ended;
        }

        public void setTimeout(GenericTimeout timeout) {
            this.timeout = timeout;
        }

        public GenericTimeout getTimeout() {
            return timeout;
        }

        public void restart() {
            charPosition = 0;
            currentText = "";
            ended = false;
        }

        public void update(GameTime gameTime) {
            if (!ended) {
                timeout.update(gameTime);

                if (timeout.isTimeOuted()) {
                    if (++charPosition == text.Length) {
                        ended = true;
                        return;
                    }
                    currentText = text.Substring(0, charPosition + 1);
                }

            }
        }

        public override void draw(SpriteBatch spriteBatch) {
            spriteBatch.DrawString(font, currentText, location, color);
        }
    }
}
