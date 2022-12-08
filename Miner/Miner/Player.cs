using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Keyboard = Microsoft.Xna.Framework.Input.Keyboard;
using Keys = Microsoft.Xna.Framework.Input.Keys;

namespace Miner
{
    internal class Player : GameObjects
    {

        private Texture2D _drivingTexture;
        private Texture2D _flyingTexture;
        private Texture2D _drillingSideTexture;
        private Texture2D _drillingDownTexture;


        //PLAYER CONSTRUCTOR
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

            #region - Player Animations -
            /*Animationerne styres ved hjælp af flere spritesheets. Disse kaldes fra GameObjects.
            Frame variablen styrer hvilke billeder der vises på de forskellige animationer.
            Alle frames er 32 brede. 32, 64, 96, 128 = De fire frames. 
            Animationerne tegnes i Gameobjects*/

            #region - UNIVERSAL -
            
            /* (Universal har ikke 'else if', da disse spriteEffects skal påvirke alle aktioner. 
                fx skal man kunne flippe spriten til venstre med A mens man flyver, 
                uden at starte køre animationen. Af denne grund er det lavet for sig.) */
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                effect = SpriteEffects.None;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                effect = SpriteEffects.FlipHorizontally;
            }

            #endregion

            #region - FLYING ANIMATIONS -

            
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

                if (frame == 128)
                {
                    frame = 0;
                }


            }

            else if (Keyboard.GetState().IsKeyDown(Keys.S) && GameWorld.inAir == false)
            {
                drilling = true;
                _spriteSheetTexture = _flyingTexture;
                frameTimer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;


                if (frameTimer > 50)
                {

                    frame = frame - 32;
                    frameTimer = 0;

                }


                if (frame < 0)
                {
                    frame = 96;
                }

            }

            #endregion

            #region - DRILLING ANIMATIONS _ SIDE -
            

            else if (Keyboard.GetState().IsKeyDown(Keys.D) && GameWorld.sideCollision == true && GameWorld.inAir == true)
            {
                drilling = true;
                _spriteSheetTexture = _drillingSideTexture;
                frameTimer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;



                if (frameTimer > 50)
                {
                    frame = frame + 32;
                    frameTimer = 0;
                }

                if (frame == 128)
                {
                    frame = 0;
                }

            }
            else if (Keyboard.GetState().IsKeyDown(Keys.A) && GameWorld.sideCollision == true && GameWorld.inAir == true)
            {
                drilling = true;
                _spriteSheetTexture = _drillingSideTexture;
                frameTimer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;



                if (frameTimer > 50)
                {
                    frame = frame + 32;
                    frameTimer = 0;
                }

                if (frame == 128)
                {
                    frame = 0;
                }

            }
            #endregion

            #region - DRIVING ANIMATIONS -

            // - DRIVING ANIMATION -
            else if (Keyboard.GetState().IsKeyDown(Keys.D) && GameWorld.inAir == true)
            {
                drilling = false;
                _spriteSheetTexture = _drivingTexture;
                frameTimer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

                if (frameTimer > 50)
                {
                    frame = frame + 32;
                    frameTimer = 0;
                }

                if (frame == 128)
                {
                    frame = 0;
                }

            }

           
            else if (Keyboard.GetState().IsKeyDown(Keys.A) && GameWorld.inAir == true)
            {
                drilling = false;
                _spriteSheetTexture = _drivingTexture;
                frameTimer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;


                if (frameTimer > 50)
                {
                    frame = frame + 32;
                    frameTimer = 0;
                }

                if (frame == 128)
                {
                    frame = 0;
                }

            }
            #endregion

            #region - DRILLING ANIMATIONS _ DOWN -

            
            else if (Keyboard.GetState().IsKeyDown(Keys.S) && GameWorld.inAir == true)
            {
                drilling = true;
                _spriteSheetTexture = _drillingDownTexture;
                frameTimer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;



                if (frameTimer > 50)
                {
                    frame = frame + 32;
                    frameTimer = 0;
                }

                if (frame == 128)
                {
                    frame = 0;
                }

            }
            #endregion

            #region -IDLE ANIMATIONS -
            else if (GameWorld.inAir == true)
            {
                _spriteSheetTexture = _drivingTexture;
                drilling = false;

            }

            else if (GameWorld.inAir == false)
            {
                frameTimer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;


                if (frameTimer > 75)
                {
                    frame = frame + 32;
                    frameTimer = 0;
                }

                if (frame == 128)
                {
                    frame = 0;
                }


                _spriteSheetTexture = _flyingTexture;
                drilling = true;

            }
            

            
            #endregion
            #endregion

            

        }


    }
}
