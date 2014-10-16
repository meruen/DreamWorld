using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace DreamWorld {
    /// <summary>
    /// Basic Picture class. This will allow to show simple Pictures on the screen.
    /// </summary>
    class Picture : BaseObject, DrawableObject {
        protected Texture2D texture;
        protected Color color = Color.White;
        protected bool inverted = false;
        public Rectangle rect;

        /// <summary>
        /// Basic Constructor.
        /// </summary>
        public Picture() {
            
        }

        /// <summary>
        /// Basic constructor that specifies the ColorKey of the Picture.
        /// </summary>
        /// <param name="color">ColorKey.</param>
        public Picture(Color color) {
            this.color = color;
        }

        /// <summary>
        /// Set the <c>Texture2D</c> Object and the basic parameters.
        /// </summary>
        /// <param name="texture"><c>Texture2D</c> Object</param>
        public virtual void loadContent(Texture2D texture) {
            this.texture = texture;
            setH(texture.Height);
            setW(texture.Width);
            rect = new Rectangle(0, 0, (int)getW(), (int)getH());
            
        }

        /// <summary>
        /// Set the ColorKey of the Picture.
        /// </summary>
        /// <param name="color">ColorKey</param>
        public void setColor(Color color) {
            this.color = color;
        }

        /// <summary>
        /// Get the ColorKey from Picture.
        /// </summary>
        /// <returns>ColorKey</returns>
        public Color getColor() {
            return color;
        }

        /// <summary>
        /// Set the <c>inverted</c> attribute to Picture. This will change the way of showed picture.
        /// </summary>
        /// <param name="inverted">Inverted attribute.</param>
        public void setInverted(bool inverted) {
            this.inverted = inverted;
        }

        /// <summary>
        /// Get the <c>inverted</c> attribute from Picture.
        /// </summary>
        /// <returns>Inverted Attribute</returns>
        public bool isInverted() {
            return inverted;
        }

        /// <summary>
        /// Get the <c>Texture2D</c> used on the Picture.
        /// </summary>
        /// <returns><c>Texture2D</c> that represents the Picture.</returns>
        public Texture2D getTexture() {
            return texture;
        }

        /// <summary>
        /// Draw function that will draw the picture with the respective attributes on the screen.
        /// </summary>
        /// <param name="spriteBatch"><c>SpriteBatch</c> that will draw the Picture.</param>
        public virtual void draw(SpriteBatch spriteBatch) {
            if (isVisible())
                if (inverted)
                    spriteBatch.Draw(texture, location, rect, color, .0f, Vector2.Zero, 1.0f, SpriteEffects.FlipHorizontally, .0f);
                else
                    spriteBatch.Draw(texture, location, rect, color, .0f, Vector2.Zero, 1.0f, SpriteEffects.None, .0f);
        }
    }
}
