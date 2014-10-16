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
    class SkillDisplay
    {
        public Picture background;

        public SkillDisplay()
        {
            background = new Picture();
        }

        public void loadContent(ContentManager contentManager)
        {
            background.loadContent(contentManager.Load<Texture2D>("abelut/skillshud"));
            background.setLocation(100, 720 - background.getH());
        }

        public void update(GameTime gameTime)
        {

        }

        public void draw(SpriteBatch spriteBatch)
        {
            background.draw(spriteBatch);
        }
    }
}
