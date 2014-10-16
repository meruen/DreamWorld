using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace DreamWorld.Try4
{
    class DamageDisplay
    {
        protected BaseObject target;
        protected List<BackText> objects, backObjects;
        private Random rd;
        private float opacityDecrement = 0.01f;
        protected SpriteFont font, backFont;


        public DamageDisplay(BaseObject target) {
            this.target = target;
            objects = new List<BackText>();
            backObjects = new List<BackText>();
            rd = new Random();
        }

        public void loadContent(ContentManager contentManager) {
            font = contentManager.Load<SpriteFont>("Examples/segoe");
            backFont = contentManager.Load<SpriteFont>("Examples/segoe_back");
        }

        public void damage(int value, bool is_critical) {
            BackText text, backText;
            if (value == 0) {
                text = new BackText("Miss!!", font, font, Color.DarkBlue, (int)target.getX() + rd.Next(0, (int)target.getW()), (int)target.getY() + rd.Next(0, 20));
               // text.backText = new GenericText();
            } else if (is_critical) {
                text = new BackText(value.ToString() + "!!", font, font, Color.DarkGoldenrod, (int)target.getX() + rd.Next(0, (int)target.getW()), (int)target.getY() + rd.Next(0, 20));
            } else {
                text = new BackText(value.ToString(), font, font, Color.DarkRed, (int)target.getX() + rd.Next(0, 70), (int)target.getY() + rd.Next(0, 20));
            }
            objects.Add(text);

        }

        public void update(GameTime gameTime) {
            foreach (BackText element in objects) {
                element.setOpacity(element.getOpacity() - getOpacityDecrement());
                element.incrementY(-1);
                if (element.getOpacity() == 0)
                    objects.Remove(element);
            }
        }

        public void draw(SpriteBatch spriteBatch) {
            foreach (GenericText element in objects) {
                element.draw(spriteBatch);
            }
        }

        public void setTarget(BaseObject target) {
            this.target = target;
        }

        public void setOpacityIncrement(float opacityDecrement) {
            this.opacityDecrement = opacityDecrement;
        }

        public float getOpacityDecrement() {
            return opacityDecrement;
        }

        public BaseObject getTarget() {
            return target;
        }

        public void setObjects(List<BackText> objects) {
            this.objects = objects;
        }
    }
}
