using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Interfaces;

namespace Tetris.Class.Components
{
    internal class CompI : Interfaces.IComponent
    {
        public ConsoleColor componentColor { get; set; }
        public componentType type { get => componentType.IComp; set => type = value; }
        public int topPosition { get ; set ; } 
        public int leftPosition { get ; set ; }
        
        public bool rotated { get; set; }

        public bool CanItGoLeft()
        {
            throw new NotImplementedException();
        }

        public bool CanItGoRight()
        {
            throw new NotImplementedException();
        }

        public bool CanItRotate()
        {
            throw new NotImplementedException();
        }

        public void Rotate()
        {
            throw new NotImplementedException();
        }
    }   
}
