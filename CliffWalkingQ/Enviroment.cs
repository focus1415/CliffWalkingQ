using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CliffWalkingQ
{
    internal class Enviroment
    {
        private Tile[,] grid;
        private int gridSize = 6;

        public Enviroment()
        {
            grid = new Tile[gridSize, gridSize];
            for (int x = 0; x < gridSize; x++)
            {
                for (int y = 0; y < gridSize; y++)
                {
                    grid[x, y] = new Tile(x, y);
                }
            }
        }

        public Tile GetTile(int x, int y)
        {
            return grid[x, y];
        }
    }
}
