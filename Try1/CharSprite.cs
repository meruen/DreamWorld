using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DreamWorld;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace DreamWorld.Try1
{
    class CharSprite : GenericSprite
    {
        public Picture head = null;

        public void loadContent(Texture2D texture, int frameCount, int currentFrame, float interval) {
            base.loadContent(texture, frameCount, currentFrame, interval);
        }

        public void loadContent(Texture2D texture, Texture2D headTexture, int frameCount, int currentFrame, float interval)
        {
            base.loadContent(texture, frameCount, currentFrame, interval);
            head = new Picture();
            head.loadContent(headTexture);
        }

        public override void draw(SpriteBatch spriteBatch)
        {
            base.draw(spriteBatch);
            if (head != null)
            {
                head.setLocation(this.getLocation());
                head.draw(spriteBatch);
            }
        }
    }
}
