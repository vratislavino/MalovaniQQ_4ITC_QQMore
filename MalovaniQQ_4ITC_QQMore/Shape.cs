using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalovaniQQ_4ITC_QQMore
{
    [Serializable]
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
        private bool showNames = false;
        private static Font assFont;
        private static Font typeFont;

        public Shape(int x, int y, Color color, bool filled)
        {
            this.width = 100;
            this.height = 100;
            this.x = x - width/2;
            this.y = y - height/2;
            this.color = color;
            this.filled = filled;

            InitRuntimeValues();
        }

        public Shape(ShapeDTO dto)
        {
            this.x = dto.x;
            this.y = dto.y;
            this.width = dto.width;
            this.height = dto.height;
            this.color = Color.FromArgb(dto.r, dto.g, dto.b);
            this.filled = dto.filled;
            InitRuntimeValues();
        }

        private void InitRuntimeValues()
        {
            this.pen = new Pen(color, 8);
            this.brush = new SolidBrush(color);
            assFont = new Font("Arial", 10, FontStyle.Regular);
            typeFont = new Font("Arial", 11, FontStyle.Bold);
            outlinePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            outlinePen.DashPattern = new float[] { 5, 5 };
        }

        public virtual void Draw(Graphics g) { 
            
            if(highlighted)
            {
                g.DrawRectangle(outlinePen, x-outlineOffset, y-outlineOffset, width+2*outlineOffset, height+2*outlineOffset);
            }
            if(showNames)
                DrawName(g);
        }

        public void ShowNames(bool show)
        {
            this.showNames = show;
        }

        private void DrawName(Graphics g)
        {
            string assText= GetType().Assembly.GetName().Name;
            string typeText = GetType().Name;   
            SizeF assSize = g.MeasureString(assText, assFont);
            SizeF typeSize = g.MeasureString(typeText, typeFont);
            

            g.DrawString(assText, assFont, Brushes.DarkGray, x + width/2 - assSize.Width/2, y+height);
            g.DrawString(typeText, assFont, Brushes.Black, x + width/2 - typeSize.Width/2, y+height+assSize.Height + 2);
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

        public ShapeDTO GetDTO()
        {
            return new ShapeDTO(this);
        }

        [Serializable]
        public class ShapeDTO
        {
            public int x;
            public int y;
            public int width;
            public int height;
            public int r;
            public int g;
            public int b;
            public bool filled;

            public string type;

            public ShapeDTO()
            {
            }

            public ShapeDTO(Shape s)
            {
                this.x = s.x;
                this.y = s.y;
                this.width = s.width;
                this.height = s.height;
                this.r = s.color.R;
                this.g = s.color.G;
                this.b = s.color.B;
                this.filled = s.filled;
                this.type = s.GetType().FullName;
            }
        }
    }
}
