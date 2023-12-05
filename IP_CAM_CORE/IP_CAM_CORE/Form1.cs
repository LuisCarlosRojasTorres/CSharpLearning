namespace IP_CAM_CORE
{
    using AForge.Video;

    public partial class Form1 : Form
    {
        MJPEGStream videostream;

        public Form1()
        {
            InitializeComponent();

            this.videostream = new MJPEGStream("http://192.168.15.102:8080/video?1280x720.mjpg");
            this.videostream.NewFrame += GetNewFrameAtSomeFPS;

        }

        private void GetNewFrameAtSomeFPS(object sender, NewFrameEventArgs e)
        {
            Bitmap bmp = (Bitmap)e.Frame.Clone();
            pictureBox1.Image = bmp;
        }

        private void button_ON_Click(object sender, EventArgs e)
        {
            videostream.Start();
        }

        private void button_OFF_Click(object sender, EventArgs e)
        {
            videostream.Stop();
        }
    }
}
