using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DreamWorld {
    class MaskFactory {
        public static TileMask upBorder(Tile tile, int h, TileMask.Type type) {
            return new TileMask(new BaseObject(tile.getX(), tile.getY(), tile.getW(), h), type);
        }

        public static TileMask fullBorder(Tile tile, int h, TileMask.Type type) {
            return new TileMask(new BaseObject(tile.getX(), tile.getY(), tile.getW(), tile.getH()), type);
        }
    }
}
