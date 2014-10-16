using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DreamWorld;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using DreamWorld.Try3;

namespace DreamWorld.Try1
{
    class MainHud
    {
        public Picture hud, hpbar, spbar, xpbar, face;
        public SkillDisplay skillDisplay;
        public GenericText hptext, sptext, nametext, lvtext;
        public SpriteFont defaultFont;
        public Character mainChar;

        public MainHud(Character parent)
        {
            this.mainChar = parent;
            hptext = new GenericText("0", new Rectangle(129, 52, 150, 20));
            sptext = new GenericText("0", new Rectangle(129, 72, 150, 20));
            nametext = new GenericText(mainChar.profile.name, new Rectangle(107, 31, 150, 20));
            lvtext = new GenericText(parent.profile.lv.ToString(), new Rectangle(232, 32, 31, 20));
            hud = new Picture();
            hpbar = new Picture();
            spbar = new Picture();
            xpbar = new Picture();
            face = new Picture();
            skillDisplay = new SkillDisplay();
            
        }

        public void update()
        {
            float proportion = (float)mainChar.profile.maxHp / hpbar.getTexture().Width;
            float proportionSp = (float)mainChar.profile.maxSp / spbar.getTexture().Width;
            float realValue = (float)mainChar.profile.hp / proportion;
            float realValueSp = (float)mainChar.profile.sp / proportionSp;
            float proportionXp = (float)mainChar.profile.maxXp / xpbar.getTexture().Width;
            float realValueXp = (float)mainChar.profile.xp / proportionXp;

            hpbar.setW(realValue);
            hpbar.rect.Width = (int)realValue;
            hptext.setText(mainChar.profile.hp.ToString() + " / " + mainChar.profile.maxHp.ToString());

            spbar.setW(realValueSp);
            spbar.rect.Width = (int)realValueSp;
            sptext.setText(mainChar.profile.sp.ToString() + " / " + mainChar.profile.maxSp.ToString());

            xpbar.setW(realValueXp);
            xpbar.rect.Width = (int)realValueXp;

            skillDisplay.update(null);

        }

        public void loadContent(ContentManager contentManager, Texture2D face)
        {
            defaultFont = contentManager.Load<SpriteFont>("Examples/babel");
            hptext.setFont(defaultFont);
            lvtext.setFont(defaultFont);
            nametext.setFont(defaultFont);
            sptext.setFont(defaultFont);
            //hptext.setLocation(300, 90);

            hud.loadContent(contentManager.Load<Texture2D>("abelut/mainhud"));
            hpbar.loadContent(contentManager.Load<Texture2D>("abelut/hpbar"));
            hpbar.setColor(Color.Red);
            spbar.loadContent(contentManager.Load<Texture2D>("abelut/mpbar"));
            spbar.setColor(Color.DarkSlateBlue);
            xpbar.loadContent(contentManager.Load<Texture2D>("abelut/xpbar"));
            this.face.loadContent(face);

            hud.setLocation(10, 10);
            this.face.setLocation(-54, 3);
            hpbar.setLocation(128, 59);
            spbar.setLocation(128, 79);
            xpbar.setLocation(41, 101);
            //hud.setColor(Color.White * 0.5f);

            skillDisplay.loadContent(contentManager);
        }

        public void draw(SpriteBatch spriteBatch)
        {
            hud.draw(spriteBatch);
            //face.draw(spriteBatch);
            spriteBatch.Draw(face.getTexture(), face.getLocation(), null, Color.White, 0.0f, Vector2.Zero, 2.0f, SpriteEffects.None, 0.0f);
            nametext.draw(spriteBatch);
            lvtext.draw(spriteBatch);
            hpbar.draw(spriteBatch);
            hptext.draw(spriteBatch);
            spbar.draw(spriteBatch);
            sptext.draw(spriteBatch);
            xpbar.draw(spriteBatch);
            skillDisplay.draw(spriteBatch);
        }
    }
}
