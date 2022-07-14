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
        public int rotated { get ; private set ; }

        public Component(componentType type)
        {
            this.type = type;
            topPosition = 0;
            leftPosition = 0;
            rotated = 0;
        }

        abstract public bool CanItGoLeft();

        abstract public bool CanItGoRight();

        abstract public bool CanItRotate(bool direction);

        abstract public void Rotate(bool direction); //true -> left, false ->right
    }
}
