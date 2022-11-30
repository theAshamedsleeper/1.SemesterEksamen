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
       
        

        public override void LoadContent(ContentManager content)
        {
           

            _spriteSheetTexture = content.Load<Texture2D>(SPRITESHEET_DRIVING);
            _spriteIdleTexture = content.Load<Texture2D>(SPRITE_OVERLAY);

            _drill = new Player(_spriteSheetTexture, position);
            _drillOverlay = new Player(_spriteIdleTexture, position);

        }

      

       

        public override void Update(GameTime gameTime, Vector2 position)
        {


     

            #region Clumsy controlls
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                _spriteSheetTexture = Content.Load<Texture2D>(SPRITESHEET_DRIVING);
                effect = SpriteEffects.None;
                timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                //position += new Vector2(5, 0);

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
                _spriteSheetTexture = Content.Load<Texture2D>(SPRITESHEET_DRIVING);
                effect = SpriteEffects.FlipHorizontally;
                timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                //position += new Vector2(-5, 0);


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
                _spriteSheetTexture = Content.Load<Texture2D>(SPRITESHEET_FLYING);
                timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                //position += new Vector2(0, -5);


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
                _spriteSheetTexture = Content.Load<Texture2D>(SPRITESHEET_DIGGING);

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
                _spriteSheetTexture = Content.Load<Texture2D>(SPRITESHEET_DRIVING);
            }
            #endregion









        }


    }
}
