using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using DreamWorld.Try1;

namespace DreamWorld.Try3
{
    class CharAvatar : BaseObject
    {
        public CharSprite sprParadoBaixo, sprParadoCima, sprParadoEsquerda, sprParadoDireita, spriteToDraw, sprWalkingUp, sprWalkingDown, sprWalkingLeft, sprWalkingRight;
        public CharSprite sprDiagonalEsquerdaBaixo, sprDiagonalDireitaBaixo, sprDiagonalDireitaCima, sprDiagonalEsquerdaCima, sprParadoBaixoEsquerda, sprParadoBaixoDireita, sprParadoCimaDireita, sprParadoCimaEsquerda;
        public CharSprite sprBattleEsquerda, sprBattleDireita, sprBattleDireitaCima, sprBattleEsquerdaCima;
        public GenericText damageText;
        public Picture sprClassPicture;
        protected Position position = Position.DOWN, lastPosition = Position.DOWN;
        protected State state = State.STOPED, lastState = State.STOPED;
        protected int speed = 2;
        protected int speedX = 0, speedY = 0;
        public Try2.BaseAtributes profile;
        private int destinyX = 0, destinyY = 0;
        public int footAutoX = 60, footAutoY = 90;
        public int x = 0, y = 0;
        public Try4.DamageDisplay damageDisplay;
        public BaseObject sender;

        public enum State
        {
            STOPED = 0,
            MOVING, 
            AUTO_MOVING,
            CASTING, 
            BATTLE_POSITION
        }

        public enum Position
        {
            DOWN = 0,
            UP,
            LEFT,
            RIGHT,
            LEFT_DOWN,
            RIGHT_DOWN,
            LEFT_UP,
            RIGHT_UP
        }
        #region GETTERS_SETTERS
        public Position getPosition() {
            return position;
        }

        public void setPosition(Position position) {
            this.position = position;
        }

        public State getState() {
            return state;
        }

        public void setState(State state) {
            this.state = state;
        }

        public void setMovementSpeed(int speed) {
            this.speed = speed;
        }

        public int getMovementSpeed() {
            return speed;
        }

        public int getSpeedX() {
            return speedX;
        }

        public int getSpeedY() {
            return speedY;
        }
        #endregion

        public virtual void initialize(Vector2 startLocation, int speed) {
            sender = null;
            sprClassPicture = new Picture();
            this.speed = speed;
            speedX = speedY = destinyX = destinyY = 0;
            this.location = startLocation;
            x = (int)location.X;
            y = (int)location.Y;

            damageText = new GenericText();
            damageText.setVisible(false);
            sprParadoBaixo = new CharSprite();
            spriteToDraw = sprParadoBaixo;
            sprParadoCima = new CharSprite();
            sprParadoEsquerda = new CharSprite();
            sprParadoDireita = new CharSprite();
            sprWalkingDown = new CharSprite();
            sprWalkingUp = new CharSprite();
            sprWalkingLeft = new CharSprite();
            sprWalkingRight = new CharSprite();
            sprDiagonalEsquerdaBaixo = new CharSprite();
            sprDiagonalDireitaBaixo = new CharSprite();
            sprDiagonalDireitaCima = new CharSprite();
            sprDiagonalEsquerdaCima = new CharSprite();
            sprParadoBaixoDireita = new CharSprite();
            sprParadoBaixoEsquerda = new CharSprite();
            sprBattleEsquerda = new CharSprite();
            sprBattleDireita = new CharSprite();
            sprBattleEsquerdaCima = new CharSprite();
            sprBattleDireitaCima = new CharSprite();

            damageDisplay = new Try4.DamageDisplay(this);
        }

        public void makeDamage(int damage, BaseObject sender)
        {
            profile.hp -= damage;
            damageDisplay.damage(damage, false);
            state = State.BATTLE_POSITION;
            this.sender = sender;
        }

        public virtual void loadContent(ContentManager contentManager) {
            //damageText.loadContent(contentManager.Load<SpriteFont>("Examples/segoe"));
            damageDisplay.loadContent(contentManager);
        }

        public virtual void update(GameTime gameTime) {
            location.X = x;
            location.Y = y;

            /*if (damageText.isVisible())
            {
                if (colorIncrement == .0f)
                    damageText.setVisible(false);
                else
                {
                    damageText.setColor(Color.DarkRed * (colorIncrement -= 0.01f));
                    damageText.incrementY(-1);
                }
            }*/

            damageDisplay.update(gameTime);

            switch (state) {
                case State.MOVING:

                    break;
                case State.STOPED:
                    //speedX = speedY = 0;
                    switch (position) {
                        case Position.DOWN:
                            spriteToDraw = sprParadoBaixo;
                            break;
                        case Position.UP:
                            spriteToDraw = sprParadoCima;
                            break;
                        case Position.LEFT:
                            spriteToDraw = sprParadoEsquerda;
                            break;
                        case Position.RIGHT:
                            spriteToDraw = sprParadoDireita;
                            break;
                        case Position.LEFT_DOWN:
                            spriteToDraw = sprParadoBaixoEsquerda;
                            break;
                        case Position.RIGHT_DOWN:
                            spriteToDraw = sprParadoBaixoDireita;
                            break;
                        case Position.LEFT_UP:
                            spriteToDraw = sprParadoCima;
                            break;
                        case Position.RIGHT_UP:
                            spriteToDraw = sprParadoCima;
                            break;
                        default: break;
                    }
                    break;
                case State.BATTLE_POSITION:
                    //if (position == Position.DOWN || position == Position.LEFT || position == Position.D
                    if (sender.getX() > x && sender.getY() > y)
                        spriteToDraw = sprBattleDireita;
                    else if (sender.getX() > x && sender.getY() < y)
                        spriteToDraw = sprBattleDireitaCima;
                    else if (sender.getX() < x && sender.getY() > y)
                        spriteToDraw = sprBattleEsquerda;
                    else if (sender.getX() < x && sender.getY() < y)
                        spriteToDraw = sprBattleEsquerdaCima;
                    break;
                case State.AUTO_MOVING:
                    footAutoX = x + 60;
                    footAutoY = y + 110;
                    if (destinyX > footAutoX && destinyY < y) {
                        position = Position.RIGHT_UP; ;
                        spriteToDraw = sprDiagonalDireitaCima;
                        x += speed;
                        y -= speed;
                    } else if (destinyX > footAutoX && destinyY > footAutoY) {
                        position = Position.RIGHT_DOWN;
                        spriteToDraw = sprDiagonalDireitaBaixo;
                        x += speed;
                        y += speed;
                    } else if (destinyX < footAutoX && destinyY < footAutoY) {
                        position = Position.LEFT_UP;
                        spriteToDraw = sprDiagonalEsquerdaCima;
                        x -= speed;
                        y -= speed;
                    } else if (destinyX < footAutoX && destinyY > footAutoY) {
                        position = Position.LEFT_DOWN;
                        spriteToDraw = sprDiagonalEsquerdaBaixo;
                        x -= speed;
                        y += speed;
                    } else if (destinyX > footAutoX) {
                        position = Position.RIGHT;
                        spriteToDraw = sprWalkingRight;
                        x += speed;
                    } else if (destinyX < footAutoX) {
                        position = Position.LEFT;
                        spriteToDraw = sprWalkingLeft;
                        x -= speed;
                    } else if (destinyY > footAutoY) {
                        position = Position.DOWN;
                        spriteToDraw = sprWalkingDown;
                        y += speed;
                    } else if (destinyY < footAutoY) {
                        position = Position.UP;
                        spriteToDraw = sprWalkingUp;
                        y -= speed;
                    } else {
                        state = State.STOPED;
                    }
                    break;
            }

            spriteToDraw.update(gameTime);

        }

        public virtual void draw(SpriteBatch spriteBatch) {
            spriteToDraw.setX(x);
            spriteToDraw.setY(y);
            spriteToDraw.draw(spriteBatch);
            //damageText.draw(spriteBatch);
            damageDisplay.draw(spriteBatch);
        }

        public void autoMove(int x, int y) {
            state = State.AUTO_MOVING;
            destinyX = x + (x % speed);
            destinyY = y + (y % speed);
        }
    }
}
