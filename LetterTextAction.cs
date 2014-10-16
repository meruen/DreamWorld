using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DreamWorld {
    class LetterTextAction : DrawableAction {
        protected LetterText letterText;

        public LetterTextAction(LetterText letterText) {
            this.letterText = letterText;
        }

        public override void update(GameTime gameTime) {
            if (!isFinished() && isRunning()) {
                letterText.update(gameTime);
                if (letterText.isEnded())
                    finish();
            }
        }

        public override void draw(SpriteBatch spriteBatch) {
            letterText.draw(spriteBatch);
        }

        public void setLetterText(LetterText letterText) {
            this.letterText = letterText;
        }

        public LetterText getLetterText() {
            return letterText;
        }
    }
}
