using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DreamWorld.Examples {
    class DrawableActionManagerExample : Example {
        DrawableActionManager actionManager;
        LetterTextAction textAction1, textAction2;
        WaitAction waitAction;
        Vector2 location;
        const double textSpeed = 150;

        public void initialize() {
            location = new Vector2(200, 200);

            textAction1 = new LetterTextAction(new LetterText("Testando a primeira frase...", new GenericTimeout(textSpeed)));
            textAction2 = new LetterTextAction(new LetterText("Testando a segunda frase...", new GenericTimeout(textSpeed)));
            waitAction = new WaitAction();

            waitAction.initialize(new GenericTimeout(10000));

            actionManager = new DrawableActionManager();
            actionManager.addAction(textAction1);
            actionManager.addAction(waitAction);
            actionManager.addAction(textAction2);
        }

        public void loadContent(ContentManager contentManager) {
            initialize();

            textAction1.getLetterText().setFont(contentManager.Load<SpriteFont>("Examples/font"));
            textAction1.getLetterText().setLocation(location);
            textAction2.getLetterText().setFont(contentManager.Load<SpriteFont>("Examples/font"));
            textAction2.getLetterText().setLocation(location);

            actionManager.start();
        }

        public void update(GameTime gameTime) {
            actionManager.update(gameTime);
        }

        public void draw(SpriteBatch spriteBatch) {
            actionManager.draw(spriteBatch);
        }
    }
}
