using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace DreamWorld {
    class InputController {
        protected KeyboardState lastState, currentState;
        protected Dictionary<String, InputKey> keys;

        public enum InputType {
            Press = 0, 
            Pressing, 
            Holding, 
            Hold
        }

        public Dictionary<String, InputKey> getKeys() {
            return keys;
        }

        public void addKey(String id, InputKey key) {
            keys.Add(id, key);
        }

        public bool isKeySatisfied(String id) {
            InputKey inputKey;
            if (keys.TryGetValue(id, out inputKey))
                if (inputKey.isSatisfied())
                    return true;
            return false;
        }

        public InputController() {
            keys = new Dictionary<String, InputKey>();
            lastState = currentState = Keyboard.GetState();
        }

        public void update(GameTime gameTime) {
            currentState = Keyboard.GetState();

            foreach (KeyValuePair<String, InputKey> pair in keys) {
                switch (pair.Value.getInputType()) {
                    case InputType.Press:
                        if (lastState.IsKeyUp(pair.Value.getKey()) && currentState.IsKeyDown(pair.Value.getKey()))
                            pair.Value.setSatisfied(true);
                        else
                            pair.Value.setSatisfied(false);
                        break;
                    case InputType.Holding:
                        if (lastState.IsKeyUp(pair.Value.getKey()) && currentState.IsKeyUp(pair.Value.getKey()))
                            pair.Value.setSatisfied(true);
                        else
                            pair.Value.setSatisfied(false);
                        break;
                    case InputType.Hold:
                        if (lastState.IsKeyDown(pair.Value.getKey()) && currentState.IsKeyUp(pair.Value.getKey()))
                            pair.Value.setSatisfied(true);
                        else
                            pair.Value.setSatisfied(false);
                        break;
                    case InputType.Pressing:
                        if (lastState.IsKeyDown(pair.Value.getKey()) && currentState.IsKeyDown(pair.Value.getKey()))
                            pair.Value.setSatisfied(true);
                        else
                            pair.Value.setSatisfied(false);
                        break;
                    default: break;
                }
            }

            lastState = currentState;
        }
    }
}
