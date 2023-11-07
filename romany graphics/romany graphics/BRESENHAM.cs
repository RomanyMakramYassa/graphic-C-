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
    public partial class BRESENHAM : Form
    {
        public BRESENHAM()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x1 = int.Parse(textBox1.Text);
            int y1 = int.Parse(textBox2.Text);
            int x2 = int.Parse(textBox3.Text);
            int y2 = int.Parse(textBox4.Text);

            int xc = pictureBox1.Width / 2;
            int yc = pictureBox1.Height / 2;

            x1 += xc;
            x2 += xc;
            y1 += yc;
            y2 += yc;
            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].Name = "k";
            dataGridView1.Columns[1].Name = "pk+1";
            dataGridView1.Columns[2].Name = "x";
            dataGridView1.Columns[3].Name = "y";
            dataGridView1.Columns[4].Name = "(x:y)";
            int dy = y2 - y1;
            int dx = x2 - x1;
            Bitmap bt = new Bitmap(pictureBox1.Height, pictureBox1.Width);
            int p0 = 2 * dy - dx;
            int j = 1;
            dataGridView1.Rows.Add(j++, p0, x1, y1, "(" + x1 + ":" + y1 + ")");
          
            for (int i = 0; i < dx; i++)
            {
                if (p0 < 0)
                {
                    p0 += p0 + 2 * dy;
                   // dataGridView1.Rows.Add(j++, p0, x1, y1,"("+x1+":"+y1+")");
                }


                else if (p0 > 0)
                {
                    p0 += p0 + 2 * dy - 2 * dx;
                    y1++;
                  //  dataGridView1.Rows.Add(j++, p0, x1, y1, "(" + x1 + ":" + y1 + ")");
                }
                x1++;
                bt.SetPixel(x1, y1, Color.Red);
                dataGridView1.Rows.Add(j++, p0, x1, y1, "(" + x1 + ":" + y1 + ")");
            }


            pictureBox1.Image = bt;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            dataGridView1.Rows.Clear();
            pictureBox1.Image = null;
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f4 = new Form1();
            f4.Show();
        }
        public int xd1, yd1, xd2, yd2, broj = 0;
            public Color boji=Color.Black;
    
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
              // sumary this mouse handleing 
     //   public int xd1, yd1, xd2, yd2, broj = 0;
       //     public Color boji=Color.Black;
    
           
            Graphics gr=pictureBox1.CreateGraphics();
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

        private void button4_Click(object sender, EventArgs e)
        {
           // Bitmap p = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = null;
            int tx = int.Parse(txttx1.Text);
            int ty = int.Parse(txtty1.Text);
            int x1 = int.Parse(textBox1.Text);
            int y1 = int.Parse(textBox2.Text);
            int x2 = int.Parse(textBox4.Text);
            int y2 = int.Parse(textBox3.Text);
            int xc = pictureBox1.Width / 2;
            int yc = pictureBox1.Height / 2;

            x1 += xc;
            x2 += xc;
            y1 += yc;
            y2 += yc;

            x1 += tx;
            x2 += tx;
            y1 += ty;
            y2 += ty;
            int dy = y2 - y1;
            int dx = x2 - x1;
            Bitmap bt = new Bitmap(pictureBox1.Height, pictureBox1.Width);
            int p0 = 2 * dy - dx;
            int j = 1;
            dataGridView1.Rows.Add(j++, p0, x1, y1, "(" + x1 + ":" + y1 + ")");

            for (int i = 0; i < dx; i++)
            {
                if (p0 < 0)
                {
                    p0 += p0 + 2 * dy;
                //    dataGridView1.Rows.Add(j++, p0, x1, y1, "(" + x1 + ":" + y1 + ")");
                }


                else if (p0 > 0)
                {
                    p0 += p0 + 2 * dy - 2 * dx;
                    y1++;
                    // dataGridView1.Rows.Add(j++, p0, x1, y1, "(" + x1 + ":" + y1 + ")");
                }
                x1++;
                bt.SetPixel(x1, y1, Color.Red);
                dataGridView1.Rows.Add(j++, p0, x1, y1, "(" + x1 + ":" + y1 + ")");
            }


            pictureBox1.Image = bt;
        }
        // scaling
        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.Refresh();
            pictureBox1.Image = null;
            int sx = int.Parse(sx1.Text);
            int sy = int.Parse(sy1.Text);

            int x1 = int.Parse(textBox1.Text);
            int y1 = int.Parse(textBox2.Text);
            int x2 = int.Parse(textBox4.Text);
            int y2 = int.Parse(textBox3.Text);
             int xc = pictureBox1.Width / 2;
            int yc = pictureBox1.Height / 2;

         
            
            //x1 *= sx;
            //x2 *= sx;
            //y1 *= sy;
            //y2 *= sy;

            x1 += xc;
            x2 += xc;
            y1 += yc;
            y2 += yc;
            
            int dy = y2*sy - y1*sy;
            int dx = x2*sx - x1*sx;
            int step = Math.Max(dx, dy);
            Bitmap bt = new Bitmap(pictureBox1.Height, pictureBox1.Width);
            int p0 = 2 * dy - dx;
            int j = 1;
            dataGridView1.Rows.Add(j++, p0, x1, y1, "(" + x1 + ":" + y1 + ")");

            for (int i = 0; i < step; i++)
            {
                if (p0 < 0)
                {
                    p0 += p0 + 2 * dy;
                    x1++;
                 //   dataGridView1.Rows.Add(j++, p0, x1, y1, "(" + x1 + ":" + y1 + ")");
                }


                else if (p0 > 0)
                {
                    p0 += p0 + 2 * dy - 2 * dx;
                    y1++; 
                    x1++;
               //     dataGridView1.Rows.Add(j++, p0, x1, y1, "(" + x1 + ":" + y1 + ")");
                }


                bt.SetPixel(x1, y1, Color.Red);
                dataGridView1.Rows.Add(j++, p0, x1, y1, "(" + x1 + ":" + y1 + ")");
            }


            pictureBox1.Image = bt;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            dataGridView1.Refresh();
            double ro = double.Parse(txtrot.Text);
            ro = ro * Math.PI / 180;
            double x1 = int.Parse(textBox1.Text);
            double y1 = int.Parse(textBox2.Text);
            double x2 = int.Parse(textBox4.Text);
            double y2 = int.Parse(textBox3.Text);
            int xc = pictureBox1.Width / 2;
            int yc = pictureBox1.Height / 2;
          //  int xr1, yr1, xr2, yr2;
            x1 = (int)((x1 * Math.Cos(ro)) - (y1 * Math.Sin(ro)));
            x2 = (int)((x2 * (Math.Cos(ro))) - (y2 * Math.Sin(ro)));
            y1 = (int)((y1 * (Math.Cos(ro))) + (x1 * Math.Sin(ro)));
            y2 = (int)((y2 * (Math.Cos(ro))) + (x2 * Math.Sin(ro)));

            //x1 += xc;
            //x2 += xc;
            //y1 += yc;
            //y2 += yc;

             double dy = y2 - y1;
            double dx = x2 - x1;
            Bitmap bt = new Bitmap(pictureBox1.Height, pictureBox1.Width);
            double p0 = 2 * dy - dx;
            int j = 1;
            dataGridView1.Rows.Add(j++, p0, x1, y1, "(" + x1 + ":" + y1 + ")");

            for (int i = 0; i < dx; i++)
            {
                if (p0 < 0)
                {
                    p0 += p0 + 2 * dy;
                 //   dataGridView1.Rows.Add(j++, p0, x1, y1, "(" + x1 + ":" + y1 + ")");
                }


                else if (p0 > 0)
                {
                    p0 += p0 + 2 * dy - 2 * dx;
                    y1++;
                   // dataGridView1.Rows.Add(j++, p0, x1, y1, "(" + x1 + ":" + y1 + ")");
                }
                x1++;
                bt.SetPixel((int)Math.Round(x1+xc),(int)Math.Round( y1+yc), Color.Red);
                dataGridView1.Rows.Add(j++, p0, x1, y1, "(" + x1 + ":" + y1 + ")");
            }


            pictureBox1.Image = bt;
        }
        }

      

    }

