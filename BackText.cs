using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace DreamWorld
{
    class BackText : GenericText
    {
        public GenericText backText;

        public BackText() {
            backText = new GenericText();
        }

        public BackText(String text, SpriteFont font, SpriteFont backFont, Color color, int x, int y)
            : base(text, font, color, x, y) {
                backText = new GenericText(text, backFont, Color.Yellow, x, y);
                
        }

        public override void  draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            backText.setText(getText());
            backText.setOpacity(getOpacity());
            backText.setLocation(getX() - 1, getY() - 1);
            backText.draw(spriteBatch);
 	        base.draw(spriteBatch);
        }
    }
}
