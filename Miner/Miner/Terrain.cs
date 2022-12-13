using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Miner
{
    internal static class Terrain
    {

        private static int width = 1024 / 32;
        private static int height = 576 / 32;
        private static int x_1 = 0;
        private static int y_1 = 0;
        private static int z_1 = 0;

        private static int[] tiles_x = new int[width * height];
        private static int[] tiles_y = new int[width * height];
        private static int[] tiles_t_c1 = new int[width * height];
        private static int[] tiles_t_c2 = new int[width * height];
        private static int[] tiles_t_c3 = new int[width * height];
        private static int[] tiles_t_c4 = new int[width * height];
        private static int[] tiles_empty = new int[width * height];
        private static float[] tiles_mined = new float[width * height];

        private static List<int[]> loaded_chunks = new List<int[]>();
        private static byte switch_off = 0;
        private static SoundEffect stonebreak_1;
        private static SoundEffect stonebreak_2;
        private static SoundEffect stonebreak_3;
        private static SoundEffect stonebreak_4;
        private static SoundEffect stonebreakfinish;
        private static float sound_timer = 0;
        #region terrain making
        /// <summary>
        /// a method to give value to 2 arrays and loading all needed soundeffects.
        /// it will give the x and y values, as i don't wanna do it manually, the array is 576 indexes long.
        /// this way we will be able to pin point a index, by finding the index with both x and y is the correct index, 
        /// and then we know the index of the terrain type array and the amount mined array.
        /// Ones the funktion is done, it should look like this if x was 3 long and y 4 long
        /// x [0, 1, 2, 0, 1, 2, 0, 1, 2, 0, 1, 2]
        /// y [0, 0, 0, 1, 1, 1, 2, 2, 2, 3, 3, 3]
        /// we believe this will be more effective than an object for each tile.
        /// </summary>
        public static void Give_Terrain(ContentManager content)
        {
            for (int i_2 = 0; i_2 < width * height; i_2++)
            {
                tiles_x[i_2] = x_1;
                tiles_y[i_2] = y_1;
                // updating the coordinates
                if (x_1 == width - 1)
                {
                    x_1 = 0;
                    y_1 += 1;
                }
                else
                {
                    x_1 += 1;
                }
            }
            stonebreak_1 = content.Load<SoundEffect>("Sound/Rocks/StoneBreak1");
            stonebreak_2 = content.Load<SoundEffect>("Sound/Rocks/StoneBreak2");
            stonebreak_3 = content.Load<SoundEffect>("Sound/Rocks/StoneBreak3");
            stonebreak_4 = content.Load<SoundEffect>("Sound/Rocks/StoneBreak4");
            stonebreakfinish = content.Load<SoundEffect>("Sound/Rocks/StoneBreakfinish");
        }
        #endregion
        #region stuff
        /// <summary>
        /// a Collision between player and terrain, will mine the terrain then called.
        /// it checks on 2 points in giving direction, those 2 points are the 2 ends of the sprite.
        /// </summary>
        /// <param name="side"> side is for the side to check on.</param>
        /// <param name="deltatime"> deltatime is for mining to call afterwards</param>
        /// <returns></returns>
        public static bool player_collis(int side, float deltatime)
        {
            float pos_x = 0;
            float pos_y = 0;
            // 0 + amount;
            int amount_of_air_tiles = 1;
            switch (side)
            {
                case 0:
                    #region left
                    for (int j = 0; j < 2; j++)
                    {
                        switch (j)
                        {
                            case 0:
                                // pos check 1
                                pos_x = 1920 / 2 - (32 * 5) / 2 - GameWorld.ofset_x -1;
                                pos_y = 1080 / 2 - (32 * 5) / 2 - GameWorld.ofset_y + 1;
                                break;
                            case 1:
                                // pos check 2
                                pos_x = 1920 / 2 - (32 * 5) / 2 - GameWorld.ofset_x -1;
                                pos_y = 1080 / 2 - (32 * 5) / 2 - GameWorld.ofset_y + 32 * 5 - 1;
                                break;
                        }
                        // if terrain not air
                        if (Terrain.Which(pos_x, pos_y, Terrain.Loaded_Chunk_differ(0)) > amount_of_air_tiles)
                        {
                            if (GameWorld.inAir == true)
                            {
                                mining_updater(pos_x, pos_y, deltatime, 0);
                                break_Sound(deltatime);
                            }
                           
                            return true;
                        }
                    }
                    #endregion
                    break;
                case 1:
                    #region right
                    for (int h = 0; h < 2; h++)
                    {
                        switch (h)
                        {
                            case 0:
                                pos_x = 1920 / 2 - (32 * 5) / 2 - GameWorld.ofset_x + 32 * 5;
                                pos_y = 1080 / 2 - (32 * 5) / 2 - GameWorld.ofset_y + 1;
                                break;
                            case 1:
                                pos_x = 1920 / 2 - (32 * 5) / 2 - GameWorld.ofset_x + 32 * 5;
                                pos_y = 1080 / 2 - (32 * 5) / 2 - GameWorld.ofset_y + 32 * 5 - 1;
                                break;
                        }
                        if (Terrain.Which(pos_x, pos_y, Terrain.Loaded_Chunk_differ(0)) > amount_of_air_tiles)
                        {
                            if (GameWorld.inAir == true)
                            {
                                mining_updater(pos_x, pos_y, deltatime, 1);
                                break_Sound(deltatime);
                            }
                           
                            return true;
                        }
                    }
                    #endregion
                    break;
                case 2:
                    #region up
                    for (int p = 0; p < 3; p++)
                    {
                        switch (p)
                        {
                            case 0:
                                pos_x = 1920 / 2  - GameWorld.ofset_x + 2;
                                pos_y = 1080 / 2 - (32 * 5) / 2 - GameWorld.ofset_y - 1;
                                break;
                            case 1:
                                pos_x = 1920 / 2 - (32 * 5) / 2 - GameWorld.ofset_x + 2;
                                pos_y = 1080 / 2 - (32 * 5) / 2 - GameWorld.ofset_y-1;
                                break;
                            case 2:
                                pos_x = 1920 / 2 - (32 * 5) / 2 - GameWorld.ofset_x + 32 * 5 - 2;
                                pos_y = 1080 / 2 - (32 * 5) / 2 - GameWorld.ofset_y - 1;
                                break;
                        }
                        if (Terrain.Which(pos_x, pos_y, Terrain.Loaded_Chunk_differ(0)) > amount_of_air_tiles)
                        {
                            if (GameWorld.inAir == true)
                            {
                                mining_updater(pos_x, pos_y, deltatime, 2);
                                break_Sound(deltatime);
                            }
                            
                            return true;
                        }
                    }
                    #endregion
                    break;
                case 3:
                    #region down
                    for (int l = 0; l < 3; l++)
                    {
                        switch (l)
                        {
                            case 0:
                                pos_x = 1920 / 2  - GameWorld.ofset_x;
                                pos_y = 1080 / 2 - (32 * 5) / 2 - GameWorld.ofset_y + 32 * 5;
                                break;
                            case 1:
                                pos_x = 1920 / 2 - (32 * 5) / 2 - GameWorld.ofset_x + 1;
                                pos_y = 1080 / 2 - (32 * 5) / 2 - GameWorld.ofset_y + 32 * 5;
                                break;
                            case 2:
                                pos_x = 1920 / 2 - (32 * 5) / 2 - GameWorld.ofset_x + 32 * 5 - 1;
                                pos_y = 1080 / 2 - (32 * 5) / 2 - GameWorld.ofset_y + 32 * 5;
                                break;
                        }
                        if (Terrain.Which(pos_x, pos_y, Terrain.Loaded_Chunk_differ(0)) > amount_of_air_tiles)
                        {
                            mining_updater(pos_x, pos_y, deltatime, 3);
                            break_Sound(deltatime);
                            return true;
                        }
                    }
                    #endregion
                    break;
            }

            return false;
        }
        /// <summary>
        /// Checks if the ground beneth is air, basically the same as player collis
        /// </summary>
        /// <returns></returns>
        public static bool player_collis_gravity()
        {
            float pos_x = 0;
            float pos_y = 0;
            // 0 + amount;
            int amount_of_air_tiles = 1;
            for (int p = 0; p < 2; p++)
            {
                switch (p)
                {
                    case 0:
                        pos_x = 1920 / 2 - (32 * 5) / 2 - GameWorld.ofset_x + 3;
                        pos_y = 1080 / 2 - (32 * 5) / 2 - GameWorld.ofset_y + 32 * 5;
                        break;
                    case 1:
                        pos_x = 1920 / 2 - (32 * 5) / 2 - GameWorld.ofset_x + 32 * 5 - 3;
                        pos_y = 1080 / 2 - (32 * 5) / 2 - GameWorld.ofset_y + 32 * 5;
                        break;
                }
                if (Terrain.Which(pos_x, pos_y, Terrain.Loaded_Chunk_differ(0)) > amount_of_air_tiles)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// checks if player is on the top part of world
        /// </summary>
        /// <returns></returns>
        public static bool is_we_on_top()
        {
            if (loaded_chunks[0][1] > -1)
            {
                if (Which(1920 / 2 - (32 * 5) / 2, 1080 / 2 - (32 * 5) / 2 - GameWorld.ofset_y, loaded_chunks[0]) == 0)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Plays a breaking sound of terrain, gets deltatime to make sure the sound isn't spammed.
        /// It has a switch to ensure that different sounds play, otherwise it would get irritating.
        /// </summary>
        /// <param name="deltatime"></param>
        private static void break_Sound(float deltatime)
        {
            sound_timer += deltatime;
            if (sound_timer > 700)
            {
                #region rnd switch
                Random rnd = new Random();
                switch (rnd.Next(4) + 1)
                {
                    case 1:
                        stonebreak_1.Play();
                        break;
                    case 2:
                        stonebreak_2.Play();
                        break;
                    case 3:
                        stonebreak_3.Play();
                        break;
                    case 4:
                        stonebreak_4.Play();
                        break;
                }
                #endregion
                sound_timer -= 500;
            }
        }
        #endregion
        #region chunks
        #region new chunks
        #region deciding
        /// <summary>
        /// checks if there should be new chunks around the player that should be made.
        /// </summary>
        /// <param name="x_off"> player x off set</param>
        /// <param name="y_off"> player y off set </param>
        public static void Load_chunks(int x_off, int y_off)
        {
            int[] direction = new int[2];
            //direction switch, choses direction based on offset.
            switch (x_off)
            {
                case int k when k > 0 + loaded_chunks[0][0] * 1920*5:
                    direction[0] = -1;
                    break;
                case int k when k < -(1920*5 - 1920/2 - 32 * 4.34375) - loaded_chunks[0][0] * 1920*5:
                    direction[0] = 1;
                    break;
                default:
                    direction[0] = 0;
                    break;
            }
            switch (y_off)
            {
                case int k when k > 0 + loaded_chunks[0][1] * 1080 * 5:
                    direction[1] = 1;
                    break;
                case int k when k < -(1080 * 5 - 1080 / 2 - 32 * 4.34375) - loaded_chunks[0][1] * (1080*5):
                    direction[1] = -1;
                    break;
                default:
                    direction[1] = 0;
                    break;
            }
            bool new_terrain = true;
            for (int i = loaded_chunks.Count - 1; i >= 0; i--)
            {
                if (direction[0] + loaded_chunks[0][0] == loaded_chunks[i][0]
                 && direction[1] + loaded_chunks[0][1] == loaded_chunks[i][1])
                {
                    new_terrain = false;
                }
            }
            if (new_terrain)
            {
                sorter_new(direction);
            }
        }
        /// <summary>
        /// checks if there should be a change in the chunks player stand on.
        /// </summary>
        /// <param name="x_1"> player x off set</param>
        /// <param name="y_1"> player y off set </param>
        public static void Move_Main_chunk(int x_1, int y_1)
        {
            int _width = 9600;
            int _height = 5400;
            // make a adding for strait and not strait, this can not add 2 chunks
            int[] direction = new int[2];
            if (x_1 < -(_width - (1920 / 2 - (32 * 5) / 2)) - loaded_chunks[0][0] * _width)
            {
                direction[0] = 1;
                direction[1] = 0;
                // change new main chunk
            }
            if (x_1 - (1920 / 2 - (32 * 5) / 2) + loaded_chunks[0][0] * _width > 0)
            {
                direction[0] = -1;
                direction[1] = 0;
                // change new main chunk
            }
            if (y_1 > _height - (1080 / 2 - (32 * 5) / 2) + loaded_chunks[0][1] * _height)
            {
                direction[0] = 0;
                direction[1] = 1;
                // change new main chunk
            }
            if (y_1 < -(_height - (1080 / 2 - (32 * 5) / 2)) + loaded_chunks[0][1] * _height)
            {
                direction[0] = 0;
                direction[1] = -1;
                // change new main chunk
            }
            if (direction[0] != 0 || direction[1] != 0)
            {
                sort_chunk_moving(direction, x_1, y_1);
            }
        }
        #endregion
        #region sorting
        /// <summary>
        /// loads in the array of a new or old chunk, 
        /// if theres a file of it, it will read that file (using the read funktion), 
        /// and get the array that way, else it will make a new chunk (with maker funktion), 
        /// that chunk will then be written as a new file.
        /// </summary>
        /// <param name="pos"> position of the chunk, x and y.</param>
        /// <param name="tile"> where the array should be set to.</param>
        private static void Get_tiles(int[] pos, int tile)
        {
            int[] tiles = new int[width * height];
            if (chunk_check_file(pos))
            {
                tiles = Chunk_Read(pos);
            }
            else
            {
                tiles = Chunk_maker(pos);
            }
            switch (tile)
            {
                case 1:
                    tiles_t_c1 = tiles;
                    break;
                case 2:
                    tiles_t_c2 = tiles;
                    break;
                case 3:
                    tiles_t_c3 = tiles;
                    break;
                case 4:
                    tiles_t_c4 = tiles;
                    break;
            }
        }
        /// <summary>
        /// I gave up on sorting a list, and now we are using switch to find the location chosen, 
        /// and then setting values based ont that position.
        /// the system is set to 9 values, set up like this.
        ///   0  1  2
        ///   3  4  5
        ///   6  7  8
        /// 4 can be forgotten, the middle is always the chunk player is in, 
        /// and all other chunks are in a order based on their value of above model.
        /// used that system as well the i tried sorting a list, 
        /// thought that this way would make it easier later to get the array of other chunks that arent main chunk later.
        /// </summary>
        /// <param name="new_one">the new position to be set to</param>
        public static void sorter_new(int[] new_one)
        {
            switch (new_one)
            {
                case int[] n when n[0] != 0 && n[1] != 0:
                    switch (new_one)
                    {
                        case int[] k when k[0] == -1 && k[1] == 1:
                            #region 1
                            if (switch_off != 1)
                            {
                                for (int i = loaded_chunks.Count - 1; i > 0; i--)
                                {
                                    loaded_chunks.RemoveAt(i);
                                }
                                int[] adds = new int[2];
                                adds[0] = loaded_chunks[0][0] + -1;
                                adds[1] = loaded_chunks[0][1] + 1;
                                loaded_chunks.Add(adds);
                                Get_tiles(adds, 2);

                                int[] adds_2 = new int[2];
                                adds_2[0] = loaded_chunks[0][0] + 0;
                                adds_2[1] = loaded_chunks[0][1] + 1;
                                loaded_chunks.Add(adds_2);
                                Get_tiles(adds_2, 3);

                                int[] adds_3 = new int[2];
                                adds_3[0] = loaded_chunks[0][0] + -1;
                                adds_3[1] = loaded_chunks[0][1] + 0;
                                loaded_chunks.Add(adds_3);
                                Get_tiles(adds_3, 4);
                                switch_off = 1;
                            }
                            #endregion
                            break;
                        case int[] k when k[0] == 1 && k[1] == 1:
                            #region 3
                            if (switch_off != 3)
                            {
                                for (int i = loaded_chunks.Count - 1; i > 0; i--)
                                {
                                    loaded_chunks.RemoveAt(i);
                                }
                                int[] adds = new int[2];
                                adds[0] = loaded_chunks[0][0] + 1;
                                adds[1] = loaded_chunks[0][1] + 1;
                                loaded_chunks.Add(adds);
                                Get_tiles(adds, 2);

                                int[] adds_2 = new int[2];
                                adds_2[0] = loaded_chunks[0][0] + 0;
                                adds_2[1] = loaded_chunks[0][1] + 1;
                                loaded_chunks.Add(adds_2);
                                Get_tiles(adds_2, 3);

                                int[] adds_3 = new int[2];
                                adds_3[0] = loaded_chunks[0][0] + 1;
                                adds_3[1] = loaded_chunks[0][1] + 0;
                                loaded_chunks.Add(adds_3);
                                Get_tiles(adds_3, 4);
                                switch_off = 3;
                            }
                            #endregion
                            break;
                        case int[] k when k[0] == -1 && k[1] == -1:
                            #region 6
                            if (switch_off != 6)
                            {
                                for (int i = loaded_chunks.Count - 1; i > 0; i--)
                                {
                                    loaded_chunks.RemoveAt(i);
                                }
                                int[] adds = new int[2];
                                adds[0] = loaded_chunks[0][0] + -1;
                                adds[1] = loaded_chunks[0][1] + -1;
                                loaded_chunks.Add(adds);
                                Get_tiles(adds, 2);

                                int[] adds_2 = new int[2];
                                adds_2[0] = loaded_chunks[0][0] + -1;
                                adds_2[1] = loaded_chunks[0][1] + 0;
                                loaded_chunks.Add(adds_2);
                                Get_tiles(adds_2, 3);

                                int[] adds_3 = new int[2];
                                adds_3[0] = loaded_chunks[0][0] + 0;
                                adds_3[1] = loaded_chunks[0][1] + -1;
                                loaded_chunks.Add(adds_3);
                                Get_tiles(adds_3, 4);
                                switch_off = 6;
                            }
                            #endregion
                            break;
                        case int[] k when k[0] == 1 && k[1] == -1:
                            #region 9
                            if (switch_off != 9)
                            {
                                for (int i = loaded_chunks.Count - 1; i > 0; i--)
                                {
                                    loaded_chunks.RemoveAt(i);
                                }

                                int[] adds = new int[2];
                                adds[0] = loaded_chunks[0][0] + 1;
                                adds[1] = loaded_chunks[0][1] + -1;
                                loaded_chunks.Add(adds);
                                Get_tiles(adds, 2);

                                int[] adds_2 = new int[2];
                                adds_2[0] = loaded_chunks[0][0] + 1;
                                adds_2[1] = loaded_chunks[0][1] + 0;
                                loaded_chunks.Add(adds_2);
                                Get_tiles(adds_2, 3);

                                int[] adds_3 = new int[2];
                                adds_3[0] = loaded_chunks[0][0] + 0;
                                adds_3[1] = loaded_chunks[0][1] + -1;
                                loaded_chunks.Add(adds_3);
                                Get_tiles(adds_3, 4);

                                switch_off = 9;
                            }
                            #endregion
                            break;
                    }
                    break;
                case int[] n when n[0] == 1 && n[1] == 0:
                    #region 5
                    if (switch_off != 5)
                    {
                        for (int i = loaded_chunks.Count - 1; i > 0; i--)
                        {
                            loaded_chunks.RemoveAt(i);
                        }
                        new_one[0] += loaded_chunks[0][0];
                        new_one[1] += loaded_chunks[0][1];
                        loaded_chunks.Add(new_one);
                        Get_tiles(new_one, 2);
                        tiles_t_c3 = tiles_empty;
                        tiles_t_c4 = tiles_empty;
                        switch_off = 5;
                    }
                    #endregion
                    break;
                case int[] n when n[0] == -1 && n[1] == 0:
                    #region 4
                    if (switch_off != 4)
                    {
                        for (int i = loaded_chunks.Count - 1; i > 0; i--)
                        {
                            loaded_chunks.RemoveAt(i);
                        }
                        new_one[0] += loaded_chunks[0][0];
                        new_one[1] += loaded_chunks[0][1];
                        loaded_chunks.Add(new_one);
                        Get_tiles(new_one, 2);
                        tiles_t_c3 = tiles_empty;
                        tiles_t_c4 = tiles_empty;
                        switch_off = 4;
                    }
                    #endregion
                    break;
                case int[] n when n[0] == 0 && n[1] == 1:
                    #region 2
                    if (switch_off != 2)
                    {
                        for (int i = loaded_chunks.Count - 1; i > 0; i--)
                        {
                            loaded_chunks.RemoveAt(i);
                        }
                        new_one[0] += loaded_chunks[0][0];
                        new_one[1] += loaded_chunks[0][1];
                        loaded_chunks.Add(new_one);
                        Get_tiles(new_one, 2);
                        tiles_t_c3 = tiles_empty;
                        tiles_t_c4 = tiles_empty;
                        switch_off = 2;
                    }
                    #endregion
                    break;
                case int[] n when n[0] == 0 && n[1] == -1:
                    #region 8
                    if (switch_off != 8)
                    {
                        for (int i = loaded_chunks.Count - 1; i > 0; i--)
                        {
                            loaded_chunks.RemoveAt(i);
                        }
                        new_one[0] += loaded_chunks[0][0];
                        new_one[1] += loaded_chunks[0][1];
                        loaded_chunks.Add(new_one);
                        Get_tiles(new_one, 2);
                        tiles_t_c3 = tiles_empty;
                        tiles_t_c4 = tiles_empty;
                        switch_off = 8;
                    }
                    #endregion
                    break;
            }
        }
        /// <summary>
        /// changes the main chunk to the direction given direction, then calls sorter_new to get the rest made.
        /// </summary>
        /// <param name="new_one"> direction given</param>
        /// <param name="x_1"> to call load_chunks</param>
        /// <param name="y_1"> to call load_chunks</param>
        private static void sort_chunk_moving(int[] new_one, int x_1, int y_1)
        {
            switch (new_one)
            {
                case int[] n when n[0] == 1 && n[1] == 0:
                    #region right
                    new_one[0] += loaded_chunks[0][0];
                    new_one[1] += loaded_chunks[0][1];
                    for (int i = loaded_chunks.Count; i > 0; i--)
                    {
                        loaded_chunks.RemoveAt(i - 1);
                    }
                    loaded_chunks.Add(new_one);
                    Get_tiles(new_one, 0);
                    Load_chunks(x_1, y_1);
                    #endregion
                    break;
                case int[] n when n[0] == -1 && n[1] == 0:
                    #region left
                    new_one[0] += loaded_chunks[0][0];
                    new_one[1] += loaded_chunks[0][1];
                    for (int i = loaded_chunks.Count; i > 0; i--)
                    {
                        loaded_chunks.RemoveAt(i - 1);
                    }
                    loaded_chunks.Add(new_one);
                    Get_tiles(new_one, 0);
                    Load_chunks(x_1, y_1);
                    #endregion
                    break;
                case int[] n when n[0] == 0 && n[1] == 1:
                    #region up
                    new_one[0] += loaded_chunks[0][0];
                    new_one[1] += loaded_chunks[0][1];
                    for (int i = loaded_chunks.Count; i > 0; i--)
                    {
                        loaded_chunks.RemoveAt(i - 1);
                    }
                    loaded_chunks.Add(new_one);
                    Get_tiles(new_one, 0);
                    Load_chunks(x_1, y_1);
                    #endregion
                    break;
                case int[] n when n[0] == 0 && n[1] == -1:
                    #region down
                    new_one[0] += loaded_chunks[0][0];
                    new_one[1] += loaded_chunks[0][1];
                    for (int i = loaded_chunks.Count; i > 0; i--)
                    {
                        loaded_chunks.RemoveAt(i - 1);
                    }
                    loaded_chunks.Add(new_one);
                    Get_tiles(new_one, 0);
                    Load_chunks(x_1, y_1);
                    #endregion
                    break;
            }
        }
        #endregion
        #region Making chunks
        /// <summary>
        /// A funktion that needs to be called at the start of the game.
        /// It will create a new chunk to start on.
        /// </summary>
        /// <param name="direction"></param>
        public static void Start_Chunk(int[] direction)
        {
            // remove all files here
            tiles_t_c1 = Chunk_maker(direction);
            loaded_chunks.Add(direction);
        }
        /// <summary>
        /// The making of chunks, it will make an array of the terrain tiles, and then send it to chunk writer, then return the array.
        /// </summary>
        /// <param name="direction"> The position of the chunk</param>
        /// <returns></returns>
        static int[] Chunk_maker(int[] direction)
        {
            int[] tiles_t = new int[width * height];
            int[] pos = new int[2];

            pos[0] = direction[0];
            pos[1] = direction[1];
            // add to list, make function to sort
            for (int i = 0; i < width * height; i++)
            {
                // function/method to see if the given x and y coordinates have a predetermined value for the terrain
                z_1 = chunk_terrain(pos, i);
                tiles_t[i] = z_1;
            }

            chunk_writer(tiles_t, pos);
            return tiles_t;
        }
        /// <summary>
        /// Decides which terrain gets placed on the given tile.
        /// This funktion will return the terrain type to give the index.
        /// Most of this funktion will then be switches and ifs as this funktion is made to decide the terrain, 
        /// and could just not be here as there will only be 1 reference, 
        /// but this funktion will get confusing and clustered the more we add to the game, so thats why.
        /// </summary>
        /// <param name="xy"> chunk location</param>
        /// <param name="i"> the index of the array</param>
        /// <returns></returns>
        static int chunk_terrain(int[] xy, int i)
        {
            if (xy[0] == 0 && xy[1] == 0)
            {
                if (i > 127)
                {
                    if (i > 319)
                    {
                        if (i > 448)
                        {
                            #region layer 3
                            int returns = (randoms(10) + 2);
                            if (returns == 10 || returns == 11 || returns == 12 || returns == 9 || returns == 8 || returns == 7 || returns == 6 || returns == 5)
                            {
                                returns = randoms(10) + 3;
                                if (returns < 10)
                                {
                                    returns = 4;
                                }
                                else
                                {
                                    returns = 3;
                                }
                            }
                            if (returns == 4)
                            {
                                if (randoms(4) == 0)
                                {
                                    returns = randoms(3) + 6;
                                }
                            }
                            if (returns == 3)
                            {
                                if (randoms(7) == 0)
                                {
                                    returns = 5;
                                }
                            }
                            return returns;
                            #endregion
                        }
                        else
                        {
                            #region layer 2
                            int returns = (randoms(10) + 2);
                            if (returns == 10 || returns == 11 || returns == 12 || returns == 9 || returns == 8 || returns == 7 || returns == 6 || returns == 5)
                            {
                                returns = randoms(2) + 3;
                            }
                            if (returns == 3)
                            {
                                if (randoms(7) == 0)
                                {
                                    returns = 5;
                                }
                            }
                            if (returns == 4)
                            {
                                if (randoms(7) == 0)
                                {
                                    returns = 6;
                                }
                            }
                            return returns;
                            #endregion
                        }
                    }
                    else
                    {
                        #region layer 1
                        int returns = (randoms(3) + 2);
                        if (returns == 3)
                        {
                            if (randoms(5) == 0)
                            {
                                returns = 5;
                            }
                        }
                        if (returns == 4)
                        {
                            if (randoms(5) == 0)
                            {
                                returns = 6;
                            }
                        }
                        return returns;
                        #endregion
                    }
                }
                return 0;
            }
            switch (xy[1])
            {
                case int n when n < 3 && n > -1:
                    return 1;
            }
            return 0;
        }
        private static int randoms(int threshold)
        {
            Random rnd = new Random();
            int num = rnd.Next(threshold);
            switch (num)
            {
                case 0:
                    return 0;
                case 1:
                    return 1;
                case 2:
                    return 2;

            }
            return num;
        }
        #endregion
        #region write chunks
        /// <summary>
        /// Writing chunks, making a text file and writes down the int array int the file, it splits each index with a comma,
        /// So then we read the file later we can see the split in each index. 
        /// </summary>
        /// <param name="t"> The array to write</param>
        /// <param name="direction"> The location of the chunk, will be name of file</param>
        private static void chunk_writer(int[] t, int[] direction)
        {
            string filename = direction[0].ToString() + " " + direction[1].ToString() + ".txt";
            if (File.Exists(@"Chunks\" + filename))
            {
                File.Delete(@"Chunks\" + filename);
            }
            //File.CreateText(@"Chunks\" + filename); Used this earlier to create files,
            //makes the files it creates protected though, and i don't need protected files.
            string write = "";
            // loop to make the hole array to an string, adds each index to the string.
            for (int i = 0; i < t.Length; i++)
            {
                write += t[i].ToString();
                write += ",";
                if (i == 200 || i == 400)
                {
                    write += "\n";
                }
            }
            // writes it.
            using (StreamWriter tw = new StreamWriter(@"Chunks\" + filename, true))
            {
                tw.WriteLine(write);
                tw.Close();
            }
        }
        #endregion
        #endregion
        #region Reading chunks
        /// <summary>
        /// checks if file exits
        /// </summary>
        /// <param name="Position"> the location of the chunk, in this case the name aswell.</param>
        /// <returns></returns>
        static bool chunk_check_file(int[] Position)
        {
            int[] filename = new int[2];
            string negative0 = "";
            string negative1 = "";
            if (Position[0] < 0)
            {
                filename[0] = Position[0] * (-1);
                negative0 = "-";
            }
            else
            {
                filename[0] = Position[0];
            }
            if (Position[1] < 0)
            {
                filename[1] = Position[1] * (-1);
                negative1 = "-";
            }
            else
            {
                filename[1] = Position[1];
            }
            if (File.Exists(@"Chunks\" + negative0 + filename[0].ToString() + " " + negative1 + filename[1].ToString() + ".txt"))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// takes the file and read all in it as a string, then it will use a for loop to go through the string.
        /// in the for loop it will add to curren_text with the numbers, and then it reaches a comma, 
        /// it will add curent_text to the int array converted to an int, 
        /// this way it will get each index of the array and numbers such as 10 and above that would fill up 2 or more chars can still be read.
        /// when done it returns the array.
        /// </summary>
        /// <param name="direction"> location of chunk, in this case also the file name. </param>
        /// <returns></returns>
        private static int[] Chunk_Read(int[] direction)
        {
            string comma = ",";
            string current_text = "";
            int[] tiles = new int[width * height];
            int current_int = 0;
            using (StreamReader sr = new StreamReader(@"Chunks\" + direction[0].ToString() + " " + direction[1].ToString() + ".txt"))
            {
                string text = sr.ReadToEnd();
                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i] != comma[0])
                    {
                        current_text += text[i];
                    }
                    else
                    {
                        tiles[current_int] = Int32.Parse(current_text);
                        current_int += 1;
                        current_text = "";
                    }
                }
            }

            return tiles;
        }
        // returns amount of chunks loaded
        public static int Chunk_differ()
        {
            return loaded_chunks.Count;
        }
        // returns the array of a chunk from the loaded_chunks list, by using given index.
        public static int[] Loaded_Chunk_differ(int i)
        {
            return loaded_chunks[i];
        }
        // gets the x and y coordinates to add then drawing in gameWorld, as the entire terrain fills 1024 * 5 and 576 * 5.
        public static int[] direction(int[] loaded_one)
        {
            int[] direction = new int[2];
            switch (loaded_one[0])
            {
                case int n when n < loaded_chunks[0][0]:
                    direction[0] = -9600;
                    break;
                case int n when n > loaded_chunks[0][0]:
                    direction[0] = 9600;
                    break;
                default:
                    direction[0] = 0;
                    break;
            }
            switch (loaded_one[1])
            {
                case int k when k < loaded_chunks[0][1]:
                    direction[1] = 5400;
                    break;
                case int k when k > loaded_chunks[0][1]:
                    direction[1] = -5400;
                    break;
                default:
                    direction[1] = 0;
                    break;
            }
            return direction;
        }
        #endregion
        #endregion
        #region getinfo
        /// <summary>
        /// method to change a tile, takes the x,y coord and the tile wanted to change into.
        /// it will then check if the tile is within the amount of tiles useable, if yes,
        /// it will find where in the array its changing the value, and then change it.
        /// </summary>
        /// <param name="x"> x coordinate </param>
        /// <param name="y"> y coordinate </param>
        /// <param name="z"> the value tile wanted to be changed to </param>
        public static void Change(float x, float y, int z, int[] chunk)
        {
            // x modification
            int x_mod = 0;

            // scaling the input into usable data
            //float y_1 = (((y / scale) - ((y / scale) % 32f)) / 32f);
            //float x_1 = (((x / scale) - ((x / scale) % 32f)) / 32f);
            float y_1 = (((y / 5) - ((y / 5) % 32f)) / 32f);
            float x_1 = (((x / 5) - ((x / 5) % 32f)) / 32f);
            // checks the y array for the location.
            for (int i = 0; i < height; i++)
            {
                if (tiles_y[i * width] == y_1)
                {
                    x_mod = i;
                }
            }
            // checks the x array for location
            for (int i = 0; i < width; i++)
            {
                if (tiles_x[(x_mod * width) + i] == x_1)
                {
                    for (int k = 0; k < loaded_chunks.Count; k++)
                    {
                        if (loaded_chunks[k][0] == chunk[0] && loaded_chunks[k][1] == chunk[1])
                        {
                            // we have x and y, now we know how far down the array we gotta go for the terrain, then we change it.
                            // the switch here is for which terrain array gotta get changed and rewritten.
                            switch (k)
                            {
                                case 0:
                                    tiles_t_c1[(x_mod * width) + i] = z;
                                    chunk_writer(tiles_t_c1, chunk);
                                    break;
                                case 1:
                                    tiles_t_c2[(x_mod * width) + i] = z;
                                    chunk_writer(tiles_t_c2, chunk);
                                    break;
                                case 2:
                                    tiles_t_c3[(x_mod * width) + i] = z;
                                    chunk_writer(tiles_t_c3, chunk);
                                    break;
                                case 3:
                                    tiles_t_c4[(x_mod * width) + i] = z;
                                    chunk_writer(tiles_t_c4, chunk);
                                    break;
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// a method to see which terrain a given input is. 
        /// </summary>
        /// <param name="x"> x coord </param>
        /// <param name="y"> y coord </param>
        /// <returns></returns>
        public static int Which(float x, float y, int[] chunk)
        {
            // Makes input applicable for sprite size.
            //float y_1 = (((y / scale) - ((y / scale) % 32f)) / 32f);
            //float x_1 = (((x / scale) - ((x / scale) % 32f)) / 32f);
            float y_1 = (((y / 5) - ((y / 5) % 32f)) / 32f);
            float x_1 = (((x / 5) - ((x / 5) % 32f)) / 32f);
            // xmod * width is basically the location of our y pos in y array
            int x_mod = 0;
            // locate location of y pos in y array
            for (int i = 0; i < height; i++)
            {
                if (tiles_y[i * width + 1] == y_1)
                {
                    x_mod = i;
                }
            }
            // locates x pos in x array, but its increases by y array possion amount.
            for (int i = 0; i < width; i++)
            {
                if (tiles_x[(x_mod * width) + i] == x_1)
                {
                    for (int k = 0; k < loaded_chunks.Count; k++)
                    {
                        if (loaded_chunks[k][0] == chunk[0] && loaded_chunks[k][1] == chunk[1])
                        {
                            // found the location of the value of terrain in terrain array
                            // the switch here is for which terrain array gotta get the terrain type from.
                            switch (k)
                            {
                                case 0:
                                    return tiles_t_c1[(x_mod * width) + i];
                                case 1:
                                    return tiles_t_c2[(x_mod * width) + i];
                                case 2:
                                    return tiles_t_c3[(x_mod * width) + i];
                                case 3:
                                    return tiles_t_c4[(x_mod * width) + i];
                            }
                        }
                    }
                }
            }
            return 0;
        }
        #endregion
        #region mining
        /// <summary>
        /// Mining updater takes a given location, change it into an index of an array, 
        /// and use this index to find the amount we have mined on that block, if we have mined enough on that block then it will break.
        /// </summary>
        /// <param name="x"> x coordinate</param>
        /// <param name="y"> y coordinate</param>
        /// <param name="deltatime"> deltatime to add to the amount mined</param>
        /// <param name="direction"> which chunk</param>
        public static void mining_updater(float x, float y, float deltatime, int direction)
        {
            int x_mod = 0;

            //x = x * (-1);
            //y = y * (-1);
            float y_1 = (((y) / 5) - ((y) / 5) % 32f) / 32f;
            float x_1 = (((x) / 5) - ((x) / 5) % 32f) / 32f;

            // checks the y array for the location.
            for (int i = 0; i < height; i++)
            {
                if (tiles_y[i * width] == y_1)
                {
                    x_mod = i;
                }
            }
            // checks the x array for location
            for (int i = 0; i < width; i++)
            {
                if (tiles_x[(x_mod * width) + i] == x_1)
                {
                    switch (tiles_t_c1[(x_mod * width) + i])
                    {
                        #region changing the terrain
                        case 2:
                            if (tiles_mined[(x_mod * width) + i] > 700)
                            {
                                stonebreakfinish.Play();
                                Terrain.Change(x, y, 1, loaded_chunks[0]);
                            }
                            else
                            {
                                mining_on_tile((x_mod * width) + i, deltatime);
                            }
                            break;
                        case int n when n == 3 || n == 5:
                            if (tiles_mined[(x_mod * width) + i] > 1300)
                            {
                                if (Terrain.Which(x, y, loaded_chunks[0]) == 5)
                                {
                                    WorkShop.R1Cop++;
                                }
                                stonebreakfinish.Play();
                                Terrain.Change(x, y, 1, loaded_chunks[0]);
                            }
                            else
                            {
                                mining_on_tile((x_mod * width) + i, deltatime);
                            }
                            break;
                        case int n when n == 4 || n == 6:
                            if (tiles_mined[(x_mod * width) + i] > 1800)
                            {
                                if (Terrain.Which(x, y, loaded_chunks[0]) == 6)
                                {
                                    WorkShop.R3Tit++;
                                }
                                stonebreakfinish.Play();
                                Terrain.Change(x, y, 1, loaded_chunks[0]);
                            }
                            else
                            {
                                mining_on_tile((x_mod * width) + i, deltatime);
                            }
                            break;
                        case int n when n == 7 || n == 8:
                            if (tiles_mined[(x_mod * width) + i] > 3000)
                            {
                                if (Terrain.Which(x, y, loaded_chunks[0]) == 8)
                                {
                                    WorkShop.R4Plat++;
                                }
                                if (Terrain.Which(x, y, loaded_chunks[0]) == 7)
                                {
                                    WorkShop.R5Uran++;
                                }
                                stonebreakfinish.Play();
                                Terrain.Change(x, y, 1, loaded_chunks[0]);
                            }
                            else
                            {
                                mining_on_tile((x_mod * width) + i, deltatime); 
                            }
                            break;
                            #endregion
                    }

                }
            }
        }
        private static void mining_on_tile(int i, float deltatime)
        {
            if (WorkShop.Upgraded[0])
            {
                if (WorkShop.Upgraded[1])
                {
                    if (WorkShop.Upgraded[2])
                    {
                        if (WorkShop.Upgraded[3])
                        {
                            tiles_mined[i] += deltatime * 5;
                        }
                        else
                        {
                            tiles_mined[i] += deltatime * 4;
                        }
                    }
                    else
                    {
                        tiles_mined[i] += deltatime * 3;
                    }
                }
                else
                {
                    tiles_mined[i] += deltatime * 2;
                }
            }
            else
            {
                tiles_mined[i] += deltatime;
            }
        }
        #endregion
    }
}
