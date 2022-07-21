using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Interfaces;

namespace Tetris.Class.Components
{
    internal class CompFal : Component
    {
        public CompFal(componentType type) : base(type)
        {
            topPosition = TheGame.startingHeight;
            leftPosition = TheGame.startingWidth;
        }
        public override bool CanItGoThere()
        {
            throw new NotImplementedException();
        }

        public override bool CanItRotate(bool direction)
        {
            throw new NotImplementedException();
        }

        public override void Rotate(bool direction)
        {
            throw new NotImplementedException();
        }

        public override void Spawn()
        {
            throw new NotImplementedException();
        }
    }
}
