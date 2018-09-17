using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyGamePractice
{
    public partial class Form1 : Form
    {
        static int x=50, y=50;           // x,y are the coordinate; width and height are the rectangle properties -- global variables
        private int width, height, WIDTH, HEIGHT;       // width,height are the distance to the edges;  WIDTH and HEIGHT are the actual box properties

        public Form1()
        {
            InitializeComponent();
        }

        private void PBShow_Paint(object sender, PaintEventArgs e)
        {
            Rectangle r = new Rectangle(x, y, width, height);
            Graphics g = e.Graphics;                                //g is the GDI, e is the Event
            g.FillRectangle(new SolidBrush(Color.Black), r);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                MoveUp();
            if (e.KeyCode == Keys.Down)
                MoveDown();
            if (e.KeyCode == Keys.Left)
                MoveLeft();
            if (e.KeyCode == Keys.Right)
                MoveRight();
        }

        // Following four functions are the moving functions
        private void MoveUp()
        {
            if (y < height)
            {
                return;
            }
            y = y - height;
            this.PBShow.Refresh();
        }

        private void MoveDown()
        {
            if (y > HEIGHT - 2*height)
            {
                return;
            }
            y = y + height;
            this.PBShow.Refresh();
        }

        private void MoveLeft()
        {
            if (x < width)
            {
                return;
            }
            x = x - width;
            this.PBShow.Refresh();
        }

        private void MoveRight()
        {
            if (x > WIDTH - 2*width)
            {
                return;
            }
            x = x + width;
            this.PBShow.Refresh();
        }

        // Setup the background box properties
        private void Form1_Load(object sender, EventArgs e)
        {
            width = 30;
            height = 30;
            HEIGHT = PBShow.Height;      // make them the same size as the box value
            WIDTH = PBShow.Width;
            PBShow.BackColor = Color.White;
        }




    }
}
