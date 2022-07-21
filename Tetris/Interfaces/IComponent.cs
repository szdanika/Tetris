using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Interfaces
{
    public enum componentType { IComp, JComp, LComp, OComp, SComp, TComp, ZComp, FalComp}
    internal interface IComponent
    {
        ConsoleColor componentColor { get; set; }
        componentType type { get; set; }
        int topPosition { get; set; }
        int leftPosition { get; set; }

        bool rotated { get; set; }

        void Rotate();
        bool CanItRotate();
        bool CanItGoRight();
        bool CanItGoLeft();


    }
}
