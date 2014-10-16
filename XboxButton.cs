using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace DreamWorld {
    class XboxButton : Picture {
        String button;
        GenericTimeout fadeIn, fadeOut;
        bool fadeInRunning = true;

        public XboxButton(String button) {
            setButton(button);
            fadeOut = new GenericTimeout(GenericTimeout.DEFAULT_INTERVAL_VALUE);
        }

        public void setButton(String button) {
            this.button = button;
        }

        public String getButton() {
            return button;
        }

        public void loadContent(ContentManager contentManager) {
            base.loadContent(contentManager.Load<Texture2D>(button));
        }

        public void update(GameTime gameTime) {
            if (visible) {
                if (fadeInRunning) {
                    fadeIn.update(gameTime);

                } else
                    fadeOut.update(gameTime);
            }

        }           

        public void start() {
            fadeInRunning = true;
            fadeIn = new GenericTimeout(GenericTimeout.DEFAULT_INTERVAL_VALUE);
        }
    }
}
