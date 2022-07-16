using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Interfaces;

namespace Tetris.Class.Components
{
    abstract internal class Component 
    {
        public componentType type { get; private set; }
        public int topPosition { get ;private set ; }
        public int leftPosition { get ; private set ; }
        public int[,] Positions;
        public int rotated { get ;  set ; } // starting in 0 and ending in 3

        public Component(componentType type)
        {
            this.type = type;
            topPosition = 0;
            leftPosition = 0;
            rotated = 0;
        }
        public void ResetPositions()
        {
            for (int i = 0; i < Positions.GetLength(0); i++)
            {
                for (int x = 0; x < Positions.GetLength(1); x++)
                {
                    Positions[i, x] = 0;
                }
            }
        }

        abstract public bool CanItGoLeft();

        abstract public bool CanItGoRight();

        abstract public bool CanItRotate(bool direction);

        abstract public void Rotate(bool direction); //true -> left, false ->right
        abstract public void Spawn();
        abstract public bool CanItGoThere();
        abstract public void WriteItOut(int curx,int cury);
    }
}
