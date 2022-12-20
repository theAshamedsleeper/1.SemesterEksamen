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
        public float gaintimer = 0;
        public static int batteryFrame = 0;
        public int batteryMax;
        public int solarPanelSize;
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
            /*(variablen solarPanelCombined^ sikrer at et større batteri tager længere tid at oplade,
            i sammenhæng med størrelsen af solpanelet. 
            Dvs. at den bruges til at skabe dynamik mellem solpanelet og batteriet,
            og definerer solpanelets virkning, når de opgraderes i de nedenstående regioner.) */


            #region - Battery upgrade -
            if (UpgradeButton.Upgraded[7] == true)
            {
                batteryMax = 30000;
            }
            if (UpgradeButton.Upgraded[6] == true)
            {
                batteryMax = 25000;
            }
            if (UpgradeButton.Upgraded[5] == true)
            {
                batteryMax = 20000;
            }
            if (UpgradeButton.Upgraded[4] == true)
            {
                batteryMax = 15000;
            }

            #endregion

            #region - Solar upgrade -

            if (UpgradeButton.Upgraded[11] == true)
            {
                if (batteryMax - 25000! <= 0)
                {
                    solarPanelSize = 25000;
                }
            }

            if (UpgradeButton.Upgraded[10] == true)
            {
                if (batteryMax - 20000! <= 0)
                {
                    solarPanelSize = 20000;
                }
            }

            if (UpgradeButton.Upgraded[9] == true)
            {
                if (batteryMax - 15000! <= 0)
                {
                    solarPanelSize = 15000;
                }
            }

            if (UpgradeButton.Upgraded[8] == true)
            {
                if (batteryMax - 10000 !<= 0)
                {
                    solarPanelSize = 10000;
                }
                
            }

            #endregion

        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            // - SOLPANELETS VIRKNING -
            gaintimer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            /*gainTimer tæller op til solarPanelCombined,
            som bliver defineret pr ovenstående upgrades på sloarSize og batteryMax. 
            Når den er nået til max, skifter den frame og timeren bliver resettet. */
            if (Terrain.is_we_on_top() == true && batteryFrame > 0 && gaintimer > solarPanelCombined)
            {
                batteryFrame -= 30;
                gaintimer = 0;

            }
            // - BATTERIETS VIRKNING OG ANIMATION -
            draintimer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            //drainTimer tæller op til batteryMax, som bliver defineret pr batteri upgrade. 
            if (Terrain.is_we_on_top() == false && draintimer > batteryMax && batteryFrame <= 300)
            {
                batteryFrame = batteryFrame + 30;
                draintimer = 0;
            }


            //batteriet tegnes. Den bruger frames på samme måde som spiller animationerne i Player klassen.
            //Hvis den løber tør for frames, vil det sige at batteriet er løbet tør for energi, og spillet er tabt.
            spriteBatch.Draw(batterySpritesheet, new Vector2(100, 100), new Rectangle(batteryFrame, 0, 32, 32), Color.White, 0f, new Vector2(0, 0), 5f, SpriteEffects.None, 1f);

        }
    }
}
