using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Miner.UiForInv
{
    internal class ArtifactsButton : WorkShop
    {
        private MouseState mouse;
        private static Rectangle[] artiRec = new Rectangle[14];
        private static Texture2D[] artifactTextArray = new Texture2D[12];
        /// <summary>
        /// Loads in the Different places, sizes of the artifacts and the menu sound
        /// </summary>
        /// <param name="content"></param>
        public override void LoadContent(ContentManager content)
        {
            artifactsSprite[0] = content.Load<Texture2D>("ArtefactPC");
            artifactsSprite[1] = content.Load<Texture2D>("KeycardArtefact5");
            artifactsSprite[2] = content.Load<Texture2D>("Toxic waste");

            artifactTextArray[0] = content.Load<Texture2D>("PC_Artefact_textNB");
            artifactTextArray[1] = content.Load<Texture2D>("Key_Artefact_textNB");
            artifactTextArray[2] = content.Load<Texture2D>("Toxic_Artefact_Text");

            artifactsSprite[12] = content.Load<Texture2D>("Ui Sprites/Question Mark no Back");
            artifactsSprite[13] = content.Load<Texture2D>("Ui Sprites/Question Mark with edge");

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

            artiRec[0] = new Rectangle(465, 550, 200, 150);

            menuSound = content.Load<SoundEffect>("Sound/Menu Selection Click");

        }
        /// <summary>
        /// Makes it so you can use the mouse for collision with an inbuild function. Calls another method
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
            ArtifactsTab(gameTime);
        }
        /// <summary>
        /// draws in the diffrent artifacts, when called on
        /// </summary>
        /// <param name="spriteBatch"></param>
        public static void DrawArtifact(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(spritePlacer[7], uiRectangles[24], Color.Black);//nothing imprtant, just a border.
            #region First line Artifacts
            if (artiFound[0] == false)
            {
                spriteBatch.Draw(artifactsSprite[13], artifactsPlacer[0], Color.Gray);
            }
            else if (artiFound[0] == true)
            {
                spriteBatch.Draw(artifactsSprite[0], artifactsPlacer[0], Color.White);
            }
            if (artiFound[1] == false)
            {
                spriteBatch.Draw(artifactsSprite[13], artifactsPlacer[1], Color.Gray);
            }
            else if (artiFound[1] == true)
            {
                spriteBatch.Draw(artifactsSprite[1], artifactsPlacer[1], Color.White);
            }
            if (artiFound[2] == false)
            {
                spriteBatch.Draw(artifactsSprite[13], artifactsPlacer[2], Color.Gray);
            }
            else if (artiFound[2] == true)
            {
                spriteBatch.Draw(artifactsSprite[2], artifactsPlacer[2], Color.White);
            }
            if (artiFound[3] == false)
            {
                spriteBatch.Draw(artifactsSprite[13], artifactsPlacer[3], Color.Gray);
            }
            else if (artiFound[3] == true)
            {
                spriteBatch.Draw(spritePlacer[7], artifactsPlacer[3], Color.White);
            }
            if (artiFound[4] == false)
            {
                spriteBatch.Draw(artifactsSprite[13], artifactsPlacer[4], Color.Gray);
            }
            else if (artiFound[4] == true)
            {
                spriteBatch.Draw(spritePlacer[7], artifactsPlacer[4], Color.White);
            }
            if (artiFound[5] == false)
            {
                spriteBatch.Draw(artifactsSprite[13], artifactsPlacer[5], Color.Gray);
            }
            else if (artiFound[5] == true)
            {
                spriteBatch.Draw(spritePlacer[7], artifactsPlacer[5], Color.White);
            }
            #endregion
            #region Second line of Artifacts
            if (artiFound[6] == false)
            {
                spriteBatch.Draw(artifactsSprite[13], artifactsPlacer[6], Color.Gray);
            }
            else if (artiFound[6] == true)
            {
                spriteBatch.Draw(spritePlacer[7], artifactsPlacer[6], Color.White);
            }
            if (artiFound[7] == false)
            {
                spriteBatch.Draw(artifactsSprite[13], artifactsPlacer[7], Color.Gray);
            }
            else if (artiFound[7] == true)
            {
                spriteBatch.Draw(spritePlacer[7], artifactsPlacer[7], Color.White);
            }
            if (artiFound[8] == false)
            {
                spriteBatch.Draw(artifactsSprite[13], artifactsPlacer[8], Color.Gray);
            }
            else if (artiFound[8] == true)
            {
                spriteBatch.Draw(spritePlacer[7], artifactsPlacer[8], Color.White);
            }
            if (artiFound[9] == false)
            {
                spriteBatch.Draw(artifactsSprite[13], artifactsPlacer[9], Color.Gray);
            }
            else if (artiFound[8] == true)
            {
                spriteBatch.Draw(spritePlacer[7], artifactsPlacer[9], Color.White);
            }
            if (artiFound[10] == false)
            {
                spriteBatch.Draw(artifactsSprite[13], artifactsPlacer[10], Color.Gray);
            }
            else if (artiFound[10] == true)
            {
                spriteBatch.Draw(spritePlacer[7], artifactsPlacer[10], Color.White);
            }
            if (artiFound[11] == false)
            {
                spriteBatch.Draw(artifactsSprite[13], artifactsPlacer[11], Color.Gray);
            }
            else if (artiFound[11] == true)
            {
                spriteBatch.Draw(spritePlacer[7], artifactsPlacer[11], Color.White);
            }
            #endregion
           //Different artifact you have clicked
            switch (artifactClicked)
            {
                case 1:
                    if (artiFound[0] == false)
                    {
                        spriteBatch.Draw(artifactsSprite[12], artiRec[0], Color.White);
                    }
                    else if (artiFound[0] == true)
                    {
                        spriteBatch.Draw(artifactTextArray[0], artiRec[0], Color.White);
                    }
                    break;
                case 2:
                    if (artiFound[1] == false)
                    {
                        spriteBatch.Draw(artifactsSprite[12], artiRec[0], Color.White);
                    }
                    else if (artiFound[1] == true)
                    {
                        spriteBatch.Draw(artifactTextArray[1], artiRec[0], Color.White);
                    }
                    break;
                case 3:
                    if (artiFound[2] == false)
                    {
                        spriteBatch.Draw(artifactsSprite[12], artiRec[0], Color.White);
                    }
                    else if (artiFound[2] == true)
                    {
                        spriteBatch.Draw(artifactTextArray[2], artiRec[0], Color.White);
                    }
                    break;
                case 4:
                    if (artiFound[3] == false)
                    {
                        spriteBatch.Draw(artifactsSprite[12], artiRec[0], Color.Gray);
                    }
                    else if (artiFound[3] == true)
                    {
                        spriteBatch.Draw(spritePlacer[7], artiRec[0], Color.White);
                    }
                    break;
                case 5:
                    if (artiFound[4] == false)
                    {
                        spriteBatch.Draw(artifactsSprite[12], artiRec[0], Color.Gray);
                    }
                    else if (artiFound[4] == true)
                    {
                        spriteBatch.Draw(spritePlacer[7], artiRec[0], Color.White);
                    }
                    break;
                case 6:
                    if (artiFound[5] == false)
                    {
                        spriteBatch.Draw(artifactsSprite[12], artiRec[0], Color.Gray);
                    }
                    else if (artiFound[5] == true)
                    {
                        spriteBatch.Draw(spritePlacer[7], artiRec[0], Color.White);
                    }
                    break;
                case 7:
                    if (artiFound[6] == false)
                    {
                        spriteBatch.Draw(artifactsSprite[12], artiRec[0], Color.Gray);
                    }
                    else if (artiFound[6] == true)
                    {
                        spriteBatch.Draw(spritePlacer[7], artiRec[0], Color.White);
                    }
                    break;
                case 8:
                    if (artiFound[7] == false)
                    {
                        spriteBatch.Draw(artifactsSprite[12], artiRec[0], Color.Gray);
                    }
                    else if (artiFound[7] == true)
                    {
                        spriteBatch.Draw(spritePlacer[7], artiRec[0], Color.White);
                    }
                    break;
                case 9:
                    if (artiFound[8] == false)
                    {
                        spriteBatch.Draw(artifactsSprite[12], artiRec[0], Color.Gray);
                    }
                    else if (artiFound[8] == true)
                    {
                        spriteBatch.Draw(spritePlacer[7], artiRec[0], Color.White);
                    }
                    break;
                case 10:
                    if (artiFound[9] == false)
                    {
                        spriteBatch.Draw(artifactsSprite[12], artiRec[0], Color.Gray);
                    }
                    else if (artiFound[9] == true)
                    {
                        spriteBatch.Draw(spritePlacer[7], artiRec[0], Color.White);
                    }
                    break;
                case 11:
                    if (artiFound[10] == false)
                    {
                        spriteBatch.Draw(artifactsSprite[12], artiRec[0], Color.Gray);
                    }
                    else if (artiFound[10] == true)
                    {
                        spriteBatch.Draw(spritePlacer[7], artiRec[0], Color.White);
                    }
                    break;
                case 12:
                    if (artiFound[11] == false)
                    {
                        spriteBatch.Draw(artifactsSprite[12], artiRec[0], Color.Gray);
                    }
                    else if (artiFound[11] == true)
                    {
                        spriteBatch.Draw(spritePlacer[7], artiRec[0], Color.White);
                    }
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
