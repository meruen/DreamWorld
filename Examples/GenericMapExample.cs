using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DreamWorld.Examples {
    class GenericMapExample : Example {
        GenericMap map;
        JumpActionExample actor;

        public GenericMapExample() {
            map = new GenericMap();
            actor = new JumpActionExample();
        }

        public void initialize() {
            actor.initialize();
        }

        public void loadContent(ContentManager contentManager) {
            initialize();
            Texture2D block = contentManager.Load<Texture2D>("Examples/base");
            
            map.addTile(new Tile(block, new Vector2(50, 400)));
            map.addTile(new Tile(block, new Vector2(500, 350)));

            actor.loadContent(contentManager);
        }

        public void update(GameTime gameTime) {
            map.update(gameTime);
            actor.update(gameTime);

            bool intersected = false, yIntersected = false;
            float yStart = 0f;

            foreach (Tile tile in map.getTile())
                if (tile.getRectBounds().Intersects(actor.picture.getRectBounds())) {
                    intersected = true;
                    if (actor.jumpAction.isJumping())
                        actor.jumpAction.finish();
                } else {
                    if (actor.picture.getLocation().X >= tile.getX() && actor.picture.getLocation().X <= tile.getX() + tile.getW()) {
                        yIntersected = true;
                        yStart = tile.getY() - actor.picture.getH();
                    }
                }

            if (!actor.jumpAction.isJumping() && !actor.jumpAction.isFalling() && !intersected) {
                actor.jumpAction.initialize(actor.picture);
                if (yIntersected) {
                    actor.jumpAction.start(7);
                    actor.jumpAction.setStartY(yStart);
                }
            }
        }

        public void draw(SpriteBatch spriteBatch) {
            map.draw(spriteBatch);
            actor.draw(spriteBatch);
        }
    }
}
