using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace DreamWorld {
    /// <summary>
    /// This class is a basic way to manage Interactive Common Objects.
    /// </summary>
    class BaseObject {
        protected Vector2 location;
        protected float w, h;
        protected bool visible = true;
        protected Rectangle rectBounds;

        /// <summary>
        /// Default constructor that does not give arguments.
        /// </summary>
        public BaseObject() {
            rectBounds = new Rectangle();
        }

        /// <summary>
        /// Common constructor that informs all the basic needed attributes of <c>BaseObject</c> Class.
        /// </summary>
        /// <param name="x">Based Left-Right location.</param>
        /// <param name="y">Based Up-Down location.</param>
        /// <param name="w">Width.</param>
        /// <param name="h">Height.</param>
        public BaseObject(float x, float y, float w, float h) {
            setX(x);
            setY(y);
            setW(w);
            setH(h);
            rectBounds = new Rectangle((int)x, (int)y, (int)w, (int)h);
        }

        /// <summary>
        /// Set's the <c>X</c> variant on <c>location</c>.
        /// </summary>
        /// <param name="x">Based Left-Right location.</param>
        public void setX(float x) {
            this.location.X = x;
        }

        /// <summary>
        /// Get the based left-right location.
        /// </summary>
        /// <returns>Based Left-Right location.</returns>
        public float getX() {
            return location.X;
        }

        /// <summary>
        /// Set the <c>Y</c> variant on <c>location</c>.
        /// </summary>
        /// <param name="y">Based Up-Down location.</param>
        public void setY(float y) {
            this.location.Y = y;
        }

        /// <summary>
        /// Get the based Up-Down location.
        /// </summary>
        /// <returns>Based Up-Down location.</returns>
        public float getY() {
            return location.Y;
        }

        /// <summary>
        /// Get the absolute location of the <c>BaseObject</c>.
        /// </summary>
        /// <returns><c>location</c> of the<c>BaseObject</c>.</returns>
        public Vector2 getLocation() {
            return location;
        }

        /// <summary>
        /// Set the absolute location of <c>BaseObject</c>.
        /// </summary>
        /// <param name="location">Location of the object.</param>
        public void setLocation(Vector2 location) {
            this.location = location;
        }

        /// <summary>
        /// Set the absolute location of <c>BaseObject</c>.
        /// </summary>
        /// <param name="x">X Coordinate.</param>
        /// <param name="y">Y Coordinate.</param>
        public void setLocation(float x, float y) {
            this.location = new Vector2(x, y);
        }

        /// <summary>
        /// Increment or decrement the X Coordinate of <c>location</c>.
        /// </summary>
        /// <param name="increment">Value of increment (Negative if is a decrement).</param>
        /// <returns>The value incremented.</returns>
        public float incrementX(float increment) {
            location.X += increment;
            return location.X;
        }

        /// <summary>
        /// Increment or decrement the Y Coordinate of <c>location</c>.
        /// </summary>
        /// <param name="increment">Value of increment (Negative if is a decrement).</param>
        /// <returns>The value incremented.</returns>
        public float incrementY(float increment) {
            location.Y += increment;
            return location.Y;
        }

        /// <summary>
        /// Increment or decrease the Location.
        /// </summary>
        /// <param name="increment">New location.</param>
        /// <returns></returns>
        public Vector2 incrementLocation(Vector2 increment) {
            location += increment;
            return location;
        }

        /// <summary>
        /// Set the Width of the <c>BaseObject</c>.
        /// </summary>
        /// <param name="w">Width.</param>
        public void setW(float w) {
            this.w = w;
        }

        /// <summary>
        /// Get the Width of the <c>BaseObject</c>.
        /// </summary>
        /// <returns>Width.</returns>
        public float getW() {
            return w;
        }

        /// <summary>
        /// Set the Height of the <c>BaseObject</c>.
        /// </summary>
        /// <param name="h">Height.</param>
        public void setH(float h) {
            this.h = h;
        }

        /// <summary>
        /// Get the Height of the <c>BaseObject</c>.
        /// </summary>
        /// <returns>Height.</returns>
        public float getH() {
            return h;
        }

        /// <summary>
        /// Set the absolute size of <c>BaseObject</c>
        /// </summary>
        /// <param name="w">Width</param>
        /// <param name="h">Height</param>
        public void setSize(float w, float h) {
            setW(w);
            setH(h);
        }

        /// <summary>
        /// Set the <c>BaseObject</c> visible or invisible.
        /// </summary>
        /// <param name="visible">Value of visibility.</param>
        public void setVisible(bool visible) {
            this.visible = visible;
        }

        /// <summary>
        /// Get the <c>BaseObject</c> visible attribute.
        /// </summary>
        /// <returns><c>visible</c> atribute.</returns>
        public bool isVisible() {
            return visible;
        }

        public Rectangle getRectBounds() {
            rectBounds.X = (int)location.X;
            rectBounds.Y = (int)location.Y;
            rectBounds.Width = (int)w;
            rectBounds.Height = (int)h;
            return rectBounds;
        }
    }
}
