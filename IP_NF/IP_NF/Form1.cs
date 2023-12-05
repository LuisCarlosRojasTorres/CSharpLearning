using AForge.Video;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IP_NF
{
    public partial class Form1 : Form
    {
        MJPEGStream videostream;

        public Form1()
        {
            InitializeComponent();
            this.videostream = new MJPEGStream("http://192.168.15.102:8080/video?1280x720.mjpg");
            //this.videostream = new MJPEGStream("http://185.18.130.194:8001/mjpg/video.mjpg");
            
            this.videostream.NewFrame += GetNewFrameAtSomeFPS;

        }


        
        private void GetNewFrameAtSomeFPS(object sender, NewFrameEventArgs e)
        {
            Bitmap bmp = (Bitmap)e.Frame.Clone();
            pictureBox1.Image = bmp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            videostream.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            videostream.Stop();
        }


    }
}
