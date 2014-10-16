using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace DreamWorld {
    abstract class DrawableAction : GenericAction {
        public abstract void draw(SpriteBatch spriteBatch);
    }
}
