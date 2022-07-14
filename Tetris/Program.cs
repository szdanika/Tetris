using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Class.WindowSettingSet windowSettingSet = new Class.WindowSettingSet();
            Class.TheGame theGame = new Class.TheGame();
            theGame.StartGame();

            Console.ReadKey();
        }
    }
}
