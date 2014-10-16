using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace DreamWorld.Try3
{
    class MTCharacter : Character
    {
        public override void initialize(Vector2 startLocation, int speed) {
            profile = new Try2.BaseAtributes();
            profile.name = "Abdias";
            profile.lv = 71;
            profile.hp = profile.maxHp = 160287;
            profile.sp = profile.maxSp = 1843;
            profile.xp = 758000;
            profile.maxXp = 758000;
            profile.at_defesa = 30;
            base.initialize(startLocation, speed);
        }

        public override void loadContent(ContentManager contentManager) {
            base.loadContent(contentManager);
            sprParadoBaixo.loadContent(contentManager.Load<Texture2D>("abelut/parado_baixo"), contentManager.Load<Texture2D>("ABELUT/PARADO_BAIXO_CABECA"), 1, 0, 0);
            sprParadoCima.loadContent(contentManager.Load<Texture2D>("ABELUT/PARADO_CIMA"), contentManager.Load<Texture2D>("ABELUT/PARADO_CIMA_CABECA"), 1, 0, 0);
            sprWalkingDown.loadContent(contentManager.Load<Texture2D>("abelut/ANDANDO_BAIXO"), contentManager.Load<Texture2D>("abelut/ANDANDO_BAIXO_CABECA"), 8, 0, 110);
            sprWalkingUp.loadContent(contentManager.Load<Texture2D>("abelut/ANDANDO_CIMA"), contentManager.Load<Texture2D>("abelut/ANDANDO_CIMA_CABECA"), 8, 0, 110);
            sprParadoEsquerda.loadContent(contentManager.Load<Texture2D>("abelut/PARADO_ESQUERDA"), contentManager.Load<Texture2D>("abelut/PARADO_ESQUERDA_CABECA"), 1, 0, 0);
            sprParadoDireita.loadContent(contentManager.Load<Texture2D>("abelut/PARADO_DIREITA"), contentManager.Load<Texture2D>("abelut/PARADO_DIREITA_CABECA"), 1, 0, 0);
            sprWalkingLeft.loadContent(contentManager.Load<Texture2D>("abelut/ANDANDO_ESQUERDA"), contentManager.Load<Texture2D>("abelut/ANDANDO_ESQUERDA_CABECA"), 8, 0, 110);
            sprWalkingRight.loadContent(contentManager.Load<Texture2D>("abelut/ANDANDO_DIREITA"), contentManager.Load<Texture2D>("abelut/ANDANDO_DIREITA_CABECA"), 8, 0, 110);
            sprDiagonalEsquerdaBaixo.loadContent(contentManager.Load<Texture2D>("abelut/ANDANDO_DIAGONAL_BAIXO_ESQUERDA"), contentManager.Load<Texture2D>("abelut/ANDANDO_DIAGONAL_BAIXO_ESQUERDA_CABECA"), 8, 0, 110);
            sprDiagonalDireitaBaixo.loadContent(contentManager.Load<Texture2D>("abelut/ANDANDO_DIAGONAL_BAIXO_DIREITA"), contentManager.Load<Texture2D>("abelut/ANDANDO_DIAGONAL_BAIXO_DIREITA_CABECA"), 8, 0, 110);
            sprDiagonalEsquerdaCima.loadContent(contentManager.Load<Texture2D>("abelut/ANDANDO_DIAGONAL_CIMA_ESQUERDA"), contentManager.Load<Texture2D>("abelut/ANDANDO_DIAGONAL_CIMA_ESQUERDA_CABECA"), 8, 0, 110);
            sprDiagonalDireitaCima.loadContent(contentManager.Load<Texture2D>("abelut/ANDANDO_DIAGONAL_CIMA_DIREITA_2"), contentManager.Load<Texture2D>("abelut/ANDANDO_DIAGONAL_CIMA_DIREITA_CABECA"), 8, 0, 110);
            sprParadoBaixoEsquerda.loadContent(contentManager.Load<Texture2D>("abelut/PARADO_BAIXO_ESQUERDA"), contentManager.Load<Texture2D>("abelut/PARADO_BAIXO_ESQUERDA_CABECA"), 1, 0, 0);
            sprParadoBaixoDireita.loadContent(contentManager.Load<Texture2D>("abelut/PARADO_BAIXO_DIREITA"), contentManager.Load<Texture2D>("abelut/PARADO_BAIXO_DIREITA_CABECA"), 1, 0, 0);
            sprBattleDireita.loadContent(contentManager.Load<Texture2D>("abelut/battle_direita"), 6, 0, 50);
            sprBattleEsquerda.loadContent(contentManager.Load<Texture2D>("abelut/battle_esquerda"), 6, 0, 50);
            sprBattleDireitaCima.loadContent(contentManager.Load<Texture2D>("abelut/battle_direita_cima"), 5, 0, 50);
            sprBattleEsquerdaCima.loadContent(contentManager.Load<Texture2D>("abelut/battle_esquerda_cima"), 5, 0, 50);
        }

        public override void update(GameTime gameTime) {
            base.update(gameTime);
        }

        public override void draw(SpriteBatch spriteBatch) {
            base.draw(spriteBatch);
        }
    }
}
