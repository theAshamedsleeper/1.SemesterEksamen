using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Miner
{
    public abstract class WorkShop
    {
        protected Texture2D[] spritePlacer = new Texture2D[10];
        protected Vector2[] spritePlacerPos = new Vector2[10];
        protected SpriteFont[] fontsTitle = new SpriteFont[4];
        protected Rectangle[] uiRectangles = new Rectangle[5];
        protected bool isCraftClicked = false;
        protected bool isUpgradesClicked = false;
        protected bool isStatsClicked = false;
        protected bool isArtiClicked = false;
        private bool isInvOpen = true;
        public bool IsInvOpen { get { return isInvOpen; } set { isInvOpen = value; } }

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

            }
        }
    }
}
