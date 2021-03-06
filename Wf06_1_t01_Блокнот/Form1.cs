﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RichTextBoxTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonSet_Click(object sender, EventArgs e)
        {
            //  richTextBox1.Text = "Не Галя воду,\n коромисло гнеться";
            //  richTextBox1.AppendText ( "Не Галя воду,\n коромисло гнеться");

            //var arr = richTextBox1.Lines;
            //arr[1]= "-----------------------------";
            //richTextBox1.Lines = arr;

            //richTextBox1.Select(100, 1);
            //richTextBox1.SelectedText = "+++++++++++++++";



            //richTextBox1.Select(
            //    richTextBox1.Lines[0].Length+1,
            //    richTextBox1.Lines[1].Length);
            //richTextBox1.SelectedText = "+++++++++++++++";

            // richTextBox1.Select(
            //    richTextBox1.GetFirstCharIndexFromLine(5),
            //    richTextBox1.Lines[5].Length);
            //richTextBox1.SelectedText = "+++++++++++++++";
            Text = "" + richTextBox1.Lines[5].Length;
            int NumberLine = 5;
            int len = 0;
            for (int i = 0; i < NumberLine; i++)
                len += richTextBox1.Lines[i].Length + 1;

            //len = richTextBox1.Lines
            //     .Where((text, i) => i < NumberLine)
            //     .Select(i => i.Length + 1)
            //     .Sum();

            len = richTextBox1.Lines.Take(NumberLine).Sum(i => i.Length + 1);

            richTextBox1.Select(
             len,
             richTextBox1.Lines[NumberLine].Length);
            richTextBox1.SelectedText = "+++++++++++++++";

            //richTextBox1.ScrollToCaret();
            //  richTextBox1.Refresh();

        }

        private void buttonFont_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font("Arial", 14, FontStyle.Bold);
        }

        private void buttonColor_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionStart = 50;
            richTextBox1.SelectionLength = 10;
            richTextBox1.SelectAll();
            richTextBox1.Focus();

            richTextBox1.SelectionColor = Color.Red;
            //   richTextBox1.SelectionStart = 0;
            richTextBox1.SelectionLength = 0;
        }

        private void buttonUndo_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void buttonRedo_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }
        // string buf = "";
        private void buttonCopy_Click(object sender, EventArgs e)
        {
            //  buf=richTextBox1.SelectedText;
            richTextBox1.Copy();
        }

        private void buttonPaste_Click(object sender, EventArgs e)
        {
            //richTextBox1.SelectedText = buf;
            richTextBox1.Paste();
        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void buttonCenter_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;

        }

        private void buttonRight_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;

        }

        private void buttonMargin_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionIndent = 120;
            richTextBox1.SelectionRightIndent = 100;
            richTextBox1.SelectionHangingIndent = -20;

        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            string text = "Галя";
            int index = richTextBox1.Find(text);
            if (index >= 0)
            {
                richTextBox1.Select(index, text.Length);
                richTextBox1.Focus();
            }
            else
                Text = "not found";
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog
            {
                Filter = "txt file|*.txt|RTF file|*.rtf|All file|*.*",
                FilterIndex = 1,
                DefaultExt = "rtf"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (dialog.FilterIndex == 1)
                    richTextBox1.SaveFile(dialog.FileName, RichTextBoxStreamType.PlainText);
                else
                    richTextBox1.SaveFile(dialog.FileName, RichTextBoxStreamType.RichText);


            }

        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "txt file|*.txt|RTF file|*.rtf|All file|*.*",
                FilterIndex = 1,
                DefaultExt = "rtf"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (dialog.FilterIndex == 1)
                    richTextBox1.LoadFile(dialog.FileName, RichTextBoxStreamType.PlainText);
                else
                    richTextBox1.LoadFile(dialog.FileName, RichTextBoxStreamType.RichText);


            }
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabPage thisTab = tabControl1.TabPages[e.Index];
            string tabTitle = thisTab.Text;
            Image icon = imageList1.Images[123];
            //Draw Close button
            Point closeLoc = new Point(15, 5);
            e.Graphics.DrawRectangle(Pens.Black, e.Bounds.Right - closeLoc.X, e.Bounds.Top + closeLoc.Y, 10, 12);
            e.Graphics.FillRectangle(Brushes.LightBlue, e.Bounds.Right - closeLoc.X, e.Bounds.Top + closeLoc.Y, 10, 12);
            e.Graphics.DrawString("x", e.Font, Brushes.Black, e.Bounds.Right - (closeLoc.X), e.Bounds.Top + closeLoc.Y - 2);
            // Draw String of Caption
            e.Graphics.DrawString(tabTitle, e.Font, Brushes.Black, e.Bounds.Left + 28, e.Bounds.Top + 4);
            // Add Icon to Front
            e.Graphics.DrawImage(icon, e.Bounds.Left + 6, e.Bounds.Top + 3);
            e.DrawFocusRectangle();
        }

        private void tabControl1_MouseDown(object sender, MouseEventArgs e)
        {
            Point closeLoc = new Point(15, 5);
            Rectangle r = tabControl1.GetTabRect(tabControl1.SelectedIndex);
            Rectangle closeButton = new Rectangle(r.Right - closeLoc.X, r.Top + closeLoc.Y, 10, 12);
            if (closeButton.Contains(e.Location))
            {
                tabControl1.TabPages.Remove(tabControl1.SelectedTab);
                return; // Don't keep running logic in method
            }
            for (int i = 0; i < tabControl1.TabCount; i++)
            {
                r = tabControl1.GetTabRect(i);
                if (r.Contains(e.Location) && e.Button == MouseButtons.Middle)
                {
                    tabControl1.TabPages.RemoveAt(i);
                }
            }
        }


    }
}