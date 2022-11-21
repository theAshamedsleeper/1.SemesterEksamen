using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miner
{
    internal abstract class GameObjects
    {
        protected Texture2D sprites;
        protected Texture2D barSprites;
        protected Rectangle energyRecBar;
        protected Rectangle seedChestRectangle;
        protected Vector2 positions;
        protected float scale;
        protected float speed;
        protected Vector2 velocity;
        protected byte charSpriteIndex;
        protected Texture2D charset;
        protected Vector2[] position1;
        protected int threshold;
        protected Rectangle SourceRectangle;

        //Constructor:

        public GameObjects(Vector2 pos)
        {

        }



        //Methods:


        private Texture2D GetCurrentSprite
        {
            get
            {
                return;
            }
        }

        private Vector2 GetSpriteSize
        {
            get
            {
                return;
            }
        }

        public void LoadContent()
        {

        }

        public abstract void Update(GameTime gameTime);

        protected void Move(GameTime gametime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }

        public Rectangle GetCollisionBox
        {
            get
            {
                return;
            }
        }

        public bool IsColliding(GameObjects other)
        {
           
        }
        



    }
}
