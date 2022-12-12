using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Miner.UiForInv;
using System.Configuration;

namespace Miner
{
    public abstract class WorkShop
    {
        protected static Texture2D[] spritePlacer = new Texture2D[30];//An array for storing diffent types of texture2d used throughout
        protected static Texture2D[] upgradeInfo = new Texture2D[13];//An array of textures for the information about each upgrade
        protected static Vector2[] spritePlacerPos = new Vector2[10]; //An array used to get a lot of different location
                                                                      //Used mainly in placing down the UI for the inventory system
        protected static SpriteFont[] fontsTitle = new SpriteFont[10];//An array for storing different texts throughout the workshop and subclasses 
        protected static Rectangle[] uiRectangles = new Rectangle[50];//An array for storing all sizes and locations of most things in the UI
        protected static Texture2D[] reCount = new Texture2D[5];//For storing an image of all the resources
        protected static Texture2D[] artifactsSprite = new Texture2D[20];//only for storing in texture of artifacts
        protected static Rectangle[] artifactsPlacer = new Rectangle[20];//only for storing the placement and size of the artifacts
        //4 bools to see which tap your are on
        protected static bool isCraftClicked = false;
        protected static bool isUpgradesClicked = false;
        protected static bool isStatsClicked = false;
        protected static bool isArtiClicked = false;

        protected static bool[] upgraded = new bool[13];//for the upgrade system
        protected static bool[] artiFound = new bool[12];//for the artifact system
        /*  index range 0-3 is drill speed
            index range 4-7 is battery storage
            index range 8-11 is battery recharge speed
            index range 12 is final upgrade*/
        protected static byte upgradeClicked;//for a switch case controling which info you can see
        protected static byte artifactClicked;//for a switch case controling which info you can see;

        //The 5 different resource
        private static int r1Copper;
        private static int r2MilitaryScrap;
        private static int r3Titanium;
        private static int r4Plat;
        private static int r5Uranium;

        protected bool isInvOpen = false;//to see if the inventory is open
        protected float closeDownShopTimer;//A timer to make sure you cant spame the invetory button.
        protected SoundEffect menuSound;//for playing the sound of moving around the inventory
        //A property so you can access the upgrade system from another class
        public static bool[] Upgraded { get { return upgraded; } set { upgraded = value; } }
        //A property so you can access the whcich artifacts you have found from another class
        public static bool[] ArtiFound { get { return artiFound; } set { artiFound = value; } }
        //A property so you can open the inventory through another sub class
        public bool IsInvOpen { get { return isInvOpen; } set { isInvOpen = value; } }
        //5 properties for each resource that can be accessed in anyother script
        public static int R1Cop { get { return r1Copper; } set { r1Copper = value; } }
        public static int R2Mili { get { return r2MilitaryScrap; } set { r2MilitaryScrap = value; } }
        public static int R3Tit { get { return r3Titanium; } set { r3Titanium = value; } }
        public static int R4Plat { get { return r4Plat; } set { r4Plat = value; } }
        public static int R5Uran { get { return r5Uranium; } set { r5Uranium = value; } }

        /// <summary>
        /// All the content needs to be loaded in form the sub classes.
        /// </summary>
        /// <param name="content"></param>
        public abstract void LoadContent(ContentManager content);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gameTime"></param>
        public abstract void Update(GameTime gameTime);
        /// <summary>
        /// Handels the drawing of the invetory UI, it only draws if the inventory is opne.
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {


            if (isInvOpen == true)//handles the drawing and the 4 buttons at the top of the inventory
            {
                //draws the button at the top of the inv
                #region Buttons
                //background
                spriteBatch.Draw(spritePlacer[0],//what to draw
                        spritePlacerPos[0],//where to draw it
                        null,//rectangle
                        Color.White,//color of the object
                        0f, //Rotation in radianer
                        new Vector2(0, 0),//Orgin Point
                        1f,//scale
                        SpriteEffects.None,//effects
                        0f);//Layer
                            //first button
                if (isCraftClicked == false)
                {
                    spriteBatch.Draw(spritePlacer[1], uiRectangles[0], Color.White);

                }
                else if (isCraftClicked == true)
                {
                    spriteBatch.Draw(spritePlacer[1], uiRectangles[0], Color.Gray);
                }
                //second button
                if (isUpgradesClicked == false)
                {
                    spriteBatch.Draw(spritePlacer[2], uiRectangles[1], Color.White);

                }
                else if (isUpgradesClicked == true)
                {
                    spriteBatch.Draw(spritePlacer[2], uiRectangles[1], Color.Gray);
                }
                //third button
                if (isArtiClicked == false)
                {
                    spriteBatch.Draw(spritePlacer[3], uiRectangles[2], Color.White);
                }
                else if (isArtiClicked == true)
                {
                    spriteBatch.Draw(spritePlacer[3], uiRectangles[2], Color.Gray);
                }
                //fourth button
                if (isStatsClicked == false)
                {
                    spriteBatch.Draw(spritePlacer[4], uiRectangles[3], Color.White);
                }
                else if (isStatsClicked == true)
                {
                    spriteBatch.Draw(spritePlacer[4], uiRectangles[3], Color.Gray);

                }
                //close button
                spriteBatch.Draw(spritePlacer[5], uiRectangles[4], Color.White);
                #endregion
                //Switches between what is shown when a button is clicked.
                if (isUpgradesClicked == true)
                {
                    UpgradeButton.DrawUpgrade(spriteBatch);
                }
                if (isArtiClicked == true)
                {
                    ArtifactsButton.DrawArtifact(spriteBatch);
                }
                if (isStatsClicked == true)
                {
                    StatsButton.DrawStats(spriteBatch);
                }
                if (isCraftClicked == true)
                {
                    CraftButton.DrawCrafting(spriteBatch);
                }


            }
        }

    }
}
