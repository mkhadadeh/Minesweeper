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

            Board my_board = new Board(board_dims[0], board_dims[1], 10);

            Point to_sweep = new Point(0, 0);
            do
            {
                my_board.print_board();
                Console.Write("X: ");
                string x_pt = Console.ReadLine();
                Console.Write("Y: ");
                string y_pt = Console.ReadLine();
                Int32.TryParse(x_pt, out to_sweep.x);
                Int32.TryParse(y_pt, out to_sweep.y);
            } while (my_board.sweep(to_sweep) != -1);

            Console.ReadKey();
        }
    }
}
