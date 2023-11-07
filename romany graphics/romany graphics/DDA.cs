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
    public partial class DDA : Form
    {
        public DDA()
        {
            InitializeComponent();
        }

        int x1, x2, y1, y2;
        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap p = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "k";
            dataGridView1.Columns[1].Name = "x";
            dataGridView1.Columns[2].Name = "y";
             x1 = int.Parse(textBox1.Text);
            y1 = int.Parse(textBox2.Text);
             x2 = int.Parse(textBox4.Text);
           y2 = int.Parse(textBox3.Text);
            int xc = pictureBox1.Width / 2;
            int yc = pictureBox1.Height / 2;

            x1 += xc;
            x2 += xc;
            y1 += yc;
            y2 += yc;
            int dx = x2 - x1;
            int dy = y2 - y1;
            int steps = Math.Max(Math.Abs(dx), Math.Abs(dy));
            float xi = dx / (float)steps;
            float yi = dy / (float)steps;
            p.SetPixel(x1, y1, Color.Red);
            float x = x1;
            float y = y1;
            int g = 1;
            dataGridView1.Rows.Add(g++, (int)Math.Round(x), (int)Math.Round(y));

            for (int i = 0; i < steps; i++)
            {
                x = x + xi;
                y = y + yi;
                p.SetPixel((int)Math.Round(x), (int)Math.Round(y), Color.Red);
                dataGridView1.Rows.Add(g++, (int)Math.Round(x), (int)Math.Round(y));
            }
            pictureBox1.Image = p;

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
            Form1 f3 = new Form1();
            f3.Show();
        }
        public int xd1, yd1, xd2, yd2, broj = 0;
        public Color boji = Color.Black;
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            // sumary this mouse handleing 
            //   public int xd1, yd1, xd2, yd2, broj = 0;
            //     public Color boji=Color.Black;


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
        public void drawing_dda(int x1, int x2, int y1, int y2)
        { 
            int xc = pictureBox1.Width / 2;
            int yc = pictureBox1.Height / 2;

           
            x1 += xc;
            x2 += xc;
            y1 += yc;
            y2 += yc;
            int dx = x2 - x1;
            int dy = y2 - y1;
           

            int no_of_steps;
            if (Math.Abs(dx) > Math.Abs(dy))
                no_of_steps = Math.Abs(dx);
            else
                no_of_steps = Math.Abs(dy);

            int incx = dx / no_of_steps;
            int incy = dy / no_of_steps;

            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            for (int i = 0; i < no_of_steps; i++)
            {
                ((Bitmap)pictureBox1.Image).SetPixel(( x1), (y1), Color.Teal);

                x1 += (int)(incx + 0.5);
                y1 += (int)(incy + 0.5);
            }
        }
        // transfer
        private void button4_Click(object sender, EventArgs e)
        {
            //Bitmap p = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = null;
            int tx = int.Parse(txttx1.Text);
            int ty = int.Parse(txtty1.Text);
            x1 = int.Parse(textBox1.Text);
            y1 = int.Parse(textBox2.Text);
            x2 = int.Parse(textBox4.Text);
            y2 = int.Parse(textBox3.Text);
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
          //  drawing_dda(x1, x2, y1, y2);
              Bitmap p = new Bitmap(pictureBox1.Width, pictureBox1.Height);
              int dx = x2 - x1;
              int dy = y2 - y1;
              int steps = Math.Max(Math.Abs(dx), Math.Abs(dy));
              float xi = dx / (float)steps;
              float yi = dy / (float)steps;
              p.SetPixel(x1, y1, Color.Red);
              float x = x1;
              float y = y1;
              int g = 1;
              dataGridView1.Rows.Add(g++, (int)Math.Round(x), (int)Math.Round(y));

              for (int i = 0; i < steps; i++)
              {
                  x = x + xi;
                  y = y + yi;
                  p.SetPixel((int)Math.Round(x), (int)Math.Round(y), Color.Red);
                  dataGridView1.Rows.Add(g++, (int)Math.Round(x), (int)Math.Round(y));
              }
              pictureBox1.Image = p;
        }
        // scale
        private void button5_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            int sx = int.Parse(sx1.Text);
            int sy = int.Parse(sy1.Text);

            x1 = int.Parse(textBox1.Text);
            y1 = int.Parse(textBox2.Text);
            x2 = int.Parse(textBox4.Text);
            y2 = int.Parse(textBox3.Text);
            int xc = pictureBox1.Width / 2;
            int yc = pictureBox1.Height / 2;

           

            x1 *= sx;
            x2 *= sx;
            y1 *= sy;
            y2 *= sy;
            
            
         x1 += xc;
            x2 += xc;
             y1 += yc;
             y2 += yc;
            //drawing_dda(x1, x2, y1, y2);
                Bitmap p = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                int dx = x2 - x1;
                int dy = y2 - y1;
                int steps = Math.Max(Math.Abs(dx), Math.Abs(dy));
                float xi = dx / (float)steps;
                float yi = dy / (float)steps;
                p.SetPixel(x1, y1, Color.Red);
                float x = x1;
                float y = y1;
                //int g = 1;
             //   dataGridView1.Rows.Add(g++, (int)Math.Round(x), (int)Math.Round(y));

                for (int i = 0; i < steps; i++)
                {
                    x = x + xi;
                    y = y + yi;
                    p.SetPixel((int)Math.Round(x), (int)Math.Round(y), Color.Red);
               //     dataGridView1.Rows.Add(g++, (int)Math.Round(x), (int)Math.Round(y));
                }
                pictureBox1.Image = p;
        }
        // rotate
        private void button6_Click(object sender, EventArgs e)
        {
            double ro = double.Parse(txtrot.Text);
            ro = ro * Math.PI / 180;
            int x11 = int.Parse(textBox1.Text);
            int y11 = int.Parse(textBox2.Text);
            int x22 = int.Parse(textBox4.Text);
            int y22 = int.Parse(textBox3.Text);
               int xc = pictureBox1.Width / 2;
             int yc = pictureBox1.Height / 2;
            double x1, y1, x2, y2;
            x1 = (int)((x11 * (Math.Cos(ro))) - (y11 * Math.Sin(ro)));
            x2 = (int)((x22 * (Math.Cos(ro))) - (y22 * Math.Sin(ro)));
            y1 = (int)((y11 * (Math.Cos(ro))) + (x11 * Math.Sin(ro)));
            y2 = (int)((y22 * (Math.Cos(ro))) + (x22 * Math.Sin(ro)));
            x1 += xc;
            x2 += xc;
            y1 += yc;
            y2 += yc;
            //drawing_dda(x1, x2, y1, y2);
             Bitmap p = new Bitmap(pictureBox1.Width, pictureBox1.Height);
             double dx = x2 - x1;
             double dy = y2 - y1;
             double steps = Math.Max(Math.Abs(dx), Math.Abs(dy));
             double xi = dx / steps;
             double yi = dy / steps;
             p.SetPixel((int)Math.Round(x1 ), (int)Math.Round(y1 ), Color.Red);
             double x = x1;
             double y = y1;
             int g = 1;
             //dataGridView1.Rows.Add(g++, (int)Math.Round(x), (int)Math.Round(y));

             for (int i = 0; i < steps; i++)
             {
                 x += xi ;
                 y += yi ;
                 p.SetPixel((int)Math.Round(x), (int)Math.Round(y), Color.Red);
                 // dataGridView1.Rows.Add(g++, (int)Math.Round(x), (int)Math.Round(y));
             }
             pictureBox1.Image = p;
        }

        //clipping button:
        public int getcode(int minx, int miny, int maxx, int maxy, int x1, int y1)
        {

            int code1 = 0;
            if (x1 >= minx && x1 <= maxx && y1 <= maxy && y1 >= miny)
                return code1 = 0000;
            else if (x1 >= minx && x1 <= maxx && y1 < maxy && y1 < miny)
                return code1 = 0100;
            else if (x1 >= minx && x1 >= maxx && y1 < maxy && y1 < miny)
                return code1 = 0110;
            else if (x1 <= minx && x1 <= maxx && y1 < maxy && y1 < miny)
                return code1 = 0101;
            else if (x1 > minx && x1 > maxx && y1 <= maxy && y1 >= miny)
                return code1 = 0010;
            else if (x1 >= minx && x1 >= maxx && y1 > maxy && y1 > miny)
                return code1 = 1010;
            else if (x1 >= minx && x1 <= maxx && y1 > maxy && y1 > miny)
                return code1 = 1000;
            else if (x1 <= minx && x1 <= maxx && y1 > maxy && y1 > miny)
                return code1 = 1001;
            else if (x1 < minx && x1 < maxx && y1 <= maxy && y1 >= miny)
                return code1 = 0001;
            else return code1;
        }
        public void check1(int code1, int minx, int maxx, int miny, int maxy)
        {
          int  x1 = int.Parse(textBox1.Text);
           int y1 = int.Parse(textBox2.Text);
           int x2 = int.Parse(textBox4.Text);
           int  y2 = int.Parse(textBox3.Text);
           /* int xc = pictureBox1.Width / 2;
            int yc = pictureBox1.Height / 2;

            x1 += xc;
            x2 += xc;
            y1 += yc;
            y2 += yc;*/
            int m = (int)(((float)(y2 - y1) / (float)(x2 - x1)) + 0.5);
            if (code1 == 0100)
                y1 = y1 + m * (miny - y1);
            else if (code1 == 0110)
                y1 = y1 + m * (miny - y1);
            else if (code1 == 0101)
                y1 = y1 + m * (miny - y1);
            else if (code1 == 1000)
                y1 = y1 + m * (maxy - y1);
            else if (code1 == 1010)
                y1 = y1 + m * (maxy - y1);
            else if (code1 == 1001)
                y1 = y1 + m * (maxy - y1);
            else if (code1 == 0010)
                x1 = x1 + m * (maxx - x1);
            else if (code1 == 0001)
                x1 = x1 + m * (minx - x1);
        }
        public void check2(int code1, int minx, int maxx, int miny, int maxy)
        {
           int  x1 = int.Parse(textBox1.Text);
             int y1 = int.Parse(textBox2.Text);
             int x2 = int.Parse(textBox4.Text);
           int  y2 = int.Parse(textBox3.Text);
          /*  int xc = pictureBox1.Width / 2;
            int yc = pictureBox1.Height / 2;

            x1 += xc;
            x2 += xc;
            y1 += yc;
            y2 += yc;/*/
            int m = (int)(((float)(y2 - y1) / (float)(x2 - x1)) + 0.5);
            if (code1 == 0100)
                y2 = y2 + m * (miny - y2);
            else if (code1 == 0110)
                y2 = y2 + m * (miny - y2);
            else if (code1 == 0101)
                y2 = y2 + m * (miny - y2);
            else if (code1 == 1000)
                y2 = y2 + m * (maxy - y2);
            else if (code1 == 1010)
                y2 = y2 + m * (maxy - y2);
            else if (code1 == 1001)
                y2 = y2 + m * (maxy - y2);
            else if (code1 == 0010)
                x2 = x2 + m * (maxx - x2);
            else if (code1 == 0001)
                x2 = x2 + m * (minx - x2);
        }


        private void button7_Click(object sender, EventArgs e)
        {
            label1.Text = " ";
         int   x1 = int.Parse(textBox1.Text);
            int y1 = int.Parse(textBox2.Text);
           int  x2 = int.Parse(textBox4.Text);
           int  y2 = int.Parse(textBox3.Text);
         /*   int xc = pictureBox1.Width / 2;
            int yc = pictureBox1.Height / 2;

            x1 += xc;
            x2 += xc;
            y1 += yc;
            y2 += yc;*/

            int minx = int.Parse(txtcx1.Text);
            int maxx = int.Parse(txtcx2.Text);
            int miny = int.Parse(txtcy1.Text);
            int maxy = int.Parse(txtcy2.Text);
            int code1, code2;
            //
            do
            {
                code1 = getcode(minx, miny, maxx, maxy, x1, y1);
                code2 = getcode(minx, miny, maxx, maxy, x2, y2);
                int and = code1 & code2;
                if (code1 == 0000 && code2 == 0000)
                {
                    label1.Text = "totaly accepted";
                    break;
                }
                else if (and != 0000)
                {
                    pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                    label1.Text = "totaly rejected";
                    break;
                }
                else
                {
                    //هعدل قيمة النقط عشان تبقى جوا الشكل
                    check1(code1, minx, maxx, miny, maxy);
                    check2(code2, minx, maxx, miny, maxy);
                }
            }
            while (code1 != 0000 || code2 != 0000);
            drawing_dda(x1, x2, y1, y2);
        }
         void Draw_DDA_line(int x1, int y1, int x2, int y2, Bitmap bit, Color color)
        {
            int dx = x2 - x1;
            int dy = y2 - y1;
            int steps = Math.Max(Math.Abs(dx), Math.Abs(dy));
            float xinc = dx / (float)steps;
            float yinc = dy / (float)steps;
            bit.SetPixel(x1, y1, Color.Blue);
            float x = x1, y = y1;
            for (int i = 0; i < steps; i++)
            {
                x = x + xinc;
                y = y + yinc;
                bit.SetPixel((int)Math.Round(x), (int)Math.Round(y), color);
            }
        }
        float x22;
        float y22;
        float u1 = 0;
        float u2 = 1;
        float dx;
        float dy;

        private void button8_Click(object sender, EventArgs e)
        {
             
      
            Bitmap bit1 = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Bitmap bit2 = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            
              x22 = int.Parse(textBox1.Text);
            y22 = int.Parse(textBox2.Text);
           float x33 = int.Parse(textBox4.Text);
           float  y33 = int.Parse(textBox3.Text);
           int xc = pictureBox1.Width / 2;
           int yc = pictureBox1.Height / 2;
         
            // t3del elan
           x22 += xc;
           x33 += xc;
           y22 += yc;
           y33 += yc;
         ////   x1 = int.Parse(txt_x1.Text);
            //y1 = int.Parse(txt_y1.Text);
           // float x2 = int.Parse(txt_x2.Text);
           // float y2 = int.Parse(txt_y2.Text);
              // int minx = int.Parse(.Text);
           // int maxx = int.Parse(.Text);
          //  int miny = int.Parse.Text);
          //  int maxy = int.Parse(txtcy2.Text);
            float xwmin = int.Parse(txtcx1.Text);
            float ywmin = int.Parse(txtcy1.Text);
            float xwmax = int.Parse(txtcx2.Text);
            float ywmax = int.Parse(txtcy2.Text);

            // t3del before exaam
            xwmax += xc;
            xwmin += xc;
            ywmax += yc;
            ywmin += yc;
            u1 = 0;
            u2 = 1;

            dx = x33 - x22;
            dy = y33 - y22;

            float p = 0;
            float q = 0;
            float r;

            float x1new;
            float y1new;
            float x2new;
            float y2new;

            for (int k = 1; k <= 4; k++)
            {
                if (k == 1)
                {
                    p = -1 * dx;
                    q = x22 - xwmin;
                }
                if (k == 2)
                {
                    p = dx;
                    q = xwmax - x22;
                }
                if (k == 3)
                {
                    p = -1 * dy;
                    q = y22 - ywmin;

                }
                if (k == 4)
                {
                    p = dy;
                    q = ywmax - y22;
                }

                r = q / p;
                if (p == 0 && q < 0)
                {
                   
                }
                if (p < 0)
                {
                    if (r > u1)
                    {
                        u1 = r;
                    }

                }
                else if (p > 0)
                {
                    if (r < u2)
                    {
                        u2 = r;
                    }
                }

            }

            if (u1 > u2)
            {
              
                //Draw Window Before Clipping
                Draw_DDA_line((int)xwmin, (int)ywmin, (int)xwmax, (int)ywmin, bit1, Color.Red);
                Draw_DDA_line((int)xwmin, (int)ywmin, (int)xwmin, (int)ywmax, bit1, Color.Red);
                Draw_DDA_line((int)xwmin, (int)ywmax, (int)xwmax, (int)ywmax, bit1, Color.Red);
                Draw_DDA_line((int)xwmax, (int)ywmin, (int)xwmax, (int)ywmax, bit1, Color.Red);

                //Draw line Before Clipping
                Draw_DDA_line((int)x22, (int)y22, (int)x33, (int)y33, bit1, Color.Red);
                pictureBox1.Image = bit1;


                //Draw Window After Clipping
                Draw_DDA_line((int)xwmin, (int)ywmin, (int)xwmax, (int)ywmin, bit2, Color.Blue);
                Draw_DDA_line((int)xwmin, (int)ywmin, (int)xwmin, (int)ywmax, bit2, Color.Blue);
                Draw_DDA_line((int)xwmin, (int)ywmax, (int)xwmax, (int)ywmax, bit2, Color.Blue);
                Draw_DDA_line((int)xwmax, (int)ywmin, (int)xwmax, (int)ywmax, bit2, Color.Blue);
                pictureBox1.Image = bit2;

            }
            else
            {
                x1new = x22 + u1 * dx;
                y1new = y22 + u1 * dy;
                x2new = x22 + u2 * dx;
                y2new = y22 + u2 * dy;

                //Draw Window Before Clipping
                Draw_DDA_line((int)xwmin, (int)ywmin, (int)xwmax, (int)ywmin, bit1, Color.Black);
                Draw_DDA_line((int)xwmin, (int)ywmin, (int)xwmin, (int)ywmax, bit1, Color.Black);
                Draw_DDA_line((int)xwmin, (int)ywmax, (int)xwmax, (int)ywmax, bit1, Color.Black);
                Draw_DDA_line((int)xwmax, (int)ywmin, (int)xwmax, (int)ywmax, bit1, Color.Black);

                //Draw line Before Clipping
                Draw_DDA_line((int)x22, (int)y22, (int)x1new, (int)y1new, bit1, Color.Red);
                Draw_DDA_line((int)x1new, (int)y1new, (int)x2new, (int)y2new, bit1, Color.Green);
                Draw_DDA_line((int)x33, (int)y33, (int)x2new, (int)y2new, bit1, Color.Red);

                pictureBox1.Image = bit1;

//dczdscsdcdjsksald;asldjsladksdsajdlkasflksajflkasfhlkasfjaslfskd;skf
                //Draw Window After Clipping
                Draw_DDA_line((int)xwmin, (int)ywmin, (int)xwmax, (int)ywmin, bit2, Color.Blue);
                Draw_DDA_line((int)xwmin, (int)ywmin, (int)xwmin, (int)ywmax, bit2, Color.Blue);
                Draw_DDA_line((int)xwmin, (int)ywmax, (int)xwmax, (int)ywmax, bit2, Color.Blue);
                Draw_DDA_line((int)xwmax, (int)ywmin, (int)xwmax, (int)ywmax, bit2, Color.Blue);

                //Draw line After Clipping
                Draw_DDA_line((int)x1new, (int)y1new, (int)x2new, (int)y2new, bit2, Color.Green);

                pictureBox1.Image = bit2;
            }


        }

        }
    }

