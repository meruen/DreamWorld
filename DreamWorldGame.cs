using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace DreamWorld {
    public class DreamWorldGame : Microsoft.Xna.Framework.Game {
        GraphicsDeviceManager graphics;

        SpriteBatch spriteBatch;
       // Examples.Example example;
        Picture bg;
        MouseState mouseState;
        Picture cursor, atkCursor, normalCursor;
        Try3.MTCharacter mtc;
        //Try1.MainChar mainChar;
        Try1.MainHud mainHud;
        Try3.MTPoring poring, poring2;
        Random rd;

        List<Try3.MonsterAvatar> monsters;

        public DreamWorldGame() {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 800;
            graphics.ApplyChanges();
            //mainChar = new Try1.MainChar();
            
            mtc = new Try3.MTCharacter();
            mtc.initialize(new Vector2(200, 200), 2);
            mainHud = new Try1.MainHud(mtc);
            cursor = new Picture();
            atkCursor = new Picture();
            normalCursor = new Picture();
            bg = new Picture();
            poring = new Try3.MTPoring();
            poring2 = new Try3.MTPoring();
            rd = new Random();

            monsters = new List<Try3.MonsterAvatar>();
            monsters.Add(poring);
            monsters.Add(poring2);
            
            

            Content.RootDirectory = "Content";

            //example = new Examples.GenericActorExample();
        }

        protected override void Initialize() {
            base.Initialize();
            
        }

        protected override void LoadContent() {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            //example.loadContent(Content);
            //mainChar.loadContent(Content);
           
            //mainHud.loadContent(Content, mainChar.sprParadoBaixo.head.getTexture());
            mtc.loadContent(Content);
            mainHud.loadContent(Content, mtc.sprParadoBaixo.head.getTexture());
            normalCursor.loadContent(Content.Load<Texture2D>("Tests/cursorblue"));
            atkCursor.loadContent(Content.Load<Texture2D>("Examples/cursor_atk"));
            cursor = normalCursor;
            bg.loadContent(Content.Load<Texture2D>("abelut/bg"));

            
            foreach (Try3.MonsterAvatar element in monsters) {

                element.initialize();
                element.loadContent(Content);
                ((Try3.MTPoring)element).skill.target = mtc;
                element.setLocation(rd.Next(50, 750), rd.Next(50, 550));
            }
        }


        protected override void UnloadContent() {

        }

        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            mouseState = Mouse.GetState();
            cursor.setLocation(mouseState.X, mouseState.Y);

            bool cursor_at_monster = false;
            Rectangle cursor_point = new Rectangle((int)cursor.getX(), (int)cursor.getY(), 1, 1);


            if (mouseState.LeftButton == ButtonState.Pressed) {
                mtc.autoMove(mouseState.X, mouseState.Y);
            }

            mtc.update(gameTime);
            foreach (Try3.MonsterAvatar element in monsters) {
                element.update(gameTime);
                if (element.getSpriteToDraw().getRect().Intersects(cursor_point)) {
                    cursor_at_monster = true;
                }
            }

            if (cursor_at_monster) {
                atkCursor.setX(cursor.getX());
                atkCursor.setY(cursor.getY());
                cursor = atkCursor;
            } else {
                normalCursor.setX(cursor.getX());
                normalCursor.setY(cursor.getY());
                cursor = normalCursor;

            }

            //poring.update(gameTime);
            //poring2.update(gameTime);
            //example.update(gameTime);
            //mainChar.update(gameTime);
            mainHud.update();
            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            bg.draw(spriteBatch);
            //example.draw(spriteBatch);
            foreach (Try3.MonsterAvatar element in monsters)
                poring.draw(spriteBatch);
            poring2.draw(spriteBatch);
            //mainChar.draw(spriteBatch);
            mtc.draw(spriteBatch);
            mainHud.draw(spriteBatch);
            cursor.draw(spriteBatch);
            spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}
