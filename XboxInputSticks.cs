using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace DreamWorld {
    class XboxInputSticks {
        protected Vector2 key;
        protected InputCondition condition;
        protected bool satisfied = false;
        protected float value;

        public enum InputCondition {
            Left = 0, 
            Right, 
            CompleteLeft, 
            CompleteRight,
            Up,
            Down,
            CompleteUp,
            CompleteDown, 
            HorizontalHigher, 
            HorizontalMinor,
            HorizontalEqual, 
            VerticalHigher, 
            VerticalMinor, 
            VerticalEqual
        }

        public XboxInputSticks() {  
        }

        public XboxInputSticks(InputCondition condition) {
            setInputCondition(condition);
            setValue(0);
        }

        public XboxInputSticks(InputCondition condition, float value) {
            setInputCondition(condition);
            setValue(value);
        }

        public void setKey(Vector2 key) {
            this.key = key;
        }

        public Vector2 getKey() {
            return key;
        }

        public void setInputCondition(InputCondition condition) {
            this.condition = condition;
        }

        public InputCondition getInputCondition() {
            return condition;
        }

        public void setSatisfied(bool satisfied) {
            this.satisfied = satisfied;
        }

        public bool isSatisfied() {
            return satisfied;
        }

        public void setValue(float value) {
            this.value = value;
        }

        public float getValue() {
            return value;
        }
    }
}
