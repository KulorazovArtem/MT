using System.Net.WebSockets;
using System.Xml.Linq;

namespace MT
{
    public partial class Form1 : Form
    {
        private int count_tracks = 2;
        private int[] text;
        
        private string FolderPath;
        private string FilePath;

        public int CountTracks => count_tracks;
        public Form1()
        {
            InitializeComponent();
            
            comboBox1.SelectedIndex = 0;
            //var name_file = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"top.{comboBox1.SelectedItem.ToString()}");
            //if (File.Exists(name_file) == false)
            //{
            //    label1.Text = "ffff";
            //    MessageBox.Show("jjjjj");
            //}
            //else
            //{
            //    label1.Text = "rrrrr";
            //}

            Label cellLabel = new Label
            {
                Text = "Текст в ячейке",
                Dock = DockStyle.Fill
            };
            tableLayoutPanel1.Controls.Add(cellLabel, 0, 0);
           

        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            string selectedText = comboBox1.SelectedItem.ToString();
            var name_file = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"top.{comboBox1.SelectedItem.ToString()}");
            if (File.Exists(name_file) == false || text == null)
            {
                tableLayoutPanel1.Visible = false;
                label3.Location = new Point(145, 250);
                label3.Text = "У вас нет результатов";
            }
           
            int[] yy = new int[] { 12, 34, 6, 87, 40 };
            if (selectedText == "JSON")
            {
                var rr = new JSON_SerializerList();
                rr.Serialize("top", yy);
                text = rr.Deserialize($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/top");
                
            }
            else // XML
            {
                var rr = new XML_SerializerList();
                rr.Serializer_top_10("top", yy);
                text = rr.Deserialize($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/top");
                
            }
        }
        public void SelectFolder(string path)
        {
            if (path == null) return;
            if (Directory.Exists(path) == false)
            {
                Directory.CreateDirectory(path);
            }
            FolderPath = path;
        }
        public void SelectFile(string name, string extension)
        {
            if (name == null || FolderPath == null) return;
            var name_file = Path.Combine(FolderPath, $"{name}.{extension}");
            if (File.Exists(name_file) == false)
            {
                File.Create(name_file).Close();
            }
            FilePath = name_file;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label2.Text = trackBar1.Value.ToString();
            count_tracks = int.Parse(trackBar1.Value.ToString());

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
