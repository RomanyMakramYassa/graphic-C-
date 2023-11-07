using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace romany_graphics
{
    public partial class CERCLE : Form
    {
        public CERCLE()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            dataGridView1.ColumnCount = 8;
            dataGridView1.Columns[0].Name = "k";
            dataGridView1.Columns[1].Name = "p1k";
            dataGridView1.Columns[2].Name = "xk+1";
            dataGridView1.Columns[3].Name = "yk+1";
            dataGridView1.Columns[4].Name = "(x;y)";
            dataGridView1.Columns[5].Name = "(-x;y)";
            dataGridView1.Columns[6].Name = "(x:-y)";
            dataGridView1.Columns[7].Name = "(-x:-y)";
            int xcentre = pictureBox1.Width / 2;
            int ycentre = pictureBox1.Height / 2;
            int r = int.Parse(textBox1.Text);
            Bitmap pc = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            int x = r, y = 0;
            int p0 = 1 - r;
            int P = p0;
            dataGridView1.Rows.Add(0, P, x, y, "(" + x + ":" + y + ")", "(" + -x + ":" + y + ")", "(" + x + ":" + -y + ")", "(" + -x + ":" + -y + ")");
            int c = 1;
            while (x > y)
            {
                pc.SetPixel(xcentre + x, ycentre + y, Color.Red);
                pc.SetPixel(xcentre - x, ycentre + y, Color.DarkBlue);
                pc.SetPixel(xcentre + x, ycentre - y, Color.Red);
                pc.SetPixel(xcentre - x, ycentre - y, Color.DarkBlue);
                pc.SetPixel(xcentre + y, ycentre + x, Color.Red);
                pc.SetPixel(xcentre - y, ycentre + x, Color.DarkBlue);
                pc.SetPixel(xcentre + y, ycentre - x, Color.Red);
                pc.SetPixel(xcentre - y, ycentre - x, Color.DarkBlue);
                if (P <= 0)
                {
                    y++;
                    P = P + 2 * (y + 1) + 1;
                    dataGridView1.Rows.Add(c++, P, x, y, "(" + x + ":" + y + ")", "(" + -x + ":" + y + ")", "(" + x + ":" + -y + ")", "(" + -x + ":" + -y + ")");
                }
                else
                {
                    x--;
                    y++;
                    P = P + 2 * (y + 1) - 2 * (x - 1) + 1;
                    dataGridView1.Rows.Add(c++, P, x, y, "(" + x + ":" + y + ")", "(" + -x + ":" + y + ")", "(" + x + ":" + -y + ")", "(" + -x + ":" + -y + ")");
                }

            }
            pictureBox1.Image = pc;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            pictureBox1.Image = null;
            textBox1.Text = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f2 = new Form1();
            f2.Show();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        // transfer
        private void button4_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            int tx = int.Parse(txttx.Text);
            int ty = int.Parse(txtty.Text);
            int xc = (pictureBox1.Width / 2) + tx;
            int yc = (pictureBox1.Height / 2) + ty;

            int x = 0, p0, y;

            int r = int.Parse(textBox1.Text);
            y = r;
            p0 = (5 / 4) - r;

            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            while (x <= y)
            {
                ((Bitmap)pictureBox1.Image).SetPixel((xc + x), (yc + y), Color.Red);
                ((Bitmap)pictureBox1.Image).SetPixel((xc - x), (yc + y), Color.DarkBlue);
                ((Bitmap)pictureBox1.Image).SetPixel((xc + x), (yc - y), Color.Red);
                ((Bitmap)pictureBox1.Image).SetPixel((xc - x), (yc - y), Color.DarkBlue);
                ((Bitmap)pictureBox1.Image).SetPixel((xc + y), (yc + x), Color.Red);
                ((Bitmap)pictureBox1.Image).SetPixel((xc - y), (yc + x), Color.DarkBlue);
                ((Bitmap)pictureBox1.Image).SetPixel((xc + y), (yc - x), Color.Red);
                ((Bitmap)pictureBox1.Image).SetPixel((xc - y), (yc - x), Color.DarkBlue);


                if (p0 < 0)
                {
                    x++;
                    p0 = p0 + (2 * x) + 1;

                }
                else
                {
                    x++;
                    y--;
                    p0 = p0 + (2 * x) + 1 - (2 * y);
                }
            }
        }
        // sumary this mouse handleing 
        public int xd1, yd1, xd2, yd2, broj = 0;
        public Color boji = Color.Black;
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {

            Graphics gr = pictureBox1.CreateGraphics();
            Pen ol = new Pen(boji, 3);
            if (broj % 3 == 0)
            {
                xd1 = e.X;
                yd1 = e.Y;

            }
            else if (broj % 3 == 1)
            {
                xd2 = e.X;
                yd2 = e.Y;
                gr.DrawLine(ol, xd1, yd1, xd2, yd2);
            }
            // else if (broj % 3 == 2) 
            //  {
            ////    xd3 = e.X;
            //  yd3 = e.Y;

            //gr.DrawLine(ol, xd1, yd1, xd3, yd3);
            //gr.DrawLine(ol, xd2, yd2, xd3, yd3);
            //}
            broj++;
        }
        // scale 
        private void button5_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            int s = int.Parse(sr.Text);
            int xc = (pictureBox1.Width / 2) ;
            int yc = (pictureBox1.Height / 2) ;

            int x = 0, p0, y=1;

            
            int r = int.Parse(textBox1.Text);
            r = r * s;
            y = r;

            p0 = (5 / 4) - r;
           
            
      

            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            while (x <= y)
            {
                ((Bitmap)pictureBox1.Image).SetPixel((xc + x), (yc + y), Color.Red);
                ((Bitmap)pictureBox1.Image).SetPixel((xc - x), (yc + y), Color.DarkBlue);
                ((Bitmap)pictureBox1.Image).SetPixel((xc + x), (yc - y), Color.Red);
                ((Bitmap)pictureBox1.Image).SetPixel((xc - x), (yc - y), Color.DarkBlue);
                ((Bitmap)pictureBox1.Image).SetPixel((xc + y), (yc + x), Color.Red);
                ((Bitmap)pictureBox1.Image).SetPixel((xc - y), (yc + x), Color.DarkBlue);
                ((Bitmap)pictureBox1.Image).SetPixel((xc + y), (yc - x), Color.Red);
                ((Bitmap)pictureBox1.Image).SetPixel((xc - y), (yc - x), Color.DarkBlue);


                if (p0 < 0)
                {
                    x++;
                    p0 = p0 + (2 * x) + 1;

                }
                else
                {
                    x++;
                    y--;
                    p0 = p0 + (2 * x) + 1 - (2 * y);
                }

            }
        }
    }
}
    
