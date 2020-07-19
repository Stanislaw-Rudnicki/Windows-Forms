using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wf04_2_t01
{
    public partial class Form1 : Form
    {

        private Size lastFormSize;

        public Form1()
        {
            InitializeComponent();

            this.Resize += new EventHandler(Form1_Resize);
            lastFormSize = this.Size;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Control control = (Control)sender;

            float scaleFactor = Size.Width / (label1.Size.Width / label1.Size.Height) > Size.Height ? (float)control.Size.Height / lastFormSize.Height : control.Size.Width / (float)lastFormSize.Width;

            label1.Font = new Font(label1.Font.FontFamily.Name, label1.Font.Size * scaleFactor, label1.Font.Style);

            label1.Location = new Point(control.ClientSize.Width / 2 - label1.Size.Width / 2, control.ClientSize.Height / 2 - label1.Size.Height / 2);

            lastFormSize = control.Size;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToLongTimeString();
        }
    }
}
