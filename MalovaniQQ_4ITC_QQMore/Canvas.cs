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
        public event Action ShapesChanged;

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
            ShapesChanged?.Invoke();
            Invalidate();
        }

        public void ClearShapes()
        {
            shapes.Clear();
            ShapesChanged?.Invoke();
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

            if (holdingShape)
            {
                highlightedShape.SetPosition(e.X, e.Y);
                ShapesChanged?.Invoke();
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
            if (e.Button == MouseButtons.Left)
            {
                if (highlightedShape != null)
                {
                    holdingShape = true;
                    highlightedShape.SetMouseDragOffset(e.X, e.Y);
                }
            } else if (e.Button == MouseButtons.Right)
            {
                if(highlightedShape != null)
                {
                    SetupContextMenu();
                    contextMenuStrip1.Show(this, e.X, e.Y);
                }
            }
        }

        private void SetupContextMenu()
        {
            toFrontToolStripMenuItem.Enabled = true;
            toBackToolStripMenuItem.Enabled = true;

            if(shapes.IndexOf(highlightedShape) == 0)
            {
                toBackToolStripMenuItem.Enabled = false;
            }
            if (shapes.IndexOf(highlightedShape) == shapes.Count - 1)
            {
                toFrontToolStripMenuItem.Enabled = false;
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

        private void toFrontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (highlightedShape == null) return;

            int index = shapes.IndexOf(highlightedShape);
            index++;
            if(index < shapes.Count)
            {
                shapes.Remove(highlightedShape);
                shapes.Insert(index, highlightedShape);
                ShapesChanged?.Invoke();
                Invalidate();
            }
        }

        private void toBackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (highlightedShape == null) return;

            int index = shapes.IndexOf(highlightedShape);
            index--;
            if (index >= 0)
            {
                shapes.Remove(highlightedShape);
                shapes.Insert(index, highlightedShape);
                ShapesChanged?.Invoke();
                Invalidate();
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(highlightedShape != null)
            {
                shapes.Remove(highlightedShape);
                highlightedShape = null;
                ShapesChanged?.Invoke();
                Invalidate();
            }
        }

        internal void HighlightShape(Shape shape, bool enable)
        {
            highlightedShape = shape;
            highlightedShape.Highlight(enable);
            Invalidate();
        }

        internal void SetActive(Shape shape, bool enable)
        {
            shape.SetActive(enable);
            Invalidate();
        }
    }
}
