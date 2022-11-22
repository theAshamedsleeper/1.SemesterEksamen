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
        protected bool isCraftClicked = true;
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
                spriteBatch.Draw(spritePlacer[1],//what to draw
                        spritePlacerPos[1],//place to draw it
                        null,//rectangle
                        Color.White,//color of the object
                        0f, //Rotation in radianer
                    new Vector2(0, 0),//Orgin Point
                        1f,//How big is 
                        SpriteEffects.None,//effects
                        0f);//Layer higher the number further back it is 

                }
                else if (isCraftClicked == true)
                {
                    spriteBatch.Draw(spritePlacer[1],//what to draw
                       spritePlacerPos[1],//place to draw it
                       null,//rectangle
                       Color.Black,//color of the object
                       0f, //Rotation in radianer
                   new Vector2(0, 0),//Orgin Point
                       1f,//How big is 
                       SpriteEffects.None,//effects
                       0f);//Layer higher the number further back it is 
                }
                //second button
                if (isUpgradesClicked == false)
                {
                spriteBatch.Draw(spritePlacer[2],//what to draw
                        spritePlacerPos[2],//place to draw it
                        null,//rectangle
                        Color.White,//color of the object
                        0f, //Rotation in radianer
                    new Vector2(0, 0),//Orgin Point
                        1f,//How big is 
                        SpriteEffects.None,//effects
                        0f);//Layer higher the number further back it is 

                }
                else if (isUpgradesClicked == true)
                {
                    spriteBatch.Draw(spritePlacer[2],//what to draw
                        spritePlacerPos[2],//place to draw it
                        null,//rectangle
                        Color.Black,//color of the object
                        0f, //Rotation in radianer
                    new Vector2(0, 0),//Orgin Point
                        1f,//How big is 
                        SpriteEffects.None,//effects
                        0f);//Layer higher the number further back it is 
                }
                //third button
                if (isArtiClicked == false)
                {
                spriteBatch.Draw(spritePlacer[3],//what to draw
                        spritePlacerPos[3],//place to draw it
                        null,//rectangle
                        Color.White,//color of the object
                        0f, //Rotation in radianer
                    new Vector2(0, 0),//Orgin Point
                        1f,//How big is 
                        SpriteEffects.None,//effects
                        0f);//Layer higher the number further back it is 
                }
                else if (isArtiClicked == true) 
                {
                    spriteBatch.Draw(spritePlacer[3],//what to draw
                       spritePlacerPos[3],//place to draw it
                       null,//rectangle
                       Color.Black,//color of the object
                       0f, //Rotation in radianer
                   new Vector2(0, 0),//Orgin Point
                       1f,//How big is 
                       SpriteEffects.None,//effects
                       0f);//Layer higher the number further back it is 
                }
                //fourth button
                if (isStatsClicked == false)
                {
                spriteBatch.Draw(spritePlacer[4],//what to draw
                        spritePlacerPos[4],//place to draw it
                        null,//rectangle
                        Color.White,//color of the object
                        0f, //Rotation in radianer
                    new Vector2(0, 0),//Orgin Point
                        1f,//How big is 
                        SpriteEffects.None,//effects
                        0f);//Layer higher the number further back it is 
                }
                else if (isStatsClicked== true)
                {
                    spriteBatch.Draw(spritePlacer[4],//what to draw
                        spritePlacerPos[4],//place to draw it
                        null,//rectangle
                        Color.Black,//color of the object
                        0f, //Rotation in radianer
                    new Vector2(0, 0),//Orgin Point
                        1f,//How big is 
                        SpriteEffects.None,//effects
                        0f);//Layer higher the number further back it is 

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
