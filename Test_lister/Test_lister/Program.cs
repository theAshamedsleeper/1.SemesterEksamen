using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private static int[] t = new int[width * height];
        private static int[] tiles_empty = new int[width * height];
        private static int[] current_chunk = new int[width * height];
        private static byte switch_off = 0;
        private static List<int[]> loaded_chunks = new List<int[]>();
        public static float t_scale { get { return scale; } }
        #region testing
        static void Main(string[] args)
        {
            //for (int i_2 = 0; i_2 < width * height; i_2++)
            //{
            //    tiles_x[i_2] = x_1;
            //    tiles_y[i_2] = y_1;
            //    if (x_1 == width - 1)
            //    {
            //        x_1 = 0;
            //        y_1 += 1;
            //    }
            //    else
            //    {
            //        x_1 += 1;
            //    }
            //}
            //for (int i = 0; i < tiles_x.Length; i++)
            //{
            //    Console.WriteLine(tiles_x[i].ToString() + " " + tiles_y[i].ToString());
            //}
            string write = "";
            chunk_0[0] = 0;
            chunk_0[1] = -1;
            Console.WriteLine(chunk_0[0].ToString() + " " + chunk_0[1].ToString());

            chunk_0[1] = 0;
            Start_Chunk(chunk_0);
            int x = 1;
            int y = 0;
            for (int k = 0; k < 5; k++)
            {
                Load_chunks(x, y);
                Console.WriteLine(tiles_t_c2[1].ToString());
                for (int i = 0; i < loaded_chunks.Count; i++)
                {
                    write = loaded_chunks[i][0].ToString();
                    write += " " + loaded_chunks[i][1].ToString();
                    Console.WriteLine(write);
                }
                
                Console.WriteLine("Done");
                switch (k)
                {
                    case 0:
                        x += 1000;
                        break;
                    case 1:
                        x -= 2000;
                        break;
                    case 2:
                        y -= 1000;
                        break;
                    case 3:
                        y += 2000;
                        break;
                }
            }
            for (int i = 0; i < width * height; i++)
            {
                Random rnd = new Random();
                int num = rnd.Next(2);
                z_1 = num;
                t[i] = z_1;
            }
            string writes = "";
            for (int i = 0; i < t.Length; i++)
            {
                writes += t[i].ToString();
                writes += ",";

            }
            Console.WriteLine(writes);

        }
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
        public static void sorter_new(int[] new_one)
        {
            switch(new_one)
            {
                case int[] n when n[0] != 0 && n[1] != 0:
                    switch (new_one)
                    {
                        case int[] k when k[0] == -1 && k[1] == 1:
                            #region 0
                            if (switch_off != 0)
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
                                switch_off = 0;
                            }
                            #endregion
                            break;
                        case int[] k when k[0] == 1 && k[1] == 1:
                            #region 2
                            if (switch_off != 2)
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
                                switch_off = 2;
                            }
                            #endregion
                            break;
                        case int[] k when k[0] == -1 && k[1] == -1:
                            #region 5
                            if (switch_off != 5)
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
                                switch_off = 5;
                            }
                            #endregion
                            break;
                        case int[] k when k[0] == 1 && k[1] == -1:
                            #region 8
                            if (switch_off != 8)
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
                                
                                switch_off = 8;
                            }
                            #endregion
                            break;
                    }
                    break;
                case int[] n when n[0] == 1 && n[1] == 0:
                    #region 4
                    if (switch_off != 4)
                    {
                        for (int i = loaded_chunks.Count - 1; i > 0; i--)
                        {
                            loaded_chunks.RemoveAt(i);
                        }
                        loaded_chunks.Add(new_one);
                        new_one[0] += loaded_chunks[0][0];
                        new_one[1] += loaded_chunks[0][1];
                        Get_tiles(new_one, 2);
                        tiles_t_c3 = tiles_empty;
                        tiles_t_c4 = tiles_empty;
                        switch_off = 4; 
                    }
                    #endregion
                    break;
                case int[] n when n[0] == -1 && n[1] == 0:
                    #region 3
                    if (switch_off != 3)
                    {
                        for (int i = loaded_chunks.Count - 1; i > 0; i--)
                        {
                            loaded_chunks.RemoveAt(i);
                        }
                        loaded_chunks.Add(new_one);
                        new_one[0] += loaded_chunks[0][0];
                        new_one[1] += loaded_chunks[0][1];
                        Get_tiles(new_one, 2);
                        tiles_t_c3 = tiles_empty;
                        tiles_t_c4 = tiles_empty;
                        switch_off = 3;
                    }
                    #endregion
                    break;
                case int[] n when n[0] == 0 && n[1] == 1:
                    #region 1
                    if (switch_off != 1)
                    {
                        for (int i = loaded_chunks.Count - 1; i > 0; i--)
                        {
                            loaded_chunks.RemoveAt(i);
                        }
                        loaded_chunks.Add(new_one);
                        new_one[0] += loaded_chunks[0][0];
                        new_one[1] += loaded_chunks[0][1];
                        Get_tiles(new_one, 2);
                        tiles_t_c3 = tiles_empty;
                        tiles_t_c4 = tiles_empty;
                        switch_off = 1;
                    }
                    #endregion
                    break;
                case int[] n when n[0] == 0 && n[1] == -1:
                    #region 7
                    if (switch_off != 7)
                    {
                        for (int i = loaded_chunks.Count - 1; i > 0; i--)
                        {
                            loaded_chunks.RemoveAt(i);
                        }
                        loaded_chunks.Add(new_one);
                        new_one[0] += loaded_chunks[0][0];
                        new_one[1] += loaded_chunks[0][1];
                        Get_tiles(new_one, 2);
                        tiles_t_c3 = tiles_empty;
                        tiles_t_c4 = tiles_empty;
                        switch_off = 7;
                    }
                    #endregion
                    break;
            }
        }
        public static void sorter(int[] new_one)
        {
            List<int[]> loaded_chunks_add = new List<int[]>();
            int amount_removed = 0;
            for (int k = 0; k < loaded_chunks.Count; k++)
            {
                loaded_chunks_add.Add(loaded_chunks[k]);
            }
            int[] pos = new int[loaded_chunks.Count];
            int[] main = new int[2];
            main = loaded_chunks[0];
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
                }
                switch (order_checker[1])
                {
                    case int n when n < main[1]:
                        switch (order_checker[0])
                        {
                            case int j when j < main[0]:
                                pos[i] = 0;
                                break;
                            case int j when j == main[0]:
                                pos[i] = 1;
                                break;
                            case int j when j > main[0]:
                                pos[i] = 2;
                                break;
                        }
                        break;
                    case int n when n == main[1]:
                        switch (order_checker[0])
                        {
                            case int j when j < main[0]:
                                pos[i] = 3;
                                break;
                            case int j when j == main[0]:
                                pos[i] = 4;
                                break;
                            case int j when j > main[0]:
                                pos[i] = 5;
                                break;
                        }
                        break;
                    case int n when n > main[1]:
                        switch (order_checker[0])
                        {
                            case int j when j < main[0]:
                                pos[i] = 6;
                                break;
                            case int j when j == main[0]:
                                pos[i] = 7;
                                break;
                            case int j when j > main[0]:
                                pos[i] = 8;
                                break;
                        }
                        break;
                }
            }
            for (int i = loaded_chunks.Count; i > 0; i--)
            {
                loaded_chunks.RemoveAt(i - 1);
                amount_removed++;
            }
        }
    #endregion
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
        #region deciding
        //public static void Load_chunks(int x_off, int y_off)
        //{
        //    bool make_side = true;
        //    bool make_top = true;
        //    bool is_there_no_chunk = true;
        //    int[] direction = new int[2];
        //    //direction switch, choses direction based on offset.
        //    switch (x_off)
        //    {
        //        case int k when k > 0:
        //            direction[0] = -1;
        //            break;
        //        case int k when k < 0:
        //            direction[0] = 1;
        //            break;
        //        default:
        //            direction[0] = 0;
        //            break;
        //    }
        //    for (int k = 0; k < loaded_chunks.Count; k++)
        //    {
        //        if (direction[0] == loaded_chunks[k][0] - loaded_chunks[0][0] && 0 == loaded_chunks[k][1] - loaded_chunks[0][1])
        //        {
        //            make_side = false;
        //        }
        //    }
        //    if (make_side)
        //    {
        //        goto maker;
        //    }
        //    switch (y_off)
        //    {
        //        case int k when k > 0:
        //            direction[1] = 1;
        //            break;
        //        case int k when k < 0:
        //            direction[1] = -1;
        //            break;
        //        default:
        //            direction[1] = 0;
        //            break;
        //    }
        //    for (int k = 0; k < loaded_chunks.Count; k++)
        //    {
        //        if (0 == loaded_chunks[k][0] - loaded_chunks[0][0] && direction[1] == loaded_chunks[k][1] - loaded_chunks[0][1])
        //        {
        //            make_top = false;
        //        }
        //    }
        //    if (make_top)
        //    {
        //        direction[0] = 0;
        //        goto maker;
        //    }
        //maker:
        //    direction[0] += loaded_chunks[0][0];
        //    direction[1] += loaded_chunks[0][1];
        //    for (int i = 0; i < loaded_chunks.Count; i++)
        //    {
        //        if (loaded_chunks[i][0] == direction[0] && loaded_chunks[i][1] == direction[1])
        //        {
        //            is_there_no_chunk = false;
        //        }
        //    }
        //    if (is_there_no_chunk)
        //    {
        //        sort_chunk_adding(direction);
        //    }
        //}
        public static void Load_chunkss(int x_off, int y_off)
        {
            bool make_side = true;
            bool make_top = true;
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
            for (int k = 0; k < loaded_chunks.Count; k++)
            {
                if (direction[0] == loaded_chunks[k][0] - loaded_chunks[0][0] && 0 == loaded_chunks[k][1] - loaded_chunks[0][1])
                {
                    make_side = false;
                }
            }
            if (make_side)
            {
                goto maker;
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
            for (int k = 0; k < loaded_chunks.Count; k++)
            {
                if (0 == loaded_chunks[k][0] - loaded_chunks[0][0] && direction[1] == loaded_chunks[k][1] - loaded_chunks[0][1])
                {
                    make_top = false;
                }
            }
            if (make_top)
            {
                direction[0] = 0;
                goto maker;
            }
        maker:
            direction[0] += loaded_chunks[0][0];
            direction[1] += loaded_chunks[0][1];
            sort_chunk_adding(direction);
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
                if (chunk_check_file(direction))
                {
                    sort_chunk_moving(direction);
                }
            }
        }
        #endregion
        #region sorting
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
                int[] position_o = new int[loaded_chunks.Count];
                List<int[]> amount_add = new List<int[]>();
                if (loaded_chunks.Count > 1)
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
                for (int i = loaded_chunks.Count; i > 0; i--)
                {
                    loaded_chunks.RemoveAt(i - 1);
                    amount_removed++;
                }
                // add
                position_o = position;
                Array.Sort(position_o);
                for (int i_2 = 0; i_2 < amount_removed + 1; i_2++)
                {
                    switch (i_2)
                    {
                        case 0:
                            loaded_chunks.Add(main);
                            Get_tiles(main, i_2 + 1);
                            break;
                        case 1:
                            switch (position_o[i_2 - 1])
                            {
                                case int k when k == position[0]:
                                    loaded_chunks.Add(new_one);
                                    Get_tiles(new_one, i_2 + 1);
                                    break;
                                case int k when k == position[1]:
                                    loaded_chunks.Add(amount_add[0]);
                                    Get_tiles(amount_add[0], i_2 + 1);
                                    break;
                                case int k when k == position[2]:
                                    loaded_chunks.Add(amount_add[1]);
                                    Get_tiles(amount_add[1], i_2 + 1);
                                    break;
                            }
                            break;
                        case 2:
                            switch (position_o[i_2 - 1])
                            {
                                case int k when k == position[0]:
                                    loaded_chunks.Add(new_one);
                                    Get_tiles(new_one, i_2 + 1);
                                    break;
                                case int k when k == position[1]:
                                    loaded_chunks.Add(amount_add[0]);
                                    Get_tiles(amount_add[0], i_2 + 1);
                                    break;
                                case int k when k == position[2]:
                                    loaded_chunks.Add(amount_add[1]);
                                    Get_tiles(amount_add[1], i_2 + 1);
                                    break;
                            }
                            break;
                        case 3:
                            switch (position_o[i_2 - 1])
                            {
                                case int k when k == position[0]:
                                    loaded_chunks.Add(new_one);
                                    Get_tiles(new_one, i_2 + 1);
                                    break;
                                case int k when k == position[1]:
                                    loaded_chunks.Add(amount_add[0]);
                                    Get_tiles(amount_add[0], i_2 + 1);
                                    break;
                                case int k when k == position[2]:
                                    loaded_chunks.Add(amount_add[1]);
                                    Get_tiles(amount_add[1], i_2 + 1);
                                    break;
                            }
                            break;
                    }
                }
            }
        }
        private static void Get_tiles(int[] pos, int tile)
        {
            int[] tiles = new int[width * height];
            if (chunk_check_file(pos))
            {
                if (pos[0] == 1 && pos[1] == 0)
                {
                    int hey = 0;
                }
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
        private static void sort_chunk_moving(int[] new_one)
        {
            #region add
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
                int[] position_o = new int[loaded_chunks.Count];
                List<int[]> amount_add = new List<int[]>();
                if (loaded_chunks.Count > 1)
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
                for (int i = loaded_chunks.Count; i > 0; i--)
                {
                    loaded_chunks.RemoveAt(i - 1);
                    amount_removed++;
                }
                // add
                position_o = position;
                Array.Sort(position_o);
                for (int i_2 = 0; i_2 < amount_removed; i_2++)
                {
                    switch (i_2)
                    {
                        case 0:
                            loaded_chunks.Add(main);
                            break;
                        case 1:
                            switch (position_o[i_2 - 1])
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
                            switch (position_o[i_2 - 1])
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
                            switch (position_o[i_2 - 1])
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
            #endregion
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
                    if (loaded_chunks[1] == new_one)
                    {
                        amount_add.Add(loaded_chunks[0]);
                    }
                    else
                    {
                        amount_add.Add(loaded_chunks[1]);
                    }
                    if (loaded_chunks.Count > 2)
                    {
                        if (loaded_chunks[1] == new_one)
                        {
                            amount_add.Add(loaded_chunks[0]);
                        }
                        else
                        {
                            amount_add.Add(loaded_chunks[2]);
                        }
                        if (loaded_chunks.Count > 3)
                        {
                            if (loaded_chunks[1] == new_one)
                            {
                                amount_add.Add(loaded_chunks[0]);
                            }
                            else
                            {
                                amount_add.Add(loaded_chunks[3]);
                            }
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
                            order_checker = amount_add[0];
                            break;
                        case 2:
                            order_checker = amount_add[1];
                            break;
                        case 3:
                            order_checker = amount_add[2];
                            break;
                    }
                    switch (order_checker[1])
                    {
                        case int n when n < new_one[1]:
                            switch (order_checker[0])
                            {
                                case int j when j < new_one[0]:
                                    position[i] = 0;
                                    break;
                                case int j when j == new_one[0]:
                                    position[i] = 1;
                                    break;
                                case int j when j > new_one[0]:
                                    position[i] = 2;
                                    break;
                            }
                            break;
                        case int n when n == new_one[1]:
                            switch (order_checker[0])
                            {
                                case int j when j < new_one[0]:
                                    position[i] = 3;
                                    break;
                                case int j when j == new_one[0]:
                                    position[i] = 4;
                                    break;
                                case int j when j > new_one[0]:
                                    position[i] = 5;
                                    break;
                            }
                            break;
                        case int n when n > new_one[1]:
                            switch (order_checker[0])
                            {
                                case int j when j < new_one[0]:
                                    position[i] = 6;
                                    break;
                                case int j when j == new_one[0]:
                                    position[i] = 7;
                                    break;
                                case int j when j > new_one[0]:
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
                            loaded_chunks.Add(new_one);
                            break;
                        case 1:
                            switch (position_o[i_2])
                            {
                                case int k when k == position[0]:
                                    loaded_chunks.Add(amount_add[0]);
                                    break;
                                case int k when k == position[1]:
                                    loaded_chunks.Add(amount_add[1]);
                                    break;
                                case int k when k == position[2]:
                                    loaded_chunks.Add(amount_add[2]);
                                    break;
                            }
                            break;
                        case 2:
                            switch (position_o[i_2])
                            {
                                case int k when k == position[0]:
                                    loaded_chunks.Add(amount_add[0]);
                                    break;
                                case int k when k == position[1]:
                                    loaded_chunks.Add(amount_add[1]);
                                    break;
                                case int k when k == position[2]:
                                    loaded_chunks.Add(amount_add[2]);
                                    break;
                            }
                            break;
                        case 3:
                            switch (position_o[i_2])
                            {
                                case int k when k == position[0]:
                                    loaded_chunks.Add(amount_add[0]);
                                    break;
                                case int k when k == position[1]:
                                    loaded_chunks.Add(amount_add[1]);
                                    break;
                                case int k when k == position[2]:
                                    loaded_chunks.Add(amount_add[2]);
                                    break;
                            }
                            break;
                    }
                }
            }
        }
        #endregion
        #region Making chunks
        public static void Start_Chunk(int[] direction)
        {
            // remove all files here
            Chunk_maker(direction);
            loaded_chunks.Add(direction);
        }
        static int[] Chunk_maker(int[] direction)
        {
            int[] tiles_t = new int[width * height];
            int[] pos = new int[2];
            if (direction[0] != 0 || direction[1] != 0)
            {
                pos[0] = direction[0] + loaded_chunks[0][0];
                pos[1] = direction[1] + loaded_chunks[0][1];
            }
            else
            {
                pos[0] = 0;
                pos[1] = 0;
            }
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

            }
            TextWriter tw = new StreamWriter(@"Chunks\" + filename, true);
            tw.WriteLine(write);
            tw.Close();

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
                    direction[0] = -1920;
                    break;
                case int n when n > loaded_chunks[0][0]:
                    direction[0] = 1920;
                    break;
                default:
                    direction[0] = 0;
                    break;
            }
            switch (loaded_one[1])
            {
                case int k when k < loaded_chunks[0][1]:
                    direction[1] = 1080;
                    break;
                case int k when k > loaded_chunks[0][1]:
                    direction[1] = -1080;
                    break;
                default:
                    direction[1] = 0;
                    break;
            }
            return direction;
        }
        #endregion
        #endregion
        #region old_chunks
        #region chunks
        #region new chunks
        //public static void Load_chunks(int x_off, int y_off)
        //{
        //    int[] direction = new int[2];
        //    //direction switch, choses direction based on offset.
        //    switch (x_off)
        //    {
        //        case int n when n > 0:
        //            switch (y_off)
        //            {
        //                case int k when k > 0:
        //                    direction[0] = 1;
        //                    direction[1] = 1;
        //                    break;
        //                case int k when k < 0:
        //                    direction[0] = 1;
        //                    direction[1] = -1;
        //                    break;
        //                default:
        //                    direction[0] = 1;
        //                    direction[1] = 0;
        //                    break;
        //            }
        //            break;
        //        case int n when n < 0:
        //            switch (y_off)
        //            {
        //                case int k when k > 0:
        //                    direction[0] = -1;
        //                    direction[1] = 1;
        //                    break;
        //                case int k when k < 0:
        //                    direction[0] = -1;
        //                    direction[1] = -1;
        //                    break;
        //                default:
        //                    direction[0] = -1;
        //                    direction[1] = 0;
        //                    break;
        //            }
        //            break;
        //        default:
        //            switch (y_off)
        //            {
        //                case int k when k > 0:
        //                    direction[0] = 0;
        //                    direction[1] = 1;
        //                    break;
        //                case int k when k < 0:
        //                    direction[0] = 0;
        //                    direction[1] = -1;
        //                    break;
        //                default:
        //                    direction[0] = 0;
        //                    direction[1] = 0;
        //                    break;
        //            }
        //            break;
        //    }
        //    // tjek by input
        //    if (direction[0] != 0 || direction[1] != 0)
        //    {
        //        bool er_der_en_chunk = false;
        //        int[] position = new int[2];
        //        position[0] += direction[0] + loaded_chunks[0][0];
        //        position[1] += direction[1] + loaded_chunks[0][1];
        //        for (int i = 0; i < loaded_chunks.Count - 1; i++)
        //        {
        //            if (loaded_chunks[i + 1][0] == position[0])
        //            {
        //                if (loaded_chunks[i + 1][0] == position[0])
        //                {
        //                    er_der_en_chunk = true;
        //                }
        //            }
        //        }
        //        if (er_der_en_chunk == false)
        //        {
        //            sort_chunk_adding(direction);
        //        }
        //    }
        //}
        //public static void Move_Main_chunk(int x_1, int y_1, int _width, int _height)
        //{
        //    // make a adding for strait and not strait, this can not add 2 chunks
        //    int[] direction = new int[2];
        //    if (x_1 > _width)
        //    {
        //        direction[0] = 1;
        //        direction[1] = 0;
        //        // change new main chunk
        //    }
        //    if (x_1 < -_width)
        //    {
        //        direction[0] = -1;
        //        direction[1] = 0;
        //        // change new main chunk
        //    }
        //    if (y_1 > _height)
        //    {
        //        direction[0] = 0;
        //        direction[1] = 1;
        //        // change new main chunk
        //    }
        //    if (y_1 < -_height)
        //    {
        //        direction[0] = 0;
        //        direction[1] = -1;
        //        // change new main chunk
        //    }
        //    if (direction[0] != 0 || direction[1] != 0)
        //    {
        //        if (chunk_check_file(direction))
        //        {
        //            sort_chunk_moving(direction);
        //        }
        //    }
        //}
        #region sorting
        //private static void sort_chunk_adding(int[] new_one)
        //{
        //    if (loaded_chunks.Count == 0)
        //    {
        //        loaded_chunks.Add(new_one);
        //    }
        //    else
        //    {
        //        int[] main = new int[2];
        //        main = loaded_chunks[0];
        //        int amount_removed = 0;
        //        int[] position = new int[loaded_chunks.Count];
        //        int[] position_o = new int[loaded_chunks.Count];
        //        List<int[]> amount_add = new List<int[]>();
        //        if (loaded_chunks.Count > 1)
        //        {
        //            amount_add.Add(loaded_chunks[1]);
        //            if (loaded_chunks.Count > 2)
        //            {
        //                amount_add.Add(loaded_chunks[2]);
        //                if (loaded_chunks.Count > 3)
        //                {
        //                    amount_add.Add(loaded_chunks[3]);

        //                }
        //            }
        //        }
        //        // pos
        //        for (int i = 0; i < loaded_chunks.Count; i++)
        //        {
        //            int[] order_checker = new int[2];
        //            switch (i)
        //            {
        //                case 0:
        //                    order_checker = new_one;
        //                    break;
        //                case 1:
        //                    order_checker = loaded_chunks[1];
        //                    break;
        //                case 2:
        //                    order_checker = loaded_chunks[2];
        //                    break;
        //                case 3:
        //                    order_checker = loaded_chunks[3];
        //                    break;
        //            }
        //            switch (order_checker[1])
        //            {
        //                case int n when n < main[1]:
        //                    switch (order_checker[0])
        //                    {
        //                        case int j when j < main[0]:
        //                            position[i] = 0;
        //                            break;
        //                        case int j when j == main[0]:
        //                            position[i] = 1;
        //                            break;
        //                        case int j when j > main[0]:
        //                            position[i] = 2;
        //                            break;
        //                    }
        //                    break;
        //                case int n when n == main[1]:
        //                    switch (order_checker[0])
        //                    {
        //                        case int j when j < main[0]:
        //                            position[i] = 3;
        //                            break;
        //                        case int j when j == main[0]:
        //                            position[i] = 4;
        //                            break;
        //                        case int j when j > main[0]:
        //                            position[i] = 5;
        //                            break;
        //                    }
        //                    break;
        //                case int n when n > main[1]:
        //                    switch (order_checker[0])
        //                    {
        //                        case int j when j < main[0]:
        //                            position[i] = 6;
        //                            break;
        //                        case int j when j == main[0]:
        //                            position[i] = 7;
        //                            break;
        //                        case int j when j > main[0]:
        //                            position[i] = 8;
        //                            break;
        //                    }
        //                    break;
        //            }
        //        }
        //        // remove
        //        for (int i = loaded_chunks.Count; i > 0; i--)
        //        {
        //            loaded_chunks.RemoveAt(i-1);
        //            amount_removed++;
        //        }
        //        // add
        //        position_o = position;
        //        Array.Sort(position_o);
        //        for (int i_2 = 0; i_2 < amount_removed + 1; i_2++)
        //        {
        //            switch (i_2)
        //            {
        //                case 0:
        //                    loaded_chunks.Add(main);
        //                    Get_tiles(main, i_2 + 1);
        //                    break;
        //                case 1:
        //                    switch (position_o[i_2 - 1])
        //                    {
        //                        case int k when k == position[0]:
        //                            loaded_chunks.Add(new_one);
        //                            Get_tiles(new_one, i_2 + 1);
        //                            break;
        //                        case int k when k == position[1]:
        //                            loaded_chunks.Add(amount_add[0]);
        //                            Get_tiles(amount_add[0], i_2 + 1);
        //                            break;
        //                        case int k when k == position[2]:
        //                            loaded_chunks.Add(amount_add[1]);
        //                            Get_tiles(amount_add[1], i_2 + 1);
        //                            break;
        //                    }
        //                    break;
        //                case 2:
        //                    switch (position_o[i_2 - 1])
        //                    {
        //                        case int k when k == position[0]:
        //                            loaded_chunks.Add(new_one);
        //                            Get_tiles(new_one, i_2 + 1);
        //                            break;
        //                        case int k when k == position[1]:
        //                            loaded_chunks.Add(amount_add[0]);
        //                            Get_tiles(amount_add[0], i_2 + 1);
        //                            break;
        //                        case int k when k == position[2]:
        //                            loaded_chunks.Add(amount_add[1]);
        //                            Get_tiles(amount_add[1], i_2 + 1);
        //                            break;
        //                    }
        //                    break;
        //                case 3:
        //                    switch (position_o[i_2 - 1])
        //                    {
        //                        case int k when k == position[0]:
        //                            loaded_chunks.Add(new_one);
        //                            Get_tiles(new_one, i_2 + 1);
        //                            break;
        //                        case int k when k == position[1]:
        //                            loaded_chunks.Add(amount_add[0]);
        //                            Get_tiles(amount_add[0], i_2 + 1);
        //                            break;
        //                        case int k when k == position[2]:
        //                            loaded_chunks.Add(amount_add[1]);
        //                            Get_tiles(amount_add[1], i_2 + 1);
        //                            break;
        //                    }
        //                    break;
        //            }
        //        }
        //    }
        //}
        //private static void Get_tiles(int[] pos, int tile)
        //{
        //    int[] tiles = new int[width * height];
        //    if (chunk_check_file(pos))
        //    {
        //        tiles = Chunk_Read(pos);
        //    }
        //    else
        //    {
        //        tiles = Chunk_maker(pos);
        //    }
        //    switch (tile)
        //    {
        //        case 1:
        //            tiles_t_c1 = tiles;
        //            break;
        //        case 2:
        //            tiles_t_c2 = tiles;
        //            break;
        //        case 3:
        //            tiles_t_c3 = tiles;
        //            break;
        //        case 4:
        //            tiles_t_c4 = tiles;
        //            break;
        //    }
        //}
        //private static void sort_chunk_moving(int[] new_one)
        //{
        //    #region add
        //    if (loaded_chunks.Count == 0)
        //    {
        //        loaded_chunks.Add(new_one);
        //    }
        //    else
        //    {
        //        int[] main = new int[2];
        //        main = loaded_chunks[0];
        //        int amount_removed = 0;
        //        int[] position = new int[loaded_chunks.Count];
        //        int[] position_o = new int[loaded_chunks.Count];
        //        List<int[]> amount_add = new List<int[]>();
        //        if (loaded_chunks.Count > 1)
        //        {
        //            amount_add.Add(loaded_chunks[1]);
        //            if (loaded_chunks.Count > 2)
        //            {
        //                amount_add.Add(loaded_chunks[2]);
        //                if (loaded_chunks.Count > 3)
        //                {
        //                    amount_add.Add(loaded_chunks[3]);

        //                }
        //            }
        //        }
        //        // pos
        //        for (int i = 0; i < loaded_chunks.Count; i++)
        //        {
        //            int[] order_checker = new int[2];
        //            switch (i)
        //            {
        //                case 0:
        //                    order_checker = new_one;
        //                    break;
        //                case 1:
        //                    order_checker = loaded_chunks[1];
        //                    break;
        //                case 2:
        //                    order_checker = loaded_chunks[2];
        //                    break;
        //                case 3:
        //                    order_checker = loaded_chunks[3];
        //                    break;
        //            }
        //            switch (order_checker[1])
        //            {
        //                case int n when n < main[1]:
        //                    switch (order_checker[0])
        //                    {
        //                        case int j when j < main[0]:
        //                            position[i] = 0;
        //                            break;
        //                        case int j when j == main[0]:
        //                            position[i] = 1;
        //                            break;
        //                        case int j when j > main[0]:
        //                            position[i] = 2;
        //                            break;
        //                    }
        //                    break;
        //                case int n when n == main[1]:
        //                    switch (order_checker[0])
        //                    {
        //                        case int j when j < main[0]:
        //                            position[i] = 3;
        //                            break;
        //                        case int j when j == main[0]:
        //                            position[i] = 4;
        //                            break;
        //                        case int j when j > main[0]:
        //                            position[i] = 5;
        //                            break;
        //                    }
        //                    break;
        //                case int n when n > main[1]:
        //                    switch (order_checker[0])
        //                    {
        //                        case int j when j < main[0]:
        //                            position[i] = 6;
        //                            break;
        //                        case int j when j == main[0]:
        //                            position[i] = 7;
        //                            break;
        //                        case int j when j > main[0]:
        //                            position[i] = 8;
        //                            break;
        //                    }
        //                    break;
        //            }
        //        }
        //        // remove
        //        for (int i = loaded_chunks.Count; i > 0; i--)
        //        {
        //            loaded_chunks.RemoveAt(i - 1);
        //            amount_removed++;
        //        }
        //        // add
        //        position_o = position;
        //        Array.Sort(position_o);
        //        for (int i_2 = 0; i_2 < amount_removed; i_2++)
        //        {
        //            switch (i_2)
        //            {
        //                case 0:
        //                    loaded_chunks.Add(main);
        //                    break;
        //                case 1:
        //                    switch (position_o[i_2 - 1])
        //                    {
        //                        case int k when k == position[0]:
        //                            loaded_chunks.Add(new_one);
        //                            break;
        //                        case int k when k == position[1]:
        //                            loaded_chunks.Add(amount_add[0]);
        //                            break;
        //                        case int k when k == position[2]:
        //                            loaded_chunks.Add(amount_add[1]);
        //                            break;
        //                    }
        //                    break;
        //                case 2:
        //                    switch (position_o[i_2 - 1])
        //                    {
        //                        case int k when k == position[0]:
        //                            loaded_chunks.Add(new_one);
        //                            break;
        //                        case int k when k == position[1]:
        //                            loaded_chunks.Add(amount_add[0]);
        //                            break;
        //                        case int k when k == position[2]:
        //                            loaded_chunks.Add(amount_add[1]);
        //                            break;
        //                    }
        //                    break;
        //                case 3:
        //                    switch (position_o[i_2 - 1])
        //                    {
        //                        case int k when k == position[0]:
        //                            loaded_chunks.Add(new_one);
        //                            break;
        //                        case int k when k == position[1]:
        //                            loaded_chunks.Add(amount_add[0]);
        //                            break;
        //                        case int k when k == position[2]:
        //                            loaded_chunks.Add(amount_add[1]);
        //                            break;
        //                    }
        //                    break;
        //            }
        //        }
        //    }
        //    #endregion
        //    if (loaded_chunks.Count == 0)
        //    {
        //        loaded_chunks.Add(new_one);
        //    }
        //    else
        //    {
        //        int[] main = new int[2];
        //        main = loaded_chunks[0];
        //        int amount_removed = 0;
        //        int[] position = new int[loaded_chunks.Count];
        //        List<int[]> amount_add = new List<int[]>();
        //        if (loaded_chunks.Count > 0)
        //        {
        //            if (loaded_chunks[1] == new_one)
        //            {
        //                amount_add.Add(loaded_chunks[0]);
        //            }
        //            else
        //            {
        //                amount_add.Add(loaded_chunks[1]);
        //            }
        //            if (loaded_chunks.Count > 2)
        //            {
        //                if (loaded_chunks[1] == new_one)
        //                {
        //                    amount_add.Add(loaded_chunks[0]);
        //                }
        //                else
        //                {
        //                    amount_add.Add(loaded_chunks[2]);
        //                }
        //                if (loaded_chunks.Count > 3)
        //                {
        //                    if (loaded_chunks[1] == new_one)
        //                    {
        //                        amount_add.Add(loaded_chunks[0]);
        //                    }
        //                    else
        //                    {
        //                        amount_add.Add(loaded_chunks[3]);
        //                    }
        //                }
        //            }
        //        }
        //        // pos
        //        for (int i = 0; i < loaded_chunks.Count; i++)
        //        {
        //            int[] order_checker = new int[2];
        //            switch (i)
        //            {
        //                case 0:
        //                    order_checker = new_one;
        //                    break;
        //                case 1:
        //                    order_checker = amount_add[0];
        //                    break;
        //                case 2:
        //                    order_checker = amount_add[1];
        //                    break;
        //                case 3:
        //                    order_checker = amount_add[2];
        //                    break;
        //            }
        //            switch (order_checker[1])
        //            {
        //                case int n when n < new_one[1]:
        //                    switch (order_checker[0])
        //                    {
        //                        case int j when j < new_one[0]:
        //                            position[i] = 0;
        //                            break;
        //                        case int j when j == new_one[0]:
        //                            position[i] = 1;
        //                            break;
        //                        case int j when j > new_one[0]:
        //                            position[i] = 2;
        //                            break;
        //                    }
        //                    break;
        //                case int n when n == new_one[1]:
        //                    switch (order_checker[0])
        //                    {
        //                        case int j when j < new_one[0]:
        //                            position[i] = 3;
        //                            break;
        //                        case int j when j == new_one[0]:
        //                            position[i] = 4;
        //                            break;
        //                        case int j when j > new_one[0]:
        //                            position[i] = 5;
        //                            break;
        //                    }
        //                    break;
        //                case int n when n > new_one[1]:
        //                    switch (order_checker[0])
        //                    {
        //                        case int j when j < new_one[0]:
        //                            position[i] = 6;
        //                            break;
        //                        case int j when j == new_one[0]:
        //                            position[i] = 7;
        //                            break;
        //                        case int j when j > new_one[0]:
        //                            position[i] = 8;
        //                            break;
        //                    }
        //                    break;
        //            }
        //        }
        //        // remove
        //        for (int i = 0; i < loaded_chunks.Count; i++)
        //        {
        //            loaded_chunks.RemoveAt(i);
        //            amount_removed++;
        //        }
        //        // add
        //        int[] position_o = new int[loaded_chunks.Count];
        //        position_o = position;
        //        Array.Sort(position_o);
        //        for (int i_2 = 0; i_2 < amount_removed + 1; i_2++)
        //        {
        //            switch (i_2)
        //            {
        //                case 0:
        //                    loaded_chunks.Add(new_one);
        //                    break;
        //                case 1:
        //                    switch (position_o[i_2])
        //                    {
        //                        case int k when k == position[0]:
        //                            loaded_chunks.Add(amount_add[0]);
        //                            break;
        //                        case int k when k == position[1]:
        //                            loaded_chunks.Add(amount_add[1]);
        //                            break;
        //                        case int k when k == position[2]:
        //                            loaded_chunks.Add(amount_add[2]);
        //                            break;
        //                    }
        //                    break;
        //                case 2:
        //                    switch (position_o[i_2])
        //                    {
        //                        case int k when k == position[0]:
        //                            loaded_chunks.Add(amount_add[0]);
        //                            break;
        //                        case int k when k == position[1]:
        //                            loaded_chunks.Add(amount_add[1]);
        //                            break;
        //                        case int k when k == position[2]:
        //                            loaded_chunks.Add(amount_add[2]);
        //                            break;
        //                    }
        //                    break;
        //                case 3:
        //                    switch (position_o[i_2])
        //                    {
        //                        case int k when k == position[0]:
        //                            loaded_chunks.Add(amount_add[0]);
        //                            break;
        //                        case int k when k == position[1]:
        //                            loaded_chunks.Add(amount_add[1]);
        //                            break;
        //                        case int k when k == position[2]:
        //                            loaded_chunks.Add(amount_add[2]);
        //                            break;
        //                    }
        //                    break;
        //            }
        //        }
        //    }
        //}
        #endregion
        #region Making chunks
        //public static void Start_Chunk(int[] direction)
        //{
        //    Chunk_maker(direction);
        //    loaded_chunks.Add(direction);
        //}
        //static int[] Chunk_maker(int[] direction)
        //{
        //    int[] tiles_t = new int[width * height];
        //    int[] pos = new int[2];
        //    if (direction[0] != 0 || direction[1] != 0)
        //    {
        //        pos[0] = direction[0] + loaded_chunks[0][0];
        //        pos[1] = direction[1] + loaded_chunks[0][1];
        //    }
        //    else
        //    {
        //        pos[0] = 0;
        //        pos[1] = 0;
        //    }
        //    // add to list, make function to sort
        //    for (int i = 0; i < width * height; i++)
        //    {
        //        // function/method to see if the given x and y coordinates have a predetermined value for the terrain
        //        z_1 = chunk_terrain(pos, i);
        //        tiles_t[i] = z_1;
        //    }
        //    chunk_writer(tiles_t, pos);
        //    return tiles_t;
        //}        
        //static int chunk_terrain(int[] xy, int i)
        //{
        //    switch (xy[1])
        //    {
        //        case int n when n < 3 && n > -1:
        //            return 2;
        //    }
        //    return 0;
        //}
        #endregion
        #region write chunks
        //private static void chunk_writer(int[] t, int[] direction)
        //{
        //    string filename = direction[0].ToString() + " " + direction[1].ToString() + ".txt";
        //    //File.CreateText(@"Chunks\" + filename);
        //    string write = "";
        //    for (int i = 0; i < t.Length; i++)
        //    {
        //        write += t[i].ToString();
        //        write += ",";

        //    }
        //    File.WriteAllText(@"Chunks\" + filename, write);
        //}
        #endregion
        #endregion
        #region Reading chunks
        //static bool chunk_check_file(int[] filename)
        //{
        //    if (File.Exists(@"@""Miner\Chunks\" + filename[0].ToString() + "," + filename[1].ToString() + ".txt"))
        //    {
        //        return true;
        //    }
        //    return false;
        //}
        //private static int[] Chunk_Read(int[] direction)
        //{
        //    string text = File.ReadAllText(@"Chunks\" + direction[0].ToString() + " " + direction[1].ToString() + ".txt");
        //    string comma = ",";
        //    string current_text = "";
        //    int[] tiles = new int[width * height];
        //    int current_int = 0;
        //    for (int i = 0; i < text.Length; i++)
        //    {
        //        if (text[i] != comma[0])
        //        {
        //            current_text += text[i];
        //        }
        //        else
        //        {
        //            tiles[current_int] = Int32.Parse(current_text);
        //            current_int += 1;
        //        }
        //    }
        //    return tiles;
        //}
        //public static int Chunk_differ()
        //{
        //    return loaded_chunks.Count;
        //}
        //public static int[] Loaded_Chunk_differ(int i)
        //{
        //    return loaded_chunks[i];
        //}
        #endregion
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
                                        chunk_writer(tiles_t_c1, chunk);
                                        break;
                                    case 2:
                                        tiles_t_c2[(x_mod * width) + i] = z;
                                        chunk_writer(tiles_t_c2, chunk);
                                        break;
                                    case 3:
                                        tiles_t_c3[(x_mod * width) + i] = z;
                                        chunk_writer(tiles_t_c3, chunk);
                                        break;
                                    case 4:
                                        tiles_t_c4[(x_mod * width) + i] = z;
                                        chunk_writer(tiles_t_c4, chunk);
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
                        if (loaded_chunks[i][0] == chunk[0])
                        {
                            // found the location of the value of terrain in terrain array
                            switch (i)
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
    }
}
