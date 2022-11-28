using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.WIC;

namespace Miner.UiForInv
{
    internal class CraftingButton : WorkShop
    {
        private MouseState mouse;
        private float closeDownShopTimer;
        private float pressTimer;
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
            uiRectangles[6] = new Rectangle(920, 540, 100, 100);
            uiRectangles[7] = new Rectangle(1060, 540, 100, 100);
            uiRectangles[8] = new Rectangle(1200, 540, 100, 100);
            //Second Upgrade Line
            uiRectangles[9] = new Rectangle(780, 660, 100, 100);
            uiRectangles[10] = new Rectangle(920, 660, 100, 100);
            uiRectangles[11] = new Rectangle(1060, 660, 100, 100);
            uiRectangles[12] = new Rectangle(1200, 660, 100, 100);
            //Third Upgrade Line
            uiRectangles[13] = new Rectangle(780, 780, 100, 100);
            uiRectangles[14] = new Rectangle(920, 780, 100, 100);
            uiRectangles[15] = new Rectangle(1060, 780, 100, 100);
            uiRectangles[16] = new Rectangle(1200, 780, 100, 100);
            //Last upgrade
            uiRectangles[17] = new Rectangle(1380, 660, 100, 100);
            //Ressource count
            uiRectangles[18] = new Rectangle(1650, 540, 50, 50);
            fontsTitle[5] = content.Load<SpriteFont>("Ui Sprites/Fonts/R1");
            uiRectangles[19] = new Rectangle(1650, 615, 50, 50);
            fontsTitle[6] = content.Load<SpriteFont>("Ui Sprites/Fonts/R2");
            uiRectangles[20] = new Rectangle(1650, 690, 50, 50);
            fontsTitle[7] = content.Load<SpriteFont>("Ui Sprites/Fonts/R3");
            uiRectangles[21] = new Rectangle(1650, 765, 50, 50);
            fontsTitle[8] = content.Load<SpriteFont>("Ui Sprites/Fonts/R4");
            uiRectangles[22] = new Rectangle(1650, 840, 50, 50);
            fontsTitle[9] = content.Load<SpriteFont>("Ui Sprites/Fonts/R5");

            // Upgrade Info
            uiRectangles[25] = new Rectangle(465, 550, 200, 300);
            uiRectangles[26] = new Rectangle(465, 550, 200, 300);
            uiRectangles[27] = new Rectangle(465, 550, 200, 300);
            uiRectangles[28] = new Rectangle(465, 550, 200, 300);
            uiRectangles[29] = new Rectangle(465, 550, 200, 300);
            uiRectangles[30] = new Rectangle(465, 550, 200, 300);
            uiRectangles[31] = new Rectangle(465, 550, 200, 300);
            uiRectangles[32] = new Rectangle(465, 550, 200, 300);
            uiRectangles[33] = new Rectangle(465, 550, 200, 300);
            uiRectangles[34] = new Rectangle(465, 550, 200, 300);
            uiRectangles[35] = new Rectangle(465, 550, 200, 300);
            uiRectangles[36] = new Rectangle(465, 550, 200, 300);

            uiRectangles[37] = new Rectangle(515, 900, 100, 50);//Confirm Upgrade  Button



            //See Upgrade Info
            #endregion
        }

        public override void Update(GameTime gameTime)
        {
            mouse = Mouse.GetState();
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
                    case 1:
                        if (R1 >= 10 && Upgraded[0] == false)
                        {
                            Upgraded[0] = true;
                            R1 -= 10;
                        }
                        break;
                    case 2:
                        if (Upgraded[1] == false && Upgraded[0] == true && R1 >= 20 && R2 >= 10)
                        {
                            Upgraded[1] = true;
                            R1 -= 20;
                            R2 -= 10;
                        }
                        break;
                    case 3:
                        if (Upgraded[2] == false && Upgraded[1] == true && R1 >= 30 && R2 >= 20 && R3 >= 10)
                        {
                            Upgraded[2] = true;
                            R1 -= 30;
                            R2 -= 20;
                            R3 -= 10;
                        }
                        break;
                    case 4:
                        if (Upgraded[3] == false && Upgraded[2] == true && R1 >= 40 && R2 >= 30 && R3 >= 20 && R4 >= 10)
                        {
                            Upgraded[3] = true;
                            R1 -= 40;
                            R2 -= 30;
                            R3 -= 20;
                            R4 -= 10;
                        }
                        break;
                    //Second Line
                    case 5:
                        if (Upgraded[4] == false && R1 >= 10)
                        {
                            Upgraded[4] = true;
                            R1 -= 10;
                        }
                        break;
                    case 6:
                        if (Upgraded[5] == false && Upgraded[4] == true && R1 >= 20 && R2 >= 10)
                        {
                            Upgraded[5] = true;
                            R1 -= 20;
                            R2 -= 10;
                        }
                        break;
                    case 7:
                        if (Upgraded[6] == false && Upgraded[5] == true && R1 >= 30 && R2 >= 20 && R3 >= 10)
                        {
                            Upgraded[6] = true;
                            R1 -= 30;
                            R2 -= 20;
                            R3 -= 10;
                        }
                        break;
                    case 8:
                        if (Upgraded[7] == false && Upgraded[6] == true && R1 >= 40 && R2 >= 30 && R3 >= 20 && R4 >= 10)
                        {
                            Upgraded[7] = true;
                            R1 -= 40;
                            R2 -= 30;
                            R3 -= 20;
                            R4 -= 10;
                        }
                        break;
                    //Third Line
                    case 9:
                        if (Upgraded[8] == false && R1 >= 10)
                        {
                            Upgraded[8] = true;
                            R1 -= 10;
                        }
                        break;
                    case 10:
                        if (Upgraded[9] == false && Upgraded[8] == true && R1 >= 20 && R2 >= 10)
                        {
                            Upgraded[9] = true;
                            R1 -= 20;
                            R2 -= 10;
                        }
                        break;
                    case 11:
                        if (Upgraded[10] == false && Upgraded[9] == true && R1 >= 30 && R2 >= 20 && R3 >= 10)
                        {
                            Upgraded[10] = true;
                            R1 -= 30;
                            R2 -= 20;
                            R3 -= 10;
                        }
                        break;
                    case 12:
                        if (Upgraded[11] == false && Upgraded[10] == true && R1 >= 40 && R2 >= 30 && R3 >= 20 && R4 >= 10)
                        {
                            Upgraded[11] = true;
                            R1 -= 40;
                            R2 -= 30;
                            R3 -= 20;
                            R4 -= 10;
                        }
                        break;
                    //Fourth Line
                    case 13:
                        if (Upgraded[7] == false && Upgraded[11] == true && Upgraded[6] == true && Upgraded[3] == true && R1 >= 50 && R2 >= 40 && R3 >= 30 && R4 >= 20 && R5 >= 10)
                        {
                            Upgraded[7] = true;
                            R1 -= 50;
                            R2 -= 40;
                            R3 -= 30;
                            R4 -= 20;
                            R5 -= 10;
                        }
                        Upgraded[12] = true;
                        break;
                }
            }//Confirm Upgrade Button


        }
        private void CraftingTab()
        {

        }
        private void UpgradeTab()
        {

        }
        private void ArtifactsTab()
        {

        }
        private void StatsTab()
        {

        }
    }
}
