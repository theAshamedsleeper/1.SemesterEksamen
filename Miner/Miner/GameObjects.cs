using Microsoft.VisualBasic.Devices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct2D1;
using SharpDX.Direct2D1.Effects;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpriteBatch = Microsoft.Xna.Framework.Graphics.SpriteBatch;

namespace Miner
{

    internal abstract class GameObjects
    {
        protected int frame = 0;
        protected float timer;
        protected Vector2 positionx = new Vector2(100, 10);
        protected SpriteEffects effect = SpriteEffects.None;
        protected float speed = 200f;
        public Vector2 position = new Vector2(10, 10);



        protected const string SPRITESHEET_DRIVING = "Digger7Spritesheet_NB";
        protected const string SPRITESHEET_DIGGING = "Pixilart Sprite Sheet (19)";
        protected const string SPRITESHEET_FLYING = "DrillFlying3Spritesheet";
        protected const string SPRITE_OVERLAY = "DrillIdleBub3";

        protected Texture2D _spriteSheetTexture;
        protected Texture2D _spriteIdleTexture; 
        public Player _drillOverlay;
        public Player _drill;

        public abstract void LoadContent(ContentManager content);
        
        

        public abstract void Update(GameTime gameTime);

        //protected void Move(GameTime gameTime)
        //{
        //    float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

        //    position += ((velocity * speed) * deltaTime);
        //}

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {


            spriteBatch.Draw(_spriteSheetTexture, position, new Rectangle(frame, 0, 32, 32), Color.White, 0f, new Vector2(0, 0), 5, effect, 1f);

            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (timer > 1500)
            {

                spriteBatch.Draw(_spriteIdleTexture, position, new Rectangle(frame, 0, 32, 32), Color.White, 0f, new Vector2(0, 0), 5, effect, 1f);

            }
            if (timer > 2000)
            {
                timer = 0;
            }


            
            
        }








    }
}
