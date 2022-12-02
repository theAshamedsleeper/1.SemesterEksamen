using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Keyboard = Microsoft.Xna.Framework.Input.Keyboard;
using Keys = Microsoft.Xna.Framework.Input.Keys;

namespace Miner
{
    internal class Player : GameObjects
    {
        private Texture2D spriteIdleTexture;
        private Texture2D _drivingTexture;
        private Texture2D _flyingTexture;
        private Texture2D _drillingSideTexture;
        private Texture2D _drillingDownTexture;
        private int collition;

        public Player(Vector2 position)
        {
            this.position = position;
        }

        public override void LoadContent(ContentManager content)
        {
            _drivingTexture = content.Load<Texture2D>(SPRITESHEET_DRIVING);
            _flyingTexture = content.Load<Texture2D>(SPRITESHEET_FLYING);
            _drillingSideTexture = content.Load<Texture2D>(SPRITESHEET_DIGGING_SIDE);
            _drillingDownTexture = content.Load<Texture2D>(SPRITESHEET_DIGGING_DOWN);

            _spriteSheetTexture = _drivingTexture;
            _spriteIdleTexture = content.Load<Texture2D>(SPRITE_OVERLAY);
            _controlsFont = content.Load<SpriteFont>("File");

        }

        public override void Update(GameTime gameTime)
        {

            //1 = venstre 2 = højre 3 = ned 4 = op


            if (Terrain.Which((position.X - GameWorld.ofset_x) - 1, (position.Y - GameWorld.ofset_y), Terrain.Loaded_Chunk_differ(0)) < 1f)
            {
                collition = 1;
                GameWorld.ofset_x + 1;
            }

            if (Terrain.Which((position.X - GameWorld.ofset_x), (position.Y - GameWorld.ofset_y) - 1, Terrain.Loaded_Chunk_differ(0)) < 1f)
            {
                collition = 2;
                GameWorld.ofset_y + 1;
            }

            if (Terrain.Which((position.X - GameWorld.ofset_x) + 33, (position.Y - GameWorld.ofset_y), Terrain.Loaded_Chunk_differ(0)) < 1f)
            {
                collition = 3;
                GameWorld.ofset_x - 1;
            }

            if (Terrain.Which((position.X - GameWorld.ofset_x), (position.Y - GameWorld.ofset_y) + 33, Terrain.Loaded_Chunk_differ(0)) < 1f)
            {
                collition = 4;
                GameWorld.ofset_y - 1;
            }


            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                drilling = true;
                _spriteSheetTexture = _flyingTexture;
                frameTimer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;



                if (frameTimer > 50)
                {
                    frame = frame + 32;
                    frameTimer = 0;
                }
                // 32, 64, 96, 128 = De fire frames
                if (frame == 128)
                {
                    frame = 0;
                }

            }


            else if (collition < 3)
            {
                drilling = true;
                _spriteSheetTexture = _drillingSideTexture;
                frameTimer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;



                if (frameTimer > 50)
                {
                    frame = frame + 32;
                    frameTimer = 0;
                }
                // 32, 64, 96, 128 = De fire frames
                if (frame == 128)
                {
                    frame = 0;
                }

            }

            else if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                drilling = false;
                _spriteSheetTexture = _drivingTexture;
                effect = SpriteEffects.None;
                frameTimer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

                if (frameTimer > 50)
                {
                    frame = frame + 32;
                    frameTimer = 0;
                }
                // 32, 64, 96, 128 = De fire frames
                if (frame == 128)
                {
                    frame = 0;
                }

            }

            else if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                drilling = false;
                _spriteSheetTexture = _drivingTexture;
                effect = SpriteEffects.FlipHorizontally;
                frameTimer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;


                if (frameTimer > 50)
                {
                    frame = frame + 32;
                    frameTimer = 0;
                }
                // 32, 64, 96, 128 = De fire frames
                if (frame == 128)
                {
                    frame = 0;
                }

            }
            else if (Keyboard.GetState().IsKeyDown(Keys.S)) // Burde være ved collision med blok
            {
                drilling = true;
                _spriteSheetTexture = _drillingDownTexture;
                frameTimer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;



                if (frameTimer > 50)
                {
                    frame = frame + 32;
                    frameTimer = 0;
                }
                // 32, 64, 96, 128 = De fire frames
                if (frame == 128)
                {
                    frame = 0;
                }





            }
            else
            {
                _spriteSheetTexture = _drivingTexture;
                drilling = false;
            }



        }


    }
}
