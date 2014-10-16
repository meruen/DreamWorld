using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DreamWorld {
    class WaitAction : DrawableAction {
        protected GenericTimeout timeOut;

        public override void update(GameTime gameTime) {
            if (running && !finished) {
                timeOut.update(gameTime);
                if (timeOut.isTimeOuted())
                    finish();
            }
        }

        public void initialize(GenericTimeout timeOut) {
            base.initialize(null);
            this.timeOut = timeOut;
        }

        public override void draw(SpriteBatch spriteBatch) {
            // Do Nothing.
        }
    }
}
