using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Miner.UiForInv;
using SpriteBatch = Microsoft.Xna.Framework.Graphics.SpriteBatch;

namespace Miner
{
    internal class Tools
    {
        protected const string SPRITESHEET_BATTERY = "BatterySpritesheet2";
        private Texture2D batterySpritesheet;


        public float Battery = 10;
        public float draintimer = 0;
        private int batteryFrame = 0;


        public int batteryMax = 10000;

        public void LoadContent(ContentManager content)
        {
            batterySpritesheet = content.Load<Texture2D>(SPRITESHEET_BATTERY);
        }

        public void Update(GameTime gameTime)
        {
            if (UpgradeButton.Upgraded[7] == true)
            {
                batteryMax = 14000;
            }
            else if (UpgradeButton.Upgraded[6] == true)
            {
                batteryMax = 13000;
            }
            else if (UpgradeButton.Upgraded[5] == true)
            {
                batteryMax = 12000;
            }
            else if (UpgradeButton.Upgraded[4] == true)
            {
                batteryMax = 11000;
            }

        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {

            draintimer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;


            if (draintimer > batteryMax && batteryFrame <= 320)
            {
                batteryFrame = batteryFrame + 30;
                draintimer = 0;
            }

            if (batteryFrame > 320)
            {
                //Game over

            }



            spriteBatch.Draw(batterySpritesheet, new Vector2(100, 100), new Rectangle(batteryFrame, 0, 32, 32), Color.White, 0f, new Vector2(0, 0), 5f, SpriteEffects.None, 1f);

        }
    }
}
