using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Miner
{
    public class WorkShop
    {
        private Texture2D[] spritePlacer = new Texture2D[10];
        private Vector2[] spritePlacerPos = new Vector2[10];
        private bool isInvOpen = false; 
        public bool IsInvOpen { get { return isInvOpen; } set { isInvOpen = value; } }

        public void LoadContent(ContentManager content)
        {
            //Background
            spritePlacer[0] = content.Load<Texture2D>("Ui Sprites/InventorybackGround");
            spritePlacerPos[0] = new Vector2(400, 400);
            //first button 
            spritePlacer[1] = content.Load<Texture2D>("Ui Sprites/CraftingButton");
            spritePlacerPos[1] = new Vector2(400, 400);
            //second button 
            spritePlacer[2] = content.Load<Texture2D>("Ui Sprites/CraftingButton");
            spritePlacerPos[2] = new Vector2(750, 400);
            //third button 
            spritePlacer[3] = content.Load<Texture2D>("Ui Sprites/CraftingButton");
            spritePlacerPos[3] = new Vector2(1100, 400);
            //fourth button 
            spritePlacer[4] = content.Load<Texture2D>("Ui Sprites/CraftingButton");
            spritePlacerPos[4] = new Vector2(1450, 400);


        }
        public void Update(GameTime gameTime)
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (isInvOpen == true)
            {

            }
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
            spriteBatch.Draw(spritePlacer[1],//what to draw
                    spritePlacerPos[1],//place to draw it
                    null,//rectangle
                    Color.White,//color of the object
                    0f, //Rotation in radianer
                new Vector2(0, 0),//Orgin Point
                    1f,//How big is 
                    SpriteEffects.None,//effects
                    0f);//Layer higher the number further back it is 
            //second button
            spriteBatch.Draw(spritePlacer[1],//what to draw
                    spritePlacerPos[2],//place to draw it
                    null,//rectangle
                    Color.White,//color of the object
                    0f, //Rotation in radianer
                new Vector2(0, 0),//Orgin Point
                    1f,//How big is 
                    SpriteEffects.None,//effects
                    0f);//Layer higher the number further back it is 
            //third button
            spriteBatch.Draw(spritePlacer[3],//what to draw
                    spritePlacerPos[3],//place to draw it
                    null,//rectangle
                    Color.White,//color of the object
                    0f, //Rotation in radianer
                new Vector2(0, 0),//Orgin Point
                    1f,//How big is 
                    SpriteEffects.None,//effects
                    0f);//Layer higher the number further back it is 
            //fourth button
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
    }
}
