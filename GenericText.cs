using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace DreamWorld {
    class GenericText : BaseObject, DrawableObject {
        protected String text;
        protected SpriteFont font;
        protected Color color = Color.White;
        protected float opacity = 1.0f;

        public GenericText() {
        }

        public GenericText(String text) : base(0, 0, 0, 0) {
            setText(text);
        }

        public GenericText(String text, SpriteFont font)
            : base(0, 0, 0, 0) {
                setText(text);
                setFont(font);
        }

        public GenericText(String text, SpriteFont font, Color color)
            : base(0, 0, 0, 0) {
                setText(text);
                setFont(font);
                setColor(color);
        }

        public GenericText(String text, SpriteFont font, Color color, int x, int y) : base(x, y, 0, 0)  {
            setText(text);
            setFont(font);
            setColor(color);
        }

        public GenericText(String text, Rectangle rect)
            : base(rect.X, rect.Y, rect.Width, rect.Height) {
                setText(text);
        }

        public void setText(String text) {
            this.text = text;
        }

        public String getText() {
            return text;
        }

        public void setFont(SpriteFont font) {
            this.font = font;
        }

        public SpriteFont getFont() {
            return font;
        }

        public void setColor(Color color) {
            this.color = color;
        }

        public Color getColor() {
            return color;
        }

        public float getOpacity() {
            return opacity;
        }

        public void setOpacity(float opacity) {
            this.opacity = opacity;
        }

        public void loadContent(SpriteFont font) {
            setFont(font);
        }

        public virtual void draw(SpriteBatch spriteBatch) {
            if (visible)
                spriteBatch.DrawString(font, text, location, color * opacity);
        }
    }
}
