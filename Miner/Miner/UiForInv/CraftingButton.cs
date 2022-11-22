using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Miner.UiForInv
{
    internal class CraftingButton : WorkShop
    {
     
        public override void LoadContent(ContentManager content)
        {
            
            //Background
            spritePlacer[0] = content.Load<Texture2D>("Ui Sprites/InventorybackGround");
            spritePlacerPos[0] = new Vector2(400, 400);
            //first button 
            spritePlacer[1] = content.Load<Texture2D>("Ui Sprites/CraftingButton");
            spritePlacerPos[1] = new Vector2(400, 400);
            fontsTitle[0] = content.Load<SpriteFont>("Ui Sprites/Fonts/CraftFontT");
            //second button 
            spritePlacer[2] = content.Load<Texture2D>("Ui Sprites/CraftingButton");
            spritePlacerPos[2] = new Vector2(750, 400);
            fontsTitle[1] = content.Load<SpriteFont>("Ui Sprites/Fonts/UpgradeFontT");
            //third button 
            spritePlacer[3] = content.Load<Texture2D>("Ui Sprites/CraftingButton");
            spritePlacerPos[3] = new Vector2(1100, 400);
            fontsTitle[2] = content.Load<SpriteFont>("Ui Sprites/Fonts/ArtifactsFontT");
            //fourth button 
            spritePlacer[4] = content.Load<Texture2D>("Ui Sprites/CraftingButton");
            spritePlacerPos[4] = new Vector2(1450, 400);
            fontsTitle[3] = content.Load<SpriteFont>("Ui Sprites/Fonts/StatsFontT");

        }

        public override void Update(GameTime gameTime)
        {
        }

    }
}
