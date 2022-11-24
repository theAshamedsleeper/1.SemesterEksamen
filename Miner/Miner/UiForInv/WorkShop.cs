using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Miner
{
    public abstract class WorkShop
    {
        protected Texture2D[] spritePlacer = new Texture2D[10];
        protected Vector2[] spritePlacerPos = new Vector2[10];
        protected SpriteFont[] fontsTitle = new SpriteFont[10];
        protected Rectangle[] uiRectangles = new Rectangle[40];
        protected bool isCraftClicked = false;
        protected bool isUpgradesClicked = false;
        protected bool isStatsClicked = false;
        protected bool isArtiClicked = false;
        // protected bool[] upgradeClicked = new bool[12];
        protected byte UpgradeClicked;
        private static int r1;
        private static int r2;
        private static int r3;
        private static int r4;
        private static int r5;
        private bool isInvOpen = true;
        public bool IsInvOpen { get { return isInvOpen; } set { isInvOpen = value; } }
        public static int R1 { get { return r1; } set { r1 = value; } }
        public static int R2 { get { return r2; } set { r2 = value; } }
        public static int R3 { get { return r3; } set { r3 = value; } }
        public static int R4 { get { return r4; } set { r4 = value; } }
        public static int R5 { get { return r5; } set { r5 = value; } }

        public abstract void LoadContent(ContentManager content);

        public abstract void Update(GameTime gameTime);
        public void Draw(SpriteBatch spriteBatch)
        {
            if (isInvOpen == true)
            {
                #region Buttons
                //background
                spriteBatch.Draw(spritePlacer[0],//what to draw
                        spritePlacerPos[0],//place to draw it
                      null,//rectangle
                        Color.White,//color of the object
                        0f, //Rotation in radianer
                    new Vector2(0, 0),//Orgin Point
                        1f,//How big is 
                        SpriteEffects.None,//effects
                        0f);//Layer higher the number further back it is 
                            //first button
                if (isCraftClicked == false)
                {
                    spriteBatch.Draw(spritePlacer[1], uiRectangles[0], Color.White);

                }
                else if (isCraftClicked == true)
                {
                    spriteBatch.Draw(spritePlacer[1], uiRectangles[0], Color.Black);
                }
                //second button
                if (isUpgradesClicked == false)
                {
                    spriteBatch.Draw(spritePlacer[2], uiRectangles[1], Color.White);

                }
                else if (isUpgradesClicked == true)
                {
                    spriteBatch.Draw(spritePlacer[2], uiRectangles[1], Color.Black);
                }
                //third button
                if (isArtiClicked == false)
                {
                    spriteBatch.Draw(spritePlacer[3], uiRectangles[2], Color.White);
                }
                else if (isArtiClicked == true)
                {
                    spriteBatch.Draw(spritePlacer[3], uiRectangles[2], Color.Black);
                }
                //fourth button
                if (isStatsClicked == false)
                {
                    spriteBatch.Draw(spritePlacer[4], uiRectangles[3], Color.White);
                }
                else if (isStatsClicked == true)
                {
                    spriteBatch.Draw(spritePlacer[4], uiRectangles[3], Color.Black);

                }
                //close button
                spriteBatch.Draw(spritePlacer[5], uiRectangles[4], Color.White);
                #endregion
                #region UpgradeButtons
                if (isUpgradesClicked == true)
                {
                    //First Upgrade Line
                    spriteBatch.Draw(spritePlacer[6], uiRectangles[5], Color.White);
                    spriteBatch.Draw(spritePlacer[6], uiRectangles[6], Color.White);
                    spriteBatch.Draw(spritePlacer[6], uiRectangles[7], Color.White);
                    spriteBatch.Draw(spritePlacer[6], uiRectangles[8], Color.White);
                    //Second Upgrade Line
                    spriteBatch.Draw(spritePlacer[6], uiRectangles[9], Color.White);
                    spriteBatch.Draw(spritePlacer[6], uiRectangles[10], Color.White);
                    spriteBatch.Draw(spritePlacer[6], uiRectangles[11], Color.White);
                    spriteBatch.Draw(spritePlacer[6], uiRectangles[12], Color.White);
                    //Third Upgrade Line
                    spriteBatch.Draw(spritePlacer[6], uiRectangles[13], Color.White);
                    spriteBatch.Draw(spritePlacer[6], uiRectangles[14], Color.White);
                    spriteBatch.Draw(spritePlacer[6], uiRectangles[15], Color.White);
                    spriteBatch.Draw(spritePlacer[6], uiRectangles[16], Color.White);
                    //Last upgrade
                    spriteBatch.Draw(spritePlacer[6], uiRectangles[17], Color.White);
                    //Ressource count
                    spriteBatch.Draw(spritePlacer[6], uiRectangles[18], Color.White);
                    spriteBatch.Draw(spritePlacer[6], uiRectangles[19], Color.White);
                    spriteBatch.Draw(spritePlacer[6], uiRectangles[20], Color.White);
                    spriteBatch.Draw(spritePlacer[6], uiRectangles[21], Color.White);
                    spriteBatch.Draw(spritePlacer[6], uiRectangles[22], Color.White);

                    spriteBatch.DrawString(fontsTitle[5], $"Name {R1}", new Vector2(1720, 550), Color.White);
                    spriteBatch.DrawString(fontsTitle[6], $"Name {R2}", new Vector2(1720, 625), Color.White);
                    spriteBatch.DrawString(fontsTitle[7], $"Name {R3}", new Vector2(1720, 700), Color.White);
                    spriteBatch.DrawString(fontsTitle[8], $"Name {R4}", new Vector2(1720, 775), Color.White);
                    spriteBatch.DrawString(fontsTitle[9], $"Name {R5}", new Vector2(1720, 850), Color.White);

                    //Border Divding from upgrades to show how many ressources you got
                    spriteBatch.Draw(spritePlacer[7], uiRectangles[23], Color.Black);
                    spriteBatch.Draw(spritePlacer[7], uiRectangles[24], Color.Black);

                    #region Upgrade Info
                    switch (UpgradeClicked)
                    {
                        case 1:
                            spriteBatch.Draw(spritePlacer[6], uiRectangles[25], Color.White);
                            spriteBatch.Draw(spritePlacer[6], uiRectangles[5], Color.Gray);

                            break;
                        case 2:
                            spriteBatch.Draw(spritePlacer[6], uiRectangles[26], Color.Red);
                            spriteBatch.Draw(spritePlacer[6], uiRectangles[6], Color.Gray);
                            break;
                        case 3:
                            spriteBatch.Draw(spritePlacer[6], uiRectangles[27], Color.Beige);
                            spriteBatch.Draw(spritePlacer[6], uiRectangles[7], Color.Gray);
                            break;
                        case 4:
                            spriteBatch.Draw(spritePlacer[6], uiRectangles[28], Color.Black);
                            spriteBatch.Draw(spritePlacer[6], uiRectangles[8], Color.Gray);
                            break;
                        case 5:
                            spriteBatch.Draw(spritePlacer[6], uiRectangles[29], Color.Blue);
                            spriteBatch.Draw(spritePlacer[6], uiRectangles[9], Color.Gray);
                            break;
                        case 6:
                            spriteBatch.Draw(spritePlacer[6], uiRectangles[30], Color.Violet);
                            spriteBatch.Draw(spritePlacer[6], uiRectangles[10], Color.Gray);
                            break;
                        case 7:
                            spriteBatch.Draw(spritePlacer[6], uiRectangles[31], Color.Purple);
                            spriteBatch.Draw(spritePlacer[6], uiRectangles[11], Color.Gray);
                            break;
                        case 8:
                            spriteBatch.Draw(spritePlacer[6], uiRectangles[32], Color.Pink);
                            spriteBatch.Draw(spritePlacer[6], uiRectangles[12], Color.Gray);
                            break;
                        case 9:
                            spriteBatch.Draw(spritePlacer[6], uiRectangles[33], Color.DarkBlue);
                            spriteBatch.Draw(spritePlacer[6], uiRectangles[13], Color.Gray);
                            break;
                        case 10:
                            spriteBatch.Draw(spritePlacer[6], uiRectangles[34], Color.Cyan);
                            spriteBatch.Draw(spritePlacer[6], uiRectangles[14], Color.Gray);
                            break;
                        case 11:
                            spriteBatch.Draw(spritePlacer[6], uiRectangles[35], Color.Green);
                            spriteBatch.Draw(spritePlacer[6], uiRectangles[15], Color.Gray);
                            break;
                        case 12:
                            spriteBatch.Draw(spritePlacer[6], uiRectangles[36], Color.Yellow);
                            spriteBatch.Draw(spritePlacer[6], uiRectangles[16], Color.Gray);
                            break;

                    }
                    #endregion

                }
                #endregion
                #region Button Text
                spriteBatch.DrawString(fontsTitle[0], "Craft", spritePlacerPos[1], Color.White, 0f, new Vector2(0, 0), 2f, SpriteEffects.None, 0f);
                spriteBatch.DrawString(fontsTitle[1], "Upgrade", spritePlacerPos[2], Color.White, 0f, new Vector2(0, 0), 2f, SpriteEffects.None, 0f);
                spriteBatch.DrawString(fontsTitle[2], "Artifacts", spritePlacerPos[3], Color.White, 0f, new Vector2(0, 0), 2f, SpriteEffects.None, 0f);
                spriteBatch.DrawString(fontsTitle[3], "Stats", spritePlacerPos[4], Color.White, 0f, new Vector2(0, 0), 2f, SpriteEffects.None, 0f);
                #endregion


            }
        }
    }
}
