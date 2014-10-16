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
    class CustomCursor : DrawableObject
    {
        
        public Picture cursor;

        public CustomCursor()
        {
            cursor = new Picture();
        }

        public void loadContent(ContentManager contentManager)
        {
            cursor.loadContent(contentManager.Load<Texture2D>("Tests/cursorblue"));

        }

        public void update()
        {
            //MouseState state = Mouse.GetState()
            //cursor.setLocation(Mouse
        }

        public void draw(SpriteBatch spriteBatch)
        {

        }


    }
}
