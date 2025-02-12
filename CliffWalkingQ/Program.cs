using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CliffWalkingQ
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Enviroment environment = new Enviroment();
            Agent agent = new Agent(environment);
            agent.Learn(100);

            Console.WriteLine("Q-values for each tile:");
            for (int x = 0; x < 6; x++)
            {
                for (int y = 0; y < 6; y++)
                {
                    Tile tile = environment.GetTile(x, y);
                    Console.Write("("+x+","+y+"): ");
                    Console.Write("U:"+Math.Round(tile.QValues[0],2)+" D:"+ Math.Round(tile.QValues[1], 2) + "L:"+ Math.Round(tile.QValues[2], 2) + " R:"+ Math.Round(tile.QValues[3], 2) + " | ");
                }
                Console.WriteLine();
            }
        }

        
        
    }
}
