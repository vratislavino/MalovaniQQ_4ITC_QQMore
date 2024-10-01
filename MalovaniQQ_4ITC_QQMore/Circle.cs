using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalovaniQQ_4ITC_QQMore
{
    public class Circle : Shape
    {
        public Circle(int x, int y, Color color, bool filled) : base(x, y, color, filled)
        {
        }

        public override void Draw(Graphics g)
        {
            if(filled)
            {
                g.FillEllipse(brush, x, y, width, height);
            } else
            {
                g.DrawEllipse(pen, x, y, width, height);
            }
            base.Draw(g);
        }

        public override void DoYourThing()
        {
            throw new NotImplementedException();
        }

        public override bool IsMouseOver(int mx, int my)
        {
            int a  = (mx - (x + (width / 2)));
            int b  = my - (y + (height / 2));
            return Math.Sqrt(a * a + b * b) < width / 2;
        }
    }
}
