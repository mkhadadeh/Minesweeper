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
            Int32.TryParse(lstr, out board_dims[0]);
            Int32.TryParse(wstr, out board_dims[1]);

            Board my_board = new Board(board_dims[0], board_dims[1]);
            my_board.print_board();

            Console.ReadKey();
        }
    }
}
