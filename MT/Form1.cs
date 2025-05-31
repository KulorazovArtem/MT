namespace MT
{
    public partial class Form1 : Form
    {
        private int count_tracks = 2;
        private string FolderPath;
        private string FilePath;

        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;


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
            comboBox1.SelectedIndex = 0;
            string selectedText = comboBox1.SelectedItem.ToString();                
            
            if(selectedText == "JSON")
            {
                
            }
            else // XML
            {

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
