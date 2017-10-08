using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VI_PATH
{
    class Knoten
    {
        public int[] dad;
        public int distance;
        // 0 = nothing 1 = Obstacle 2 = Start 3 = Finish 
        public int state;
        public int[] pos;
        public bool visited = false;
        public Knoten(int x, int y)
        {
            pos = new int[2];
            pos[0] = x;
            pos[1] = y;
            state = 0;
            distance = 999;
            dad = new int[2];
            dad[0] = 0;
            dad[1] = 0;
        }
    }
}
