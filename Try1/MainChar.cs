using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DreamWorld;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace DreamWorld.Try1 {
    class MainChar {
        public CharSprite sprParadoBaixo, sprParadoCima, sprParadoEsquerda, sprParadoDireita, spriteToDraw, sprWalkingUp, sprWalkingDown, sprWalkingLeft, sprWalkingRight;
        public CharSprite sprDiagonalEsquerdaBaixo, sprDiagonalDireitaBaixo, sprDiagonalDireitaCima, sprDiagonalEsquerdaCima, sprParadoBaixoEsquerda, sprParadoBaixoDireita, sprParadoCimaDireita, sprParadoCimaEsquerda;
        public GenericSprite sprPointer;
        public Picture classPicture;
        public SpriteFont tinyBabel;
        private InputController input, lastInput;
        public PositionType position = PositionType.baixo, lastPosition = PositionType.baixo;
        public StateType state = StateType.parado, lastState = StateType.parado;
        public const int MOVSPEED = 2;
        public int x, y, autoX, autoY, footAutoX, footAutoY;
        public int speedX, speedY;
        public bool canMove = true;
        public DashAction dashAction;
        public GenericText debug, characterName;
        public String temp = "";
        public Try2.BaseAtributes profile;
        public bool autoMoving = false;
        public MouseState mouseState, lastMouseState;
        public SoundEffect clickSe;

        public class DashAction : GenericAction
        {
            public GenericTimeout disapearTimer, apearTimer;
            public double appearInterval, disapearInterval;
            public MainChar mainChar;
            public Stage stage = Stage.In;
            public float colorIncrement = 0.25f, actualColor = 1.0f;
            public const int DEFAULT_TRANSLATE_INCREMENT = 100;
            public SoundEffect se = null;

            public enum Stage
            {
                In = 0, 
                Out
            }

            public override void start()
            {
                base.start();
                stage = Stage.In;
                appearInterval = disapearInterval = 10.0;
                apearTimer = new GenericTimeout();
                apearTimer.setInterval(100.0);
                disapearTimer = new GenericTimeout(disapearInterval);
                disapearTimer = new GenericTimeout();
                
            }
            
            public DashAction(MainChar mainChar)
            {
                base.initialize(mainChar);
                this.mainChar = mainChar;
                setRunning(false);

            }

            public void translate()
            {
                /*if (mainChar.speedX < 0)
                    mainChar.x -= DEFAULT_TRANSLATE_INCREMENT;
                if (mainChar.speedY < 0)
                    mainChar.y -= DEFAULT_TRANSLATE_INCREMENT;
                if (mainChar.speedX > 0)
                    mainChar.x += DEFAULT_TRANSLATE_INCREMENT;
                if (mainChar.speedY > 0)
                    mainChar.y += DEFAULT_TRANSLATE_INCREMENT;
                 */

                switch (mainChar.position)
                {
                    case PositionType.baixo:
                        mainChar.y += DEFAULT_TRANSLATE_INCREMENT;
                        break;
                    case PositionType.cima:
                        mainChar.y -= DEFAULT_TRANSLATE_INCREMENT;
                        break;
                    case PositionType.direita:
                        mainChar.x += DEFAULT_TRANSLATE_INCREMENT;
                        break;
                    case PositionType.esquerda:
                        mainChar.x -= DEFAULT_TRANSLATE_INCREMENT;
                        break;
                    case PositionType.direitaBaixo:
                        mainChar.x += DEFAULT_TRANSLATE_INCREMENT;
                        mainChar.y += DEFAULT_TRANSLATE_INCREMENT;
                        break;
                    case PositionType.direitaCima:
                        mainChar.x += DEFAULT_TRANSLATE_INCREMENT;
                        mainChar.y -= DEFAULT_TRANSLATE_INCREMENT;
                        break;
                    case PositionType.esquerdaBaixo:
                        mainChar.x -= DEFAULT_TRANSLATE_INCREMENT;
                        mainChar.y += DEFAULT_TRANSLATE_INCREMENT;
                        break;
                    case PositionType.esquerdaCima:
                        mainChar.x -= DEFAULT_TRANSLATE_INCREMENT;
                        mainChar.y -= DEFAULT_TRANSLATE_INCREMENT;
                        break;
                    default: break;
                }
            }

            public override void update(GameTime gameTime)
            {
                if (!isFinished())
                {
                    disapearTimer.update(gameTime);
                    if (disapearTimer.isTimeOuted())
                        switch (stage)
                        {
                            case Stage.In:
                                if (actualColor == 0.0f)
                                {
                                    stage = Stage.Out;
                                    if (se != null)
                                        se.Play();
                                    translate();
                                }
                                else
                                {
                                    actualColor -= colorIncrement;
                                    mainChar.spriteToDraw.setColor(Color.White * actualColor);
                                    mainChar.spriteToDraw.head.setColor(Color.White * actualColor);
                                    mainChar.temp = "\nDecrementou";
                                }
                                break;
                            case Stage.Out:
                                if (actualColor == 1.0f)
                                {
                                    stage = Stage.In;
                                    this.setFininshed(true);
                                }
                                else
                                {
                                    actualColor += colorIncrement;
                                    mainChar.spriteToDraw.setColor(Color.White * actualColor);
                                    mainChar.spriteToDraw.head.setColor(Color.White * actualColor);
                                }
                                break;
                            default:
                                break;
                        }

                }
            }

        }

        public enum StateType
        {
            parado = 0, 
            andando
        }

        public enum PositionType {
            baixo = 0, 
            cima, 
            esquerda, 
            direita, 
            esquerdaBaixo, 
            direitaBaixo, 
            esquerdaCima, 
            direitaCima
        }

        public MainChar()
        {
            debug = new GenericText();
            debug.setLocation(new Vector2(30, 30));
            debug.setColor(Color.White);

            characterName = new GenericText("");

            classPicture = new Picture();

            profile = new Try2.BaseAtributes();
            profile.name = "Abdias";
            profile.lv = 71;
            profile.hp = profile.maxHp = 160287;
            profile.sp = profile.maxSp = 1843;
            profile.xp = 758000;
            profile.maxXp = 758000;
           
            speedX = speedY = autoX = autoY = 0;
            x = y = 200;
            input = new InputController();
            lastInput = input;
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
            sprPointer = new GenericSprite();
            configureController();

            mouseState = lastMouseState = Mouse.GetState();

            dashAction = new DashAction((MainChar) this);
        }

        public void loadContent(ContentManager contentManager)
        {
            clickSe = contentManager.Load<SoundEffect>("abelut/Cursor");
            classPicture.loadContent(contentManager.Load<Texture2D>("abelut/classicontest"));
            tinyBabel = contentManager.Load<SpriteFont>("Examples/tinybabel");
            characterName.loadContent(tinyBabel);
            dashAction.se = contentManager.Load<SoundEffect>("abelut/teleport");
            debug.loadContent(contentManager.Load<SpriteFont>("Examples/font"));
            sprParadoBaixo.loadContent(contentManager.Load<Texture2D>("abelut/parado_baixo"), contentManager.Load<Texture2D>("ABELUT/PARADO_BAIXO_CABECA"), 1, 0, 0);
            sprParadoCima.loadContent(contentManager.Load<Texture2D>("ABELUT/PARADO_CIMA"), contentManager.Load<Texture2D>("ABELUT/PARADO_CIMA_CABECA"), 1, 0, 0);
            sprWalkingDown.loadContent(contentManager.Load<Texture2D>("abelut/ANDANDO_BAIXO"), contentManager.Load<Texture2D>("abelut/ANDANDO_BAIXO_CABECA"), 8, 0, 110);
            sprWalkingUp.loadContent(contentManager.Load<Texture2D>("abelut/ANDANDO_CIMA"), contentManager.Load<Texture2D>("abelut/ANDANDO_CIMA_CABECA"), 8, 0, 110);
            sprParadoEsquerda.loadContent(contentManager.Load<Texture2D>("abelut/PARADO_ESQUERDA"), contentManager.Load<Texture2D>("abelut/PARADO_ESQUERDA_CABECA"), 1, 0, 0);
            sprParadoDireita.loadContent(contentManager.Load<Texture2D>("abelut/PARADO_DIREITA"), contentManager.Load<Texture2D>("abelut/PARADO_DIREITA_CABECA"), 1, 0, 0);
            sprWalkingLeft.loadContent(contentManager.Load<Texture2D>("abelut/ANDANDO_ESQUERDA"), contentManager.Load<Texture2D>("abelut/ANDANDO_ESQUERDA_CABECA"), 8, 0, 110);
            sprWalkingRight.loadContent(contentManager.Load<Texture2D>("abelut/ANDANDO_DIREITA"), contentManager.Load<Texture2D>("abelut/ANDANDO_DIREITA_CABECA"), 8, 0, 110);
            sprDiagonalEsquerdaBaixo.loadContent(contentManager.Load<Texture2D>("abelut/ANDANDO_DIAGONAL_BAIXO_ESQUERDA"), contentManager.Load<Texture2D>("abelut/ANDANDO_DIAGONAL_BAIXO_ESQUERDA_CABECA"), 8, 0, 110);
            sprDiagonalDireitaBaixo.loadContent(contentManager.Load<Texture2D>("abelut/ANDANDO_DIAGONAL_BAIXO_DIREITA"), contentManager.Load<Texture2D>("abelut/ANDANDO_DIAGONAL_BAIXO_DIREITA_CABECA") , 8, 0, 110);
            sprDiagonalEsquerdaCima.loadContent(contentManager.Load<Texture2D>("abelut/ANDANDO_DIAGONAL_CIMA_ESQUERDA"), contentManager.Load<Texture2D>("abelut/ANDANDO_DIAGONAL_CIMA_ESQUERDA_CABECA"), 8, 0, 110);
            sprDiagonalDireitaCima.loadContent(contentManager.Load<Texture2D>("abelut/ANDANDO_DIAGONAL_CIMA_DIREITA_2"), contentManager.Load<Texture2D>("abelut/ANDANDO_DIAGONAL_CIMA_DIREITA_CABECA"), 8, 0, 110);
            sprParadoBaixoEsquerda.loadContent(contentManager.Load<Texture2D>("abelut/PARADO_BAIXO_ESQUERDA"), contentManager.Load<Texture2D>("abelut/PARADO_BAIXO_ESQUERDA_CABECA"), 1, 0, 0);
            sprParadoBaixoDireita.loadContent(contentManager.Load<Texture2D>("abelut/PARADO_BAIXO_DIREITA"), contentManager.Load<Texture2D>("abelut/PARADO_BAIXO_DIREITA_CABECA"), 1, 0, 0);
            sprPointer.loadContent(contentManager.Load<Texture2D>("abelut/pointer"), 2, 0, 300);
            sprPointer.setVisible(false);
        }

        public void configureController()
        {
            input.addKey("press-down", new InputKey(Keys.S, InputController.InputType.Press));
            input.addKey("press-up", new InputKey(Keys.W, InputController.InputType.Press));
            input.addKey("pressing-up", new InputKey(Keys.W, InputController.InputType.Pressing));
            input.addKey("pressing-down", new InputKey(Keys.S, InputController.InputType.Pressing));
            input.addKey("hold-up", new InputKey(Keys.W, InputController.InputType.Hold));
            input.addKey("hold-down", new InputKey(Keys.S, InputController.InputType.Hold));
            input.addKey("press-left", new InputKey(Keys.A, InputController.InputType.Press));
            input.addKey("press-right", new InputKey(Keys.D, InputController.InputType.Press));
            input.addKey("pressing-left", new InputKey(Keys.A, InputController.InputType.Pressing));
            input.addKey("pressing-right", new InputKey(Keys.D, InputController.InputType.Pressing));
            input.addKey("hold-left", new InputKey(Keys.A, InputController.InputType.Hold));
            input.addKey("hold-right", new InputKey(Keys.D, InputController.InputType.Hold));
            input.addKey("pressing-ctrl", new InputKey(Keys.LeftControl, InputController.InputType.Press));
        }

        public void clearOpacity()
        {

        }

        public void update(GameTime gameTime)
        {
            characterName.setText(profile.name);
            input.update(gameTime);
            mouseState = Mouse.GetState();

            if (sprPointer.isVisible())
                sprPointer.update(gameTime);

            if (lastMouseState.LeftButton == ButtonState.Released && mouseState.LeftButton == ButtonState.Pressed 
                && mouseState.X > 0 && mouseState.Y > 0 && mouseState.X < 800 && mouseState.Y < 600)
            {
                clickSe.Play();
                autoX = mouseState.X;
                autoY = mouseState.Y;
                autoX = autoX % 2 == 0 ? autoX : autoX + 1;
                autoY = autoY % 2 == 0 ? autoY : autoY + 1;

                autoMoving = true;
                sprPointer.setLocation(autoX - 5, autoY - 5);
                sprPointer.setVisible(true);
            }

            if (autoMoving)
            {
                if (input.isKeySatisfied("press-left") || input.isKeySatisfied("press-right") ||
                    input.isKeySatisfied("press-up") || input.isKeySatisfied("press-down"))
                {
                    autoMoving = false;
                    sprPointer.setVisible(false);
                }
                else
                {

                    state = StateType.andando;
                    //footAutoX = (int)Utils.getGenericSpriteFoot(spriteToDraw).X;
                    //footAutoY = (int)Utils.getGenericSpriteFoot(spriteToDraw).Y;
                    footAutoX = x + 60;
                    footAutoY = y + 110;
                    if (autoX > footAutoX && autoY < y)
                    {
                        position = PositionType.direitaCima; ;
                        spriteToDraw = sprDiagonalDireitaCima;
                        x += MOVSPEED;
                        y -= MOVSPEED;
                        //speedX = MOVSPEED;
                        //speedY = -MOVSPEED;
                    }
                    else if (autoX > footAutoX && autoY > footAutoY)
                    {
                        position = PositionType.direitaBaixo;
                        spriteToDraw = sprDiagonalDireitaBaixo;
                        x += MOVSPEED;
                        y += MOVSPEED;
                    }
                    else if (autoX < footAutoX && autoY < footAutoY)
                    {
                        position = PositionType.esquerdaCima;
                        spriteToDraw = sprDiagonalEsquerdaCima;
                        x -= MOVSPEED;
                        y -= MOVSPEED;
                    }
                    else if (autoX < footAutoX && autoY > footAutoY)
                    {
                        position = PositionType.esquerdaBaixo;
                        spriteToDraw = sprDiagonalEsquerdaBaixo;
                        x -= MOVSPEED;
                        y += MOVSPEED;
                    }
                    else if (autoX > footAutoX)
                    {
                        position = PositionType.direita;
                        spriteToDraw = sprWalkingRight;
                        x += MOVSPEED;
                    }
                    else if (autoX < footAutoX)
                    {
                        position = PositionType.esquerda;
                        spriteToDraw = sprWalkingLeft;
                        x -= MOVSPEED;
                    }
                    else if (autoY > footAutoY)
                    {
                        position = PositionType.baixo;
                        spriteToDraw = sprWalkingDown;
                        y += MOVSPEED;
                    }
                    else if (autoY < footAutoY)
                    {
                        position = PositionType.cima;
                        spriteToDraw = sprWalkingUp;
                        y -= MOVSPEED;
                    }
                    else
                    {
                        autoMoving = false;
                        state = StateType.parado;
                        sprPointer.setVisible(false);
                    }
                }
            }

            if (input.isKeySatisfied("pressing-ctrl") && profile.sp >= 19)
            {
                dashAction.start();

                profile.sp -= 19;
            }

            if (dashAction != null && dashAction.isRunning())
                dashAction.update(gameTime);
            
            if (input.isKeySatisfied("press-down")) {
                position = PositionType.baixo;
                sprWalkingDown.setCurrentFrame(0);
            }

            if (input.isKeySatisfied("press-left"))
            {
                position = PositionType.esquerda;
                sprWalkingLeft.setCurrentFrame(0);
            }

            if (input.isKeySatisfied("press-right"))
            {
                position = PositionType.direita;
                sprWalkingRight.setCurrentFrame(0);
            }

            if (input.isKeySatisfied("pressing-left") && input.isKeySatisfied("pressing-down"))
            {
                position = PositionType.esquerdaBaixo;
                state = StateType.andando;
                spriteToDraw = sprDiagonalEsquerdaBaixo;
                speedY = MOVSPEED;
                speedX = -MOVSPEED;
            } else if (input.isKeySatisfied("pressing-left") && input.isKeySatisfied("pressing-up")) {
                position = PositionType.esquerdaCima;
                state = StateType.andando;
                spriteToDraw = sprDiagonalEsquerdaCima;
                speedY = -MOVSPEED;
                speedX = -MOVSPEED;
            } else if (input.isKeySatisfied("pressing-right") && input.isKeySatisfied("pressing-up")) {
                position = PositionType.direitaCima;
                state = StateType.andando;
                spriteToDraw = sprDiagonalDireitaCima;
                speedY = -MOVSPEED;
                speedX = MOVSPEED;
            } else if (input.isKeySatisfied("pressing-right") && input.isKeySatisfied("pressing-down"))
            {
                position = PositionType.direitaBaixo;
                state = StateType.andando;
                spriteToDraw = sprDiagonalDireitaBaixo;
                speedY = MOVSPEED;
                speedX = MOVSPEED;
            }  else if (input.isKeySatisfied("pressing-down"))
            {
                temp = "PRESSING_DOWN";
                position = PositionType.baixo;
                state = StateType.andando;
                spriteToDraw = sprWalkingDown;
                speedY = MOVSPEED;
            } else if (input.isKeySatisfied("pressing-left"))
            {
                position = PositionType.esquerda;
                state = StateType.andando;
                spriteToDraw = sprWalkingLeft;
                speedX = -MOVSPEED;
            }  else if (input.isKeySatisfied("pressing-right"))
            {
                position = PositionType.direita;
                state = StateType.andando;
                spriteToDraw = sprWalkingRight;
                speedX = MOVSPEED;
            } else if (input.isKeySatisfied("press-up"))
            {
                position = PositionType.cima;
                sprWalkingUp.setCurrentFrame(0);
            } else if (input.isKeySatisfied("pressing-up"))
            {
                position = PositionType.cima;
                state = StateType.andando;
                spriteToDraw = sprWalkingUp;
                speedY = -MOVSPEED;
            }

            if ((input.isKeySatisfied("hold-down") && input.isKeySatisfied("hold-left"))
                || (input.isKeySatisfied("hold-down") && lastInput.isKeySatisfied("hold-left"))
                || (input.isKeySatisfied("hold-left") && lastInput.isKeySatisfied("hold-down")))
            {
                position = PositionType.esquerdaBaixo;
                state = StateType.parado;
            } else if ((input.isKeySatisfied("hold-down") && input.isKeySatisfied("hold-right"))
                || (input.isKeySatisfied("hold-down") && lastInput.isKeySatisfied("hold-right"))
                || (input.isKeySatisfied("hold-right") && lastInput.isKeySatisfied("hold-down"))) {
                    position = PositionType.direitaBaixo;
                    state = StateType.parado;
            } else if (input.isKeySatisfied("hold-up"))
            {
                position = PositionType.cima;
                state = StateType.parado;
            } else if (input.isKeySatisfied("hold-down"))
            {
                if (lastPosition != PositionType.esquerdaBaixo)
                    position = PositionType.baixo;
                state = StateType.parado;
            } else if (input.isKeySatisfied("hold-left"))
            {
                if (lastPosition != PositionType.esquerdaBaixo)
                    position = PositionType.esquerda;
                state = StateType.parado;
            } else if (input.isKeySatisfied("hold-right"))
            {
                if (lastPosition != PositionType.direitaBaixo)
                    position = PositionType.direita;
                state = StateType.parado;
            }

            if (state != StateType.andando)
            {
                switch (position)
                {
                    case PositionType.baixo:
                        spriteToDraw = sprParadoBaixo;
                        break;
                    case PositionType.cima:
                        spriteToDraw = sprParadoCima;
                        break;
                    case PositionType.esquerda:
                        spriteToDraw = sprParadoEsquerda;
                        break;
                    case PositionType.direita:
                        spriteToDraw = sprParadoDireita;
                        break;
                    case PositionType.esquerdaBaixo:
                        spriteToDraw = sprParadoBaixoEsquerda;
                        break;
                    case PositionType.direitaBaixo:
                        spriteToDraw = sprParadoBaixoDireita;
                        break;
                    case PositionType.esquerdaCima:
                        spriteToDraw = sprParadoCima;
                        break;
                    case PositionType.direitaCima:
                        spriteToDraw = sprParadoCima;
                        break;
                    default: break;
                }
                speedX = speedY = 0;
            }


            ///TESTE COMPLETO
            

            

            spriteToDraw.update(gameTime);
            x += speedX;
            y += speedY;
            spriteToDraw.setX(x);
            spriteToDraw.setY(y);

            lastInput = input;
            lastState = state;
            lastPosition = position;
            lastMouseState = mouseState;

            classPicture.setLocation(x + 20, y - 10);
            characterName.setLocation(x + 40, y - 8);

            debug.setText("Position: " + position + "\n" + temp + "\nX: " + x);
        }

        public void dash()
        {

        }

        public void draw(SpriteBatch spriteBatch)
        {
            //debug.draw(spriteBatch);
            if (spriteToDraw != null)
            {
                //spriteToDraw.setColor(Color.PowderBlue);
                sprPointer.draw(spriteBatch);
                spriteToDraw.draw(spriteBatch);
                classPicture.draw(spriteBatch);
                characterName.draw(spriteBatch);
                
                
            }
        }
    }
}
