using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Miner.UiForInv;
using SharpDX.Direct3D9;
using System.Net;
using System.Threading;

namespace Miner
{
    public abstract class WorkShop
    {
        protected static Texture2D[] spritePlacer = new Texture2D[30];
        protected static Texture2D[] upgradeInfo = new Texture2D[13];
        protected static Vector2[] spritePlacerPos = new Vector2[10];
        protected static SpriteFont[] fontsTitle = new SpriteFont[10];
        protected static Rectangle[] uiRectangles = new Rectangle[50];
        protected static Texture2D[] reCount= new Texture2D[5];
        protected static Texture2D[] artifactsSprite = new Texture2D[20];
        protected static Rectangle[] artifactsPlacer = new Rectangle[20];
        protected bool isCraftClicked = false;
        protected static bool isUpgradesClicked = false;
        protected bool isStatsClicked = false;
        protected static bool isArtiClicked = false;
        protected static bool[] upgraded = new bool[13];
        protected static byte upgradeClicked;
        private static int r1Copper;
        private static int r2MilitaryScrap;
        private static int r3Titanium;
        private static int r4Plat;
        private static int r5Uranium;
        private bool isInvOpen = true;
        public static bool[] Upgraded { get { return upgraded; } set { upgraded = value; } }
        public bool IsInvOpen { get { return isInvOpen; } set { isInvOpen = value; } }
        public static int R1Cop { get { return r1Copper; } set { r1Copper = value; } }
        public static int R2Mili { get { return r2MilitaryScrap; } set { r2MilitaryScrap = value; } }
        public static int R3Tit { get { return r3Titanium; } set { r3Titanium = value; } }
        public static int R4Plat { get { return r4Plat; } set { r4Plat = value; } }
        public static int R5Uran { get { return r5Uranium; } set { r5Uranium = value; } }

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
                #region Button Text
                spriteBatch.DrawString(fontsTitle[0], "Craft", spritePlacerPos[1], Color.White, 0f, new Vector2(0, 0), 2f, SpriteEffects.None, 0f);
                spriteBatch.DrawString(fontsTitle[1], "Upgrade", spritePlacerPos[2], Color.White, 0f, new Vector2(0, 0), 2f, SpriteEffects.None, 0f);
                spriteBatch.DrawString(fontsTitle[2], "Artifacts", spritePlacerPos[3], Color.White, 0f, new Vector2(0, 0), 2f, SpriteEffects.None, 0f);
                spriteBatch.DrawString(fontsTitle[3], "Stats", spritePlacerPos[4], Color.White, 0f, new Vector2(0, 0), 2f, SpriteEffects.None, 0f);
                #endregion
                if (isUpgradesClicked == true)
                {
                UpgradeButton.DrawUpgrade(spriteBatch);
                }
                if (isArtiClicked == true)
                {
                    ArtifactsButton.DrawArtifact(spriteBatch);
                }
                

            }
        }

    }
}
