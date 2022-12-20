using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Miner.UiForInv;
using System.Collections.Generic;
using SpriteBatch = Microsoft.Xna.Framework.Graphics.SpriteBatch;

namespace Miner
{
    public class GameWorld : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private static Vector2 screenSize;

        private const string BACKGROUND_TOP = "BackgroundTopBigScale5";
        private Texture2D backgroundTop;

        private Texture2D[] groundSprite = new Texture2D[20];
        private Texture2D texture_terrain;
        private SpriteFont ContFont;

        private List<GameObjects> gameObjects = new List<GameObjects>();
        private List<Tools> toolList = new List<Tools>();
        private List<WorkShop> workShop = new List<WorkShop>();

        private float worldScale = 5f;//2.4f så passer den i width
        public static int ofset_x = 0;
        public static int ofset_y = 0;
        public static bool sideCollision = false;
        public static bool upCollision = false;
        public static bool inAir = false;
        public static bool passive = false;

        private SoundEffect engine_sound;
        private SoundEffectInstance engine_sound_inst;

        private Rectangle invOpenRecBag;
        private Texture2D invOpenTab;
        private MouseState mouseMove;
        private bool gamePaused = false;
        private Rectangle[] menuButtonRec = new Rectangle[3];
        private Texture2D[] menuButtonTex = new Texture2D[3];
        private float pauseButtonTimer;

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
            gameObjects.Add(new Player(new Vector2(screenSize.X / 2 - (32 * 5) / 2, screenSize.Y / 2 - (32 * 5) / 2)));
            workShop.Add(new UpgradeButton());
            toolList.Add(new Tools());
            workShop.Add(new ArtifactsButton());
            Terrain.Give_Terrain(Content);
            int[] ints = new int[] { 0, 0 };
            Terrain.Start_Chunk(ints);
            base.Initialize();

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            invOpenTab = Content.Load<Texture2D>("Ui Sprites/OpenInv");
            invOpenRecBag = new Rectangle(1800, 10, 100, 100);
            menuButtonTex[0] = Content.Load<Texture2D>("Ui Sprites/Menu Buttons/ButtonMenu");
            menuButtonTex[1] = Content.Load<Texture2D>("Ui Sprites/Menu Buttons/ButtonOptions");
            menuButtonTex[2] = Content.Load<Texture2D>("Ui Sprites/Menu Buttons/ButtonQuit");
            menuButtonRec[0] = new Rectangle(850, 400, 300, 100);
            menuButtonRec[1] = new Rectangle(850, 525, 300, 100);
            menuButtonRec[2] = new Rectangle(850, 650, 300, 100);
            for (int i = 0; i < workShop.Count; i++)
            {
                workShop[i].LoadContent(Content);
            }
            groundSprite[0] = Content.Load<Texture2D>("BackgroundTop3");//Baggrund Over Jorden
            groundSprite[1] = Content.Load<Texture2D>("GroundSprite/output-onlinepngtools (1)");
            groundSprite[2] = Content.Load<Texture2D>("NewDirt2");//dirt Terrain
            groundSprite[3] = Content.Load<Texture2D>("GroundSprite/Stone");
            groundSprite[4] = Content.Load<Texture2D>("GroundSprite/RockyDrit");
            groundSprite[5] = Content.Load<Texture2D>("GroundSprite/Kobber");
            groundSprite[6] = Content.Load<Texture2D>("GroundSprite/Titanium");
            groundSprite[7] = Content.Load<Texture2D>("GroundSprite/UraniumNew");
            groundSprite[8] = Content.Load<Texture2D>("GroundSprite/Platinium2");
            groundSprite[9] = Content.Load<Texture2D>("MilitaryScrapBlock2");
            groundSprite[10] = Content.Load<Texture2D>("RedClayBlock");
            groundSprite[11] = Content.Load<Texture2D>("DarkRedClayBlock");
            groundSprite[12] = Content.Load<Texture2D>("NewDirtSmallRocks");
            groundSprite[13] = Content.Load<Texture2D>("NewDirtRootV1");
            groundSprite[14] = Content.Load<Texture2D>("NewDirtRootV2");
            groundSprite[15] = Content.Load<Texture2D>("ArtefactBlock");



            engine_sound = Content.Load<SoundEffect>("Sound/motorcycle-idle-01");
            engine_sound_inst = engine_sound.CreateInstance();

            backgroundTop = Content.Load<Texture2D>(BACKGROUND_TOP);

            ContFont = Content.Load<SpriteFont>("FileFont");

            for (int i = 0; i < gameObjects.Count; i++)
            {
                gameObjects[i].LoadContent(Content);
            }

            for (int i = 0; i < toolList.Count; i++)
            {
                toolList[i].LoadContent(Content);
            }
        }

        protected override void Update(GameTime gameTime)
        {
            mouseMove = Mouse.GetState();
            pauseButtonTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            #region Menu
            if (WorkShop.IsInvOpen == false && pauseButtonTimer > 0.5f && gamePaused == false && Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                gamePaused = true;
                pauseButtonTimer = 0f;
            }
            if (pauseButtonTimer > 0.5f && gamePaused == true && Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                gamePaused = false;
                pauseButtonTimer = 0f;
            }
            if (gamePaused == false && pauseButtonTimer > 0.5f && WorkShop.IsInvOpen == false && Keyboard.GetState().IsKeyDown(Keys.I))
            {
                WorkShop.IsInvOpen = true;
                pauseButtonTimer = 0f;
            }
            if (pauseButtonTimer > 0.5f && WorkShop.IsInvOpen == true && Keyboard.GetState().IsKeyDown(Keys.I))
            {
                WorkShop.IsInvOpen = false;
                pauseButtonTimer = 0f;
            }
            if (gamePaused== true && menuButtonRec[2].Contains(mouseMove.X, mouseMove.Y) && mouseMove.LeftButton == ButtonState.Pressed)
            {
                Exit();
            }
            #endregion
            //Back pack
            if (WorkShop.IsInvOpen == false && invOpenRecBag.Contains(mouseMove.X, mouseMove.Y) && mouseMove.LeftButton == ButtonState.Pressed)
            {
                WorkShop.IsInvOpen = true;
            }
            #region input
            float deltatime = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            //
            if (Tools.batteryFrame >= 300)
            {
                Exit();

            }

            Terrain.Move_Main_chunk(ofset_x, ofset_y);

            if (Keyboard.GetState().IsKeyDown(Keys.D) || Keyboard.GetState().IsKeyDown(Keys.A) || Keyboard.GetState().IsKeyDown(Keys.S) || Keyboard.GetState().IsKeyDown(Keys.W))
            {
                if (engine_sound_inst.State == SoundState.Stopped)
                {
                    engine_sound_inst.Play();
                }
                engine_sound_inst.Volume = 0.8f;


                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.D))
                {
                    if (Terrain.player_collis(1, deltatime) == false)
                    {
                        sideCollision = false;
                        ofset_x -= 4;
                        Terrain.Load_chunks(ofset_x, ofset_y);

                    }
                    else
                    {
                        sideCollision = true;

                    }

                }

                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.A))
                {
                    if (Terrain.player_collis(0, deltatime) == false)
                    {
                        sideCollision = false;
                        ofset_x += 4;
                        Terrain.Load_chunks(ofset_x, ofset_y);
                    }
                    else
                    {
                        sideCollision = true;
                    }
                }


                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.S))
                {
                    if (Terrain.player_collis(3, deltatime) == false)
                    {
                        ofset_y -= 4;
                        Terrain.Load_chunks(ofset_x, ofset_y);

                    }

                }
                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.W))
                {
                    if (Terrain.player_collis(2, deltatime) == false)
                    {
                        upCollision = false;

                        ofset_y += 8;
                        Terrain.Load_chunks(ofset_x, ofset_y);
                    }
                    else
                    {
                        upCollision = true;

                    }
                }
            }
            else
            {

                engine_sound_inst.Volume = 0.4f;
            }

            #endregion
            #region gravity
            if (Terrain.player_collis_gravity() == false)
            {
                ofset_y -= 4;
                inAir = false;
            }
            else
            {
                inAir = true;
            }
            #endregion

            for (int i = 0; i < workShop.Count; i++)
            {
                workShop[i].Update(gameTime);
            }


            for (int i = 0; i < gameObjects.Count; i++)
            {
                gameObjects[i].Update(gameTime);
            }

            for (int i = 0; i < toolList.Count; i++)
            {
                toolList[i].Update(gameTime);
            }

            base.Update(gameTime);



        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Beige);
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            _spriteBatch.Draw(backgroundTop, new Vector2(ofset_x / 2, ofset_y - 160), new Rectangle(0, 0, 3500, 800), Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 0f);

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

                    if (Terrain.Which(gx, gy, loaded_chunk) > 16)
                    {
                        texture_terrain = groundSprite[15];
                    }
                    else
                    {
                        texture_terrain = groundSprite[Terrain.Which(gx, gy, loaded_chunk)];
                    }

                    switch (texture_terrain)
                    {
                        case Texture n when n == groundSprite[5]:
                            _spriteBatch.Draw(groundSprite[3],//what to draw
                            new Vector2(gx + ofset_x + direction[0], gy + ofset_y + direction[1]),//place to draw it
                            null,//rectangle
                            Color.White,//color of player
                            0f, //Rotation of player
                            Vector2.Zero,//Orgin Point
                            worldScale,//How big is the player
                            SpriteEffects.None,//effects
                            1f);//Layer 
                            break;
                        case Texture n when n == groundSprite[6] || n == groundSprite[7] || n == groundSprite[8]:
                            _spriteBatch.Draw(groundSprite[4],//what to draw
                            new Vector2(gx + ofset_x + direction[0], gy + ofset_y + direction[1]),//place to draw it
                            null,//rectangle
                            Color.White,//color of player
                            0f, //Rotation of player
                            Vector2.Zero,//Orgin Point
                            worldScale,//How big is the player
                            SpriteEffects.None,//effects
                            1f);//Layer 
                            break;
                        case Texture n when n == groundSprite[15]:
                            int terrain_mod = Terrain.Which(gx, gy, loaded_chunk);
                            _spriteBatch.Draw(groundSprite[2 + terrain_mod - 15],//what to draw
                            new Vector2(gx + ofset_x + direction[0], gy + ofset_y + direction[1]),//place to draw it
                            null,//rectangle
                            Color.White,//color of player
                            0f, //Rotation of player
                            Vector2.Zero,//Orgin Point
                            worldScale,//How big is the player
                            SpriteEffects.None,//effects
                            1f);//Layer 
                            break;
                    }
                    #endregion
                    if (Terrain.Which(gx, gy, loaded_chunk) != 0)
                    {
                        _spriteBatch.Draw(texture_terrain,//what to draw
                   new Vector2(gx + ofset_x + direction[0], gy + ofset_y + direction[1]),//place to draw it
                   null,//rectangle
                   Color.White,//color of player
                   0f, //Rotation of player
                   Vector2.Zero,//Orgin Point
                   worldScale,//How big is the player
                   SpriteEffects.None,//effects
                   1f);//Layer 
                    }
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
            text += ofset_x + " " + ofset_y;
            _spriteBatch.DrawString(ContFont, text, new Vector2(1600, 100), Color.Green);
            _spriteBatch.Draw(invOpenTab, invOpenRecBag, Color.White);

            foreach (GameObjects objects in gameObjects)
            {
                objects.Draw(_spriteBatch, gameTime);
            }
            foreach (WorkShop go in workShop)
            {
                go.Draw(_spriteBatch);
            }

            foreach (Tools tool in toolList)
            {
                tool.Draw(_spriteBatch, gameTime);
            }
            if (gamePaused == true)
            {
                _spriteBatch.Draw(menuButtonTex[0], menuButtonRec[0], Color.White);
                _spriteBatch.Draw(menuButtonTex[1], menuButtonRec[1], Color.White);
                _spriteBatch.Draw(menuButtonTex[2], menuButtonRec[2], Color.White);
            }




            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}