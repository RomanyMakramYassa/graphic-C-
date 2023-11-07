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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            DDA DDA1 = new DDA();
            DDA1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            BRESENHAM BRA1 = new BRESENHAM();
            BRA1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            ELLIPSE ELIPSE1 = new ELLIPSE();
            ELIPSE1.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            CERCLE CERCLE1 = new CERCLE();
            CERCLE1.Show();
        }
    }
}
