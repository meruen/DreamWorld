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
    class Utils
    {
        public static Vector2 getGenericSpriteCenter(GenericSprite picture)
        {
            float x = picture.getX(), y = picture.getY(), w = picture.getW(), h = picture.getH();
            float centerX = x + (w / 2),
                centerY = x + (h / 2);
            return new Vector2(centerX, centerY);
        }

        public static Vector2 getGenericSpriteFoot(GenericSprite picture)
        {
            float x = picture.getX(), y = picture.getY(), w = picture.getW(), h = picture.getH();
            float centerX = x + (w / 2),
                centerY = x + (h - 10);
            return new Vector2(centerX, centerY);
        }
    }
}
