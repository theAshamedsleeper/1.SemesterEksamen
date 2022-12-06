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
        private static int terrain_amount = 6;
        private static float scale = 1.875f;
        private static List<int[]> chunks = new List<int[]>();
        private static int[] chunk_0 = new int[2];
        private static int[] tiles_x = new int[width * height];
        private static int[] tiles_y = new int[width * height];
        private static int[] tiles_t_c1 = new int[width * height];
        private static int[] tiles_t_c2 = new int[width * height];
        private static int[] tiles_t_c3 = new int[width * height];
        private static int[] tiles_t_c4 = new int[width * height];
        private static int[] tiles_empty = new int[width * height];
        static Random rnd = new Random();
        private static int[] current_chunk = new int[width * height];
        private static List<int[]> loaded_chunks = new List<int[]>();
        private static float[] tiles_mined = new float[width * height];
        private static byte switch_off = 0;
        private static SoundEffect stonebreak_1;
        private static SoundEffect stonebreak_2;
        private static SoundEffect stonebreak_3;
        private static SoundEffect stonebreak_4;
        private static SoundEffect stonebreakfinish;
        private static float sound_timer = 0;
        public static float t_scale { get { return scale; } }
        #region terrain making
        /// <summary>
        /// a method to give value to 3 arrays, so we can more easily allocate which is dirt grass or hoed dirt.
        /// it will give the x and y values, and check if those coordinates are dirt or grass.
        /// it has 3 arrays one for x, y and terrain type, the terrain type is chosen with a number.
        /// this way we will be able to pin point a location, 
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
                                pos_x = 1920 / 2 - (32 * 5) / 2 - GameWorld.ofset_x;
                                pos_y = 1080 / 2 - (32 * 5) / 2 - GameWorld.ofset_y+1;
                                break;
                            case 1:
                                pos_x = 1920 / 2 - (32 * 5) / 2 - GameWorld.ofset_x;
                                pos_y = 1080 / 2 - (32 * 5) / 2 - GameWorld.ofset_y + 32 * 5-1;
                                break;
                        }
                        if (Terrain.Which(pos_x, pos_y, Terrain.Loaded_Chunk_differ(0)) > amount_of_air_tiles)
                        {
                            mining_updater(pos_x, pos_y, deltatime, 0);
                            Walk_Sound(deltatime);
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
                                pos_y = 1080 / 2 - (32 * 5) / 2 - GameWorld.ofset_y+1;
                                break;
                            case 1:
                                pos_x = 1920 / 2 - (32 * 5) / 2 - GameWorld.ofset_x + 32 * 5;
                                pos_y = 1080 / 2 - (32 * 5) / 2 - GameWorld.ofset_y + 32 * 5-1;
                                break;
                        }
                        if (Terrain.Which(pos_x, pos_y, Terrain.Loaded_Chunk_differ(0)) > amount_of_air_tiles)
                        {
                            mining_updater(pos_x, pos_y, deltatime, 1);
                            Walk_Sound(deltatime);
                            return true;
                        }
                    }
                    #endregion
                    break;
                case 2:
                    #region up
                    for (int p = 0; p < 2; p++)
                    {
                        switch (p)
                        {
                            case 0:
                                pos_x = 1920 / 2 - (32 * 5) / 2 - GameWorld.ofset_x;
                                pos_y = 1080 / 2 - (32 * 5) / 2 - GameWorld.ofset_y;
                                break;
                            case 1:
                                pos_x = 1920 / 2 - (32 * 5) / 2 - GameWorld.ofset_x + 32 * 5;
                                pos_y = 1080 / 2 - (32 * 5) / 2 - GameWorld.ofset_y;
                                break;
                        }
                        if (Terrain.Which(pos_x, pos_y, Terrain.Loaded_Chunk_differ(0)) > amount_of_air_tiles)
                        {
                            mining_updater(pos_x, pos_y, deltatime, 2);
                            Walk_Sound(deltatime);
                            return true;
                        }
                    }
                    #endregion
                    break;
                case 3:
                    #region down
                    for (int l = 0; l < 2; l++)
                    {
                        switch (l)
                        {
                            case 0:
                                pos_x = 1920 / 2 - (32 * 5) / 2 - GameWorld.ofset_x;
                                pos_y = 1080 / 2 - (32 * 5) / 2 - GameWorld.ofset_y + 32 * 5;
                                break;
                            case 1:
                                pos_x = 1920 / 2 - (32 * 5) / 2 - GameWorld.ofset_x + 32 * 5;
                                pos_y = 1080 / 2 - (32 * 5) / 2 - GameWorld.ofset_y + 32 * 5;
                                break;
                        }
                        if (Terrain.Which(pos_x, pos_y, Terrain.Loaded_Chunk_differ(0)) > amount_of_air_tiles)
                        {
                            mining_updater(pos_x, pos_y, deltatime, 3);
                            Walk_Sound(deltatime);
                            return true;
                        }
                    }
                    #endregion
                    break;
            }

            return false;
        }
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
                        pos_x = 1920 / 2 - (32 * 5) / 2 - GameWorld.ofset_x - 1;
                        pos_y = 1080 / 2 - (32 * 5) / 2 - GameWorld.ofset_y+ 32 *5;
                        break;
                    case 1:
                        pos_x = 1920 / 2 - (32 * 5) / 2 - GameWorld.ofset_x + 32 * 5 + 1;
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
        public static bool is_we_on_top()
        {
            if (loaded_chunks[0][1] > -1)
            {
                if (Which(1920 / 2 - (32 * 5) / 2, 1080 / 2 - (32 * 5) / 2, loaded_chunks[0]) == 0)
                {
                    return true;
                }
            }
            return false;
        }
        private static void Walk_Sound(float deltatime)
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
        public static void Load_chunks(int x_off, int y_off)
        {
            int[] direction = new int[2];
            //direction switch, choses direction based on offset.
            switch (x_off)
            {
                case int k when k > 0:
                    direction[0] = -1;
                    break;
                case int k when k < 0:
                    direction[0] = 1;
                    break;
                default:
                    direction[0] = 0;
                    break;
            }
            switch (y_off)
            {
                case int k when k > 0:
                    direction[1] = 1;
                    break;
                case int k when k < 0:
                    direction[1] = -1;
                    break;
                default:
                    direction[1] = 0;
                    break;
            }
            sorter_new(direction);
        }
        public static void Move_Main_chunk(int x_1, int y_1)
        {
            int _width = 5120;
            int _height = 2880;
            // make a adding for strait and not strait, this can not add 2 chunks
            int[] direction = new int[2];
            if (x_1 < -(_width - (1920 / 2 - (32 * 5) / 2)) - loaded_chunks[0][0] * 5120)
            {
                direction[0] = 1;
                direction[1] = 0;
                // change new main chunk
            }
            if (x_1 - (1920 / 2 - (32 * 5) / 2) + loaded_chunks[0][0] * 5120 > 0)
            {
                direction[0] = -1;
                direction[1] = 0;
                // change new main chunk
            }
            if (y_1 > _height - (1080 / 2 - (32 * 5) / 2) + loaded_chunks[0][1] * 2880)
            {
                direction[0] = 0;
                direction[1] = 1;
                // change new main chunk
            }
            if (y_1 < -(_height - (1080 / 2 - (32 * 5) / 2)) + loaded_chunks[0][1] * 2880)
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
        public static void Start_Chunk(int[] direction)
        {
            // remove all files here
            tiles_t_c1 = Chunk_maker(direction);
            loaded_chunks.Add(direction);
        }
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
        static int chunk_terrain(int[] xy, int i)
        {
            if (xy[0] == 0 && xy[1] == 0)
            {
                if (i > 127)
                {
                    int returns = (Randomies.randoms(3) + 2);
                    if (returns == 3)
                    {
                        if (Randomies.randoms(5) == 0)
                        {
                            returns = 5;
                        }
                    }
                    if (returns == 4)
                    {
                        if (Randomies.randoms(5) == 0)
                        {
                            returns = 6;
                        }
                    }
                    return returns;
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
        #endregion
        #region write chunks
        private static void chunk_writer(int[] t, int[] direction)
        {
            string filename = direction[0].ToString() + " " + direction[1].ToString() + ".txt";
            if (File.Exists(@"Chunks\" + filename))
            {
                File.Delete(@"Chunks\" + filename);
            }

            //File.CreateText(@"Chunks\" + filename);
            string write = "";
            for (int i = 0; i < t.Length; i++)
            {
                write += t[i].ToString();
                write += ",";
                if (i == 200 || i == 400)
                {
                    write += "\n";
                }

            }
            using (StreamWriter tw = new StreamWriter(@"Chunks\" + filename, true))
            {
                tw.WriteLine(write);
                tw.Close();
            }

        }
        #endregion
        #endregion
        #region Reading chunks
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
        public static int Chunk_differ()
        {
            return loaded_chunks.Count;
        }
        public static int[] Loaded_Chunk_differ(int i)
        {
            return loaded_chunks[i];
        }
        public static int[] direction(int[] loaded_one)
        {
            int[] direction = new int[2];
            switch (loaded_one[0])
            {
                case int n when n < loaded_chunks[0][0]:
                    direction[0] = -5120;
                    break;
                case int n when n > loaded_chunks[0][0]:
                    direction[0] = 5120;
                    break;
                default:
                    direction[0] = 0;
                    break;
            }
            switch (loaded_one[1])
            {
                case int k when k < loaded_chunks[0][1]:
                    direction[1] = 2880;
                    break;
                case int k when k > loaded_chunks[0][1]:
                    direction[1] = -2880;
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
                    switch(tiles_t_c1[(x_mod*width) + i])
                    {
                        case 2:
                            if (tiles_mined[(x_mod * width) + i] > 700)
                            {
                                stonebreakfinish.Play();
                                Terrain.Change(x, y, 1, loaded_chunks[0]);
                            }
                            else
                            {
                                tiles_mined[(x_mod * width) + i] += deltatime;
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
                                tiles_mined[(x_mod * width) + i] += deltatime;
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
                                tiles_mined[(x_mod * width) + i] += deltatime;
                            }
                            break;
                    }
                    
                }
            }
        }
        #endregion
    }
}
