using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Miner.UiForInv;
using System;
using Keyboard = Microsoft.Xna.Framework.Input.Keyboard;
using Keys = Microsoft.Xna.Framework.Input.Keys;
using SpriteBatch = Microsoft.Xna.Framework.Graphics.SpriteBatch;

namespace Miner
{
    internal class Tools
    {
        protected const string SPRITESHEET_BATTERY = "BatterySpritesheet2";
        private Texture2D batterySpritesheet;


        public float Battery = 10;
        public float draintimer = 0;
        public float gaintimer = 0;
        private int batteryFrame = 0;


        public int batteryMax;
        public int solarPanelSize;
        //Balancen mellem solpanel og batteri
        public int solarPanelCombined;

        public void LoadContent(ContentManager content)
        {
            batterySpritesheet = content.Load<Texture2D>(SPRITESHEET_BATTERY);
            batteryMax = 10000;
            solarPanelSize = 8000;
            
        }

        
        public void Update(GameTime gameTime)
        {
            solarPanelCombined = batteryMax - solarPanelSize;
            //Battery upgrade

            if (UpgradeButton.Upgraded[7] == true)
            {
                batteryMax = 14000;
            }
            
            if (UpgradeButton.Upgraded[6] == true)
            {
                batteryMax = 13000;
            }
            
            if (UpgradeButton.Upgraded[5] == true)
            {
                batteryMax = 12000;
            }

            if (UpgradeButton.Upgraded[4] == true)
            {
                batteryMax = 11000;
            }

            //Solar upgrade
            
            if (UpgradeButton.Upgraded[11] == true)
            {
                solarPanelSize = 10000;
            }

            if (UpgradeButton.Upgraded[10] == true)
            {
                solarPanelSize = 9500;
            }

            if (UpgradeButton.Upgraded[9] == true)
            {
                solarPanelSize = 9000;
            }

            if (UpgradeButton.Upgraded[8] == true)
            {
                solarPanelSize = 8500;
            }

        }
        
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            gaintimer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (Keyboard.GetState().IsKeyDown(Keys.Q) && batteryFrame > 0 && gaintimer > solarPanelCombined)
            {

                batteryFrame = batteryFrame - 30;
                gaintimer = 0;
                
            }

            


            draintimer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (draintimer > batteryMax && batteryFrame <= 320 && !Keyboard.GetState().IsKeyDown(Keys.Q))

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
