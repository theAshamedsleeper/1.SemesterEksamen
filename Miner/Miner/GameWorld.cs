using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Miner.UiForInv;
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
        private SpriteFont ContFont;
        private List<GameObjects> gameObjects = new List<GameObjects>();
        

        private Texture2D player_terrain;
        private float worldScale = 5f;//2.4f så passer den i width
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
            gameObjects.Add(new Player(new Vector2(screenSize.X /2, screenSize.Y / 2)));
            workShop.Add(new CraftingButton());
            Terrain.Give_Terrain();
            int[] ints = new int[] { 0, 0 };
            Terrain.Start_Chunk(ints);
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
            ContFont = Content.Load<SpriteFont>("FileFont");

            for (int i = 0; i < gameObjects.Count; i++)
            {
                gameObjects[i].LoadContent(Content);
            }
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            #region input
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.D))
            {
                ofset_x--;
                Terrain.Load_chunks(ofset_x, ofset_y);
            }
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.A))
            {
                ofset_x++;
                Terrain.Load_chunks(ofset_x, ofset_y);
            }
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.S))
            {
                ofset_y--;
                Terrain.Load_chunks(ofset_x, ofset_y);
            }
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.W))
            {
                ofset_y++;
                Terrain.Load_chunks(ofset_x, ofset_y);
            }

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.E))
            {
                int[] loaded_chunk = new int[2];
                loaded_chunk = Terrain.Loaded_Chunk_differ(0);
                if (Terrain.Which(_graphics.PreferredBackBufferWidth / 2 - player_terrain.Width / 2 - ofset_x, _graphics.PreferredBackBufferHeight / 2 - player_terrain.Height / 2 - ofset_y, loaded_chunk) == 1)
                {
                    Terrain.Change(_graphics.PreferredBackBufferWidth / 2 - player_terrain.Width / 2 - ofset_x, _graphics.PreferredBackBufferHeight / 2 - player_terrain.Height / 2 - ofset_y, 0, loaded_chunk);
                }
            }
            #endregion
            for (int i = 0; i < workShop.Count; i++)
            {
                workShop[i].Update(gameTime);
            }
            base.Update(gameTime);

            for (int i = 0; i < gameObjects.Count; i++)
            {
                gameObjects[i].Update(gameTime);
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            #region terain World
            // x and y coords of where the terrain tiles are drawn.
            float gx = 0f;
            float gy = 0f;
            int tx = 0;
            int ty = 0;
            int[] loaded_chunk = new int[2];
            for (int i = 0; i < Terrain.Chunk_differ(); i++)
            {
                loaded_chunk = Terrain.Loaded_Chunk_differ(i);
                int[] direction = new int[2];
                direction = Terrain.direction(loaded_chunk);

                gx = 0f;
                gy = 0f;

                tx = 0;
                ty = 0;
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
                        case 1:
                            texture_terrain = dirt_terrain;
                            break;
                    }
                    #endregion
                    _spriteBatch.Draw(texture_terrain,//what to draw
                    new Vector2(gx + ofset_x + direction[0], gy + ofset_y + direction[1]),//place to draw it
                    null,//rectangle
                    Color.White,//color of player
                    0f, //Rotation of player
                    Vector2.Zero,//Orgin Point
                    worldScale,//How big is the player
                    SpriteEffects.None,//effects
                    1f);//Layer 
                    if (tx >= 31)
                    {
                        tx = 0;
                        gx = 0;
                        gy += 32f * worldScale;
                    }
                    else
                    {
                        tx++;
                        gx += 32f * worldScale;
                    }
                }
            }
            #endregion
            string text = "";
            for (int i = 0; i < Terrain.Chunk_differ(); i++)
            {
                loaded_chunk = Terrain.Loaded_Chunk_differ(i);
                text += loaded_chunk[0];
                text += loaded_chunk[1];
                text += "\n";
            }
            _spriteBatch.DrawString(ContFont, text, new Vector2(1600, 100), Color.White);

            foreach (WorkShop go in workShop)
            {
                go.Draw(_spriteBatch);
            }

            foreach (GameObjects objects in gameObjects)
            {
                objects.Draw(_spriteBatch, gameTime);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}