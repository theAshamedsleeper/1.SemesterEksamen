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
        protected Vector2 positionx = new Vector2(10, 10);
        protected SpriteEffects effect = SpriteEffects.None;
        protected float speed = 200f;
        


        protected const string ASSET_NAME_SPRITESHEET = "Digger7Spritesheet_NB";

      

        protected Texture2D _spriteSheetTexture;


        public abstract void LoadContent(ContentManager content);

        public abstract void Update(GameTime gameTime);

        //protected void Move(GameTime gameTime)
        //{
        //    float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

        //    position += ((velocity * speed) * deltaTime);
        //}

        public void Draw(SpriteBatch spriteBatch)
        {
            


            spriteBatch.Draw(_spriteSheetTexture, positionx, new Rectangle(frame, 0, 32, 32), Color.White, 0f, new Vector2(0, 0), 7, effect, 1f);
            
        }








    }
}
