using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Net.Mime.MediaTypeNames;

namespace Stopwatch
{
    public partial class Form1 : Form
    {
        private DateTime startTime;
        private TimeSpan elapsedTime;
        private List<ImageList> images;
        
        public Form1()
        {
            InitializeComponent();

            images = new List<ImageList>()
            {
                Properties.Resources.image1,
                Properties.Resources.image2,
                Properties.Resources.image3
            };

        }

        private int currentImageIndex = 0;
        private DateTime lastImageChangeTime;

        private void timer1_Tick(object sender, EventArgs e)
        {
            elapsedTime = DateTime.Now - startTime;
            label1.Text = elapsedTime.ToString(@"mm\:ss\.f");

            if (DateTime.Now -lastImageChangeTime > TimeSpan.FromSeconds(5))
            {
                

                currentImageIndex++;
                if (currentImageIndex >= images.Count)
                {
                    currentImageIndex = 0;
                }
                this.BackgroundImage = images[currentImageIndex];

                lastImageChangeTime = DateTime.Now;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(timer1.Enabled)
            {
                timer1.Stop();
                button1.Text = "Пуск";
            }
            else
            {
                startTime = DateTime.Now - elapsedTime;
                timer1.Start();
                button1.Text = "Стоп";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            elapsedTime = TimeSpan.Zero;
            label1.Text = "00:00.0";
            button1.Text = "Пуск";

        }
    
    }
}
