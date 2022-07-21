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
        public int topPosition { get ; set ; }
        public int leftPosition { get ;  set ; }
        public int[,] Positions;
        public int rotated { get ;  set ; } // starting in 0 and ending in 3
        public TheGame game;

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
        
        public bool CanItBeThere(int[,] pos)
        {
            if (leftPosition == 0)
                return false;
            for (int i = 0; i < 3; i++)
            {
                for (int x = 0; x < 3; x++)
                {
                    if (pos[i, x] != 0 && game.positions[leftPosition , topPosition ] != null)
                        return false;
                }
            }
            return true;
        }

        public bool CanItGoLeft()
        {
            leftPosition -= 1;
            try
            {
                if (!CanItBeThere(Positions))
                    leftPosition += 1;
                else
                {
                    leftPosition += 1;
                    return true;
                }
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                leftPosition += 1;
            }
            catch(IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                leftPosition += 1;
            }
            return false;
        }

        public bool CanItGoRight()
        {
            leftPosition += 1;
            try
            {
                if (!CanItBeThere(Positions))
                    leftPosition -= 1;
                else
                {
                    leftPosition -= 1;
                    return true;
                }
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                leftPosition -= 1;
            }
            return false;
        }
 
        abstract public bool CanItRotate(bool direction);

        abstract public void Rotate(bool direction); //true -> left, false ->right
        abstract public void Spawn();
        abstract public bool CanItGoThere();
        public void WriteItOut(int curx,int cury)
        {
            int x = curx, y = cury;
            Console.SetCursorPosition(x, y);
            for (int i = 0; i < Positions.GetLength(0); i++)
            {
                for (int k = 0; k < Positions.GetLength(1); k++)
                {
                    if (Positions[i, k] == 1)
                        Console.Write("*");

                    x++;
                    Console.SetCursorPosition(x, y);
                }
                x = curx;
                y++;
                Console.SetCursorPosition(x, y);
            }
        }
        public void MovingRight()
        {
            if (CanItGoRight())
                leftPosition++;
        }
        public void MovingLeft()
        {
            if(CanItGoLeft())
                leftPosition--;
        }
        public void CleanMap(int x, int y)
        {
            int sx = x, sy = y;
            for (int i = 0; i < 3; i++)
            {
                for (int s = 0; s < 3; s++)
                {
                    Console.SetCursorPosition(sx, sy);
                    Console.Write(" ");
                    sx++;
                }
                sx = x;
                sy++;
                Console.SetCursorPosition(sx, sy);
            }
        }
    }
}
