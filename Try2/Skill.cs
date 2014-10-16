using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using DreamWorld;
using Microsoft.Xna.Framework.Audio;

namespace DreamWorld.Try2
{
   abstract class Skill : GenericAction
    {
        public String name;
        public float coolDown, actualCoolDown;
        public bool canCast = true, casting = false;
        public GenericTimeout timer;
        public Stage stage = Stage.stoped;
        public int damage;
        public SoundEffect se;

        public enum Stage
        {
            stoped = 0,
            casting,
            making_damage,
            endCasting
        }

        public Skill()
        {
        }

        public void initialize(String name, float coolDown)
        {
            this.name = name;
            this.coolDown = coolDown;
        }

        public abstract void interrupt();
             //throw new NotImplementedException();
        
    }
}
