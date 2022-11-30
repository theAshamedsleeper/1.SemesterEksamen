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
        protected float frameTimer = 0f;
        protected float idletimer = 0f;
        protected Vector2 positionx = new Vector2(100, 10);
        protected SpriteEffects effect = SpriteEffects.None;
        protected float speed = 200f;
        public Vector2 position = new Vector2(10, 10);



        protected const string SPRITESHEET_DRIVING = "DrillMoving9Spritesheet";
        protected const string SPRITESHEET_DIGGING_SIDE = "DrillDiggingSide6Spritesheet";
        protected const string SPRITESHEET_FLYING = "DrillFlying6Spritesheet";
        protected const string SPRITESHEET_DIGGING_DOWN = "DrillDiggingDown3Spritesheet";
        protected const string SPRITE_OVERLAY = "DrillIdleBub3";
        

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


            spriteBatch.Draw(_spriteSheetTexture, position, new Rectangle(frame, 0, 32, 32), Color.White, 0f, new Vector2(0, 0), 5, effect, 1f);

            idletimer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (idletimer > 1500)
            {
                if (drilling == false)
                {
                    spriteBatch.Draw(_spriteIdleTexture, position, new Rectangle(0, 0, 32, 32), Color.White, 0f, new Vector2(0, 0), 5, effect, 1f);
                }
                
                
                

            }
            if (idletimer > 2000)
            {
                idletimer = 0;
            }


            spriteBatch.DrawString(_controlsFont, 
                " Fly               : T \n Drive           : F & H \n Dig down    : G \n Dig side      : B"
                , new Vector2(1600, 100), Color.Black, 0f, new Vector2 (0,0),2, SpriteEffects.None,1);

        }








    }
}
