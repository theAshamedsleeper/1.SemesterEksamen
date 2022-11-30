using Microsoft.VisualBasic.Devices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct2D1.Effects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Xna.Framework.Input;
using Keyboard = Microsoft.Xna.Framework.Input.Keyboard;
using Keys = Microsoft.Xna.Framework.Input.Keys;
using ButtonState = Microsoft.Xna.Framework.Input.ButtonState;

namespace Miner
{
    internal class Player : GameObjects
    {
        private Texture2D spriteIdleTexture;
        private Texture2D _drivingTexture;
        private Texture2D _flyingTexture;
        private Texture2D _drillingTexture;

        public Player(Vector2 position)
        {
            this.position = position;
        }

        public override void LoadContent(ContentManager content)
        {
            _drivingTexture = content.Load<Texture2D>(SPRITESHEET_DRIVING);
            _flyingTexture = content.Load<Texture2D>(SPRITESHEET_FLYING);
            _drillingTexture = content.Load<Texture2D>(SPRITESHEET_DIGGING);

            _spriteSheetTexture = _drivingTexture;
            _spriteIdleTexture = content.Load<Texture2D>(SPRITE_OVERLAY);

            

        }

      

       

        public override void Update(GameTime gameTime)
        {

           
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                
                effect = SpriteEffects.None;
                timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                
                if (timer > 50)
                {
                    frame = frame + 32;
                    timer = 0;
                }
                // 32, 64, 96, 128 = De fire frames
                if (frame == 128)
                {
                    frame = 0;
                }



            }

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                _spriteSheetTexture = _drivingTexture;
                effect = SpriteEffects.FlipHorizontally;
                timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                



                if (timer > 50)
                {
                    frame = frame + 32;
                    timer = 0;
                }
                // 32, 64, 96, 128 = De fire frames
                if (frame == 128)
                {
                    frame = 0;
                }

            }


            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                _spriteSheetTexture = _flyingTexture;
                timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                


                if (timer > 50)
                {
                    frame = frame + 32;
                    timer = 0;
                }
                // 32, 64, 96, 128 = De fire frames
                if (frame == 128)
                {
                    frame = 0;
                }

            }

            if (Keyboard.GetState().IsKeyDown(Keys.R)) // Burde være ved collision med blok
            {
                _spriteSheetTexture = _drillingTexture;

                timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;



                if (timer > 50)
                {
                    frame = frame + 32;
                    timer = 0;
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
            }
        


        }

        
    }
}
