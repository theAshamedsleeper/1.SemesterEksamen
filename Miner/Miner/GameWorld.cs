using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Miner
{
    public class GameWorld : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private static Vector2 screenSize;

        private Texture2D texture_terrain;
        private Texture2D dirt_terrain;
        private Texture2D grass_terrain;

        private Texture2D player_terrain;
        private float worldScale = 1.875f;//2.4f så passer den i width
        private bool inv = false;
        private int ofset_x = 0;
        private int ofset_y = 0;
        private int current_chunk = 0;

        private List<WorkShop> workShop = new List<WorkShop>();


        public GameWorld()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            _graphics.PreferredBackBufferHeight = 1080;
            _graphics.PreferredBackBufferWidth = 1920;
            screenSize = new Vector2(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
            _graphics.IsFullScreen = false;
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            Terrain.Give_Terrain();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
           
            for (int i = 0; i < workShop.Count; i++)
            {
                workShop[i].LoadContent(Content);
            }
            grass_terrain = Content.Load<Texture2D>("pixil-frame-0");
            dirt_terrain = Content.Load<Texture2D>("pixil-frame-2");
            player_terrain = Content.Load<Texture2D>("pixilart-drawing_1");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.A))
                ofset_x--;
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.D))
                ofset_x++;
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.W))
                ofset_y--;
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.S))
                ofset_y++;
            Terrain.Load_chunks(ofset_x, ofset_y);
            Terrain.Move_Main_chunk(ofset_x, ofset_y, _graphics.PreferredBackBufferWidth / 2 - player_terrain.Width / 2, _graphics.PreferredBackBufferHeight / 2 - player_terrain.Height / 2);
            for (int i = 0; i < workShop.Count; i++)
            {
                workShop[i].Update(gameTime);
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            #region terain World
            // x and y coords of where the terrain tiles are drawn.
            float gx = 0f;
            float gy = 0f;
            for (int i = 0; i < Terrain.Chunk_differ(); i++)
            {
                int[] loaded_chunk = new int[2];
                loaded_chunk = Terrain.Loaded_Chunk_differ(i);
                // for loop to draw all the terrain.
                for (int i_2 = 0; i_2 < (32) * (18); i_2++)
                {
                    #region texture terrain switch
                    // the switch changes the terrain drawn depending on the terrain int.
                    switch (Terrain.Which(gx, gy, loaded_chunk))
                    {
                        case 0:
                            texture_terrain = grass_terrain;
                            break;
                        case 2:
                            texture_terrain = dirt_terrain;
                            break;
                    }
                    #endregion
                    _spriteBatch.Draw(texture_terrain,//what to draw
                    new Vector2(gx + ofset_x, gy + ofset_y),//place to draw it
                    null,//rectangle
                    Color.White,//color of player
                    0f, //Rotation of player
                    Vector2.Zero,//Orgin Point
                    worldScale,//How big is the player
                    SpriteEffects.None,//effects
                    1f);//Layer 
                    if (gx >= 1920 - 32 * worldScale)
                    {
                        gx = 0;
                        gy += 32f * worldScale;
                    }
                    else
                    {
                        gx += 32f * worldScale;
                    }
                }
            }
            #endregion
            foreach (WorkShop go in workShop)
            {
                go.Draw(_spriteBatch);
            }
            _spriteBatch.Draw(player_terrain,//what to draw
                new Vector2(_graphics.PreferredBackBufferWidth/2 - player_terrain.Width / 2, _graphics.PreferredBackBufferHeight/2 - player_terrain.Height / 2),//place to draw it
                null,//rectangle
                Color.White,//color of player
                0f, //Rotation of player
                Vector2.Zero,//Orgin Point
                worldScale,//How big is the player
                SpriteEffects.None,//effects
                0f);//Layer 

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}