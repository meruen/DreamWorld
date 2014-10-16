using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace DreamWorld {
    class TileMask {
        protected BaseObject baseObject;
        protected Type type;

        public enum Type {
            block, 
            pass, 
            blockVerticall, 
            blockHorizontall
        }

        public TileMask(BaseObject baseObject, Type type) {
            setBaseObject(baseObject);
            setType(type);
        }

        public void setBaseObject(BaseObject baseObject) {
            this.baseObject = baseObject;
        }

        public BaseObject getBaseObject() {
            return baseObject;
        }

        public void setType(Type type) {
            this.type = type;
        }

        public Type getType() {
            return type;
        }

        //public BaseObject getBaseObject
    }
}
