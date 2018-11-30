using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    class Point
    {
        public int x;
        public int y;
        public Point(int xpos, int ypos)
        {
            x = xpos;
            y = ypos;
        }

        static public bool operator==(Point t, Point other)
        {
            return ((t.x == other.x) && (t.y == other.y));
        }
        static public bool operator !=(Point t, Point other)
        {
            return !((t.x == other.x) && (t.y == other.y));
        }
    }
}
