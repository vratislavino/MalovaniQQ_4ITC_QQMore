namespace MalovaniQQ_4ITC_QQMore
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CreateShape();
        }

        private void CreateShape()
        {
            canvas1.AddShape(new Circle(canvas1.Width / 2, canvas1.Height / 2, button1.BackColor, checkBox1.Checked));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                button1.BackColor = colorDialog1.Color;
            }
        }
    }
}
