using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DreamWorld.Examples {
    interface Example {
        void initialize();
        void loadContent(ContentManager contentManager);
        void update(GameTime gameTime);
        void draw(SpriteBatch spriteBatch);
    }
}
