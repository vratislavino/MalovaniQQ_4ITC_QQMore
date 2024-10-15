using System;
using System.Reflection;

namespace MalovaniQQ_4ITC_QQMore
{
    public partial class Form1 : Form
    {
        SaveLoadManager saveLoadManager = new SaveLoadManager();
        Dictionary<string, Assembly> assemblies = new Dictionary<string, Assembly>();

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
            var shapeType = comboBox1.SelectedItem as Type;
            if (shapeType == null) return;

            var newShape = Activator.CreateInstance(
                shapeType,
                canvas1.Width / 2,
                canvas1.Height / 2,
                button1.BackColor,
                checkBox1.Checked
                ) as Shape;

            canvas1.AddShape(newShape);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                button1.BackColor = colorDialog1.Color;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            canvas1.ClearShapes();
        }
        int a = 5;
        private void Form1_Load(object sender, EventArgs e)
        {
            Assembly a = Assembly.GetExecutingAssembly();
            LoadShapesFromAssembly(a);
            comboBox1.SelectedIndex = 0;


            var assies = saveLoadManager.GetAssembliesFromAppDataFolder();
            assies.ForEach(a => LoadShapesFromAssembly(a));
        }

        private async void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                toolStripStatusLabel1.Visible = true;
                loadToolStripMenuItem.Visible = true;
                var path = sfd.FileName;
                saveLoadManager.SaveShapes(path, canvas1.Shapes, () =>
                {
                    toolStripStatusLabel1.Visible = false;
                    loadToolStripMenuItem.Visible = false;
                });
            }
        }

        private async void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var path = ofd.FileName;
                canvas1.ClearShapes();
                var loadedShapes = await saveLoadManager.LoadShapes(path, assemblies);
                loadedShapes.ForEach(s => canvas1.AddShape(s));
            }
        }

        private async void addMoreShapesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "C:\\Users\\vrati\\source\\repos\\MalovaniQQ_4ITC_QQMore\\MyNewShapes\\bin\\Debug\\net8.0-windows";
            ofd.Filter = "Shapes library|*.dll";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var path = ofd.FileName;
                var filename = ofd.FileName.Split('\\').Last();
                saveLoadManager.CopyDllToAppFolder(path, filename);
                LoadShapesFromAssembly(Assembly.LoadFile(path));
            }
        }

        private void LoadShapesFromAssembly(Assembly ass)
        {
            var types = ass.GetTypes();
            var filtered = types.ToList().Where(t => t.IsSubclassOf(typeof(Shape)));
            filtered.ToList().ForEach(t => {
                assemblies.Add(t.FullName, ass);
                comboBox1.Items.Add(t); 
            });

        }
    }
}
