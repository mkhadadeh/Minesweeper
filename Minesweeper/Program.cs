using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    class Program
    {
        static void Main(string[] args)
        {
            // Setting dimensions of board
            int[] board_dims = new int[2];
            Console.Write("Enter length: ");
            string lstr = Console.ReadLine();
            Console.Write("Enter width: ");
            string wstr = Console.ReadLine();
            Int32.TryParse(lstr, out board_dims[1]);
            Int32.TryParse(wstr, out board_dims[0]);

            // Populating board
            int[,] board = new int[board_dims[0], board_dims[1]];
            for(int i = 0; i < board_dims[0]; i++)
            {
                for(int j = 0; j < board_dims[1]; j++)
                {
                    board[i, j] = i + j;
                }
            }

            // Printing board
            printBoard(board, board_dims);

            Console.ReadKey();
        }
        static void printBoard(int[,] b, int[] dims)
        {
            for (int i = 0; i < dims[0]; i++)
            {
                for (int j = 0; j < dims[1]; j++)
                {
                    Console.Write((b[i, j]).ToString() + ' ');
                }
                Console.Write('\n');
            }
        }
    }
}
