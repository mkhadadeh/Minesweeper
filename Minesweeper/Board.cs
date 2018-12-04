using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Minesweeper
{
    class Board
    {
        private enum TILES : int { WALL = -2, MINE = -1};
        private int length, width;
        private int[,] board_rep;
        private bool[,] board_found;
        private int mine_count;
        private bool populated;
        

        public Board(int l, int w, int num_mines)
        {
            //Collect board dims
            Debug.Assert(l > 0 && w > 0);
            length = l;
            width = w;

            //Set up board with borders
            board_rep = new int[length + 2, width + 2];
            board_found = new bool[length + 2, width + 2];
            for (int i = 0; i < length + 2; i++)
            {
                board_rep[i, 0] = (int)TILES.WALL;
                board_rep[i, width + 1] = (int)TILES.WALL;
            }
            for (int i = 0; i < width + 2; i++)
            {
                board_rep[0, i] = (int)TILES.WALL;
                board_rep[length + 1, i] = (int)TILES.WALL;
            }

            for (int i = 1; i < width + 1; i++)
            {
                for (int j = 1; j < length + 1; j++)
                {
                    board_rep[j, i] = 0;
                    board_found[j, i] = false;
                }
            }

            mine_count = num_mines;
            populated = false;
        }

        private Point[] get_around(Point p, bool only_plus = false)
        {
            Point[] possibilities = new Point[8];
            int count = 0;
            for(int i = p.y - 1; i < p.y + 2; i++)
            {
                for (int j = p.x - 1; j < p.x + 2; j++)
                {
                    if (i == p.y && j == p.x)
                        continue;
                    if((board_rep[j, i] != -2) && !(only_plus && !(i == p.y || j == p.x)))
                    {
                        possibilities[count++] = new Point(j, i);
                    }
                    else
                    {
                        possibilities[count++] = new Point(0, 0);
                    }
                }
            }

            return possibilities;
        }

        private void populate_board(Point start)
        {
            Random rnd = new Random();

            //Select safe spots
            Point[] safe_spots = new Point[9];
            safe_spots[0] = start;
            Point[] around = get_around(safe_spots[0]);
            for (int i = 0; i < 8; i++)
            {
                safe_spots[i + 1] = around[i];
            }

            //Place mines
            int mines_to_place = mine_count;
            do
            {
                int pick_x = rnd.Next(1, length);
                int pick_y = rnd.Next(1, width);
                if ((board_rep[pick_y, pick_x] != (int)TILES.MINE))
                {
                    bool can_place = true;
                    for(int i = 0; i < 9; i++)
                    {
                        if (pick_x == safe_spots[i].x && pick_y == safe_spots[i].y)
                            can_place = false;
                    }
                    if (can_place)
                    {
                        board_rep[pick_y, pick_x] = (int)TILES.MINE;
                        mines_to_place--;
                    }
                }
            } while (mines_to_place != 0);

            //Calculate hints
            for (int i = 1; i < width + 1; i++)
            {
                for (int j = 1; j < length + 1; j++)
                {
                    if (board_rep[j, i] < 0)
                        continue;
                    Point[] around_hints = get_around(new Point(j, i));
                    for(int k = 0; k < 8; k++)
                    {
                        if(board_rep[around_hints[k].x,around_hints[k].y] == (int)TILES.MINE)
                        {
                            board_rep[j, i]++;
                        }
                    }
                }
            }
            populated = true;
        }

        public int sweep(Point p)
        {
            if(!populated)
            {
                populate_board(p);
                sweep(p);
            }
            if(!board_found[p.x,p.y])
            {
                board_found[p.x, p.y] = true;
                if(board_rep[p.x, p.y] == 0)
                {
                    Point[] around = get_around(p);
                    foreach (Point a in around) {
                        sweep(a);
                    }
                }
            }
            return board_rep[p.x, p.y];
        }

        public void print_board()
        {
            for (int i = 1; i < width + 1; i++)
            {
                for (int j = 1; j < length + 1; j++)
                {
                    if (board_found[j, i])
                    {
                    if (board_rep[j, i] == (int)TILES.MINE)
                        Console.Write("M ");
                    else
                        Console.Write((board_rep[j, i]).ToString() + " ");
                    }
                    else
                    {
                        Console.Write("-" + " ");
                    }
                }
                Console.Write("\n");
            }
        }
    }
}
