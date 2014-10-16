using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace DreamWorld {
    /// <summary>
    /// This interface is used for class that needs the implementation of method <c>draw(SpriteBatch)</c>.
    /// </summary>
    interface DrawableObject {
        /// <summary>
        /// Method <c>draw</c> that needs to be implemented on the child classes.
        /// </summary>
        /// <param name="spriteBatch"></param>
        void draw(SpriteBatch spriteBatch);
    }
}
