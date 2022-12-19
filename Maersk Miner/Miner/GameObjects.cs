using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SpriteBatch = Microsoft.Xna.Framework.Graphics.SpriteBatch;

namespace Miner
{

    internal abstract class GameObjects
    {
        protected int frame = 0;
        protected float frameTimer = 0f;
        protected float idletimer = 0f;
        protected SpriteEffects effect = SpriteEffects.None;
        protected float speed = 200f;
        public Vector2 position = new Vector2(10, 10);

        protected const string SPRITESHEET_DRIVING = "DrillMoving9Spritesheet";
        protected const string SPRITESHEET_DIGGING_SIDE = "DrillDiggingSide6Spritesheet";
        protected const string SPRITESHEET_FLYING = "DrillFlying7Spritesheet";
        protected const string SPRITESHEET_DIGGING_DOWN = "DrillDiggingDown3Spritesheet";
        protected const string SPRITE_OVERLAY = "DrillIdleBub3";
        protected const string SPRITESHEET_DIGGING_UP = "DrillDiggingUp4Spr";


        protected Texture2D _spriteSheetTexture;
        protected Texture2D _spriteIdleTexture;
        public SpriteFont _controlsFont;
        public Player _drillOverlay;
        public Player _drill;
        public bool drilling = false;

        public abstract void LoadContent(ContentManager content);



        public abstract void Update(GameTime gameTime);

        //protected void Move(GameTime gameTime)
        //{
        //    float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

        //    position += ((velocity * speed) * deltaTime);
        //}

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {


            spriteBatch.Draw(_spriteSheetTexture, position, new Rectangle(frame, 0, 32, 32), Color.White, 0f, new Vector2(0, 0), 4.34375f, effect, 1f);

            idletimer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (idletimer > 750)
            {
                if (drilling == false)
                {
                    spriteBatch.Draw(_spriteIdleTexture, position, new Rectangle(0, 0, 32, 32), Color.White, 0f, new Vector2(0, 0), 4.34375f, effect, 1f);
                }

            }
            if (idletimer > 1000)
            {
                idletimer = 0;
            }




            //spriteBatch.DrawString(_controlsFont,
            //    $"Inventory: I\nMove:  W, S, A, D"
            //    , new Vector2(1600, 20), Color.Green, 0f, new Vector2 (0,0),2f, SpriteEffects.None,1);

        }








    }
}
