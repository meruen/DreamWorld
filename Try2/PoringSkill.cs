using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using DreamWorld.Try3;
using Microsoft.Xna.Framework.Audio;

namespace DreamWorld.Try2
{
    class PoringSkill : Skill
    {
        public GenericSprite animation;
        public CharAvatar target;
        public BaseObject sender;
        Random variation;

        public PoringSkill()
        {
            animation = new GenericSprite();
            variation = new Random();
            
        }

        public void initialize(CharAvatar target, BaseObject sender)
        {
            this.sender = sender;
            base.initialize(target);
            this.target = target;
            this.stage = Stage.casting;
            this.damage = 29;
        }

        public void loadContent(ContentManager contentManager)
        {
            animation.loadContent(contentManager.Load<Texture2D>("mobs/poring_atk"), 8, 0, 50);
            //animation.setStopAtEnd(true);
            se = contentManager.Load<SoundEffect>("Examples/Blow1");
        }

        public override void interrupt()
        {
            
        }

        public override void update(GameTime gameTime)
        {
            
            switch (stage)
            {
                case Stage.casting:
                    animation.update(gameTime);
                    if (animation.isEnded()) {
                        
                        //target.profile.hp -= variation.Next(target.profile.at_defesa / 2, target.profile.at_defesa);
                        target.makeDamage(variation.Next(target.profile.at_defesa / 2, target.profile.at_defesa), sender);
                        se.Play();
                        finished = true;
                        animation.setCurrentFrame(0);
                        stage = Stage.endCasting;
                    }
                    break;
                default: break;
            }
        }

        public override void start()
        {
            base.start();
            this.stage = Stage.casting;
            animation.setCurrentFrame(0);
            //mainChar.spriteToDraw = animation;
        }

        public void draw(SpriteBatch spriteBatch)
        {

        }
    }
}
