using System;
using System.Drawing;
using System.Windows.Forms;

namespace Wf07_1_t01
{
    public partial class Form1 : Form
    {
        Timer t = new Timer();

        int WIDTH = 300, HEIGHT = 300, secHAND = 140, minHAND = 110, hrHAND = 80;

        // center
        int cy, cx;

        Bitmap bmp;
        Graphics g;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // create a new bitmap
            bmp = new Bitmap(WIDTH + 1, HEIGHT + 1);

            // placing in center
            cx = WIDTH / 2;
            cy = HEIGHT / 2;

            //backcolor
            this.BackColor = Color.White;

            //timer
            t.Interval = 1000;
            t.Tick += new EventHandler(this.t_Tick);
            t.Start();
        }

        private void t_Tick(object sender, EventArgs e)
        {
            // create an image
            g = Graphics.FromImage(bmp);
            double r = Math.Min(WIDTH, HEIGHT) / 2;

            //get time
            int ss = DateTime.Now.Second;
            int mm = DateTime.Now.Minute;
            int hh = DateTime.Now.Hour;

            int[] handCoord = new int[2];

            g.Clear(Color.White);

            //draw a circle
            //cg.DrawEllipse(new Pen(Color.Black, 1f), 0, 0, WIDTH, HEIGHT);

            // draw the ticks
            int tickLen = 5;
            int medTickLen = 10;
            int longTickLen = 15; // at the quarters
            
            for (int i = 1; i <= 60; i++)
            {
                int len = tickLen;
                if (i % 15 == 0)
                {
                    len = longTickLen;
                }
                else if (i % 5 == 0)
                {
                    len = medTickLen;
                }
                double di = (double)i;
                double angleFrom12 = di / 60.0 * 2.0 * Math.PI;
                double angleFrom3 = Math.PI / 2.0 - angleFrom12;
                
                Point point1 = new Point((int)(cx + Math.Cos(angleFrom3) * r), (int)(cy - Math.Sin(angleFrom3) * r));
                Point point2 = new Point((int)(cx + Math.Cos(angleFrom3) * (r - len)), (int)(cy - Math.Sin(angleFrom3) * (r - len)));

                // Draw line to screen.
                g.DrawLine(new Pen(ColorTranslator.FromHtml("#B2B2B2"), 1f), point1, point2);
            }
            
            for (int i = 1; i <= 12; i++)
            {
                // Calculate the string width and height so we can center it properly
                String numStr = "" + i;
                int charWidth = (int)g.MeasureString(numStr, new Font("Sans Serif", 14, FontStyle.Bold)).Width;
                int charHeight = (int)g.MeasureString(numStr, new Font("Sans Serif", 14, FontStyle.Bold)).Height;

                double di = (double)i;

                // Calculate the position along the edge of the clock where the number should be drawn
                // Get the angle from 12 O'Clock to this tick (radians)
                double angleFrom12 = di / 12.0 * 2.0 * Math.PI;

                // Get the angle from 3 O'Clock to this tick
                // Note: 3 O'Clock corresponds with zero angle in unit circle
                // Makes it easier to do the math.
                double angleFrom3 = Math.PI / 2.0 - angleFrom12;

                // Get diff between number position and clock center
                int tx = (int)(Math.Cos(angleFrom3) * (r - longTickLen * 1.5));
                int ty = (int)(-Math.Sin(angleFrom3) * (r - longTickLen * 1.5));

                // For 6 and 12 we will shift number slightly so they are more even
                if (i == 6)
                {
                    ty -= charHeight / 3;
                }
                else if (i == 12)
                {
                    ty += charHeight / 3;
                }

                // Translate the graphics context by delta between clock center and number position
                g.TranslateTransform(tx, ty);

                // Draw number at clock center.
                g.DrawString(
                    numStr,
                    new Font("Sans Serif", 14, FontStyle.Bold),
                    Brushes.Black,
                    (int)cx - charWidth / 2,
                    (int)cy - charHeight / 2);

                // Undo translation
                g.TranslateTransform(-tx, -ty);
            }

            //draw seconds hand
            handCoord = msCoord(ss, secHAND);
            g.DrawLine(new Pen(Color.Red, 2f), new Point(cx, cy), new Point(handCoord[0], handCoord[1]));

            //draw minutes hand
            handCoord = msCoord(mm, minHAND);
            g.DrawLine(new Pen(Color.Black, 3f), new Point(cx, cy), new Point(handCoord[0], handCoord[1]));

            //draw hours hand
            handCoord = hrCoord(hh % 12, mm, hrHAND);
            g.DrawLine(new Pen(Color.Black, 3f), new Point(cx, cy), new Point(handCoord[0], handCoord[1]));

            //load the bitmap image
            pictureBox1.Image = bmp;

            //display time in the heading
            //this.Text = "Analog Clock - " + hh + ":" + mm.ToString("00") + ":" + ss.ToString("00");
            this.Text = "Годинник GDI+";
            g.Dispose();
        }

        //coord for minute and second
        private int[] msCoord(int val, int hlen)
        {
            int[] coord = new int[2];
            val *= 6;
            // note: each minute and seconds make a 6 degree

            if (val >= 0 && val <= 100)
            {
                coord[0] = cx + (int)(hlen * Math.Sin(Math.PI * val / 180));
                coord[1] = cy - (int)(hlen * Math.Cos(Math.PI * val / 180));
            }
            else
            {
                coord[0] = cx - (int)(hlen * -Math.Sin(Math.PI * val / 180));
                coord[1] = cy - (int)(hlen * Math.Cos(Math.PI * val / 180));
            }
            return coord;
        }

        //coord for hour private
        int[] hrCoord(int hval, int mval, int hlen)
        {
            int[] coord = new int[2];
            //each hour makes 60 degree with min making 0.5 degree
            int val = (int)((hval * 30) + (mval * 0.5));
            if (val >= 0 && val <= 180)
            {
                coord[0] = cx + (int)(hlen * Math.Sin(Math.PI * val / 180));
                coord[1] = cy - (int)(hlen * Math.Cos(Math.PI * val / 180));
            }
            else
            {
                coord[0] = cx - (int)(hlen * -Math.Sin(Math.PI * val / 180));
                coord[1] = cy - (int)(hlen * Math.Cos(Math.PI * val / 180));
            }
            return coord;
        }
    }
}