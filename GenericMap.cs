using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DreamWorld {
    class GenericMap {
        protected LinkedList<Tile> tile;
        protected LinkedList<GenericActor> actor;

        public GenericMap() {
            tile = new LinkedList<Tile>();
            actor = new LinkedList<GenericActor>();
        }

        public void addTile(Tile tile) {
            this.tile.AddLast(tile);
        }

        public LinkedList<Tile> getTile() {
            return tile;
        }

        public void addActor(GenericActor actor) {
            this.actor.AddLast(actor);
        }

        public LinkedList<GenericActor> getActor() {
            return actor;
        }

        public virtual void initialize() {
        }

        public void update(GameTime gameTime) {
            foreach (GenericActor actor in this.actor) {
                bool intersected = false;
                actor.setBaseGravityY(0f);

                foreach (Tile tile in this.tile) {
                    foreach (TileMask mask in tile.getMask()) {
                        if (mask.getType() == TileMask.Type.blockVerticall) {
                            if (ColisionHelper.collideX(actor, mask.getBaseObject()))
                                if (actor.getBaseGravityY() == 0) { 
                                    actor.setBaseGravityY(ColisionHelper.baseGravityY(actor, mask.getBaseObject()));
                                } else if (ColisionHelper.isDownFromLastObj(actor, mask.getBaseObject()))
                                    actor.setBaseGravityY(ColisionHelper.baseGravityY(actor, mask.getBaseObject()));
                            if (ColisionHelper.collide(actor, mask.getBaseObject()))
                                intersected = true;
                        }
                    }
                }

                if (intersected) {
                    if (actor.getState() == GenericActor.State.Jumping || actor.getState() == GenericActor.State.Falling) {

                        if (actor.jumpAction.isFalling()) {
                            actor.setState(GenericActor.State.Stand);
                            if (actor.jumpAction.isJumping()) {
                                actor.jumpAction.finish();
                                actor.setY(actor.getBaseGravityY());
                                actor.setState(GenericActor.State.Stand);
                            }
                        }
                    }
                } else {
                    if (!actor.jumpAction.isRunning()) {
                        actor.jumpAction.initialize(actor);
                        actor.jumpAction.setStartY(actor.getBaseGravityY());
                        actor.jump(-7);
                        actor.setState(GenericActor.State.Jumping);
                    }

                }
            }
        }
        

        public virtual void draw(SpriteBatch spriteBatch) {
            foreach (Tile tile in this.tile) {
                if (tile.getTexture() != null)
                    tile.draw(spriteBatch);
            }
        }
    }
}
