using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework;

namespace DreamWorld {
    class SpecialSprite : GenericSprite {
        protected Dictionary<uint, SoundEffect> soundBank;

        public SpecialSprite() : base() {
            soundBank = new Dictionary<uint,SoundEffect>();
        }

        public Dictionary<uint, SoundEffect> getSoundBank() {
            return soundBank;
        }

        public void addSound(uint frameIndex, SoundEffect soundEffect) {
            SoundEffect temp;

            if (!soundBank.TryGetValue(frameIndex, out temp)) {
                soundBank.Add(frameIndex, soundEffect);
            }
        }

        public bool deleteSound(uint frameIndex) {
            return soundBank.Remove(frameIndex);
        }

        public override void update(GameTime gameTime) {
            base.update(gameTime);
            foreach (KeyValuePair<uint, SoundEffect> pair in soundBank) {
                if (pair.Key == currentFrame)
                    pair.Value.Play();
            }
        }
    }
}
