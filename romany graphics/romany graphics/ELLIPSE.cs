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
    public partial class ELLIPSE : Form
    {
        public ELLIPSE()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap pe = new Bitmap(pictureBox1.Width, pictureBox1.Height);
           // int xcenter = int.Parse(txt_x.Text);
            //int ycenter = int.Parse(txt_y.Text);
            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = 11;
            dataGridView1.Columns[0].Name = "k";
            dataGridView1.Columns[1].Name = "p1k";
            dataGridView1.Columns[2].Name = "xk+1";
            dataGridView1.Columns[3].Name = "yk+1";
            dataGridView1.Columns[4].Name = "2 ry xk+1";
            dataGridView1.Columns[5].Name = " 2 rx yK+1";
            dataGridView1.Columns[6].Name = "(x:y)";
            dataGridView1.Columns[7].Name = "(-x:y)";
            dataGridView1.Columns[8].Name = "(x:-y)";
            dataGridView1.Columns[9].Name = "(-x:-y)";
            dataGridView1.Columns[10].Name = "(-x:-y)";

            int xcenter = pictureBox1.Width / 2;
            int ycenter = pictureBox1.Height / 2;
            int rx = int.Parse(txt_rx.Text);
            int ry = int.Parse(txt_ry.Text);
             int p10 = (ry * ry) - (rx * rx) * ry + ((rx * rx) / 4);
            int x = 0, y = ry;
            int p1k = p10;
            int c = 1;
            while(2*(ry*ry)*x < 2*(rx*rx)*y)
            {
                pe.SetPixel(xcenter + x, ycenter + y, Color.Red);
                pe.SetPixel(xcenter - x, ycenter + y, Color.DarkBlue);
                pe.SetPixel(xcenter + x, ycenter - y, Color.Red);
                pe.SetPixel(xcenter - x, ycenter - y, Color.DarkBlue);
                if(p1k < 0)
                {
                    x++;
                    p1k = p1k + (ry * ry) * (2 * x );
                    dataGridView1.Rows.Add(c++, p1k, x, y, 2 * ry * ry * x, 2 * rx * rx * y, "(" + x + ":" + y + ")", "(" + -x + ":" + y + ")", "(" + x + ":" + -y + ")", "(" + -x + ":" + -y + ")");
                }
                else
                {
                    x++;
                    y--;
                    p1k = p1k + (ry * ry) * (2 * x ) - 2 * (rx * rx) * y;
                    dataGridView1.Rows.Add(c++, p1k, x, y, 2 * ry * ry * x, 2 * rx * rx * y, "(" + x + ":" + y + ")", "(" + -x + ":" + y + ")", "(" + x + ":" + -y + ")", "(" + -x + ":" + -y + ")");
                }
               
               
            }
            int p20=(ry*ry)*((x +(1/2))*(x +(1/2))) + (rx*rx)*((y-1)*(y-1))-((rx*rx)*(ry*ry));
            dataGridView1.Rows.Add("region2", "region2", "region2", "region2", "region2", "region2");
            int p2k=p20;
            while(y >= 0)
            {
                pe.SetPixel(xcenter + x, ycenter + y, Color.Red);
                pe.SetPixel(xcenter - x, ycenter + y, Color.DarkBlue);
                pe.SetPixel(xcenter + x, ycenter - y, Color.Red);
                pe.SetPixel(xcenter - x, ycenter - y, Color.DarkBlue);
                if(p2k >0)
                {
                    y--;
                    p2k = p2k - ((rx * rx) * (2 * y ));
                    dataGridView1.Rows.Add(c++, p2k, x, y, 2 * ry * ry * x, 2 * rx * rx * y, "(" + x + ":" + y + ")", "(" + -x + ":" + y + ")", "(" + x + ":" + -y + ")", "(" + -x + ":" + -y + ")");

                }
                else
                {
                    x++;
                    y--;
                    p2k=p2k+2*(ry*ry)*x - (rx*rx)*(2*y );
                    dataGridView1.Rows.Add(c++, p2k, x, y, 2 * ry * ry * x, 2 * rx * rx * y, "(" + x + ":" + y + ")", "(" + -x + ":" + y + ")", "(" + x + ":" + -y + ")", "(" + -x + ":" + -y + ")");
                }
                
            }
            pictureBox1.Image = pe;
        }
        // el clear 
        private void button2_Click(object sender, EventArgs e)
        {

            dataGridView1.Rows.Clear();
            pictureBox1.Image = null;
            txt_rx.Text = null;
            txt_ry.Text = null;
           
        }
     
        // elback 
        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();

        }

          public int xd1, yd1, xd2, yd2, broj = 0;
            public Color boji=Color.Black;
           
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
              // sumary this mouse handleing 
      
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
        // trans foe elipse
        private void button4_Click(object sender, EventArgs e)
        {
   pictureBox1.Image = null;
      int rx = int.Parse(txt_rx.Text);
       int ry = int.Parse(txt_ry.Text);
            int tx = int.Parse(txttx1.Text);
            int ty = int.Parse(txtty2.Text);
          int  xcenter = (pictureBox1.Width / 2) + tx;
            int ycenter = (pictureBox1.Height / 2) + ty;

            Bitmap pe = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            // int xcenter = int.Parse(txt_x.Text);
            //int ycenter = int.Parse(txt_y.Text);
          //  dataGridView1.Rows.Clear();
            //dataGridView1.ColumnCount = 11;
            /*dataGridView1.Columns[0].Name = "k";
            dataGridView1.Columns[1].Name = "p1k";
            dataGridView1.Columns[2].Name = "xk+1";
            dataGridView1.Columns[3].Name = "yk+1";
            dataGridView1.Columns[4].Name = "2 ry xk+1";
            dataGridView1.Columns[5].Name = " 2 rx yK+1";
            dataGridView1.Columns[6].Name = "(x:y)";
            dataGridView1.Columns[7].Name = "(-x:y)";
            dataGridView1.Columns[8].Name = "(x:-y)";
            dataGridView1.Columns[9].Name = "(-x:-y)";
            dataGridView1.Columns[10].Name = "(-x:-y)";
            */
           // int xcenter = pictureBox1.Width / 2;
            //int ycenter = pictureBox1.Height / 2;
           // int rx = int.Parse(txt_rx.Text);
            //int ry = int.Parse(txt_ry.Text);
            int p10 = (ry * ry) - (rx * rx) * ry + ((rx * rx) / 4);
            int x = 0, y = ry;
            int p1k = p10;
         //   int c = 1;
            while (2 * (ry * ry) * x < 2 * (rx * rx) * y)
            {   
                pe.SetPixel(xcenter + x, ycenter + y, Color.Red);
                pe.SetPixel(xcenter - x, ycenter + y, Color.DarkBlue);
                pe.SetPixel(xcenter + x, ycenter - y, Color.Red);
                pe.SetPixel(xcenter - x, ycenter - y, Color.DarkBlue);
                if (p1k < 0)
                {
                    x++;
                    p1k = p1k + (ry * ry) * (2 * x);
              //      dataGridView1.Rows.Add(c++, p1k, x, y, 2 * ry * ry * x, 2 * rx * rx * y, "(" + x + ":" + y + ")", "(" + -x + ":" + y + ")", "(" + x + ":" + -y + ")", "(" + -x + ":" + -y + ")");
                }
                else
                {
                    x++;
                    y--;
                    p1k = p1k + (ry * ry) * (2 * x) - 2 * (rx * rx) * y;
                //    dataGridView1.Rows.Add(c++, p1k, x, y, 2 * ry * ry * x, 2 * rx * rx * y, "(" + x + ":" + y + ")", "(" + -x + ":" + y + ")", "(" + x + ":" + -y + ")", "(" + -x + ":" + -y + ")");
                }


            }
            int p20 = (ry * ry) * ((x + (1 / 2)) * (x + (1 / 2))) + (rx * rx) * ((y - 1) * (y - 1)) - ((rx * rx) * (ry * ry));
            //dataGridView1.Rows.Add("region2", "region2", "region2", "region2", "region2", "region2");
            int p2k = p20;
            while (y >= 0)
            {
                pe.SetPixel(xcenter + x, ycenter + y, Color.Red);
                pe.SetPixel(xcenter - x, ycenter + y, Color.DarkBlue);
                pe.SetPixel(xcenter + x, ycenter - y, Color.Red);
                pe.SetPixel(xcenter - x, ycenter - y, Color.DarkBlue);
                if (p2k > 0)
                {
                    y--;
                    p2k = p2k - ((rx * rx) * (2 * y));
              //      dataGridView1.Rows.Add(c++, p2k, x, y, 2 * ry * ry * x, 2 * rx * rx * y, "(" + x + ":" + y + ")", "(" + -x + ":" + y + ")", "(" + x + ":" + -y + ")", "(" + -x + ":" + -y + ")");

                }
                else
                {
                    x++;
                    y--;
                    p2k = p2k + 2 * (ry * ry) * x - (rx * rx) * (2 * y);
                //    dataGridView1.Rows.Add(c++, p2k, x, y, 2 * ry * ry * x, 2 * rx * rx * y, "(" + x + ":" + y + ")", "(" + -x + ":" + y + ")", "(" + x + ":" + -y + ")", "(" + -x + ":" + -y + ")");
                }

            }
            pictureBox1.Image = pe;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            Bitmap pe = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            int sx = int.Parse(srx.Text);
            int sy = int.Parse(sry.Text);
           
            int xcenter = pictureBox1.Width / 2;
            int ycenter = pictureBox1.Height / 2;
            int rx = int.Parse(txt_rx.Text);
            int ry = int.Parse(txt_ry.Text);
            rx =rx* sx;
            ry =ry* sy;
            int p10 = (ry * ry) - (rx * rx) * ry + ((rx * rx) / 4);
            int x = 0, y = ry;
            int p1k = p10;
         //   int c = 1;
            while (2 * (ry * ry) * x < 2 * (rx * rx) * y)
            {
                pe.SetPixel(xcenter + x, ycenter + y, Color.Red);
                pe.SetPixel(xcenter - x, ycenter + y, Color.DarkBlue);
                pe.SetPixel(xcenter + x, ycenter - y, Color.Red);
                pe.SetPixel(xcenter - x, ycenter - y, Color.DarkBlue);
                if (p1k < 0)
                {
                    x++;
                    p1k = p1k + (ry * ry) * (2 * x);
                ///    dataGridView1.Rows.Add(c++, p1k, x, y, 2 * ry * ry * x, 2 * rx * rx * y, "(" + x + ":" + y + ")", "(" + -x + ":" + y + ")", "(" + x + ":" + -y + ")", "(" + -x + ":" + -y + ")");
                }
                else
                {
                    x++;
                    y--;
                    p1k = p1k + (ry * ry) * (2 * x) - 2 * (rx * rx) * y;
              //      dataGridView1.Rows.Add(c++, p1k, x, y, 2 * ry * ry * x, 2 * rx * rx * y, "(" + x + ":" + y + ")", "(" + -x + ":" + y + ")", "(" + x + ":" + -y + ")", "(" + -x + ":" + -y + ")");
                }


            }
            int p20 = (ry * ry) * ((x + (1 / 2)) * (x + (1 / 2))) + (rx * rx) * ((y - 1) * (y - 1)) - ((rx * rx) * (ry * ry));
            //dataGridView1.Rows.Add("region2", "region2", "region2", "region2", "region2", "region2");
            int p2k = p20;
            while (y >= 0)
            {
                pe.SetPixel(xcenter + x, ycenter + y, Color.Red);
                pe.SetPixel(xcenter - x, ycenter + y, Color.DarkBlue);
                pe.SetPixel(xcenter + x, ycenter - y, Color.Red);
                pe.SetPixel(xcenter - x, ycenter - y, Color.DarkBlue);
                if (p2k > 0)
                {
                    y--;
                    p2k = p2k - ((rx * rx) * (2 * y));
                    //dataGridView1.Rows.Add(c++, p2k, x, y, 2 * ry * ry * x, 2 * rx * rx * y, "(" + x + ":" + y + ")", "(" + -x + ":" + y + ")", "(" + x + ":" + -y + ")", "(" + -x + ":" + -y + ")");

                }
                else
                {
                    x++;
                    y--;
                    p2k = p2k + 2 * (ry * ry) * x - (rx * rx) * (2 * y);
                    //dataGridView1.Rows.Add(c++, p2k, x, y, 2 * ry * ry * x, 2 * rx * rx * y, "(" + x + ":" + y + ")", "(" + -x + ":" + y + ")", "(" + x + ":" + -y + ")", "(" + -x + ":" + -y + ")");
                }

            }
            pictureBox1.Image = pe;

        }
        // retuta
        private void button6_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            dataGridView1.Refresh();
            Bitmap pe = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            double ro = double.Parse(txtrot.Text);
            ro = ro * Math.PI / 180;

             double  rx = int.Parse(txt_rx.Text);
            double ry = int.Parse(txt_ry.Text);
           
            rx = (int)((rx * (Math.Cos(ro))) - (rx * Math.Sin(ro)));
            ry = (int)((ry * (Math.Cos(ro))) + (ry * Math.Sin(ro)));

            int xcenter = pictureBox1.Width / 2;
            int ycenter = pictureBox1.Height / 2;
           
            double p1k = (ry * ry) - (rx * rx) * ry + ((rx * rx) / 4);
            double  x = 0, y = ry;
            
               int c = 1;
            while (2 * (ry * ry) * x < 2 * (rx * rx) * y)
            {
                pe.SetPixel((int)Math.Round(xcenter + x),(int)Math.Round( ycenter + y), Color.Red);
                pe.SetPixel((int)Math.Round(xcenter - x), (int)Math.Round(ycenter + y), Color.DarkBlue);
                pe.SetPixel((int)Math.Round(xcenter + x), (int)Math.Round(ycenter - y), Color.Red);
                pe.SetPixel((int)Math.Round(xcenter - x),(int)Math.Round( ycenter - y), Color.DarkBlue);
                if (p1k < 0)
                {
                    x++;
                    p1k = p1k + (ry * ry) * (2 * x);
                     dataGridView1.Rows.Add(c++, p1k, x, y, 2 * ry * ry * x, 2 * rx * rx * y, "(" + x + ":" + y + ")", "(" + -x + ":" + y + ")", "(" + x + ":" + -y + ")", "(" + -x + ":" + -y + ")");
                }
                else
                {
                    x++;
                    y--;
                    p1k = p1k + (ry * ry) * (2 * x) - 2 * (rx * rx) * y;
                          dataGridView1.Rows.Add(c++, p1k, x, y, 2 * ry * ry * x, 2 * rx * rx * y, "(" + x + ":" + y + ")", "(" + -x + ":" + y + ")", "(" + x + ":" + -y + ")", "(" + -x + ":" + -y + ")");
                }


            }
            double p20 = (ry * ry) * ((x + (1 / 2)) * (x + (1 / 2))) + (rx * rx) * ((y - 1) * (y - 1)) - ((rx * rx) * (ry * ry));
            dataGridView1.Rows.Add("region2", "region2", "region2", "region2", "region2", "region2");
            double p2k = p20;
            while (y >= 0)
            {
                pe.SetPixel((int)Math.Round(xcenter + x),(int)Math.Round( ycenter + y), Color.Red);
                pe.SetPixel((int)Math.Round(xcenter - x), (int)Math.Round(ycenter + y), Color.DarkBlue);
                pe.SetPixel((int)Math.Round(xcenter + x), (int)Math.Round(ycenter - y), Color.Red);
                pe.SetPixel((int)Math.Round(xcenter - x), (int)Math.Round(ycenter - y), Color.DarkBlue);
                if (p2k > 0)
                {
                    y--;
                    p2k = p2k - ((rx * rx) * (2 * y));
                    dataGridView1.Rows.Add(c++, p2k, x, y, 2 * ry * ry * x, 2 * rx * rx * y, "(" + x + ":" + y + ")", "(" + -x + ":" + y + ")", "(" + x + ":" + -y + ")", "(" + -x + ":" + -y + ")");

                }
                else
                {
                    x++;
                    y--;
                    p2k = p2k + 2 * (ry * ry) * x - (rx * rx) * (2 * y);
                    dataGridView1.Rows.Add(c++, p2k, x, y, 2 * ry * ry * x, 2 * rx * rx * y, "(" + x + ":" + y + ")", "(" + -x + ":" + y + ")", "(" + x + ":" + -y + ")", "(" + -x + ":" + -y + ")");
                }

            }
            pictureBox1.Image = pe;
        }

       

      
      

    }
}
