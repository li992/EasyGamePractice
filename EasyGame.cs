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
        static int tc = 0, tc2 = 0;
        static int timerNum = 0, timer2Num = 0;
        static int randX, randY, randV, randX2, randY2, randV2;
        Random rand, rand2, rand3;

        public EasyGame()
        {
            InitializeComponent();
        }

        // Setup the background box properties
        private void Form1_Load(object sender, EventArgs e)
        {
            width = 60;
            height = 60;
            HEIGHT = PBShow.Height;      // make them the same size as the box value
            WIDTH = PBShow.Width;
            PBShow.BackColor = Color.White;
            this.timer1.Enabled = true;
            this.timer2.Enabled = true;
            XrandNum = new int[2];
            YrandNum = new int[2];
            dangerX = new int[2];
            dangerY = new int[2];
            for (int i = 0; i < 2; i++)
            {
                dangerX[i] = 999;
                dangerY[i] = 999;
            }

        }

        private void PBShow_Paint(object sender, PaintEventArgs e)
        {
            Rectangle r = new Rectangle(x, y, width, height);
            Graphics g = e.Graphics;                                //g is the GDI, e is the Event
            g.FillRectangle(new SolidBrush(Color.Black), r);

            for (int i = 0; i < 2; i++)
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

            for (int i = 0; i < 2; i++)
            {
                if (x == dangerX[i] && y == dangerY[i])
                {
                    timer1.Stop();
                    timer2.Stop();
                    MessageBox.Show("Game Over", "Too bad", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    GameMenu menu = new GameMenu();
                    menu.Show();
                    this.Close();
                    break;
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

        public void getRandValue(int randvalue)
        {
            switch (randvalue)
            {
                case 0: randX = 0;
                    randY = 0;
                    break;
                case 1: randX = 0;
                    randY = 1;
                    break;
                case 2: randX = 0;
                    randY = 2;
                    break;
                case 3: randX = 1;
                    randY = 0;
                    break;
                case 4: randX = 1;
                    randY = 1;
                    break;
                case 5: randX = 1;
                    randY = 2;
                    break;
                case 6: randX = 2;
                    randY = 0;
                    break;
                case 7: randX = 2;
                    randY = 1;
                    break;
                case 8: randX = 2;
                    randY = 2;
                    break;
            };
        }

        public void getRand2Value(int randvalue2)
        {
            switch (randvalue2)
            {
                case 0: randX2 = 0;
                    randY2 = 0;
                    break;
                case 1: randX2 = 0;
                    randY2 = 1;
                    break;
                case 2: randX2 = 0;
                    randY2 = 2;
                    break;
                case 3: randX2 = 1;
                    randY2 = 0;
                    break;
                case 4: randX2 = 1;
                    randY2 = 1;
                    break;
                case 5: randX2 = 1;
                    randY2 = 2;
                    break;
                case 6: randX2 = 2;
                    randY2 = 0;
                    break;
                case 7: randX2 = 2;
                    randY2 = 1;
                    break;
                case 8: randX2 = 2;
                    randY2 = 2;
                    break;
            };
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (tc % 9 == 1)
            {
                // set the danger box position
                rand = new Random();
                randV = rand.Next(0,1000)%9;
                getRandValue(randV);
                XrandNum[0] = randX * 60;
                YrandNum[0] = randY * 60;

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

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (tc2 % 9 == 1)
            {
                // set the danger box position
                rand2 = new Random();
                randV2 = rand2.Next(0, 1000) % 9;
                getRand2Value(randV2);
                XrandNum[1] = randX2 * 60;
                YrandNum[1] = randY2 * 60;

                timer2Num = 1;
                this.PBShow.Refresh();
            }
            if (tc2 % 9 == 2 || tc2 % 9 == 3)
            {
                timer2Num = 1;
                this.PBShow.Refresh();
            }
            if (tc2 % 9 == 5 || tc2 % 9 == 6 || tc2 % 9 == 7 || tc2 % 9 == 8 || tc2 % 9 == 4)
            {
                timer2Num = 2;
                this.PBShow.Refresh();
            }

            if (tc2 % 9 == 0)
            {
                timer2Num = 3;
                this.PBShow.Refresh();
            }
            tc2++;
        }


    }
}
