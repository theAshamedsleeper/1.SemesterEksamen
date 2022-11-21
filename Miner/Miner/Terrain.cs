using System;
using System.Collections;
using System.Collections.Generic;
using System.DirectoryServices;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

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
        private static int[] current_chunk = new int[width * height];
        private static List<int[]> loaded_chunks = new List<int[]>();   
        public static float t_scale { get { return scale; } }
        #region terrain making
        /// <summary>
        /// a method to give value to 3 arrays, so we can more easily allocate which is dirt grass or hoed dirt.
        /// it will give the x and y values, and check if those coordinates are dirt or grass.
        /// it has 3 arrays one for x, y and terrain type, the terrain type is chosen with a number.
        /// this way we will be able to pin point a location, 
        /// we believe this will be more effective than an object for each tile.
        /// </summary>
        public static void Give_Terrain()
        {
            for (int i_2 = 0; i_2 < width * height; i_2++)
            {
                // function/method to see if the given x and y coordinates have a predetermined value for the terrain
                z_1 = start_terrain(x_1, y_1);
                // giving the values to the arrays
                tiles_x[i_2] = x_1;
                tiles_y[i_2] = y_1;
                tiles_t_c1[i_2] = z_1;
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
            int[] gow = new int[2];
            gow[0] = 0;
            gow[1] = 0;
            chunks.Add(gow);
        }
        // our start terrain method,
        // it will say which coordinates should return dirt or grass,
        // with what we wish the starting land should look like
        static int start_terrain(int x_1, int y_1)
        {
            switch (x_1)
            {
                case 17:
                    return 2;
                case 0:
                    return 2;
            }
            switch (x_1)
            {
                case 0:
                    return 2;
                case 31:
                    return 2;
            }
            return 0;
        }

        #endregion
        #region chunks
        #region new chunks
        public static void Load_chunks(int x_1, int y_1)
        {
            int[] direction = new int[2];
            if (x_1 > 0)
            {
                direction[0] = 1;
                direction[1] = 0;
                // change new main chunk
            }
            if (x_1 < 0)
            {
                direction[0] = -1;
                direction[1] = 0;
                // change new main chunk
            }
            if (y_1 > 0)
            {
                direction[0] = 0;
                direction[1] = 1;
                // change new main chunk
            }
            if (y_1 < 0)
            {
                direction[0] = 0;
                direction[1] = -1;
                // change new main chunk
            }
            if (direction[0] != 0 || direction[1] != 0)
            {
                if (chunk_check(direction))
                {
                    Chunk_Read(direction);
                }
                else
                {
                    Chunk_maker(direction);
                }
            }
        }
        public static void Move_Main_chunk(int x_1, int y_1, int _width, int _height)
        {
            // make a adding for strait and not strait, this can not add 2 chunks
            int[] direction = new int[2];
            if (x_1 > _width)
            {
                direction[0] = 1;
                direction[1] = 0;
                // change new main chunk
            }
            if (x_1 < -_width)
            {
                direction[0] = -1;
                direction[1] = 0;
                // change new main chunk
            }
            if (y_1 > _height)
            {
                direction[0] = 0;
                direction[1] = 1;
                // change new main chunk
            }
            if (y_1 < -_height)
            {
                direction[0] = 0;
                direction[1] = -1;
                // change new main chunk
            }
            if (direction[0] != 0 || direction[1] != 0)
            {
                if (chunk_check(direction))
                {

                }
            }
        }
        private static void sort_chunk_adding(int[] new_one)
        {
            if (loaded_chunks.Count == 0)
            {
                loaded_chunks.Add(new_one);
            }
            else
            {
                int[] main = new int[2];
                main = loaded_chunks[0];
                int amount_removed = 0;
                int[] position = new int[loaded_chunks.Count];
                List<int[]> amount_add = new List<int[]>(); 
                if (loaded_chunks.Count > 0)
                {
                    amount_add.Add(loaded_chunks[1]);
                    if (loaded_chunks.Count > 2)
                    {
                        amount_add.Add(loaded_chunks[2]);
                        if (loaded_chunks.Count > 3)
                        {
                            amount_add.Add(loaded_chunks[3]);

                        }
                    }
                }
                // pos
                for (int i = 0; i < loaded_chunks.Count; i++)
                {
                    int[] order_checker = new int[2];
                    switch (i)
                    {
                        case 0:
                            order_checker = new_one;
                            break;
                        case 1:
                            order_checker = loaded_chunks[1];
                            break;
                        case 2:
                            order_checker = loaded_chunks[2];
                            break;
                        case 3:
                            order_checker = loaded_chunks[3];
                            break;
                    }
                    switch (order_checker[1])
                    {
                        case int n when n < main[1]:
                            switch (order_checker[0])
                            {
                                case int j when j < main[0]:
                                    position[i] = 0;
                                    break;
                                case int j when j == main[0]:
                                    position[i] = 1;
                                    break;
                                case int j when j > main[0]:
                                    position[i] = 2;
                                    break;
                            }
                            break;
                        case int n when n == main[1]:
                            switch (order_checker[0])
                            {
                                case int j when j < main[0]:
                                    position[i] = 3;
                                    break;
                                case int j when j == main[0]:
                                    position[i] = 4;
                                    break;
                                case int j when j > main[0]:
                                    position[i] = 5;
                                    break;
                            }
                            break;
                        case int n when n > main[1]:
                            switch (order_checker[0])
                            {
                                case int j when j < main[0]:
                                    position[i] = 6;
                                    break;
                                case int j when j == main[0]:
                                    position[i] = 7;
                                    break;
                                case int j when j > main[0]:
                                    position[i] = 8;
                                    break;
                            }
                            break;
                    }
                }
                // remove
                for (int i = 0; i < loaded_chunks.Count; i++)
                {
                    loaded_chunks.RemoveAt(i);
                    amount_removed++;
                }
                // add
                int[] position_o = new int[loaded_chunks.Count];
                position_o = position;
                Array.Sort(position_o);
                for (int i_2 = 0; i_2 < amount_removed + 1; i_2++)
                {
                    switch (i_2)
                    {
                        case 0:
                            loaded_chunks.Add(main);
                            break;
                        case 1:
                            switch (position_o[i_2])
                            {
                                case int k when k == position[0]:
                                    loaded_chunks.Add(new_one);
                                    break;
                                case int k when k == position[1]:
                                    loaded_chunks.Add(amount_add[0]);
                                    break;
                                case int k when k == position[2]:
                                    loaded_chunks.Add(amount_add[1]);
                                    break;
                            }
                            break;
                        case 2:
                            switch (position_o[i_2])
                            {
                                case int k when k == position[0]:
                                    loaded_chunks.Add(new_one);
                                    break;
                                case int k when k == position[1]:
                                    loaded_chunks.Add(amount_add[0]);
                                    break;
                                case int k when k == position[2]:
                                    loaded_chunks.Add(amount_add[1]);
                                    break;
                            }
                            break;
                        case 3:
                            switch (position_o[i_2])
                            {
                                case int k when k == position[0]:
                                    loaded_chunks.Add(new_one);
                                    break;
                                case int k when k == position[1]:
                                    loaded_chunks.Add(amount_add[0]);
                                    break;
                                case int k when k == position[2]:
                                    loaded_chunks.Add(amount_add[1]);
                                    break;
                            }
                            break;
                    }
                }
            }
        }
        #region Making chunks
        public static void Start_Chunk(int[] direction, int[] last_chunk)
        {
            loaded_chunks[0] = direction;
            Chunk_maker(direction);
        }
        static void Chunk_maker(int[] direction)
        {
            int[] tiles_t = new int[width * height];
            if (direction[0] != 0 || direction[1] != 0)
            {
                direction[0] += loaded_chunks[0][0];
                direction[1] += loaded_chunks[0][1];
            }
            // add to list, make function to sort
            for (int i = 0; i < width * height; i++)
            {
                // function/method to see if the given x and y coordinates have a predetermined value for the terrain
                z_1 = chunk_terrain(direction, i);
                tiles_t[i] = z_1;
            }
            chunk_writer(tiles_t, direction);
        }
        static int chunk_terrain(int[] xy, int i)
        {
            switch (xy[1])
            {
                case int n when n < 3 && n > -1:
                    return 2;
            }
            return 0;
        }
        #endregion
        #region write chunks
        private static void chunk_writer(int[] t, int[] direction)
        {
            string filename = direction[0].ToString() + " " + direction[1].ToString() + ".txt";
            //File.CreateText(@"Chunks\" + filename);
            string write = "";
            for (int i = 0; i < t.Length; i++)
            {
                write += t[i].ToString();
                write += ",";

            }
            File.WriteAllText(@"Chunks\" + filename, write);
        }
        #endregion
        #endregion
        #region Reading chunks
        static bool chunk_check(int[] filename)
        {
            if (File.Exists(@"@""Miner\Chunks\ " + filename[0].ToString() + "," + filename[1].ToString() + ".txt"))
            {
                return true;
            }
            return false;
        }
        private static int[] Chunk_Read(int[] direction)
        {
            string text = File.ReadAllText(@"Chunks\" + direction[0].ToString() + " " + direction[1].ToString() + ".txt");
            string comma = ",";
            string current_text = "";
            int[] tiles = new int[width * height];
            int current_int = 0;
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
            if (0 <= z && z <= terrain_amount)
            {
                // scaling the input into usable data
                float y_1 = (((y / scale) - ((y / scale) % 32f)) / 32f);
                float x_1 = (((x / scale) - ((x / scale) % 32f)) / 32f);
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
                        for (i = 0; i < loaded_chunks.Count; i++)
                        {
                            if (loaded_chunks[i] == chunk)
                            {
                                // we have x and y, now we know how far down the array we gotta go for the terrain, then we change it.
                                switch (i)
                                {
                                    case 1:
                                        tiles_t_c1[(x_mod * width) + i] = z;
                                        break;
                                    case 2:
                                        tiles_t_c2[(x_mod * width) + i] = z;
                                        break;
                                    case 3:
                                        tiles_t_c3[(x_mod * width) + i] = z;
                                        break;
                                    case 4:
                                        tiles_t_c4[(x_mod * width) + i] = z;
                                        break;
                                }
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
            float y_1 = (((y / scale) - ((y / scale) % 32f)) / 32f);
            float x_1 = (((x / scale) - ((x / scale) % 32f)) / 32f);
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
                    for (i = 0; i < loaded_chunks.Count; i++)
                    {
                        if (loaded_chunks[i] == chunk)
                        {
                            // found the location of the value of terrain in terrain array
                            switch (i)
                            {
                                case 1:
                                    return tiles_t_c1[(x_mod * width) + i];
                                case 2:
                                    return tiles_t_c2[(x_mod * width) + i];
                                case 3:
                                    return tiles_t_c3[(x_mod * width) + i];
                                case 4:
                                    return tiles_t_c4[(x_mod * width) + i];
                            }
                        }
                    }
                }
            }
            return 0;
        }
        #endregion
    }
}
