using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Wf04_3_t01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Select();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox1.Text))
                listBox1.Items.Add(textBox1.Text);
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox1.Text) && listBox1.SelectedIndex != -1)
                listBox1.Items.Insert(listBox1.SelectedIndex, textBox1.Text);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox1.Text) && listBox1.SelectedIndex != -1)
                listBox1.Items[listBox1.SelectedIndex] = textBox1.Text.ToString();
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                int n = listBox1.SelectedIndex;
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                if (n < listBox1.Items.Count)
                    listBox1.SelectedIndex = n;
                else if (listBox1.Items.Count != 0)
                    listBox1.SelectedIndex = listBox1.Items.Count - 1;
            }
        }

        private void buttonEvaluate_Click(object sender, EventArgs e)
        {
            //var minMax = listBox1.Items.Cast<string>().Aggregate(new Tuple<string, string>(null, null), (res, x) =>
            //{
            //    if (res.Item1 == null || res.Item2 == null)
            //        return new Tuple<string, string>(x, x);
            //    return new Tuple<string, string>(x.Length < res.Item1.Length ? x : res.Item1,
            //                                     x.Length > res.Item2.Length ? x : res.Item2);
            //});
            //textBox2.Text = minMax.Item2;
            //textBox3.Text = minMax.Item1;

            var minMax = listBox1.Items.Cast<string>().Aggregate(new string[] { null, null }, (res, x) =>
            {
                if (res[0] == null || res[1] == null)
                    return new string[] { x, x };
                res[0] = x.Length < res[0].Length ? x : res[0];
                res[1] = x.Length > res[1].Length ? x : res[1];
                return res;
            });
            textBox2.Text = minMax[1];
            textBox3.Text = minMax[0];
        }
    }
}
