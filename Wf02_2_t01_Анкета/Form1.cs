// Завдання "Анкета".
// Завдання користувача ввести свої дані в форму.
// При натисканні на кнопку дані з форми та дата заповнення анкети записуються до файлу
// та відображаються у блокноті (У файлі мають зберігатись всі анкети).
// Зовнішній вигляд програми:

using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Wf02_2_t01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            Font = SystemFonts.DialogFont;
            InitializeComponent();
            groupBox_Form.Font = SystemFonts.DialogFont;
            button_ViewResults.Font = SystemFonts.DialogFont;
            groupBox_Form.Font = new Font(groupBox_Form.Font.Name, groupBox_Form.Font.Size + 1.0F,
                groupBox_Form.Font.Style, groupBox_Form.Font.Unit);
            button_ViewResults.Font = new Font(button_ViewResults.Font.Name, button_ViewResults.Font.Size + 1.0F,
                button_ViewResults.Font.Style, button_ViewResults.Font.Unit);
            dateTimePicker1.CustomFormat = "  dd MMMM yyyy";
            InitTextBoxValidating();
            maskedTextBox1.Mask = "";
        }
  
        private void lbClick(object sender, EventArgs e)
        {
            groupBox_Form.Controls
                .Cast<Control>()
                .Where(c => !(c is Label) && (sender as Label).Name.Contains(c.Name))
                .FirstOrDefault()?.Select();
        }

        private void maskedTextBox1_Enter(object sender, EventArgs e)
        {
            maskedTextBox1.Mask = "+00 (000) 000-0009";
        }

        private void maskedTextBox1_Leave(object sender, EventArgs e)
        {
            if (!maskedTextBox1.Text.Any(char.IsDigit))
            {
                maskedTextBox1.Mask = "";
            }
        }

        private void InitTextBoxValidating()
        {
            radioButton1.Validating += rbValidating;
            maskedTextBox1.Validating += maskedTextBox1_Validating;
            foreach (var control in groupBox_Form.Controls)
            {
                if (control is TextBox)
                    (control as TextBox).Validating += tbValidating;
                else if (control is Label)
                    (control as Label).Click += lbClick;
            }
        }

        private void tbValidating(object sender, CancelEventArgs e)
        {
            //if (ActiveControl.Equals(sender))
            //    return;
            var tb = sender as TextBox;
            errorProvider1.SetIconPadding(tb, -18);
            if (String.IsNullOrEmpty(tb.Text))
            {
                errorProvider1.SetError(tb, "Поле не заполнено!");
                e.Cancel = true;
            }
            else if (tb.Text.Length < 2)
            {
                errorProvider1.SetError(tb, "Должно быть не менее 2 символов!");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(tb, "");
                e.Cancel = false;
            }
            if (firstInvalidControl == null && e.Cancel) firstInvalidControl = tb;
        }

        private void maskedTextBox1_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetIconPadding(maskedTextBox1, -18);
            if (!maskedTextBox1.MaskCompleted || maskedTextBox1.Mask == "")
            {
                errorProvider1.SetError(maskedTextBox1, "Поле заполнено некорректно!");
                e.Cancel = true;
            }
            else if (!maskedTextBox1.Text.Any(char.IsDigit))
            {
                errorProvider1.SetError(maskedTextBox1, "Поле не заполнено!");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(maskedTextBox1, "");
                e.Cancel = false;
            }
            if (firstInvalidControl == null && e.Cancel) firstInvalidControl = maskedTextBox1;
        }

        private void rbValidating(object sender, CancelEventArgs e)
        {
            var rb = sender as RadioButton;
            errorProvider1.SetIconAlignment(rb, ErrorIconAlignment.TopLeft);
            errorProvider1.SetIconPadding(rb, 4);
            if (!groupBox_Form.Controls
                .OfType<RadioButton>()
                .Any(r => r.Checked))
            {
                errorProvider1.SetError(rb, "Выбор не сделан!");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(rb, "");
                e.Cancel = false;
            }
            if (firstInvalidControl == null && e.Cancel) firstInvalidControl = rb;
        }

        private Control firstInvalidControl;

        private void button_ViewResults_Click(object sender, EventArgs e)
        {
            firstInvalidControl = null;
            if (!ValidateChildren())
                firstInvalidControl?.Select();
            else
            {
                string fileName = "..\\..\\Anketa.txt";
                using (StreamWriter stream = new StreamWriter(fileName, true, Encoding.Unicode))
                {
                    foreach (var control in groupBox_Form.Controls
                        .Cast<Control>()
                        .Where(c => (c is TextBox)))
                    {
                        stream.WriteLine(control.Text);
                    }
                    stream.WriteLine(maskedTextBox1.Text);
                    stream.WriteLine(dateTimePicker1.Value.ToShortDateString());
                    stream.WriteLine(groupBox_Form.Controls
                        .OfType<RadioButton>()
                        .Where(r => r.Checked)
                        .FirstOrDefault()
                        .Text);
                    stream.WriteLine(DateTime.Now.ToShortDateString());
                    stream.WriteLine("--------------------");
                }
                Process.Start("notepad.exe", fileName);
                Application.Exit();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }
    }
}
