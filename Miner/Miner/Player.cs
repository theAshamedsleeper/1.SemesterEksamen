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

namespace Miner
{
    internal class Player : GameObjects
    {
        

        

        public override void LoadContent(ContentManager content)
        {
           

            _spriteSheetTexture = content.Load<Texture2D>(ASSET_NAME_SPRITESHEET);
        }

        public override void Update(GameTime gameTime)
        {


            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                effect = SpriteEffects.None;
                timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                velocity += new Vector2(5, 0);

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
                effect = SpriteEffects.FlipHorizontally;
                timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                velocity += new Vector2(-5, 0);


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



            
        }

       
    }
}
