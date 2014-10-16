using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace DreamWorld.Try3
{
    class MTPoring : MonsterAvatar
    {
        public Try2.PoringSkill skill;
        Texture2D tempTex;
        GenericTimeout timeOutSkill;
        Random rd;

        public override void initialize() {
            base.initialize();
            speed = 1;
            skill = new Try2.PoringSkill();
            skill.sender = this;
            timeOutSkill = new GenericTimeout(1500);
            rd = new Random();
        }

        public override void loadContent(ContentManager contentManager) {
            base.loadContent(contentManager);
            sprDown.loadContent(contentManager.Load<Texture2D>("mobs/poring_baixo"), 4, 0, 50);
            sprUp.loadContent(contentManager.Load<Texture2D>("mobs/poring_cima"), 4, 0, 50);
            tempTex = contentManager.Load<Texture2D>("mobs/poring_atk");
            //sprCast.loadContent(tempTex, 8, 0, 5);
            
            
            skill.loadContent(contentManager);
            spriteToDraw = sprDown;
        }

        public override void update(GameTime gameTime)
        {
            if (skill.stage != Try2.Skill.Stage.casting)
            {
                base.update(gameTime);
            }// else 
                timeOutSkill.update(gameTime);

            Rectangle r1 = spriteToDraw.getRect();
            Rectangle r2 = skill.target.spriteToDraw.getRect();
            r2.X += (r2.Width / 4);
            r2.Width -= (r2.Width / 4);
            r2.Y += 20;
            r2.Height -= 30;
            
            //if (r2.Contains(r1))
            if (r2.Intersects(r1))
            {
                
                if (timeOutSkill.isTimeOuted())
                {
                    skill.animation = new GenericSprite();
                    skill.animation.loadContent(tempTex, 8, 0, 120);
                    skill.start();
                    spriteToDraw = skill.animation;
                    spriteToDraw.setLocation(location);
                    state = State.STOPED;
                }
            }
            else
            {
                
                //autoMove((int)skill.target.x + (skill.target.spriteToDraw.getH() / 2), (int)skill.target.y + skill.target.spriteToDraw.getH()- 35);
                // (state != State.MOVING)
                autoMove((int)skill.target.spriteToDraw.getRect().Center.X + rd.Next(10), (int)skill.target.spriteToDraw.getRect().Center.Y);
            }
           
            
            skill.update(gameTime); ;//.animation.update(gameTime);
            if (skill.isFinished() && state == State.STOPED)
            {
                skill.stage = Try2.Skill.Stage.stoped;

            }

            
        }

        private void autoMove(float p, float p_2)
        {
            base.autoMove((int)p, (int)p_2);
        }

    }
}
