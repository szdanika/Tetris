﻿using System;
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
        int[,] pos1 = new int[,] { { 0, 1, 0 }, { 0, 1, 1 }, { 0, 0, 1 } };
        public CompZ(componentType type) : base(type)
        {
            Positions = pos0; // Starter Z starting in 0,0 and ending in 2,2 (We dont use the last row here)
        }

        public override bool CanItGoLeft()
        {
            throw new NotImplementedException();
        }

        public override bool CanItGoRight()
        {
            throw new NotImplementedException();
        }

        public override bool CanItGoThere()
        {
            throw new NotImplementedException();
        }

        public override bool CanItRotate(bool direction)
        {

            return true;
        }

        public override void Rotate(bool direction)
        {
            ResetPositions();
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
            Console.SetCursorPosition(TheGame.startingHeight, TheGame.startingWidth);
            CleanMap(TheGame.startingHeight, TheGame.startingWidth);
            WriteItOut(TheGame.startingHeight, TheGame.startingWidth);
        }
        public void CleanMap(int x, int y)
        {
            int sx = x, sy = y;
            for (int i = 0; i < 3; i++)
            {
                for (int s = 0; s < 3; s++)
                {
                    Console.Write("");
                    x++;
                    Console.SetCursorPosition(x, y);
                }
                sx = x;
                sy++;
                Console.SetCursorPosition(x, y);
            }
        }

        public override void WriteItOut(int curx, int cury)
        {
            int x = curx, y = cury;
            for (int i = 0; i < 3; i++)
            {
                for (int k = 0; k < 3; k++)
                {
                    if (Positions[i,k] == 1)
                        Console.Write("*");

                    x++;
                    Console.SetCursorPosition(x, y );
                }
                x = curx;
                y++;
             Console.SetCursorPosition(x ,y);
            }    
        }
    }
}
