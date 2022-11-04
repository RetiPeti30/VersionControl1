using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mikulas.Entities
{
    public class BallFactory
    {
        public Ball CreateNew()
        {
            return new Ball();
        }
    }
}
