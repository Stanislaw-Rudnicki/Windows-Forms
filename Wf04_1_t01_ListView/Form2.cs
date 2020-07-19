using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wf04_1_t01
{
    public partial class Form2 : Form
    {
        public Student Stud { get; set; }
        private Control firstInvalidControl;
        private DateTime zeroTime = new DateTime(1, 1, 1);

        public Form2()
        {
            InitializeComponent();
            textBoxPib.Validating += texBoxPibValidating;
            dateTimePickerBday.Validating += dateTimePickerBdayValidating;
            textBoxAvg.KeyPress += textBoxAvg_KeyPress;
            textBoxAvg.Validating += textBoxAvgValidating;
        }


        private void buttonSave_Click(object sender, EventArgs e)
        {
            firstInvalidControl = null;
            if (!ValidateChildren())
                firstInvalidControl?.Select();
            else
            {
                double.TryParse(textBoxAvg.Text.Replace(".", ","), out double average);
                Stud = new Student
                {
                    PIB = textBoxPib.Text,
                    Bday = dateTimePickerBday.Value,
                    Avg = average
                };
                DialogResult = DialogResult.OK;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (Stud != null)
            {
                Text = "Редагування";
                textBoxPib.Text = Stud.PIB;
                dateTimePickerBday.Value = Stud.Bday;
                textBoxAvg.Text = Stud.Avg.ToString();
            }
            else
            {
                Text = "Новий студент";
            }
        }

        private void texBoxPibValidating(object sender, CancelEventArgs e)
        {
            var tb = sender as TextBox;
            errorProvider1.SetIconPadding(tb, -18);
            if (String.IsNullOrEmpty(tb.Text))
            {
                errorProvider1.SetError(tb, "Поле не заполнено!");
                e.Cancel = true;
            }
            else if (tb.Text.Trim().Length < 2)
            {
                errorProvider1.SetError(tb, "Должно быть не менее 2 символов!");
                e.Cancel = true;
            }
            else if (!tb.Text.Trim().Any(char.IsLetter))
            {
                errorProvider1.SetError(tb, "Должно быть не менее 1 буквы!");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(tb, "");
                e.Cancel = false;
            }
            if (firstInvalidControl == null && e.Cancel) firstInvalidControl = tb;
        }

        private void dateTimePickerBdayValidating(object sender, CancelEventArgs e)
        {
            var tb = sender as DateTimePicker;
            errorProvider1.SetIconPadding(tb, -51);
            if ((zeroTime + (DateTime.Now - tb.Value)).Year - 1 < 6 ||
                (zeroTime + (DateTime.Now - tb.Value)).Year - 1 > 120)
            {
                errorProvider1.SetError(tb, "Допустимый возраст от 6 до 120 лет.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(tb, "");
                e.Cancel = false;
            }
            if (firstInvalidControl == null && e.Cancel) firstInvalidControl = tb;
        }

        private void textBoxAvgValidating(object sender, CancelEventArgs e)
        {
            var tb = sender as TextBox;
            errorProvider1.SetIconPadding(tb, -18);
            if (String.IsNullOrEmpty(tb.Text))
            {
                errorProvider1.SetError(tb, "Поле не заполнено!");
                e.Cancel = true;
            }
            else if (!tb.Text.All(c => ((c >= '0' && c <= '9')) || c == '.' || c == ',') ||
                      tb.Text.Count(c => c == '.') + tb.Text.Count(c => c == ',') > 1)
            {
                errorProvider1.SetError(tb, "Поле заполнено некорректно!");
                e.Cancel = true;
            }
            else if (!double.TryParse(tb.Text.Replace(".", ","), out double n))
            {
                errorProvider1.SetError(tb, "Поле заполнено некорректно!");
                e.Cancel = true;
            }


            else
            {
                errorProvider1.SetError(tb, "");
                e.Cancel = false;
            }
            if (firstInvalidControl == null && e.Cancel) firstInvalidControl = tb;
        }

        private void textBoxAvg_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) &&
                        !char.IsControl(e.KeyChar) &&
                        (e.KeyChar != '.' && e.KeyChar != ',' ||
                        (((e.KeyChar == '.') || (e.KeyChar == ',')) &&
                        (((sender as TextBox).Text.IndexOf('.') > -1) ||
                        (sender as TextBox).Text.IndexOf(',') > -1)));
        }

        private void form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }
    }
}
