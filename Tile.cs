using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DreamWorld {
    class Tile : Picture {
        protected LinkedList<TileMask> mask;

        public Tile() : base() {
            mask = new LinkedList<TileMask>();
        }

        public Tile(Texture2D texture, Vector2 location) {
            mask = new LinkedList<TileMask>();
            setLocation(location);
            loadContent(texture);
        }

        public void addMask(String key, BaseObject baseObject, TileMask.Type type) {
            this.mask.AddLast(new TileMask(baseObject, type));
        }

        public void addMask(String key, TileMask mask) {
            this.mask.AddLast(mask);
        }

        public void setMask(LinkedList<TileMask> mask) {
            this.mask = mask;
        }

        public LinkedList<TileMask> getMask() {
            return mask;
        }
    }
}
