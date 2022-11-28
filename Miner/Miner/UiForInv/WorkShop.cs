using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Miner
{
    public abstract class WorkShop
    {
        protected Texture2D[] spritePlacer = new Texture2D[30];
        protected Texture2D[] upgradeInfo = new Texture2D[13];
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
                        case 1: //first on first line
                            if (Upgraded[0] == false)
                            {
                                spriteBatch.Draw(upgradeInfo[0], uiRectangles[25], Color.White);//Upgrade Info
                                spriteBatch.Draw(spritePlacer[14], uiRectangles[5], Color.Gray);//Upgrade box
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[37], Color.Gray);//Upgrade Button
                            }
                            else if (Upgraded[0] == true)
                            {
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[37], Color.Green);//Upgrade Button
                                spriteBatch.Draw(upgradeInfo[0], uiRectangles[25], Color.White);//Uprade Info
                            }
                            break;
                        case 2://second on first line
                            if (Upgraded[1] == false)
                            {
                                spriteBatch.Draw(spritePlacer[15], uiRectangles[6], Color.Gray);//Upgrade box
                                spriteBatch.Draw(upgradeInfo[1], uiRectangles[26], Color.White);//Uprade Info
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[37], Color.Gray);//Upgrade Button
                            }
                            else if (Upgraded[1] == true)
                            {
                                spriteBatch.Draw(upgradeInfo[1], uiRectangles[26], Color.White);//Uprade Info
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[37], Color.Green);//Upgrade Button
                            }
                            break;
                        case 3://third on first line
                            if (Upgraded[2] == false)
                            {
                                spriteBatch.Draw(upgradeInfo[2], uiRectangles[27], Color.White);//Uprade Info
                                spriteBatch.Draw(spritePlacer[16], uiRectangles[7], Color.Gray);//Upgrade box
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[37], Color.Gray);//Upgrade Button

                            }
                            else if (Upgraded[2] == true)
                            {
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[37], Color.Green);//Upgrade Button
                                spriteBatch.Draw(upgradeInfo[2], uiRectangles[27], Color.White);//Uprade Info
                            }
                            break;
                        case 4://fourth on first line
                            if (Upgraded[3] == false)
                            {
                                spriteBatch.Draw(upgradeInfo[3], uiRectangles[28], Color.White);//Uprade Info
                                spriteBatch.Draw(spritePlacer[17], uiRectangles[8], Color.Gray);//Upgrade box
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[37], Color.Gray);//Upgrade Button
                            }
                            else if (Upgraded[3] == true)
                            {
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[37], Color.Green);//Upgrade Button
                                spriteBatch.Draw(upgradeInfo[3], uiRectangles[28], Color.White);//Uprade Info
                            }
                            break;
                        case 5://first on second line
                            if (Upgraded[4] == false)
                            {
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[29], Color.White);//Uprade Info
                                spriteBatch.Draw(spritePlacer[18], uiRectangles[9], Color.Gray);//Upgrade box
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[37], Color.Gray);//Upgrade Button
                            }
                            else if (Upgraded[4] == true)
                            {
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[37], Color.Green);//Upgrade Button
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[29], Color.White);//Uprade Info
                            }
                            break;
                        case 6://second on second line
                            if (Upgraded[5] == false)
                            {
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[30], Color.White);//Uprade Info
                                spriteBatch.Draw(spritePlacer[19], uiRectangles[10], Color.Gray);//Upgrade box
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[37], Color.Gray);//Upgrade Button
                            }
                            else if (Upgraded[5] == true)
                            {
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[37], Color.Green);//Upgrade Button
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[30], Color.White);//Uprade Info

                            }
                            break;
                        case 7://third on second line
                            if (Upgraded[6] == false)
                            {
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[31], Color.White);//Uprade Info
                                spriteBatch.Draw(spritePlacer[20], uiRectangles[11], Color.Gray);//Upgrade box
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[37], Color.Gray);//Upgrade Button
                            }
                            else if (Upgraded[6] == true)
                            {
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[37], Color.Green);//Upgrade Button
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[31], Color.White);//Uprade Info
                            }
                            break;
                        case 8://Fourth on second line
                            if (Upgraded[7] == false)
                            {
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[32], Color.White);//Uprade Info
                                spriteBatch.Draw(spritePlacer[21], uiRectangles[12], Color.Gray);//Upgrade box
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[37], Color.Gray);//Upgrade Button
                            }
                            else if (Upgraded[7] == true)
                            {
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[37], Color.Green);//Upgrade Button
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[32], Color.White);//Uprade Info
                            }
                            break;
                        case 9://First on Third Line
                            if (Upgraded[8] == false)
                            {
                                spriteBatch.Draw(upgradeInfo[8], uiRectangles[33], Color.White);//Uprade Info
                                spriteBatch.Draw(spritePlacer[22], uiRectangles[13], Color.Gray);//Upgrade box
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[37], Color.Gray);//Upgrade Button
                            }
                            else if (Upgraded[8] == true)
                            {
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[37], Color.Green);//Upgrade Button
                                spriteBatch.Draw(upgradeInfo[8], uiRectangles[33], Color.White);//Uprade Info
                            }
                            break;
                        case 10://second on Third Line
                            if (Upgraded[9] == false)
                            {
                                spriteBatch.Draw(upgradeInfo[9], uiRectangles[34], Color.White);//Uprade Info
                                spriteBatch.Draw(spritePlacer[23], uiRectangles[14], Color.Gray);//Upgrade box
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[37], Color.Gray);//Upgrade Button
                            }
                            else if (Upgraded[9] == true)
                            {
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[37], Color.Green);//Upgrade Button
                                spriteBatch.Draw(upgradeInfo[9], uiRectangles[34], Color.White);//Uprade Info
                            }
                            break;
                        case 11://Third on Third Line
                            if (Upgraded[10] == false)
                            {
                                spriteBatch.Draw(upgradeInfo[10], uiRectangles[35], Color.White);//Uprade Info
                                spriteBatch.Draw(spritePlacer[24], uiRectangles[15], Color.Gray);//Upgrade box
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[37], Color.Gray);//Upgrade Button
                            }
                            else if (Upgraded[10] == true)
                            {
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[37], Color.Green);//Upgrade Button
                                spriteBatch.Draw(upgradeInfo[10], uiRectangles[35], Color.White);//Uprade Info
                            }
                            break;
                        case 12://fourth on Third Line
                            if (Upgraded[11] == false)
                            {
                                spriteBatch.Draw(upgradeInfo[11], uiRectangles[36], Color.White);//Uprade Info
                                spriteBatch.Draw(spritePlacer[25], uiRectangles[16], Color.Gray);//Upgrade box
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[37], Color.Gray);//Upgrade Button
                            }
                            else if (Upgraded[11] == true)
                            {
                                spriteBatch.Draw(spritePlacer[6], uiRectangles[37], Color.Green);//Upgrade Button
                                spriteBatch.Draw(upgradeInfo[11], uiRectangles[36], Color.White);//Uprade Info
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
