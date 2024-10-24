namespace MalovaniQQ_4ITC_QQMore
{
    partial class Canvas
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            contextMenuStrip1 = new ContextMenuStrip(components);
            moveToolStripMenuItem = new ToolStripMenuItem();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            toFrontToolStripMenuItem = new ToolStripMenuItem();
            toBackToolStripMenuItem = new ToolStripMenuItem();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { moveToolStripMenuItem, deleteToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(211, 80);
            // 
            // moveToolStripMenuItem
            // 
            moveToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toFrontToolStripMenuItem, toBackToolStripMenuItem });
            moveToolStripMenuItem.Name = "moveToolStripMenuItem";
            moveToolStripMenuItem.Size = new Size(210, 24);
            moveToolStripMenuItem.Text = "Move";
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(210, 24);
            deleteToolStripMenuItem.Text = "Delete";
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            // 
            // toFrontToolStripMenuItem
            // 
            toFrontToolStripMenuItem.Name = "toFrontToolStripMenuItem";
            toFrontToolStripMenuItem.Size = new Size(224, 26);
            toFrontToolStripMenuItem.Text = "To front";
            toFrontToolStripMenuItem.Click += toFrontToolStripMenuItem_Click;
            // 
            // toBackToolStripMenuItem
            // 
            toBackToolStripMenuItem.Name = "toBackToolStripMenuItem";
            toBackToolStripMenuItem.Size = new Size(224, 26);
            toBackToolStripMenuItem.Text = "To back";
            toBackToolStripMenuItem.Click += toBackToolStripMenuItem_Click;
            // 
            // Canvas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BorderStyle = BorderStyle.FixedSingle;
            Name = "Canvas";
            Size = new Size(690, 453);
            Paint += Canvas_Paint;
            MouseDown += Canvas_MouseDown;
            MouseMove += Canvas_MouseMove;
            MouseUp += Canvas_MouseUp;
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem moveToolStripMenuItem;
        private ToolStripMenuItem toFrontToolStripMenuItem;
        private ToolStripMenuItem toBackToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
    }
}
