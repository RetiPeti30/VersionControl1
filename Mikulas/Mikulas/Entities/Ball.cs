using Mikulas.Abstraction;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mikulas.Entities
{
    public class Ball : Toy
    {
       

        protected override void DrawImage(Graphics graphics)
        {
            graphics.FillEllipse(new SolidBrush(Color.Blue), 0, 0, Width, Height);
        }

        
    }
}
