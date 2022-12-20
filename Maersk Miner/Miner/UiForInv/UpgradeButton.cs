using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Miner.UiForInv
{
    internal class UpgradeButton : WorkShop
    {
        private MouseState mouse;
        /// <summary>
        /// Loads in all the different spirtes, location and sizes.
        /// </summary>
        /// <param name="content"></param>
        public override void LoadContent(ContentManager content)
        {
            #region Tabs
            //Background
            spritePlacer[0] = content.Load<Texture2D>("Ui Sprites/InventorybackGround");
            spritePlacerPos[0] = new Vector2(400, 400);
            //first button 
            spritePlacer[1] = content.Load<Texture2D>("Ui Sprites/InvetoryTitleCraft");
            spritePlacerPos[1] = new Vector2(400, 400);
            uiRectangles[0] = new Rectangle(400, 400, 350, 100);
            //second button 
            spritePlacer[2] = content.Load<Texture2D>("Ui Sprites/InvetoryTitleUpgrade");
            spritePlacerPos[2] = new Vector2(750, 400);
            uiRectangles[1] = new Rectangle(750, 400, 350, 100);
            //third button 
            spritePlacer[3] = content.Load<Texture2D>("Ui Sprites/InvetoryTitleArtifacts");
            spritePlacerPos[3] = new Vector2(1100, 400);
            uiRectangles[2] = new Rectangle(1100, 400, 350, 100);
            //fourth button 
            spritePlacer[4] = content.Load<Texture2D>("Ui Sprites/InvetoryTitleStats");
            spritePlacerPos[4] = new Vector2(1450, 400);
            uiRectangles[3] = new Rectangle(1450, 400, 350, 100);
            //close ButtonUI
            spritePlacer[5] = content.Load<Texture2D>("Ui Sprites/Fonts/CloseUIButton");
            uiRectangles[4] = new Rectangle(1800, 400, 100, 100);

            #endregion
            #region UpgradeTab
            spritePlacer[6] = content.Load<Texture2D>("Ui Sprites/UpgradePlaceHolder");
            spritePlacer[7] = content.Load<Texture2D>("Ui Sprites/BarDivider");//Nothing Important, just a black line
            uiRectangles[23] = new Rectangle(1600, 500, 4, 500);//Nothing Important, just the location for one of the black line
            uiRectangles[24] = new Rectangle(720, 500, 4, 500);//Nothing Important, just the location for one of the black line

            //First Upgrade Line
            uiRectangles[5] = new Rectangle(780, 540, 100, 100);
            spritePlacer[14] = content.Load<Texture2D>("Ui Sprites/UpgradeInfo/10P faster drill_Layer 0");
            uiRectangles[6] = new Rectangle(920, 540, 100, 100);
            spritePlacer[15] = content.Load<Texture2D>("Ui Sprites/UpgradeInfo/20P faster drill_Layer 1");
            uiRectangles[7] = new Rectangle(1060, 540, 100, 100);
            spritePlacer[16] = content.Load<Texture2D>("Ui Sprites/UpgradeInfo/30P faster drill_Layer 2");
            uiRectangles[8] = new Rectangle(1200, 540, 100, 100);
            spritePlacer[17] = content.Load<Texture2D>("Ui Sprites/UpgradeInfo/40P faster drill_Layer 3");
            //Second Upgrade Line
            uiRectangles[9] = new Rectangle(780, 660, 100, 100);
            spritePlacer[18] = content.Load<Texture2D>("Ui Sprites/UpgradeInfo/Biger battery_Layer 0");
            uiRectangles[10] = new Rectangle(920, 660, 100, 100);
            spritePlacer[19] = content.Load<Texture2D>("Ui Sprites/UpgradeInfo/Biger battery_Layer 1");
            uiRectangles[11] = new Rectangle(1060, 660, 100, 100);
            spritePlacer[20] = content.Load<Texture2D>("Ui Sprites/UpgradeInfo/Biger battery_Layer 2");
            uiRectangles[12] = new Rectangle(1200, 660, 100, 100);
            spritePlacer[21] = content.Load<Texture2D>("Ui Sprites/UpgradeInfo/Biger battery_Layer 3");
            //Third Upgrade Line
            uiRectangles[13] = new Rectangle(780, 780, 100, 100);
            spritePlacer[22] = content.Load<Texture2D>("Ui Sprites/UpgradeInfo/faster Battery recharge_Layer 0");
            uiRectangles[14] = new Rectangle(920, 780, 100, 100);
            spritePlacer[23] = content.Load<Texture2D>("Ui Sprites/UpgradeInfo/faster Battery recharge_Layer 0");
            uiRectangles[15] = new Rectangle(1060, 780, 100, 100);
            spritePlacer[24] = content.Load<Texture2D>("Ui Sprites/UpgradeInfo/faster Battery recharge_Layer 0");
            uiRectangles[16] = new Rectangle(1200, 780, 100, 100);
            spritePlacer[25] = content.Load<Texture2D>("Ui Sprites/UpgradeInfo/faster Battery recharge_Layer 0");
            //Last upgrade
            uiRectangles[17] = new Rectangle(1380, 600, 200, 200);
            spritePlacer[27] = content.Load<Texture2D>("Ui Sprites/Upgradeinfo/Last Upgrade AiBrainPng");
            //Ressource count
            uiRectangles[18] = new Rectangle(1600, 520, 100, 100);//where to place the icon for copper
            reCount[0] = content.Load<Texture2D>("Ui Sprites/Upgradeinfo/OreSymbol_Copper");//load in copper
            fontsTitle[5] = content.Load<SpriteFont>("Ui Sprites/Fonts/R1");//load in the amount of copper
            uiRectangles[19] = new Rectangle(1600, 590, 100, 100);//where to place the icon for MiliScrap
            reCount[1] = content.Load<Texture2D>("Ui Sprites/Upgradeinfo/OreSymbol_MiliScrap");//Load in miliScrap
            fontsTitle[6] = content.Load<SpriteFont>("Ui Sprites/Fonts/R2");//load in the amount of MiliScrap
            uiRectangles[20] = new Rectangle(1600, 660, 100, 100);////where to place the icon for titanium
            reCount[2] = content.Load<Texture2D>("Ui Sprites/Upgradeinfo/OreSymbol_Titanium");//load in Titanium
            fontsTitle[7] = content.Load<SpriteFont>("Ui Sprites/Fonts/R3");//load in the amount of Titanium
            uiRectangles[21] = new Rectangle(1600, 755, 100, 100);//Where to place the icon for Plat
            reCount[3] = content.Load<Texture2D>("Ui Sprites/Upgradeinfo/OreSymbol_Plat");//load in plat
            fontsTitle[8] = content.Load<SpriteFont>("Ui Sprites/Fonts/R4");//load in the amount of plat
            uiRectangles[22] = new Rectangle(1600, 820, 100, 100);//Where to place the icon for Uranium
            reCount[4] = content.Load<Texture2D>("Ui Sprites/Upgradeinfo/OreSymbol_Uranium");//Load in Uranium
            fontsTitle[9] = content.Load<SpriteFont>("Ui Sprites/Fonts/R5");//The amount of Uranium

            // Upgrade Info
            uiRectangles[25] = new Rectangle(465, 550, 200, 300);//First Line
            upgradeInfo[0] = content.Load<Texture2D>("Ui Sprites/UpgradeInfo/10PBetterDrill_Info");
            uiRectangles[26] = new Rectangle(465, 550, 200, 300);//First Line
            upgradeInfo[1] = content.Load<Texture2D>("Ui Sprites/UpgradeInfo/20PBetterDrill_Info");
            uiRectangles[27] = new Rectangle(465, 550, 200, 300);//First Line
            upgradeInfo[2] = content.Load<Texture2D>("Ui Sprites/UpgradeInfo/30PBetterDrill_Info");
            uiRectangles[28] = new Rectangle(465, 550, 200, 300);//First Line
            upgradeInfo[3] = content.Load<Texture2D>("Ui Sprites/UpgradeInfo/40PBetterDrill_Info");

            uiRectangles[29] = new Rectangle(465, 550, 200, 300);//Second Line
            upgradeInfo[4] = content.Load<Texture2D>("Ui Sprites/UpgradeInfo/10PBetterBattery");
            uiRectangles[30] = new Rectangle(465, 550, 200, 300);//Second Line
            upgradeInfo[5] = content.Load<Texture2D>("Ui Sprites/UpgradeInfo/20PBetterBattery");
            uiRectangles[31] = new Rectangle(465, 550, 200, 300);//Second Line
            upgradeInfo[6] = content.Load<Texture2D>("Ui Sprites/UpgradeInfo/30PBetterBattery");
            uiRectangles[32] = new Rectangle(465, 550, 200, 300);//Second Line
            upgradeInfo[7] = content.Load<Texture2D>("Ui Sprites/UpgradeInfo/40PBetterBattery");

            uiRectangles[33] = new Rectangle(465, 550, 200, 300);//Third Line
            upgradeInfo[8] = content.Load<Texture2D>("Ui Sprites/UpgradeInfo/10PBetterSolarPanel");
            uiRectangles[34] = new Rectangle(465, 550, 200, 300);//Third Line
            upgradeInfo[9] = content.Load<Texture2D>("Ui Sprites/UpgradeInfo/20PBetterSolarPanel");
            uiRectangles[35] = new Rectangle(465, 550, 200, 300);//Third Line
            upgradeInfo[10] = content.Load<Texture2D>("Ui Sprites/UpgradeInfo/30PBetterSolarPanel");
            uiRectangles[36] = new Rectangle(465, 550, 200, 300);//Third Line
            upgradeInfo[11] = content.Load<Texture2D>("Ui Sprites/UpgradeInfo/40PBetterSolarPanel");

            uiRectangles[38] = new Rectangle(465, 550, 200, 300);//Last Upgrade Info
            upgradeInfo[12] = content.Load<Texture2D>("Ui Sprites/UpgradeInfo/RougeAiUpgradeInfo");
            //Upgrade Button
            uiRectangles[37] = new Rectangle(515, 900, 100, 50);//location for Upgrade  Button
            spritePlacer[26] = content.Load<Texture2D>("Ui Sprites/UpgradeInfo/UpgradeButton");
            #endregion
            menuSound = content.Load<SoundEffect>("Sound/Menu Selection Click");
        }
        /// <summary>
        /// Calls another method, and makes you able to use the mouse.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            mouse = Mouse.GetState();//So you can click around with the mouse.
            //Closses down the Invetory
            if (IsInvOpen == true && Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                IsInvOpen = false;
            }
            UpgradeTab(gameTime);

        }
        /// <summary>
        /// Draws each upgrade in, and if certain conditions are meet it changes the look of the upgrade.
        /// Draws in each resource with the amount you have.
        /// </summary>
        /// <param name="spriteBatch"></param>
        public static void DrawUpgrade(SpriteBatch spriteBatch)
        {
            if (isUpgradesClicked == true)
            {

                #region UpgradeButtons
                //First Upgrade Line
                spriteBatch.Draw(spritePlacer[14], uiRectangles[5], Color.White);//Frist line first upgrade
                if (Upgraded[0] == true)
                {
                    spriteBatch.Draw(spritePlacer[14], uiRectangles[5], Color.Gray);
                }
                spriteBatch.Draw(spritePlacer[15], uiRectangles[6], Color.White);//Fist line second Upgrade
                if (Upgraded[1] == true)
                {
                    spriteBatch.Draw(spritePlacer[15], uiRectangles[6], Color.Gray);
                }
                spriteBatch.Draw(spritePlacer[16], uiRectangles[7], Color.White);//First Line third Upgrade
                if (Upgraded[2] == true)
                {
                    spriteBatch.Draw(spritePlacer[16], uiRectangles[7], Color.Gray);
                }
                spriteBatch.Draw(spritePlacer[17], uiRectangles[8], Color.White);//First Line Fourth Upgrade
                if (Upgraded[3] == true)
                {
                    spriteBatch.Draw(spritePlacer[17], uiRectangles[8], Color.Gray);
                }
                //Second Upgrade Line
                spriteBatch.Draw(spritePlacer[18], uiRectangles[9], Color.White);//Second Line first upgrade
                if (Upgraded[4] == true)
                {
                    spriteBatch.Draw(spritePlacer[18], uiRectangles[9], Color.Gray);
                }
                spriteBatch.Draw(spritePlacer[19], uiRectangles[10], Color.White);//Second Line second upgrade
                if (Upgraded[5] == true)
                {
                    spriteBatch.Draw(spritePlacer[19], uiRectangles[10], Color.Gray);
                }
                spriteBatch.Draw(spritePlacer[20], uiRectangles[11], Color.White);//Second Line third upgrade
                if (Upgraded[6] == true)
                {
                    spriteBatch.Draw(spritePlacer[20], uiRectangles[11], Color.Gray);
                }
                spriteBatch.Draw(spritePlacer[21], uiRectangles[12], Color.White);//Second Line fourth upgrade
                if (Upgraded[7] == true)
                {
                    spriteBatch.Draw(spritePlacer[21], uiRectangles[12], Color.Gray);
                }
                //Third Upgrade Line
                spriteBatch.Draw(spritePlacer[22], uiRectangles[13], Color.White);//Third line first upgrade
                if (Upgraded[8] == true)
                {
                    spriteBatch.Draw(spritePlacer[22], uiRectangles[13], Color.Gray);
                }
                spriteBatch.Draw(spritePlacer[23], uiRectangles[14], Color.White);//Third line second upgrade
                if (Upgraded[9] == true)
                {
                    spriteBatch.Draw(spritePlacer[23], uiRectangles[14], Color.Gray);
                }
                spriteBatch.Draw(spritePlacer[24], uiRectangles[15], Color.White);//Third line third upgrade
                if (Upgraded[10] == true)
                {
                    spriteBatch.Draw(spritePlacer[24], uiRectangles[15], Color.Gray);
                }
                spriteBatch.Draw(spritePlacer[25], uiRectangles[16], Color.White);//Third line fourth upgrade
                if (Upgraded[11] == true)
                {
                    spriteBatch.Draw(spritePlacer[25], uiRectangles[16], Color.Gray);
                }
                //Last upgrade
                spriteBatch.Draw(spritePlacer[27], uiRectangles[17], Color.White);// very Last Upgrade
                if (Upgraded[12] == true)
                {
                    spriteBatch.Draw(spritePlacer[27], uiRectangles[17], Color.Gray);
                }
                #endregion
                //Ressource count
                spriteBatch.Draw(reCount[0], uiRectangles[18], Color.White);//Copper
                spriteBatch.Draw(reCount[1], uiRectangles[19], Color.White);//MiliScrap
                spriteBatch.Draw(reCount[2], uiRectangles[20], Color.White);//Titanium
                spriteBatch.Draw(reCount[3], uiRectangles[21], Color.White);//Platinium
                spriteBatch.Draw(reCount[4], uiRectangles[22], Color.White);//Uranium

                spriteBatch.DrawString(fontsTitle[5], $"Copper   {R1Cop}", new Vector2(1700, 550), Color.White);
                spriteBatch.DrawString(fontsTitle[6], $"Scrap    {R2Mili}", new Vector2(1700, 625), Color.White);
                spriteBatch.DrawString(fontsTitle[7], $"Titanium {R3Tit}", new Vector2(1700, 700), Color.White);
                spriteBatch.DrawString(fontsTitle[8], $"Platinum {R4Plat}", new Vector2(1700, 775), Color.White);
                spriteBatch.DrawString(fontsTitle[9], $"Uranium  {R5Uran}", new Vector2(1700, 850), Color.White);

                //Border Divding from upgrades to show how many ressources you got
                spriteBatch.Draw(spritePlacer[7], uiRectangles[23], Color.Black);
                spriteBatch.Draw(spritePlacer[7], uiRectangles[24], Color.Black);

                #region Upgrade Info
                switch (upgradeClicked)
                {
                    case 1: //first on first line
                        if (Upgraded[0] == false)
                        {
                            spriteBatch.Draw(upgradeInfo[0], uiRectangles[25], Color.White);//Upgrade Info
                            spriteBatch.Draw(spritePlacer[14], uiRectangles[5], Color.Gray);//Upgrade box
                            spriteBatch.Draw(spritePlacer[26], uiRectangles[37], Color.White);//Upgrade Button
                        }
                        else if (Upgraded[0] == true)
                        {
                            spriteBatch.Draw(spritePlacer[26], uiRectangles[37], Color.Green);//Upgrade Button
                            spriteBatch.Draw(upgradeInfo[0], uiRectangles[25], Color.White);//Uprade Info
                        }
                        break;
                    case 2://second on first line
                        if (Upgraded[1] == false)
                        {
                            spriteBatch.Draw(spritePlacer[15], uiRectangles[6], Color.Gray);//Upgrade box
                            spriteBatch.Draw(upgradeInfo[1], uiRectangles[26], Color.White);//Uprade Info
                            spriteBatch.Draw(spritePlacer[26], uiRectangles[37], Color.White);//Upgrade Button
                        }
                        else if (Upgraded[1] == true)
                        {
                            spriteBatch.Draw(upgradeInfo[1], uiRectangles[26], Color.White);//Uprade Info
                            spriteBatch.Draw(spritePlacer[26], uiRectangles[37], Color.Green);//Upgrade Button
                        }
                        break;
                    case 3://third on first line
                        if (Upgraded[2] == false)
                        {
                            spriteBatch.Draw(upgradeInfo[2], uiRectangles[27], Color.White);//Uprade Info
                            spriteBatch.Draw(spritePlacer[16], uiRectangles[7], Color.Gray);//Upgrade box
                            spriteBatch.Draw(spritePlacer[26], uiRectangles[37], Color.White);//Upgrade Button

                        }
                        else if (Upgraded[2] == true)
                        {
                            spriteBatch.Draw(spritePlacer[26], uiRectangles[37], Color.Green);//Upgrade Button
                            spriteBatch.Draw(upgradeInfo[2], uiRectangles[27], Color.White);//Uprade Info
                        }
                        break;
                    case 4://fourth on first line
                        if (Upgraded[3] == false)
                        {
                            spriteBatch.Draw(upgradeInfo[3], uiRectangles[28], Color.White);//Uprade Info
                            spriteBatch.Draw(spritePlacer[17], uiRectangles[8], Color.Gray);//Upgrade box
                            spriteBatch.Draw(spritePlacer[26], uiRectangles[37], Color.White);//Upgrade Button
                        }
                        else if (Upgraded[3] == true)
                        {
                            spriteBatch.Draw(spritePlacer[26], uiRectangles[37], Color.Green);//Upgrade Button
                            spriteBatch.Draw(upgradeInfo[3], uiRectangles[28], Color.White);//Uprade Info
                        }
                        break;
                    case 5://first on second line
                        if (Upgraded[4] == false)
                        {
                            spriteBatch.Draw(upgradeInfo[4], uiRectangles[29], Color.White);//Uprade Info
                            spriteBatch.Draw(spritePlacer[18], uiRectangles[9], Color.Gray);//Upgrade box
                            spriteBatch.Draw(spritePlacer[26], uiRectangles[37], Color.White);//Upgrade Button
                        }
                        else if (Upgraded[4] == true)
                        {
                            spriteBatch.Draw(spritePlacer[26], uiRectangles[37], Color.Green);//Upgrade Button
                            spriteBatch.Draw(upgradeInfo[4], uiRectangles[29], Color.White);//Uprade Info
                        }
                        break;
                    case 6://second on second line
                        if (Upgraded[5] == false)
                        {
                            spriteBatch.Draw(upgradeInfo[5], uiRectangles[30], Color.White);//Uprade Info
                            spriteBatch.Draw(spritePlacer[19], uiRectangles[10], Color.Gray);//Upgrade box
                            spriteBatch.Draw(spritePlacer[26], uiRectangles[37], Color.White);//Upgrade Button
                        }
                        else if (Upgraded[5] == true)
                        {
                            spriteBatch.Draw(spritePlacer[26], uiRectangles[37], Color.Green);//Upgrade Button
                            spriteBatch.Draw(upgradeInfo[5], uiRectangles[30], Color.White);//Uprade Info

                        }
                        break;
                    case 7://third on second line
                        if (Upgraded[6] == false)
                        {
                            spriteBatch.Draw(upgradeInfo[6], uiRectangles[31], Color.White);//Uprade Info
                            spriteBatch.Draw(spritePlacer[20], uiRectangles[11], Color.Gray);//Upgrade box
                            spriteBatch.Draw(spritePlacer[26], uiRectangles[37], Color.White);//Upgrade Button
                        }
                        else if (Upgraded[6] == true)
                        {
                            spriteBatch.Draw(spritePlacer[26], uiRectangles[37], Color.Green);//Upgrade Button
                            spriteBatch.Draw(upgradeInfo[6], uiRectangles[31], Color.White);//Uprade Info
                        }
                        break;
                    case 8://Fourth on second line
                        if (Upgraded[7] == false)
                        {
                            spriteBatch.Draw(upgradeInfo[7], uiRectangles[32], Color.White);//Uprade Info
                            spriteBatch.Draw(spritePlacer[21], uiRectangles[12], Color.Gray);//Upgrade box
                            spriteBatch.Draw(spritePlacer[26], uiRectangles[37], Color.White);//Upgrade Button
                        }
                        else if (Upgraded[7] == true)
                        {
                            spriteBatch.Draw(spritePlacer[26], uiRectangles[37], Color.Green);//Upgrade Button
                            spriteBatch.Draw(upgradeInfo[7], uiRectangles[32], Color.White);//Uprade Info
                        }
                        break;
                    case 9://First on Third Line
                        if (Upgraded[8] == false)
                        {
                            spriteBatch.Draw(upgradeInfo[8], uiRectangles[33], Color.White);//Uprade Info
                            spriteBatch.Draw(spritePlacer[22], uiRectangles[13], Color.Gray);//Upgrade box
                            spriteBatch.Draw(spritePlacer[26], uiRectangles[37], Color.White);//Upgrade Button
                        }
                        else if (Upgraded[8] == true)
                        {
                            spriteBatch.Draw(spritePlacer[26], uiRectangles[37], Color.Green);//Upgrade Button
                            spriteBatch.Draw(upgradeInfo[8], uiRectangles[33], Color.White);//Uprade Info
                        }
                        break;
                    case 10://second on Third Line
                        if (Upgraded[9] == false)
                        {
                            spriteBatch.Draw(upgradeInfo[9], uiRectangles[34], Color.White);//Uprade Info
                            spriteBatch.Draw(spritePlacer[23], uiRectangles[14], Color.Gray);//Upgrade box
                            spriteBatch.Draw(spritePlacer[26], uiRectangles[37], Color.White);//Upgrade Button
                        }
                        else if (Upgraded[9] == true)
                        {
                            spriteBatch.Draw(spritePlacer[26], uiRectangles[37], Color.Green);//Upgrade Button
                            spriteBatch.Draw(upgradeInfo[9], uiRectangles[34], Color.White);//Uprade Info
                        }
                        break;
                    case 11://Third on Third Line
                        if (Upgraded[10] == false)
                        {
                            spriteBatch.Draw(upgradeInfo[10], uiRectangles[35], Color.White);//Uprade Info
                            spriteBatch.Draw(spritePlacer[24], uiRectangles[15], Color.Gray);//Upgrade box
                            spriteBatch.Draw(spritePlacer[26], uiRectangles[37], Color.White);//Upgrade Button
                        }
                        else if (Upgraded[10] == true)
                        {
                            spriteBatch.Draw(spritePlacer[26], uiRectangles[37], Color.Green);//Upgrade Button
                            spriteBatch.Draw(upgradeInfo[10], uiRectangles[35], Color.White);//Uprade Info
                        }
                        break;
                    case 12://fourth on Third Line
                        if (Upgraded[11] == false)
                        {
                            spriteBatch.Draw(upgradeInfo[11], uiRectangles[36], Color.White);//Uprade Info
                            spriteBatch.Draw(spritePlacer[25], uiRectangles[16], Color.Gray);//Upgrade box
                            spriteBatch.Draw(spritePlacer[26], uiRectangles[37], Color.White);//Upgrade Button
                        }
                        else if (Upgraded[11] == true)
                        {
                            spriteBatch.Draw(spritePlacer[26], uiRectangles[37], Color.Green);//Upgrade Button
                            spriteBatch.Draw(upgradeInfo[11], uiRectangles[36], Color.White);//Uprade Info
                        }
                        break;
                    case 13://last upgrade
                        if (Upgraded[12] == false)
                        {
                            spriteBatch.Draw(spritePlacer[27], uiRectangles[17], Color.Gray);//Upgrade Box
                            spriteBatch.Draw(upgradeInfo[12], uiRectangles[38], Color.White);//Upgrade info
                            spriteBatch.Draw(spritePlacer[26], uiRectangles[37], Color.White);//Upgrade Button
                        }
                        else if (Upgraded[12] == true)
                        {
                            spriteBatch.Draw(upgradeInfo[12], uiRectangles[38], Color.White);//Upgrade info
                            spriteBatch.Draw(spritePlacer[26], uiRectangles[37], Color.Green);//Upgrade Button
                        }
                        break;

                }
                #endregion
            }
        }
        /// <summary>
        /// All functionality between the mouse and the upgrade boxes.
        /// When you click on a upgrade icon you get another box with the information about that upgrade.
        /// on that box is another which can be clicked on if you have the right amount of resources.
        /// Its a swith case that controls which upgrade info you can see.
        /// </summary>
        /// <param name="gameTime"></param>
        private void UpgradeTab(GameTime gameTime)
        {
            #region switch tabs
            //showing Craft tab
            if (uiRectangles[0].Contains(mouse.X, mouse.Y) && mouse.LeftButton == ButtonState.Pressed)
            {
                isCraftClicked = true;
                isStatsClicked = false;
                isArtiClicked = false;
                isUpgradesClicked = false;
            }
            //showing upgrade tab
            if (uiRectangles[1].Contains(mouse.X, mouse.Y) && mouse.LeftButton == ButtonState.Pressed)
            {
                isCraftClicked = false;
                isStatsClicked = false;
                isArtiClicked = false;
                isUpgradesClicked = true;
            }
            //showing Artifacts tab
            if (uiRectangles[2].Contains(mouse.X, mouse.Y) && mouse.LeftButton == ButtonState.Pressed)
            {
                isCraftClicked = false;
                isStatsClicked = false;
                isArtiClicked = true;
                isUpgradesClicked = false;
            }
            //showing stats tab
            if (uiRectangles[3].Contains(mouse.X, mouse.Y) && mouse.LeftButton == ButtonState.Pressed)
            {
                isCraftClicked = false;
                isStatsClicked = true;
                isArtiClicked = false;
                isUpgradesClicked = false;
            }
            closeDownShopTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            // close down Shop
            if (IsInvOpen == true && uiRectangles[4].Contains(mouse.X, mouse.Y) && mouse.LeftButton == ButtonState.Pressed)
            {
                IsInvOpen = false;
            }
            #endregion
            #region See Upgrades
            if (uiRectangles[5].Contains(mouse.X, mouse.Y) && mouse.LeftButton == ButtonState.Pressed)
            {
                upgradeClicked = 1;
            }
            if (uiRectangles[6].Contains(mouse.X, mouse.Y) && mouse.LeftButton == ButtonState.Pressed)
            {
                upgradeClicked = 2;
            }
            if (uiRectangles[7].Contains(mouse.X, mouse.Y) && mouse.LeftButton == ButtonState.Pressed)
            {
                upgradeClicked = 3;
            }
            if (uiRectangles[8].Contains(mouse.X, mouse.Y) && mouse.LeftButton == ButtonState.Pressed)
            {
                upgradeClicked = 4;
            }
            if (uiRectangles[9].Contains(mouse.X, mouse.Y) && mouse.LeftButton == ButtonState.Pressed)
            {
                upgradeClicked = 5;
            }
            if (uiRectangles[10].Contains(mouse.X, mouse.Y) && mouse.LeftButton == ButtonState.Pressed)
            {
                upgradeClicked = 6;
            }
            if (uiRectangles[11].Contains(mouse.X, mouse.Y) && mouse.LeftButton == ButtonState.Pressed)
            {
                upgradeClicked = 7;
            }
            if (uiRectangles[12].Contains(mouse.X, mouse.Y) && mouse.LeftButton == ButtonState.Pressed)
            {
                upgradeClicked = 8;
            }
            if (uiRectangles[13].Contains(mouse.X, mouse.Y) && mouse.LeftButton == ButtonState.Pressed)
            {
                upgradeClicked = 9;
            }
            if (uiRectangles[14].Contains(mouse.X, mouse.Y) && mouse.LeftButton == ButtonState.Pressed)
            {
                upgradeClicked = 10;
            }
            if (uiRectangles[15].Contains(mouse.X, mouse.Y) && mouse.LeftButton == ButtonState.Pressed)
            {
                upgradeClicked = 11;
            }
            if (uiRectangles[16].Contains(mouse.X, mouse.Y) && mouse.LeftButton == ButtonState.Pressed)
            {
                upgradeClicked = 12;
            }
            if (uiRectangles[17].Contains(mouse.X, mouse.Y) && mouse.LeftButton == ButtonState.Pressed)
            {
                upgradeClicked = 13;
            }
            #endregion
            if (uiRectangles[37].Contains(mouse.X, mouse.Y) && mouse.LeftButton == ButtonState.Pressed)
            {
                switch (upgradeClicked)
                {
                    //First line
                    case 1://Upgrade DrilBit 10% faster
                        if (R2Mili >= 10 && R4Plat >= 5 && Upgraded[0] == false)
                        {
                            Upgraded[0] = true;
                            R4Plat -= 5;
                            R2Mili -= 10;
                            menuSound.Play();
                        }
                        break;
                    case 2://Upgrade DrilBit 20% faster
                        if (Upgraded[1] == false && Upgraded[0] == true && R2Mili >= 20 && R4Plat >= 10)
                        {
                            Upgraded[1] = true;
                            R2Mili -= 20;
                            R4Plat -= 10;
                            menuSound.Play();
                        }
                        break;
                    case 3://Upgrade DrilBit 30% faster
                        if (Upgraded[2] == false && Upgraded[1] == true && R2Mili >= 30 && R4Plat >= 20)
                        {
                            Upgraded[2] = true;
                            R2Mili -= 30;
                            R4Plat -= 20;
                            menuSound.Play();
                        }
                        break;
                    case 4://Upgrade DrilBit 40% faster
                        if (Upgraded[3] == false && Upgraded[2] == true && R2Mili >= 40 && R4Plat >= 30)
                        {
                            Upgraded[3] = true;
                            R2Mili -= 40;
                            R4Plat -= 30;
                            menuSound.Play();
                        }
                        break;
                    //Second Line
                    case 5://Upgrade Battery Storage 10% more
                        if (Upgraded[4] == false && R3Tit >= 10 && R5Uran >= 5)
                        {
                            Upgraded[4] = true;
                            R3Tit -= 10;
                            R5Uran -= 5;
                            menuSound.Play();
                        }
                        break;
                    case 6://Upgrade Battery Storage 20% more
                        if (Upgraded[5] == false && Upgraded[4] == true && R3Tit >= 20 && R5Uran >= 10)
                        {
                            Upgraded[5] = true;
                            R3Tit -= 20;
                            R5Uran -= 10;
                            menuSound.Play();
                        }
                        break;
                    case 7://Upgrade Battery Storage 30% more
                        if (Upgraded[6] == false && Upgraded[5] == true && R3Tit >= 30 && R5Uran >= 20)
                        {
                            Upgraded[6] = true;
                            R3Tit -= 30;
                            R5Uran -= 20;
                            menuSound.Play();
                        }
                        break;
                    case 8://Upgrade Battery Storage 40% more
                        if (Upgraded[7] == false && Upgraded[6] == true && R3Tit >= 40 && R5Uran >= 30)
                        {
                            Upgraded[7] = true;
                            R3Tit -= 40;
                            R5Uran -= 30;
                            menuSound.Play();
                        }
                        break;
                    //Third Line
                    case 9://Upgrade battery recharge speed 10% faster
                        if (Upgraded[8] == false && R1Cop >= 10 && R3Tit >= 5)
                        {
                            Upgraded[8] = true;
                            R1Cop -= 10;
                            R3Tit -= 5;
                            menuSound.Play();
                        }
                        break;
                    case 10://Upgrade battery recharge speed 20% faster
                        if (Upgraded[9] == false && Upgraded[8] == true && R1Cop >= 20 && R3Tit >= 10)
                        {
                            Upgraded[9] = true;
                            R1Cop -= 20;
                            R3Tit -= 10;
                            menuSound.Play();
                        }
                        break;
                    case 11://Upgrade battery recharge speed 30% faster
                        if (Upgraded[10] == false && Upgraded[9] == true && R1Cop >= 30 && R3Tit >= 20)
                        {
                            Upgraded[10] = true;
                            R1Cop -= 30;
                            R3Tit -= 20;
                            menuSound.Play();
                        }
                        break;
                    case 12://Upgrade battery recharge speed 40% faster
                        if (Upgraded[11] == false && Upgraded[10] == true && R1Cop >= 40 && R3Tit >= 30)
                        {
                            Upgraded[11] = true;
                            R1Cop -= 40;
                            R3Tit -= 30;
                            menuSound.Play();
                        }
                        break;
                    //Last Upgrade
                    case 13://checks that all the last upgrades have been made and you have the resource needed.
                        if (Upgraded[7] == false && Upgraded[11] == true && Upgraded[3] == true
                            && R1Cop >= 50 && R3Tit >= 50 && R4Plat >= 50 && R5Uran >= 50)
                        {
                            Upgraded[12] = true;
                            R1Cop -= 50;
                            R3Tit -= 50;
                            R4Plat -= 50;
                            R5Uran -= 50;
                            menuSound.Play();
                        }
                        break;
                }
            }//Confirm Upgrade Button
        }
    }
}
