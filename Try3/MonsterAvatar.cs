using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace DreamWorld.Try3
{
    class MonsterAvatar : BaseObject
    {
        protected GenericSprite sprUp, sprDown, sprCast, spriteToDraw;
        protected State state = State.STOPED;
        protected Direction direction = Direction.LEFT;
        protected PositionType position = PositionType.BAIXO;
        protected int destinyX = 0, destinyY = 0;
        protected int speed = 1;
        protected bool inverted = false;
        protected Try2.BaseAtributes profile;
        protected Try3.Character target;

        public enum Direction
        {
            LEFT,
            RIGHT
        }

        public enum State
        {
            STOPED,
            MOVING,
            CASTING
        }

        public enum PositionType
        {
            BAIXO = 0,
            CIMA
        }

        public void setTarget(Character target)
        {
            this.target = target;
        }

        public Character getTarget()
        {
            return target;
        }

        public int getSpeed() {
            return speed;
        }

        public void setSpeed(int speed) {
            this.speed = speed;
        }

        public void setSprUp(GenericSprite sprUp) {
            this.sprUp = sprUp;
        }

        public GenericSprite getSprUp() {
            return sprUp;
        }

        public void setSprDown(GenericSprite sprDown) {
            this.sprDown = sprDown;
        }

        public GenericSprite getSprDown() {
            return sprDown;
        }

        public void setSprCast(GenericSprite sprCast) {
            this.sprCast = sprCast;
        }

        public GenericSprite getSpriteToDraw() {
            return spriteToDraw;
        }

        public void setSpriteToDraw(GenericSprite spriteToDraw) {
            this.spriteToDraw = spriteToDraw;
        }

        public State getState() {
            return state;
        }

        public void setState(State state) {
            this.state = state;
        }

        public Direction getDirection() {
            return direction;
        }

        public void setDirection(Direction direction) {
            this.direction = direction;
        }

        public Try2.BaseAtributes getProfile()
        {
            return profile;
        }

        public virtual void initialize() {
            spriteToDraw = new GenericSprite();
            sprUp = new GenericSprite();
            sprDown = new GenericSprite();
            sprCast = new GenericSprite();
            target = null;
        }

        public virtual void loadContent(ContentManager contentManager) {
        }

        public virtual void update(GameTime gameTime) {
            if (state == State.MOVING) {
                int x = (int)getX(),
                    y = (int)getY();

                if (x > destinyX) {
                    direction = Direction.LEFT;
                    incrementX(-speed);
                } else if (x < destinyX) {
                    direction = Direction.RIGHT;
                    incrementX(speed);
                }

                if (y < destinyY) {
                    position = PositionType.BAIXO;
                    incrementY(speed);
                } else if (y > destinyY) {
                    position = PositionType.CIMA;
                    incrementY(-speed);
                }

                if (x == destinyX && y == destinyY) {
                    state = State.STOPED;
                }
            }

            switch (direction) {
                case Direction.LEFT:
                    inverted = false;
                    break;
                case Direction.RIGHT:
                    inverted = true;
                    break;
                default: break;
            }

            switch (position) {
                case PositionType.CIMA:
                    spriteToDraw = sprUp;
                    break;
                case PositionType.BAIXO:
                    spriteToDraw = sprDown;
                    break;
                default:
                    break;
            }

            spriteToDraw.setLocation(this.getLocation());
            spriteToDraw.setInverted(inverted);
            spriteToDraw.update(gameTime);            
        }

        public virtual void draw(SpriteBatch spriteBatch) {
            spriteToDraw.draw(spriteBatch);
        }

        public void autoMove(int x, int y) {
            state = State.MOVING;
            destinyX = x + (x % speed);
            destinyY = y + (y % speed);
        }
    }
}
