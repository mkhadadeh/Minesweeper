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

        public Board(int l, int w)
        {
            //Collect board dims
            Debug.Assert(l > 0 && w > 0);
            length = l;
            width = w;

            //Set up board with borders
            board_rep = new int[length + 2, width + 2];
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
                }
            }
            populate_board();
        }
        private void populate_board()
        {
            //Place mines and numbers
        }
        public void print_board()
        {
            for (int i = 1; i < width + 1; i++)
            {
                for (int j = 1; j < length + 1; j++)
                {
                    Console.Write((board_rep[j, i]).ToString() + " ");
                }
                Console.Write("\n");
            }
        }

    }
}
