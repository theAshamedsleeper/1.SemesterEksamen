﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miner.UiForInv
{
    internal class ArtifactsButton : WorkShop
    {
        private MouseState mouse;

        /// <summary>
        /// Loads in the Different places, sizes of the artifacts and the menu sound
        /// </summary>
        /// <param name="content"></param>
        public override void LoadContent(ContentManager content)
        {
            artifactsPlacer[0] = new Rectangle(750, 560, 150, 150);
            artifactsPlacer[1] = new Rectangle(935, 560, 150, 150);
            artifactsPlacer[2] = new Rectangle(1120, 560, 150, 150); 
            artifactsPlacer[3] = new Rectangle(1305, 560, 150, 150); 
            artifactsPlacer[4] = new Rectangle(1490, 560, 150, 150); 
            artifactsPlacer[5] = new Rectangle(1675, 560, 150, 150); 
            
            artifactsPlacer[6] = new Rectangle(750, 800, 150, 150);
            artifactsPlacer[7] = new Rectangle(935, 800, 150, 150);
            artifactsPlacer[8] = new Rectangle(1120, 800, 150, 150);
            artifactsPlacer[9] = new Rectangle(1305, 800, 150, 150);
            artifactsPlacer[10] = new Rectangle(1490, 800, 150, 150);
            artifactsPlacer[11] = new Rectangle(1675, 800, 150, 150);

            menuSound = content.Load<SoundEffect>("Sound/Menu Selection Click");

        }
        /// <summary>
        /// Makes it so you can use the mouse for collision with an inbuild function. Calls another method
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            mouse = Mouse.GetState();//So you can click around with the mouse.
            ArtifactsTab(gameTime);
        }
        /// <summary>
        /// draws in the diffrent artifacts, when called on
        /// </summary>
        /// <param name="spriteBatch"></param>
        public static void DrawArtifact(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(spritePlacer[7], uiRectangles[24], Color.Black);//nothing imprtant, just a border.
            spriteBatch.Draw(spritePlacer[7], artifactsPlacer[0], Color.White);
            spriteBatch.Draw(spritePlacer[7], artifactsPlacer[1], Color.White);
            spriteBatch.Draw(spritePlacer[7], artifactsPlacer[2], Color.White);
            spriteBatch.Draw(spritePlacer[7], artifactsPlacer[3], Color.White);
            spriteBatch.Draw(spritePlacer[7], artifactsPlacer[4], Color.White);
            spriteBatch.Draw(spritePlacer[7], artifactsPlacer[5], Color.White);
            spriteBatch.Draw(spritePlacer[7], artifactsPlacer[6], Color.White);
            spriteBatch.Draw(spritePlacer[7], artifactsPlacer[7], Color.White);
            spriteBatch.Draw(spritePlacer[7], artifactsPlacer[8], Color.White);
            spriteBatch.Draw(spritePlacer[7], artifactsPlacer[9], Color.White);
            spriteBatch.Draw(spritePlacer[7], artifactsPlacer[10], Color.White);
            spriteBatch.Draw(spritePlacer[7], artifactsPlacer[11], Color.White);

            switch (artifactClicked)
            {
                case 1:
                   // spriteBatch.Draw(spritePlacer[7], )
                    break;
            }
        }
        /// <summary>
        /// All functionality between the mouse and each boxs of artifacts.
        /// When you click an icon it changes the number of which artifact is click
        /// and shows diffenct information about the item
        /// </summary>
        /// <param name="gameTime"></param>
        private void ArtifactsTab(GameTime gameTime)
        {
            #region Invetory Tab
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
            #region Mouse Collsion
            if (artifactsPlacer[0].Contains(mouse.X, mouse.Y) && mouse.LeftButton == ButtonState.Pressed)
            {
                artifactClicked = 1;
            }
            if (artifactsPlacer[1].Contains(mouse.X, mouse.Y) && mouse.LeftButton == ButtonState.Pressed)
            {
                artifactClicked = 2;
            }
            if (artifactsPlacer[2].Contains(mouse.X, mouse.Y) && mouse.LeftButton == ButtonState.Pressed)
            {
                artifactClicked = 3;
            }
            if (artifactsPlacer[3].Contains(mouse.X, mouse.Y) && mouse.LeftButton == ButtonState.Pressed)
            {
                artifactClicked = 4;
            }
            if (artifactsPlacer[4].Contains(mouse.X, mouse.Y) && mouse.LeftButton == ButtonState.Pressed)
            {
                artifactClicked = 5;
            }
            if (artifactsPlacer[5].Contains(mouse.X, mouse.Y) && mouse.LeftButton == ButtonState.Pressed)
            {
                artifactClicked = 6;
            }
            if (artifactsPlacer[6].Contains(mouse.X, mouse.Y) && mouse.LeftButton == ButtonState.Pressed)
            {
                artifactClicked = 7;
            }
            if (artifactsPlacer[7].Contains(mouse.X, mouse.Y) && mouse.LeftButton == ButtonState.Pressed)
            {
                artifactClicked = 8;
            }
            if (artifactsPlacer[8].Contains(mouse.X, mouse.Y) && mouse.LeftButton == ButtonState.Pressed)
            {
                artifactClicked = 9;
            }
            if (artifactsPlacer[9].Contains(mouse.X, mouse.Y) && mouse.LeftButton == ButtonState.Pressed)
            {
                artifactClicked = 10;
            }
            if (artifactsPlacer[10].Contains(mouse.X, mouse.Y) && mouse.LeftButton == ButtonState.Pressed)
            {
                artifactClicked = 11;
            }
            if (artifactsPlacer[11].Contains(mouse.X, mouse.Y) && mouse.LeftButton == ButtonState.Pressed)
            {
                artifactClicked = 12;
            }
            #endregion
           
        }
    }
}
