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

        public int[] positions = new int[gameHight * gameWidth];

        public int pointsHeight = 10;
        public int pointsWidth = 15;
        public int points = 0;

        public static int startingHeight = 5;
        public static int startingWidth = 1;


        public void StartGame()
        {
            UISetUp();
            Components.Component teszt = CreatingNewComp(Interfaces.componentType.ZComp);
            //teszt.Rotate(true);
            //teszt.Spawn();
            //ConsoleKey key;
            //teszt.Spawn();
            //Thread.Sleep(1000);
            //teszt.Rotate(true);
            //teszt.Spawn();
            ConsoleKey key;
            do
            {
                key = Console.ReadKey().Key;
                if (key == ConsoleKey.Q)
                    teszt.Rotate(true);
                else if (key == ConsoleKey.E)
                    teszt.Rotate(false);

                teszt.Spawn();
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
