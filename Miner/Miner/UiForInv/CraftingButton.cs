using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.WIC;
using System;

namespace Miner.UiForInv
{
    internal class CraftingButton : WorkShop
    {
        private MouseState mouse;
        private float closeDownShopTimer;
        public override void LoadContent(ContentManager content)
        {
            #region Tabs
            //Background
            spritePlacer[0] = content.Load<Texture2D>("Ui Sprites/InventorybackGround");
            spritePlacerPos[0] = new Vector2(400, 400);
            //first button 
            spritePlacer[1] = content.Load<Texture2D>("Ui Sprites/CraftingButton");
            spritePlacerPos[1] = new Vector2(400, 400);
            uiRectangles[0] = new Rectangle(400, 400, 350, 100);
            fontsTitle[0] = content.Load<SpriteFont>("Ui Sprites/Fonts/CraftFontT");
            //second button 
            spritePlacer[2] = content.Load<Texture2D>("Ui Sprites/CraftingButton");
            spritePlacerPos[2] = new Vector2(750, 400);
            uiRectangles[1] = new Rectangle(750, 400, 350, 100);
            fontsTitle[1] = content.Load<SpriteFont>("Ui Sprites/Fonts/UpgradeFontT");
            //third button 
            spritePlacer[3] = content.Load<Texture2D>("Ui Sprites/CraftingButton");
            spritePlacerPos[3] = new Vector2(1100, 400);
            uiRectangles[2] = new Rectangle(1100, 400, 350, 100);
            fontsTitle[2] = content.Load<SpriteFont>("Ui Sprites/Fonts/ArtifactsFontT");
            //fourth button 
            spritePlacer[4] = content.Load<Texture2D>("Ui Sprites/CraftingButton");
            spritePlacerPos[4] = new Vector2(1450, 400);
            uiRectangles[3] = new Rectangle(1450, 400, 350, 100);
            fontsTitle[3] = content.Load<SpriteFont>("Ui Sprites/Fonts/StatsFontT");
            //close ButtonUI
            spritePlacer[5] = content.Load<Texture2D>("Ui Sprites/Fonts/CloseUIButton");
            uiRectangles[4] = new Rectangle(1800, 400, 100, 100);

            #endregion
            #region UpgradeTab
            spritePlacer[6] = content.Load<Texture2D>("Ui Sprites/UpgradePlaceHolder");
            spritePlacer[7] = content.Load<Texture2D>("Ui Sprites/BarDivider");
            uiRectangles[23] = new Rectangle(1600, 500, 4, 500);
            uiRectangles[24] = new Rectangle(720, 500, 4, 500);

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
            spritePlacer[26] = content.Load<Texture2D>("Ui Sprites/Upgradeinfo/Last Upgrade AiBrainPng");
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

            uiRectangles[38] = new Rectangle(465,550,200,300);//Last Upgrade Info
            upgradeInfo[12] = content.Load<Texture2D>("Ui Sprites/UpgradeInfo/RougeAiUpgradeInfo");

            uiRectangles[37] = new Rectangle(515, 900, 100, 50);//Confirm Upgrade  Button
            #endregion
        }

        public override void Update(GameTime gameTime)
        {
            mouse = Mouse.GetState();

            UpgradeTab(gameTime);

        }
        private void CraftingTab()
        {

        }
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
            if (IsInvOpen == true && Keyboard.GetState().IsKeyDown(Keys.I) && closeDownShopTimer > 0.3f)
            {
                IsInvOpen = false;
                closeDownShopTimer = 0f;
            }
            else if (IsInvOpen == false && Keyboard.GetState().IsKeyDown(Keys.I) && closeDownShopTimer > 0.3f)
            {
                IsInvOpen = true;
                closeDownShopTimer = 0f;
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
                        }
                        break;
                    case 2://Upgrade DrilBit 20% faster
                        if (Upgraded[1] == false && Upgraded[0] == true && R2Mili >= 20 && R4Plat >= 10)
                        {
                            Upgraded[1] = true;
                            R2Mili -= 20;
                            R4Plat -= 10;
                        }
                        break;
                    case 3://Upgrade DrilBit 30% faster
                        if (Upgraded[2] == false && Upgraded[1] == true && R2Mili >= 30 && R4Plat >= 20)
                        {
                            Upgraded[2] = true;
                            R2Mili -= 30;
                            R4Plat -= 20;
                        }
                        break;
                    case 4://Upgrade DrilBit 40% faster
                        if (Upgraded[3] == false && Upgraded[2] == true && R2Mili >= 40 && R4Plat >= 30)
                        {
                            Upgraded[3] = true;
                            R2Mili -= 40;
                            R4Plat -= 30;
                        }
                        break;
                    //Second Line
                    case 5://Upgrade Battery Storage 10% more
                        if (Upgraded[4] == false && R3Tit>=10 && R5Uran >= 5)
                        {
                            Upgraded[4] = true;
                            R3Tit -= 10;
                            R5Uran -= 5;
                        }
                        break;
                    case 6://Upgrade Battery Storage 20% more
                        if (Upgraded[5] == false && Upgraded[4] == true && R3Tit >= 20 && R5Uran >= 10)
                        {
                            Upgraded[5] = true;
                            R3Tit -= 20;
                            R5Uran -= 10;
                        }
                        break;
                    case 7://Upgrade Battery Storage 30% more
                        if (Upgraded[6] == false && Upgraded[5] == true && R3Tit >= 30 && R5Uran >= 20)
                        {
                            Upgraded[6] = true;
                            R3Tit -= 30;
                            R5Uran -= 20;
                        }
                        break;
                    case 8://Upgrade Battery Storage 40% more
                        if (Upgraded[7] == false && Upgraded[6] == true && R3Tit >= 40 && R5Uran >= 30)
                        {
                            Upgraded[7] = true;
                            R3Tit -= 40;
                            R5Uran -= 30;
                        }
                        break;
                    //Third Line
                    case 9://Upgrade battery recharge speed 10% faster
                        if (Upgraded[8] == false && R1Cop >= 10 && R3Tit >= 5)
                        {
                            Upgraded[8] = true;
                            R1Cop -= 10;
                            R3Tit -= 5;
                        }
                        break;
                    case 10://Upgrade battery recharge speed 20% faster
                        if (Upgraded[9] == false && Upgraded[8] == true && R1Cop >= 20 && R3Tit >= 10)
                        {
                            Upgraded[9] = true;
                            R1Cop -= 20;
                            R3Tit -= 10;
                        }
                        break;
                    case 11://Upgrade battery recharge speed 30% faster
                        if (Upgraded[10] == false && Upgraded[9] == true && R1Cop >= 30 && R3Tit >= 20)
                        {
                            Upgraded[10] = true;
                            R1Cop -= 30;
                            R3Tit -= 20;
                        }
                        break;
                    case 12://Upgrade battery recharge speed 40% faster
                        if (Upgraded[11] == false && Upgraded[10] == true && R1Cop >= 40 && R3Tit >= 30)
                        {
                            Upgraded[11] = true;
                            R1Cop -= 40;
                            R3Tit -= 30;
                        }
                        break;
                    //Last Upgrade
                    case 13://checks that all the last upgrades have been made and you have the resource needed.
                        if (Upgraded[7] == false && Upgraded[11] == true && Upgraded[6] == true && Upgraded[3] == true 
                            && R1Cop >= 50 && R3Tit >= 50 && R4Plat >= 50 && R5Uran >= 50)
                        {
                            Upgraded[7] = true;
                            R1Cop -= 50;
                            R3Tit -= 50;
                            R4Plat -= 50;
                            R5Uran -= 50;
                        }
                        Upgraded[12] = true;
                        break;
                }
            }//Confirm Upgrade Button
        }
        private void ArtifactsTab()
        {

        }
        private void StatsTab()
        {

        }
    }
}
