using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MalovaniQQ_4ITC_QQMore
{
    public partial class Canvas : UserControl
    {
        private List<Shape> shapes = new List<Shape>();
        public List<Shape> Shapes => shapes;

        private Shape highlightedShape;
        private bool holdingShape = false;
        private bool namesVisible = false;

        public Canvas()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        public void AddShape(Shape shape)
        {
            shapes.Add(shape);
            shape.ShowNames(namesVisible);
            Invalidate();
        }

        public void ClearShapes()
        {
            shapes.Clear();
            Invalidate();
            highlightedShape = null;
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            foreach (var shape in shapes)
            {
                shape.Draw(e.Graphics);
            }
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (shapes.Count == 0) return;

            if(holdingShape)
            {
                highlightedShape.SetPosition(e.X, e.Y);
                Invalidate();
                return;
            }

            var shape = shapes.LastOrDefault(s => s.IsMouseOver(e.X, e.Y));
            if (shape != null)
            {
                if (highlightedShape != shape)
                {
                    highlightedShape?.Highlight(false);
                    highlightedShape = shape;
                    highlightedShape.Highlight(true);
                }
            }
            else
            {
                if (highlightedShape != null)
                {
                    highlightedShape?.Highlight(false);
                    highlightedShape = null;
                }
            }

            Invalidate();
        }

        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if(highlightedShape != null)
            {
                holdingShape = true;
                highlightedShape.SetMouseDragOffset(e.X, e.Y);
            }
        }

        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (holdingShape)
            {
                holdingShape = false;
            }
        }

        public void ShowNames(bool isChecked)
        {
            namesVisible = isChecked;
            shapes.ForEach(s => s.ShowNames(isChecked));
            Invalidate();
        }
    }
}
