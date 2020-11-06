using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace многоугольники
{
    public partial class Form1 : Form
    {

        int x, y;
        Versch shaper;
        int shape = 1;
        int deltax;
        int deltay;
        bool existance = false;
        bool drag;
        
        static Form1()
        {



        }
        public Form1()
        {
            InitializeComponent();
            deltax = 0;
            deltay = 0;
            drag = false;
            Versch shaper;
        }

        private void КругToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shape = 1;
            
        }

        private void КвадратToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shape = 2;
            

        }



        private void ТреугольникToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shape = 3;
            

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if(existance && shaper.check(e.X,e.Y))
            {
                if (e.Button== MouseButtons.Left)
                {
                    deltax = e.X - shaper.SetX;
                    deltay = e.Y - shaper.SetY;
                    drag = true;
                }
                if(e.Button == MouseButtons.Right)
                {
                    //null

                }
            }
            else
            {
                existance = true;
                switch (shape)
                {
                    case 1: shaper = new circle(e.X, e.Y);break;
                    case 2: shaper = new square(e.X, e.Y); break;
                    case 3: shaper = new triangle(e.X, e.Y); break;


                }

            }
            x = e.X;
            y = e.Y;
            
            this.Invalidate();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if(drag)
            {
                shaper.SetX = e.X - deltax;
                shaper.SetY = e.Y - deltay;


            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            shaper.paintshit(e.Graphics);



        }
    }
}
