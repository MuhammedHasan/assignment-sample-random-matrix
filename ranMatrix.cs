using System;
using System.Collections.Generic;
using System.Linq;

namespace ranMatrix
{
    class RanMatrix
    {
        public int[,] Matrix { get; set; }
        public int CurrentValueRow { get; set; }
        public int CurrentValueCol { get; set; }
        public RanMatrix()
        {
            this.Matrix = new int[20, 20];

            var random = new Random();
            for (int i = 0; i < this.Matrix.GetLength(0); i++)
                for (int j = 0; j < this.Matrix.GetLength(1); j++)
                    this.Matrix[i, j] = random.Next(10, 100);

            this.CurrentValueCol = random.Next(0, 20);
            this.CurrentValueRow = 0;
        }

        public void ConsoleWrite()
        {
            for (int i = 0; i < this.Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < this.Matrix.GetLength(1); j++)
                    Console.Write("{0} ", this.Matrix[i, j]);
                Console.WriteLine();
            }
        }

        public int Next()
        {
            if (this.CurrentValueRow == 20)
                return -1;

            int curr = this.Matrix[this.CurrentValueRow, this.CurrentValueCol];

            if (this.CurrentValueRow == 19)
            {
                this.CurrentValueRow++;
                return curr;
            }

            this.CurrentValueRow++;
            
            switch (this.MaxNeighbour())
            {
                case 0:
                    break;
                case 1:
                    this.CurrentValueCol++;
                    break;
                case 2:
                    this.CurrentValueCol--;
                    break;
            }
            return curr;
        }

        private int[] GetNeighbour()
        {
            int[] neighbour = { -1, -1, -1 };
            neighbour[0] = this.Matrix[this.CurrentValueRow, this.CurrentValueCol];

            if (this.CurrentValueCol != 19)
                neighbour[1] = this.Matrix[this.CurrentValueRow, this.CurrentValueCol + 1];
            if (this.CurrentValueCol != 0)
                neighbour[2] = this.Matrix[this.CurrentValueRow, this.CurrentValueCol - 1];
            return neighbour;
        }
        
        private int MaxNeighbour(){
            int[] neighbour = this.GetNeighbour();
            int maxIndex = neighbour.ToList().IndexOf(neighbour.Max());
            return maxIndex;
        }
    }
}