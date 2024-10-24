using MalovaniQQ_4ITC_QQMore;
using System.Drawing;

namespace MyNewShapes
{
    public class Triangle : Shape
    {
        public Triangle(int x, int y, Color color, bool filled) : base(x, y, color, filled)
        {
        }

        public Triangle(ShapeDTO dto) : base(dto) { }

        protected override void DrawShape(Graphics g)
        {
            Point[] points = new Point[3] {
                new Point(x, y + height),
                new Point(x + width, y + height),
                new Point(x + width/2, y)
            };
            if(filled)
            {
                g.FillPolygon(brush, points);
            } else
            {
                g.DrawPolygon(pen, points);
            }

            base.Draw(g);
        }

        public override void DoYourThing()
        {
            throw new NotImplementedException();
        }

        public override bool IsMouseOver(int mx, int my)
        {
            return mx >= x && mx <= x + width && my >= y && my <= y + height; 
        }
    }
}
