using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miner.UiForInv
{
    internal class ArtifactsButton : WorkShop
    {
        private MouseState mouse;
        private float closeDownShopTimer;


        public override void LoadContent(ContentManager content)
        {
           // artifactsSprite[0] = content.Load<Texture2D>("");
            artifactsPlacer[0] = new Rectangle(765, 540, 125, 125);
            artifactsPlacer[1] = new Rectangle(765, 690, 125, 125);
            artifactsPlacer[2] = new Rectangle(765, 840, 125, 125);
        }

        public override void Update(GameTime gameTime)
        {
            mouse = Mouse.GetState();
            ArtifactsTab(gameTime);
        }
        public static void DrawArtifact(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(spritePlacer[7], uiRectangles[24], Color.Black);//nothing imprtant, just a border.
            spriteBatch.Draw(spritePlacer[7], artifactsPlacer[0], Color.White);
            spriteBatch.Draw(spritePlacer[7], artifactsPlacer[1], Color.White);
            spriteBatch.Draw(spritePlacer[7], artifactsPlacer[2], Color.White);
        }
        private void ArtifactsTab(GameTime gameTime)
        {
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
            if (IsInvOpen == true && Keyboard.GetState().IsKeyDown(Keys.I) && closeDownShopTimer > 0.3f)
            {
                IsInvOpen = false;
                closeDownShopTimer = 0f;
            }
            else if (IsInvOpen == false && Keyboard.GetState().IsKeyDown(Keys.I) && closeDownShopTimer > 0.3f)
            {
                IsInvOpen = true;
                closeDownShopTimer = 0f;
            }
        }
    }
}
