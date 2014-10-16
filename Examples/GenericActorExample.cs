using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DreamWorld.Examples {
    class GenericActorExample : Example {
        public Picture actorPicture;
        public GenericActor actor;
        public GenericMap map;
        public XboxInputController inputController;
        public InputController input;
        public GenericText text;

        public void initialize() {
            actorPicture = new Picture();
            actor = new GenericActor(GenericActor.State.Stand, GenericActor.Direction.Right, new Vector2(80, 10), 3, -7);
            map = new GenericMap();
            inputController = new XboxInputController();
            input = new InputController();
            text = new GenericText();
            text.setColor(Color.White);
            text.setLocation(10, 10);

            inputController.addKey("press_a", new InputXboxKey(Buttons.A, InputController.InputType.Press));
            inputController.addKey("press_dleft", new InputXboxKey(Buttons.DPadLeft, InputController.InputType.Press));
            inputController.addKey("press_dright", new InputXboxKey(Buttons.DPadRight, InputController.InputType.Press));
            inputController.addKey("pressed_dleft", new InputXboxKey(Buttons.DPadLeft, InputController.InputType.Pressing));
            inputController.addKey("pressed_dright", new InputXboxKey(Buttons.DPadRight, InputController.InputType.Pressing));
            inputController.addKey("hold_dleft", new InputXboxKey(Buttons.DPadLeft, InputController.InputType.Hold));
            inputController.addKey("hold_dright", new InputXboxKey(Buttons.DPadRight, InputController.InputType.Hold));

            inputController.addStickKey("pressed_left", new XboxInputSticks(XboxInputSticks.InputCondition.Left));
            inputController.addStickKey("pressed_right", new XboxInputSticks(XboxInputSticks.InputCondition.Right));

            input.addKey("press_z", new InputKey(Keys.Z, InputController.InputType.Press));
            input.addKey("press_left", new InputKey(Keys.Left, InputController.InputType.Press));
            input.addKey("press_right", new InputKey(Keys.Right, InputController.InputType.Press));
            input.addKey("pressed_left", new InputKey(Keys.Left, InputController.InputType.Pressing));
            input.addKey("pressed_right", new InputKey(Keys.Right, InputController.InputType.Pressing));
            input.addKey("hold_left", new InputKey(Keys.Left, InputController.InputType.Hold));
            input.addKey("hold_right", new InputKey(Keys.Right, InputController.InputType.Hold));
        }

        public void loadContent(ContentManager contentManager) {
            initialize();
            actorPicture.loadContent(contentManager.Load<Texture2D>("Examples/ironball"));
            actorPicture.setLocation(actor.getLocation());
            actor.setSize(actorPicture.getW(), actorPicture.getH());
            Texture2D platform = contentManager.Load<Texture2D>("Examples/base");
            map.addTile(new Tile(platform, new Vector2(220, 240)));
            map.addTile(new Tile(platform, new Vector2(10, 300)));
            map.addTile(new Tile(platform, new Vector2(100, 350)));
            map.addTile(new Tile(platform, new Vector2(0, 400)));
            map.addTile(new Tile(platform, new Vector2(128, 400)));
            map.addTile(new Tile(platform, new Vector2(256, 400)));
            map.addTile(new Tile(platform, new Vector2(384, 400)));

            foreach (Tile tile in map.getTile())
                tile.addMask(".", MaskFactory.upBorder(tile, 5, TileMask.Type.blockVerticall));

            map.addActor(actor);
            text.loadContent(contentManager.Load<SpriteFont>("Examples/font"));
        }

        public void update(GameTime gameTime) {
            map.update(gameTime);
            inputController.update(gameTime);
            input.update(gameTime);
            actor.setSize(actorPicture.getW(), actorPicture.getH());

            if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X == 0f &&
                actor.getState() != GenericActor.State.Jumping)
                actor.setState(GenericActor.State.Stand);
                
            if (input.isKeySatisfied("pressed_left") || inputController.isStickSatisfied("pressed_left")) {
                actor.incrementX(-actor.getMoveSpeed());
                if (actor.getState() != GenericActor.State.Jumping)
                    actor.setState(GenericActor.State.Moving);
                actor.setDirection(GenericActor.Direction.Left);
            }
            if (input.isKeySatisfied("pressed_right") || inputController.isStickSatisfied("pressed_right")) {
                actor.incrementX(actor.getMoveSpeed());
                if (actor.getState() != GenericActor.State.Jumping)
                    actor.setState(GenericActor.State.Moving);
                actor.setDirection(GenericActor.Direction.Right);
            }

            if (actor.jumpAction.isRunning())
                actor.jumpAction.update(gameTime);
            if (input.isKeySatisfied("press_z") || inputController.isKeySatisfied("press_a")) {
                if (actor.jumpAction.isFinished()) {
                    actor.jumpAction.initialize(actor);
                    actor.jumpAction.start(-7);
                    actor.setState(GenericActor.State.Jumping);
                }
            }

            text.setText("BaseY: " + actor.getBaseGravityY() + "\nY: " + actor.getY() + "\nX: " + actor.getX() + "\nState: " + actor.getState() + "\nDirection: " + actor.getDirection());
            

            actorPicture.setLocation(actor.getLocation());          

        }

        public void draw(SpriteBatch spriteBatch) {
            map.draw(spriteBatch);
            actorPicture.draw(spriteBatch);
            text.draw(spriteBatch);
        }
    }
}
