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
        public CompZ(componentType type) : base(type)
        {
        }

        public override bool CanItGoLeft()
        {
            throw new NotImplementedException();
        }

        public override bool CanItGoRight()
        {
            throw new NotImplementedException();
        }

        public override bool CanItRotate(bool direction)
        {

            throw new NotImplementedException();
        }

        public override void Rotate(bool direction)
        {
            if(CanItRotate(direction))
            {

            }
        }
    }
}
