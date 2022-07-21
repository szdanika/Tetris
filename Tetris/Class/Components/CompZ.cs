using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Interfaces;

namespace Tetris.Class.Components
{
    internal class CompZ : Component
    {
        int[,] pos0 = new int[,] { { 1, 1, 0 }, { 0, 1, 1 }, { 0, 0, 0 } };
        int[,] pos1 = new int[,] { { 0, 0, 1 }, { 0, 1, 1 }, { 0, 1, 0 } };
        public CompZ(componentType type) : base(type)
        {
            Positions = pos0; // Starter Z starting in 0,0 and ending in 2,2 (We dont use the last row here)
            topPosition = TheGame.startingHeight;
            leftPosition = TheGame.startingWidth;
        }


        public override bool CanItGoThere()
        {
            throw new NotImplementedException();
        }

        public override bool CanItRotate(bool direction)
        {
            int temp = rotated;
            if (direction == false)
                temp += 1;
            else
                temp -= 1;

            switch(temp)
            {
                case 0: return CanItBeThere(pos0);
                case 1: return CanItBeThere(pos1);
                case -1: return CanItBeThere(pos1);
                case 2: return CanItBeThere(pos0);
            }
            return true;
        }

        public override void Rotate(bool direction)
        {
            //ResetPositions(); It's just works so i let it be
            if(CanItRotate(direction))
            {
                if(direction == false)
                    base.rotated += 1;
                else
                    base.rotated -= 1;
            }
            switch(base.rotated)
            {
                case 0:
                    Positions = pos0;
                    break;
                case 1: 
                    Positions = pos1;
                    break;
                case -1:
                    Positions = pos1;
                    rotated = 1;
                    break;
                case 2:
                    Positions = pos0;
                    rotated = 0;
                    break;
            }
        }

        public override void Spawn()
        {
            Console.SetCursorPosition(TheGame.startingWidth, TheGame.startingHeight);
            CleanMap(TheGame.startingWidth, TheGame.startingHeight);
            Console.SetCursorPosition(TheGame.startingWidth, TheGame.startingHeight);
            WriteItOut(TheGame.startingWidth, TheGame.startingHeight);
        }

    }
}
