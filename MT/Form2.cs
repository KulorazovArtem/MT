using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MT
{
    public partial class Form2 : Form
    {
        private System.Windows.Forms.Timer timer;
        private int speed = 5;
        public Form2()
        {
            InitializeComponent();
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 50; // Интервал в миллисекундах (20 раз в секунду)
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Увеличиваем позицию Y (движение вниз)
            pictureBox1.Top += speed;


            // Остановка при достижении нижней границы формы
            if (pictureBox1.Bottom >= this.ClientSize.Height)
            {
                timer.Stop();
                // Можно добавить дополнительные действия при достижении низа
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer.Start();
            //pictureBox1.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
