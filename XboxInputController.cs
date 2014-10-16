using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace DreamWorld {
    class XboxInputController {
        protected GamePadState lastState, currentState;
        protected Dictionary<String, InputXboxKey> keys;
        protected Dictionary<String, XboxInputSticks> sticks;

        public Dictionary<String, InputXboxKey> getKeys() {
            return keys;
        }

        public Dictionary<String, XboxInputSticks> getSticks() {
            return sticks;
        }

        public void addKey(String id, InputXboxKey key) {
            keys.Add(id, key);
        }

        public void addStickKey(String id, XboxInputSticks stick) {
            sticks.Add(id, stick);
        }

        public bool isKeySatisfied(String id) {
            InputXboxKey inputKey;
            if (keys.TryGetValue(id, out inputKey))
                if (inputKey.isSatisfied())
                    return true;
            return false;
        }

        public bool isStickSatisfied(String id) {
            XboxInputSticks inputStick;
            if (sticks.TryGetValue(id, out inputStick))
                if (inputStick.isSatisfied())
                    return true;
            return false;
        }

        public XboxInputController() {
            keys = new Dictionary<String, InputXboxKey>();
            sticks = new Dictionary<string, XboxInputSticks>();
            lastState = currentState = GamePad.GetState(PlayerIndex.One);
        }

        public void update(GameTime gameTime) {
            currentState = GamePad.GetState(PlayerIndex.One);

            foreach (KeyValuePair<String, XboxInputSticks> pair in sticks) {
                Vector2 stick = pair.Value.getKey();

                pair.Value.setKey(currentState.ThumbSticks.Left);

                switch (pair.Value.getInputCondition()) {
                    case XboxInputSticks.InputCondition.CompleteDown:
                        if (stick.Y == -1.0f)
                            pair.Value.setSatisfied(true);
                        else
                            pair.Value.setSatisfied(false);
                        break;
                    case XboxInputSticks.InputCondition.CompleteUp:
                        if (stick.Y == 1.0f)
                            pair.Value.setSatisfied(true);
                        else
                            pair.Value.setSatisfied(false);
                        break;
                    case XboxInputSticks.InputCondition.CompleteLeft:
                        if (stick.X == -1.0f)
                            pair.Value.setSatisfied(true);
                        else
                            pair.Value.setSatisfied(false);
                        break;
                    case XboxInputSticks.InputCondition.CompleteRight:
                        if (stick.X == 1.0f)
                            pair.Value.setSatisfied(true);
                        else
                            pair.Value.setSatisfied(false);
                        break;
                    case XboxInputSticks.InputCondition.Down:
                        if (stick.Y < .0f)
                            pair.Value.setSatisfied(true);
                        else
                            pair.Value.setSatisfied(false);
                        break;
                    case XboxInputSticks.InputCondition.Up:
                        if (stick.Y > .0f)
                            pair.Value.setSatisfied(true);
                        else
                            pair.Value.setSatisfied(false);
                        break;
                    case XboxInputSticks.InputCondition.Right:
                        if (stick.X > .0f)
                            pair.Value.setSatisfied(true);
                        else
                            pair.Value.setSatisfied(false);
                        break;
                    case XboxInputSticks.InputCondition.Left:
                        if (stick.X < .0f)
                            pair.Value.setSatisfied(true);
                        else
                            pair.Value.setSatisfied(false);
                        break;
                    case XboxInputSticks.InputCondition.HorizontalEqual:
                        if (stick.X == pair.Value.getValue())
                            pair.Value.setSatisfied(true);
                        else
                            pair.Value.setSatisfied(false);
                        break;
                    case XboxInputSticks.InputCondition.HorizontalHigher:
                        if (stick.X > pair.Value.getValue())
                            pair.Value.setSatisfied(true);
                        else
                            pair.Value.setSatisfied(false);
                        break;
                    case XboxInputSticks.InputCondition.HorizontalMinor:
                        if (stick.X < pair.Value.getValue())
                            pair.Value.setSatisfied(true);
                        else
                            pair.Value.setSatisfied(false);
                        break;
                    case XboxInputSticks.InputCondition.VerticalEqual:
                        if (stick.Y == pair.Value.getValue())
                            pair.Value.setSatisfied(true);
                        else
                            pair.Value.setSatisfied(false);
                        break;
                    case XboxInputSticks.InputCondition.VerticalHigher:
                        if (stick.Y > pair.Value.getValue())
                            pair.Value.setSatisfied(true);
                        else
                            pair.Value.setSatisfied(false);
                        break;
                    case XboxInputSticks.InputCondition.VerticalMinor:
                        if (stick.Y < pair.Value.getValue())
                            pair.Value.setSatisfied(true);
                        else
                            pair.Value.setSatisfied(false);
                        break;
                    default: break;
                }
            }

            foreach (KeyValuePair<String, InputXboxKey> pair in keys)
                switch (pair.Value.getInputType()) {
                    case InputController.InputType.Press:
                        if (lastState.IsButtonUp(pair.Value.getKey()) && currentState.IsButtonDown(pair.Value.getKey()))
                            pair.Value.setSatisfied(true);
                        else
                            pair.Value.setSatisfied(false);
                        break;
                    case InputController.InputType.Holding:
                        if (lastState.IsButtonUp(pair.Value.getKey()) && currentState.IsButtonUp(pair.Value.getKey()))
                            pair.Value.setSatisfied(true);
                        else
                            pair.Value.setSatisfied(false);
                        break;
                    case InputController.InputType.Hold:
                        if (lastState.IsButtonDown(pair.Value.getKey()) && currentState.IsButtonUp(pair.Value.getKey()))
                            pair.Value.setSatisfied(true);
                        else
                            pair.Value.setSatisfied(false);
                        break;
                    case InputController.InputType.Pressing:
                        if (lastState.IsButtonDown(pair.Value.getKey()) && currentState.IsButtonDown(pair.Value.getKey()))
                            pair.Value.setSatisfied(true);
                        else
                            pair.Value.setSatisfied(false);
                        break;
                    default: break;
                }

            lastState = currentState;
        }
    }
}
