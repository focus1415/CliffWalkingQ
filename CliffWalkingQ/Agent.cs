using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CliffWalkingQ
{
    internal class Agent
    {
        private Enviroment environment;
        private Tile currentTile;
        private Random random;
        private double learningRate = 0.1;
        private double discountFactor = 0.9;
        private double explorationProbability = 0.2;

        public Agent(Enviroment env)
        {
            environment = env;
            currentTile = environment.GetTile(0, 5); 
            random = new Random();
        }

        public void Learn(int round)
        {
            int win = 0, lose = 0;
            for (int i = 0; i < round; i++)
            {
                Console.WriteLine("----------Round" + i + "----------");
                currentTile = environment.GetTile(0, 5); 
                while (!currentTile.IsGoal&& !currentTile.IsCliff)
                {
                    int action = ChooseAction();
                    Tile nextTile = TakeAction(action);
                    UpdateQValues(action, nextTile);
                    currentTile = nextTile;
                    this.Wind();
                    if (currentTile.IsCliff) { 
                        Console.WriteLine("Fell of Cliff!!!");
                        lose++;
                    }

                    if (currentTile.IsGoal) {
                        Console.WriteLine("Got a Goal!!!");
                        win++;
                    }
                        
                }
                Console.WriteLine("--------------------------");
            }
            Console.WriteLine("win : " + win + " lose : " + lose);
        }

        private int ChooseAction()
        {
            if (random.NextDouble() < explorationProbability)
            {
                return random.Next(4); 
            }
            else
            {
                
                double maxQ = double.MinValue;
                int bestAction = -1;
                for (int i = 0; i < 4; i++)
                {
                    if (currentTile.QValues[i] > maxQ)
                    {
                        maxQ = currentTile.QValues[i];
                        bestAction = i;
                    }
                }
                return bestAction;
            }
        }

        private Tile TakeAction(int action)
        {
            int newX = currentTile.X;
            int newY = currentTile.Y;

            switch (action)
            {
                case 0: newY = Math.Max(0, newY - 1); 
                        break; 
                case 1: newY = Math.Min(5, newY + 1); 
                        break; 
                case 2: newX = Math.Max(0, newX - 1); 
                        break; 
                case 3: newX = Math.Min(5, newX + 1); 
                        break; 
            }

            return environment.GetTile(newX, newY);
        }

        private void UpdateQValues(int action, Tile nextTile)
        {
            double maxNextQ = double.MinValue;
            for (int i = 0; i < 4; i++)
            {
                if (nextTile.QValues[i] > maxNextQ)
                {
                    maxNextQ = nextTile.QValues[i];
                }
            }

            currentTile.QValues[action] += learningRate * (GetReward(nextTile) + discountFactor * maxNextQ - currentTile.QValues[action]);
        }

        private double GetReward(Tile tile)
        {
            if (tile.IsGoal) return 100;
            if (tile.IsCliff) return -100;
            return 0;
        }

        private void Wind()
        {
            if(currentTile.X >= 1 && currentTile.X <= 4 && currentTile.Y == 5)
            {

                if (random.Next(100) <= 10)
                {
                    Tile nextTile = TakeAction(3);
                    UpdateQValues(3, nextTile);
                    currentTile = nextTile;
                }
            }
        }
    }
}
