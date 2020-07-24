using System;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Wf04_3_t02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var numbers = Enumerable.Range(-10, 21).Cast<object>().ToArray();
            foreach (ComboBox item in panel1.Controls.OfType<ComboBox>())
            {
                item.Items.AddRange(numbers);
                item.DropDownHeight = comboBox1.ItemHeight * 9;
                item.TextChanged += comboBox_TextChanged;
            }
            //comboBox1.KeyPress += comboBox_KeyPress;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double a, xMin, xMax, dx, y = 0;
            if (double.TryParse(comboBox1.Text.Replace(".", ","), out a) &&
                double.TryParse(comboBox3.Text.Replace(".", ","), out xMin) &&
                double.TryParse(comboBox4.Text.Replace(".", ","), out xMax) &&
                double.TryParse(comboBox5.Text.Replace(".", ","), out dx))
            {
                listBox1.Items.Clear();
                if (dx == 0)
                    listBox1.Items.Add("Шаг не может быть 0");
                else
                {
                    try
                    {
                        for (double x = xMin;
                            (xMin < xMax ? xMin : xMax) <= x && x <= (xMin < xMax ? xMax : xMin); x += dx)
                        {
                            if (x <= 0) // x^4 + 2x^3 - x
                                y = Math.Pow(x, 4) + 2 * Math.Pow(x, 3) - x;
                            else if (0 < x && x <= a) // 1,3 * sqrt(4 + x^2)
                                y = 1.3 * Math.Sqrt(4 + x * x);
                            else if (x > a) // |x + 1|^x
                                y = Math.Pow(Math.Abs(x + 1), x);

                            listBox1.Items.Add($"При x = {x:0.##}  y = {y:0.##}");
                        }
                    }
                    catch (Exception ex)
                    {
                        listBox1.Items.Add(ex.Message);
                    }
                }
            }
            else
            {
                listBox1.Items.Clear();
                listBox1.Items.Add("Некорректные исходные данные");
            }
        }

        //private void comboBox_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    ComboBox cb = sender as ComboBox;
        //    e.Handled = !char.IsDigit(e.KeyChar) &&
        //                !char.IsControl(e.KeyChar) &&
        //                (e.KeyChar != '.' && e.KeyChar != ',' ||
        //                (((e.KeyChar == '.') || (e.KeyChar == ',')) &&
        //                ((cb.Text.IndexOf('.') > -1) ||
        //                cb.Text.IndexOf(',') > -1))) &&
        //                (e.KeyChar != '-') ||
        //                ((e.KeyChar == '-') &&
        //                (cb.Text.IndexOf('-') > -1));
        //}

        string previousInput = "";
        private void comboBox_TextChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            //if (cb.Text.IndexOf('-') > -1 && cb.Text.IndexOf('-') != 0)
            //{
            //    int pos = cb.SelectionStart;
            //    cb.Text = cb.Text.Remove(cb.Text.IndexOf('-'), 1);
            //    cb.SelectionStart = pos != 0 ? --pos : pos;;
            //}
            Regex r = new Regex("^-{0,1}\\d*(\\.|,){0,1}\\d*$");
            Match m = r.Match(cb.Text);
            if (m.Success)
            {
                previousInput = cb.Text;
            }
            else
            {
                int pos = cb.SelectionStart;
                cb.Text = previousInput;
                cb.SelectionStart = pos != 0 ? --pos : pos;
            }
        }
    }
}
