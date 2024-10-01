using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalovaniQQ_4ITC_QQMore
{
    public abstract class Shape
    {
        protected int x;
        protected int y;
        protected int width;
        protected int height;

        protected Color color;
        protected Pen pen;
        protected Brush brush;

        protected bool filled;

        protected bool highlighted;

        protected static Pen outlinePen = new Pen(Color.Black);
        protected static float outlineOffset = 4;

        public int mouseDragOffsetX;
        public int mouseDragOffsetY;

        public Shape(int x, int y, Color color, bool filled)
        {
            this.width = 100;
            this.height = 100;
            this.x = x - width/2;
            this.y = y - height/2;
            this.color = color;
            this.pen = new Pen(color, 8);
            this.brush = new SolidBrush(color);
            this.filled = filled;

            outlinePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            outlinePen.DashPattern = new float[] { 5, 5 };
        }

        public virtual void Draw(Graphics g) { 
            
            if(highlighted)
            {
                g.DrawRectangle(outlinePen, x-outlineOffset, y-outlineOffset, width+2*outlineOffset, height+2*outlineOffset);
            }
        }

        public abstract bool IsMouseOver(int mx, int my);

        public abstract void DoYourThing();
        public void Highlight(bool shouldBe) {
            this.highlighted = shouldBe;
        }

        internal void SetMouseDragOffset(int mouseX, int mouseY)
        {
            this.mouseDragOffsetX = mouseX - this.x;
            this.mouseDragOffsetY = mouseY - this.y;
        }

        internal void SetPosition(int x, int y)
        {
            this.x = x - mouseDragOffsetX;
            this.y = y - mouseDragOffsetY;
        }
    }
}
