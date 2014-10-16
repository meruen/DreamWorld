using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace DreamWorld {
    class ColisionHelper {
        public static bool collide(BaseObject obj1, BaseObject obj2) {
            return obj1.getRectBounds().Intersects(obj2.getRectBounds());
        }

        public static bool collideX(BaseObject act, BaseObject obj) {
            if (act.getX() >= obj.getX() - act.getW() && act.getX() <= obj.getX() + obj.getW())
                return true;
            return false;
        }

        public static float baseGravityY(BaseObject act, BaseObject obj) {
            return obj.getY() - act.getH() + 1;
        }

        public static bool isDownFromLastObj(GenericActor act, BaseObject obj) {
            if (act.getBaseGravityY() < obj.getY() - act.getH() &&
                act.getY() > act.getBaseGravityY() + act.getH())
                return true;
            return false;
        }

        public static BaseObject getFootBorder(BaseObject obj1, int size) {
            return new BaseObject(obj1.getX() + obj1.getH() - size, obj1.getY(), (int)obj1.getW(), size);
        }
    }
}
