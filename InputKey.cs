using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace DreamWorld {
    class InputKey {
        protected Keys key;
        protected InputController.InputType inputType;
        protected bool satisfied = false;

        public InputKey() {
        }

        public InputKey(Keys key, InputController.InputType inputType) {
            setKey(key);
            setInputType(inputType);
        }

        public void setKey(Keys key) {
            this.key = key;
        }

        public Keys getKey() {
            return key;
        }

        public void setInputType(InputController.InputType inputType) {
            this.inputType = inputType;
        }

        public InputController.InputType getInputType() {
            return inputType;
        }

        public void setSatisfied(bool satisfied) {
            this.satisfied = satisfied;
        }

        public bool isSatisfied() {
            return satisfied;
        }
    }
}
