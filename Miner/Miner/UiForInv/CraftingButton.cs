﻿using Microsoft.Xna.Framework;
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
            
            //Background
            spritePlacer[0] = content.Load<Texture2D>("Ui Sprites/InventorybackGround");
            spritePlacerPos[0] = new Vector2(400, 400);
            //first button 
            spritePlacer[1] = content.Load<Texture2D>("Ui Sprites/CraftingButton");
            spritePlacerPos[1] = new Vector2(400, 400);
            uiRectangles[0] = new Rectangle(400,400,350,100);
            fontsTitle[0] = content.Load<SpriteFont>("Ui Sprites/Fonts/CraftFontT");
            //second button 
            spritePlacer[2] = content.Load<Texture2D>("Ui Sprites/CraftingButton");
            spritePlacerPos[2] = new Vector2(750, 400);
            uiRectangles[1] = new Rectangle(750, 400, 350, 100);
            fontsTitle[1] = content.Load<SpriteFont>("Ui Sprites/Fonts/UpgradeFontT");
            //third button 
            spritePlacer[3] = content.Load<Texture2D>("Ui Sprites/CraftingButton");
            spritePlacerPos[3] = new Vector2(1100, 400);
            uiRectangles[2] = new Rectangle(1100,400,350,100);
            fontsTitle[2] = content.Load<SpriteFont>("Ui Sprites/Fonts/ArtifactsFontT");
            //fourth button 
            spritePlacer[4] = content.Load<Texture2D>("Ui Sprites/CraftingButton");
            spritePlacerPos[4] = new Vector2(1450, 400);
            uiRectangles[3] = new Rectangle(1450,400,350,100);
            fontsTitle[3] = content.Load<SpriteFont>("Ui Sprites/Fonts/StatsFontT");
            //close ButtonUI
            spritePlacer[5] = content.Load<Texture2D>("Ui Sprites/Fonts/CloseUIButton");
            uiRectangles[4] = new Rectangle(1800, 400, 100, 100);

        }

        public override void Update(GameTime gameTime)
        {
            mouse = Mouse.GetState();
            #region switch tabs
            //showing Craft tab
            if (uiRectangles[0].Contains(mouse.X,mouse.Y)&& mouse.LeftButton == ButtonState.Pressed)
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
            if(IsInvOpen == true &&Keyboard.GetState().IsKeyDown(Keys.I)&& closeDownShopTimer > 0.5f)
            {
                IsInvOpen = false;
                closeDownShopTimer = 0f;
            }
            else if (IsInvOpen == false && Keyboard.GetState().IsKeyDown(Keys.I)&& closeDownShopTimer > 0.5f)
            {
                IsInvOpen = true;
                closeDownShopTimer = 0f;
            }
            #endregion

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
