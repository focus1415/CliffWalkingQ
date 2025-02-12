using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CliffWalkingQ
{
    internal class Tile
    {
        public int X { get; }
        public int Y { get; }
        public double[] QValues { get; }
        public bool IsCliff { get; }
        public bool IsGoal { get; }

        public Tile(int x, int y)
        {
            X = x;
            Y = y;
            QValues = new double[4]; // 0: up, 1: down, 2: left, 3: right
            IsCliff = (x >= 1 && x <= 4 && y == 5);
            IsGoal = (x == 5 && y == 5);

            if (IsCliff)
            {
                for (int i = 0; i < QValues.Length; i++)
                {
                    QValues[i] = -100; 
                }
            }
            else if (IsGoal)
            {
                for (int i = 0; i < QValues.Length; i++)
                {
                    QValues[i] = 100; 
                }
            }
            else
            {
                for (int i = 0; i < QValues.Length; i++)
                {
                    QValues[i] = 0; 
                }
            }
        }
    }
}
