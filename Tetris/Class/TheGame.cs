using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Tetris.Class
{
    internal class TheGame
    {
        public static int gameHight = 20;
        public static int gameWidth = 10;

        public Class.Components.Component[,] positions = new Components.Component[gameWidth, gameHight];

        public int pointsHeight = 10;
        public int pointsWidth = 15;
        public int points = 0;

        public static int startingWidth = 5; 
        public static int startingHeight = 1;


        public void StartGame()
        {
            UISetUp();
            Components.Component teszt = CreatingNewComp(Interfaces.componentType.ZComp);
            ConsoleKey key;
            teszt.game = this;
            teszt.Spawn();
            do
            {
                //teszt.CleanMap(teszt.leftPosition, teszt.topPosition);
                key = Console.ReadKey().Key;
                switch(key)
                {
                    case ConsoleKey.Q:
                        teszt.CleanMap(teszt.leftPosition, teszt.topPosition);
                        teszt.Rotate(true);
                        break;
                    case ConsoleKey.E:
                        teszt.CleanMap(teszt.leftPosition, teszt.topPosition);
                        teszt.Rotate(false);
                        break;
                    case ConsoleKey.D:
                        teszt.CleanMap(teszt.leftPosition, teszt.topPosition);
                        teszt.MovingRight();
                        break;
                    case ConsoleKey.A:
                        teszt.CleanMap(teszt.leftPosition, teszt.topPosition);
                        teszt.MovingLeft();
                        break;
                    default:
                        teszt.CleanMap(teszt.leftPosition, teszt.topPosition);
                        break;
                }
                teszt.topPosition++;
                teszt.WriteItOut(teszt.leftPosition,teszt.topPosition);
            } while (key != ConsoleKey.R);
        }
        public void Menu()
        {
            bool MadeAChoice = false;
            while(MadeAChoice == false)
            {
                Console.WriteLine("(1) Start Game (1)");
                if(Console.ReadLine() == "1")
                    MadeAChoice = true;
                else
                    Console.Clear();
            }
            StartGame();
        }
        public void UISetUp()
        {
            for(int i = 0; i < gameWidth+2; i++)
            {
                Console.SetCursorPosition(i,0);
                Console.Write("-");
                Console.SetCursorPosition(i, gameHight + 2);
                Console.Write("-");
            }
            for (int i = 1; i < gameHight+2; i++)
            {
                Console.SetCursorPosition(0,i);
                Console.Write("|");
                Console.SetCursorPosition(gameWidth + 2, i);
                Console.Write("|");
            }
            PointChange();
        }
        void PointChange()
        {
            Console.SetCursorPosition(pointsWidth, pointsHeight);
            Console.Write("U have " + points + " Points ");
        }
        Components.Component CreatingNewComp(Interfaces.componentType comType)
        {
            switch(comType)
            {
                case Interfaces.componentType.ZComp: return new Components.CompZ(comType);
                default: return null;
            }
        }

    }
}
