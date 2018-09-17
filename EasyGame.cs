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
    public partial class EasyGame : Form
    {
        static int x=0, y=0;           // x,y are the coordinate; width and height are the rectangle properties -- global variables
        private int width, height, WIDTH, HEIGHT;       // width,height are the distance to the edges;  WIDTH and HEIGHT are the actual box properties
        static int[] XrandNum ,YrandNum;
        static int[] dangerX, dangerY;
        static int tc = 0;
        static int timerNum = 0;
        Random Xrnd = new Random();
        Random Yrnd = new Random();

        public EasyGame()
        {
            InitializeComponent();
            this.timer1.Enabled = true;
            XrandNum = new int[3];
            YrandNum = new int[3];
            dangerX = new int[3];
            dangerY = new int[3];
            for (int i = 0; i < 3; i++)
            {
                XrandNum[i] = Xrnd.Next(0, 3) * 60;
                YrandNum[i] = Yrnd.Next(0, 3) * 60;
                dangerX[i] = 999;
                dangerY[i] = 999;
            }
        }

        // Setup the background box properties
        private void Form1_Load(object sender, EventArgs e)
        {
            width = 60;
            height = 60;
            HEIGHT = PBShow.Height;      // make them the same size as the box value
            WIDTH = PBShow.Width;
            PBShow.BackColor = Color.White;

        }

        private void PBShow_Paint(object sender, PaintEventArgs e)
        {
            Rectangle r = new Rectangle(x, y, width, height);
            Graphics g = e.Graphics;                                //g is the GDI, e is the Event
            g.FillRectangle(new SolidBrush(Color.Black), r);

            for (int i = 0; i < 3; i++)
            {
                if (timerNum == 1)
                {
                    Rectangle db = new Rectangle(XrandNum[i], YrandNum[i], 60, 60);
                    g.FillRectangle(new SolidBrush(Color.Yellow), db);
                }
                if (timerNum == 2)
                {
                    Rectangle db = new Rectangle(XrandNum[i], YrandNum[i], 60, 60);
                    g.FillRectangle(new SolidBrush(Color.Red), db);
                    dangerX[i] = XrandNum[i];
                    dangerY[i] = YrandNum[i];
                }
                if (timerNum == 3)
                {
                    Rectangle db = new Rectangle(XrandNum[i], YrandNum[i], 60, 60);
                    g.FillRectangle(new SolidBrush(Color.White), db);
                    dangerX[i] = 6666;
                    dangerY[i] = 6666;
                }
            }

            for (int i = 0; i < 3; i++)
            {
                if (x == dangerX[i] && y == dangerY[i])
                {
                    MessageBox.Show("Game Over", "Too bad", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    GameMenu menu = new GameMenu();
                    menu.Show();
                    this.Close();
                }
            }
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
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult ans = MessageBox.Show("Do you want to go back to menu?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ans == DialogResult.Yes)
                {
                    GameMenu menu = new GameMenu();
                    menu.Show();
                    this.Hide();
                }
                else
                {
                    DialogResult quit = MessageBox.Show("Do you want to quit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (quit == DialogResult.Yes)
                        System.Environment.Exit(0);
                }
            }
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



        private void timer1_Tick(object sender, EventArgs e)
        {

            if (tc % 9 == 1)
            {
                XrandNum[0] = Xrnd.Next(0, 100) % 3 * 60;
                YrandNum[0] = Yrnd.Next(0, 100) % 3 * 60;
                XrandNum[1] = Xrnd.Next(0, 100) % 3 * 60;
                YrandNum[1] = Yrnd.Next(0, 100) % 3 * 60;
                XrandNum[2] = Xrnd.Next(0, 100) % 3 * 60;
                YrandNum[2] = Yrnd.Next(0, 100) % 3 * 60;
                /*while ((XrandNum[1] == XrandNum[0] && YrandNum[1] == YrandNum[0]) || (XrandNum[1] == XrandNum[2] && YrandNum[1] == YrandNum[2]))
                {
                    XrandNum[1] = Xrnd.Next(0, 100) % 3 * 60;
                    YrandNum[1] = Yrnd.Next(0, 100) % 3 * 60;
                }
                while (XrandNum[2] == XrandNum[0] && YrandNum[2] == YrandNum[0])
                {
                    XrandNum[2] = Xrnd.Next(0, 100) % 3 * 60;
                    YrandNum[2] = Yrnd.Next(0, 100) % 3 * 60;
                }*/
                timerNum = 1;
                this.PBShow.Refresh();
            }
            if (tc % 9 == 2 || tc % 9 == 3)
            {
                timerNum = 1;
                this.PBShow.Refresh();
            }
            if (tc % 9 == 5 || tc % 9 == 6 || tc % 9 == 7 || tc % 9 == 8 || tc % 9 == 4)
            {
                timerNum = 2;
                this.PBShow.Refresh();
            }

            if (tc % 9 == 0)
            {
                timerNum = 3;
                this.PBShow.Refresh();
            }
            tc++;
        }


    }
}
