using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalovaniQQ_4ITC_QQMore
{
    public class Square : Shape
    {
        public Square(int x, int y, Color color, bool filled) : base(x, y, color, filled)
        {
        }

        public Square(ShapeDTO dto) : base(dto) { }

        public override void DoYourThing()
        {
            throw new NotImplementedException();
        }

        public override bool IsMouseOver(int mx, int my)
        {
            return mx >= x 
                && mx <= x + width 
                && my >= y 
                && my <= y + height;
        }

        protected override void DrawShape(Graphics g)
        {
            if (filled)
            {
                g.FillRectangle(brush, x, y, width, height);
            } else
            {
                g.DrawRectangle(pen, x, y, width, height);
            }
        }
    }
}
