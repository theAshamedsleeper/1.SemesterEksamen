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
        protected Rectangle[] uiRectangles = new Rectangle[50];
        protected bool isCraftClicked = false;
        protected bool isUpgradesClicked = false;
        protected bool isStatsClicked = false;
        protected bool isArtiClicked = false;
        protected static bool[] upgraded = new bool[13];
        protected byte upgradeClicked;
        private static int r1 = 100;
        private static int r2 = 100;
        private static int r3;
        private static int r4;
        private static int r5;
        private bool isInvOpen = true;
        public static bool[] Upgraded { get { return upgraded; } set { upgraded = value; } }
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
                    spriteBatch.Draw(spritePlacer[6], uiRectangles[5], Color.White);//Frist line first upgrade
                    if (Upgraded[0] == true)
                    {
                        spriteBatch.Draw(spritePlacer[6], uiRectangles[5], Color.Gray);
                    }
                    spriteBatch.Draw(spritePlacer[6], uiRectangles[6], Color.White);//Fist line second Upgrade
                    if (Upgraded[1] == true)
                    {
                        spriteBatch.Draw(spritePlacer[6], uiRectangles[6], Color.Gray);
                    }
                    spriteBatch.Draw(spritePlacer[6], uiRectangles[7], Color.White);//First Line third Upgrade
                    if (Upgraded[2] == true)
                    {
                        spriteBatch.Draw(spritePlacer[6], uiRectangles[7], Color.Gray);
                    }
                    spriteBatch.Draw(spritePlacer[6], uiRectangles[8], Color.White);//First Line Fourth Upgrade
                    if (Upgraded[3] == true)
                    {
                        spriteBatch.Draw(spritePlacer[6], uiRectangles[8], Color.Gray);
                    }
                    //Second Upgrade Line
                    spriteBatch.Draw(spritePlacer[6], uiRectangles[9], Color.White);//Second Line first upgrade
                    if (Upgraded[4] == true)
                    {
                        spriteBatch.Draw(spritePlacer[6], uiRectangles[9], Color.Gray);
                    }
                    spriteBatch.Draw(spritePlacer[6], uiRectangles[10], Color.White);//Second Line second upgrade
                    if (Upgraded[5] == true)
                    {
                        spriteBatch.Draw(spritePlacer[6], uiRectangles[10], Color.Gray);
                    }
                    spriteBatch.Draw(spritePlacer[6], uiRectangles[11], Color.White);//Second Line third upgrade
                    if (Upgraded[6] == true)
                    {
                        spriteBatch.Draw(spritePlacer[6], uiRectangles[11], Color.Gray);
                    }
                    spriteBatch.Draw(spritePlacer[6], uiRectangles[12], Color.White);//Second Line fourth upgrade
                    if (Upgraded[7] == true)
                    {
                        spriteBatch.Draw(spritePlacer[6], uiRectangles[12], Color.Gray);
                    }
                    //Third Upgrade Line
                    spriteBatch.Draw(spritePlacer[6], uiRectangles[13], Color.White);//Third line first upgrade
                    if (Upgraded[8] == true)
                    {
                        spriteBatch.Draw(spritePlacer[6], uiRectangles[13], Color.Gray);
                    }
                    spriteBatch.Draw(spritePlacer[6], uiRectangles[14], Color.White);//Third line second upgrade
                    if (Upgraded[9] == true)
                    {
                        spriteBatch.Draw(spritePlacer[6], uiRectangles[14], Color.Gray);
                    }
                    spriteBatch.Draw(spritePlacer[6], uiRectangles[15], Color.White);//Third line third upgrade
                    if (Upgraded[10] == true)
                    {
                        spriteBatch.Draw(spritePlacer[6], uiRectangles[15], Color.Gray);
                    }
                    spriteBatch.Draw(spritePlacer[6], uiRectangles[16], Color.White);//Third line fourth upgrade
                    if (Upgraded[11] == true)
                    {
                        spriteBatch.Draw(spritePlacer[6], uiRectangles[16], Color.Gray);
                    }
                    //Last upgrade
                    spriteBatch.Draw(spritePlacer[6], uiRectangles[17], Color.White);// very Last Upgrade
                    if (Upgraded[12] == true)
                    {
                        spriteBatch.Draw(spritePlacer[6], uiRectangles[17], Color.Gray);
                    }
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
                    switch (upgradeClicked)
                    {
                        case 1:
                            if (Upgraded[0] == false)
                            {
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[25], Color.White);
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[5], Color.Gray);
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[37], Color.Gray);
                            }
                            else if (Upgraded[0] == true)
                            {
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[37], Color.Green);
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[25], Color.White);
                            }
                            break;
                        case 2:
                            if (Upgraded[1] == false)
                            {
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[6], Color.Gray);
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[26], Color.Red);
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[37], Color.Gray);
                            }
                            else if (Upgraded[1] == true)
                            {
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[26], Color.Red);
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[37], Color.Green);
                            }
                            break;
                        case 3:
                            if (Upgraded[2] == false)
                            {
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[27], Color.Beige);
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[7], Color.Gray);
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[37], Color.Gray);

                            }
                            else if (Upgraded[2] == true)
                            {
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[37], Color.Green);
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[27], Color.Beige);
                            }
                            break;
                        case 4:
                            if (Upgraded[3] == false)
                            {
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[28], Color.Black);
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[8], Color.Gray);
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[37], Color.Gray);
                            }
                            else if (Upgraded[3] == true)
                            {
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[37], Color.Green);
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[28], Color.Black);
                            }
                            break;
                        case 5:
                            if (Upgraded[4] == false)
                            {
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[29], Color.Blue);
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[9], Color.Gray);
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[37], Color.Gray);
                            }
                            else if (Upgraded[4] == true)
                            {
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[37], Color.Green);
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[29], Color.Blue);
                            }
                            break;
                        case 6:
                            if (Upgraded[5] == false)
                            {
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[30], Color.Violet);
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[10], Color.Gray);
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[37], Color.Gray);
                            }
                            else if (Upgraded[5] == true)
                            {
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[37], Color.Green);
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[30], Color.Violet);

                            }
                            break;
                        case 7:
                            if (Upgraded[6] == false)
                            {
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[31], Color.Purple);
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[11], Color.Gray);
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[37], Color.Gray);
                            }
                            else if (Upgraded[6] == true)
                            {
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[37], Color.Green);
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[31], Color.Purple);
                            }
                            break;
                        case 8:
                            if (Upgraded[7] == false)
                            {
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[32], Color.Pink);
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[12], Color.Gray);
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[37], Color.Gray);
                            }
                            else if (Upgraded[7] == true)
                            {
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[37], Color.Green);
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[32], Color.Pink);
                            }
                            break;
                        case 9:
                            if (Upgraded[8] == false)
                            {
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[33], Color.DarkBlue);
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[13], Color.Gray);
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[37], Color.Gray);
                            }
                            else if (Upgraded[8] == true)
                            {
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[37], Color.Green);
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[33], Color.DarkBlue);
                            }
                            break;
                        case 10:
                            if (Upgraded[9] == false)
                            {
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[34], Color.Cyan);
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[14], Color.Gray);
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[37], Color.Gray);
                            }
                            else if (Upgraded[9] == true)
                            {
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[37], Color.Green);
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[34], Color.Cyan);
                            }
                            break;
                        case 11:
                            if (Upgraded[10] == false)
                            {
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[35], Color.Green);
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[15], Color.Gray);
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[37], Color.Gray);
                            }
                            else if (Upgraded[10] == true)
                            {
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[37], Color.Green);
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[35], Color.Green);
                            }
                            break;
                        case 12:
                            if (Upgraded[11] == false)
                            {
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[36], Color.Yellow);
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[16], Color.Gray);
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[37], Color.Gray);
                            }
                            else if (Upgraded[11] == true)
                            {
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[37], Color.Green);
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[36], Color.Yellow);
                            }
                            break;
                        case 13:
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
