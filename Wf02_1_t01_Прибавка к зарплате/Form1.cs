// При наведенні миші на кнопку «Да» кнопка змінює своє місце розташування в межах видимої частини вікна.
// Користувач не повинен мати змогу натиснути на її.
// При зміні розмірів вікна кнопки повинні бути в межах вікна.
// При натисканні на кнопку «Нет», вивести повідомлення «Дякую за співпрацю».

using System;
using System.Drawing;
using System.Windows.Forms;

namespace Wf02_1_t01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void buttonNO_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Дякую за співпрацю", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            Random rnd = new Random();
            int x = buttonNO.Location.X;
            int y = buttonNO.Location.Y;
            while ((x > buttonNO.Location.X - buttonNO.Size.Width && x < buttonNO.Location.X + buttonNO.Size.Width) &&
                (y > buttonNO.Location.Y - buttonNO.Size.Height && y < buttonNO.Location.Y + buttonNO.Size.Height))
            {
                x = rnd.Next(10, ClientSize.Width - 111);
                y = rnd.Next(label1.Size.Height + label1.Location.Y + 10, ClientSize.Height - 53);
            }
            button1.Location = new Point(x, y);

        }
        private void Form1_OnLoad(object sender, EventArgs e)
        {
            MinimumSize = new Size(label1.Size.Width + 30, 200);
            label1.Width = ClientSize.Width - 10;
            button1.Location = new Point((ClientSize.Width / 2) - 130, button1.Location.Y + (label1.Size.Height / 2));
            buttonNO.Location = new Point((ClientSize.Width / 2) + 30, buttonNO.Location.Y + (label1.Size.Height / 2));
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (button1.Location.X < 10)
                button1.Location = new Point(10, button1.Location.Y);
            if (button1.Location.X > ClientSize.Width - button1.Size.Width - 10)
                button1.Location = new Point(ClientSize.Width - button1.Size.Width - 10, button1.Location.Y);
            if (button1.Location.Y > ClientSize.Height - button1.Size.Height - 10)
                button1.Location = new Point(button1.Location.X, ClientSize.Height - button1.Size.Height - 10);
        }
    }
}