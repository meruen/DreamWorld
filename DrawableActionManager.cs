using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace DreamWorld {
    /// <summary>
    /// This class implements the ActionManager adding the method <c>draw(SpriteBatch)</c>.
    /// </summary>
    class DrawableActionManager : ActionManager, DrawableObject {
        /// <summary>
        /// <c>draw(SpriteBatch)</c> method for the proccessment of the DrawableActions.
        /// </summary>
        /// <param name="spriteBatch">Basic SpriteBatch parameter.</param>
        public void draw(SpriteBatch spriteBatch) {
            if (currentAction != null)
                ((DrawableAction)currentAction).draw(spriteBatch);
        }
    }
}
