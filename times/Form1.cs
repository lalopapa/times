using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace times
{
    public partial class Form1 : Form
    {
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        private int timer2Counter = 0;

        private void bgColorToggle()
        {
            if (label1.BackColor == System.Drawing.Color.Black)
            {
                label1.BackColor = System.Drawing.Color.Gray;
            }
            else
            {
                label1.BackColor = System.Drawing.Color.Black;
            }
        }
        
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //progressBar1.Increment(34);
            this.TopLevel = true;
            this.TopMost = true;
            //this.Show(Form1);
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left){
                dragging = true;
                dragCursorPoint = Cursor.Position;
                dragFormPoint = this.Location;
                System.Diagnostics.Debug.WriteLine("Good evening.");
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < progressBar1.Maximum)
            {
                progressBar1.Increment(17);
            }
            else
            {
                timer1.Stop();
                progressBar1.Visible = false;
                progressBar1.Value = progressBar1.Minimum;

                //label1.Width = 72;
                //label1.Height = 72;
                
                label1.Visible = true;
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C:\Users\Jahrvis\Documents\C#\times\times\sounds\tik_tak.wav");
                player.Play();
                timer2Counter = 0;
                timer2.Start();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            bgColorToggle();
            if (timer2Counter < 2)
            {
                //label1.Width += 5;
                //label1.Height += 5;
                //label1.BackColor = System.Drawing.Color.Gray;
                //label1.BackColor = System.Drawing.Color.Black;
                /*if (timer2Counter == 0)
                {
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C:\Users\Jahrvis\Documents\C#\times\times\sounds\tik_tak.wav");
                    player.Play();
                }*/
                timer2Counter++;
            }
            else
            {
                
                timer2.Stop();
                progressBar1.Visible = true;
                label1.Visible = false;
                timer1.Start();

            }
        }
    }
}
