using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wf04_2_t02
{
    public partial class Form1 : Form
    {
        Dictionary<string, double> fuel = new Dictionary<string, double>();
        int s = 10;
        double totalSum = 0;

        public Form1()
        {
            InitializeComponent();

            fuel.Add("А-76", 6.4);
            fuel.Add("А-92", 7.2);
            fuel.Add("А-95", 7.5);
            fuel.Add("ДП", 7.4);

            comboBox1.DataSource = new BindingSource(fuel, null);
            comboBox1.DisplayMember = "Key";
            comboBox1.ValueMember = "Value";
            comboBox1.SelectedIndex = 2;

            textBoxQuantity.KeyPress += textBoxQuantity_KeyPress;
            textBoxQuantity.Validating += textBoxQuantity_Validating;
            textBoxQuantity.TextChanged += textBoxQuantity_TextChanged;

            textBoxAmount.KeyPress += textBoxQuantity_KeyPress;
            textBoxAmount.Validating += textBoxQuantity_Validating;
            textBoxAmount.TextChanged += textBoxAmount_TextChanged;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxPrice.Text = ((KeyValuePair<string, double>)comboBox1.SelectedItem).Value.ToString("0.00");
            if (radioButton1.Checked)
            {
                double.TryParse(textBoxQuantity.Text.Replace(".", ","), out double qty);
                textBoxAmount.Text = (((KeyValuePair<string, double>)comboBox1.SelectedItem).Value * qty).ToString("0.00");
            }
            else
            {
                double.TryParse(textBoxAmount.Text.Replace(".", ","), out double amount);
                textBoxQuantity.Text = (amount / ((KeyValuePair<string, double>)comboBox1.SelectedItem).Value).ToString("0.00");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDownHotDogQty.ReadOnly = !numericUpDownHotDogQty.ReadOnly;
            numericUpDownHotDogQty.Increment = numericUpDownHotDogQty.ReadOnly ? 0 : 1;
            cafeSum();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDownHamburgerQty.ReadOnly = !numericUpDownHamburgerQty.ReadOnly;
            numericUpDownHamburgerQty.Increment = numericUpDownHamburgerQty.ReadOnly ? 0 : 1;
            cafeSum();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDownFriesQty.ReadOnly = !numericUpDownFriesQty.ReadOnly;
            numericUpDownFriesQty.Increment = numericUpDownFriesQty.ReadOnly ? 0 : 1;
            cafeSum();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDownColaQty.ReadOnly = !numericUpDownColaQty.ReadOnly;
            numericUpDownColaQty.Increment = numericUpDownColaQty.ReadOnly ? 0 : 1;
            cafeSum();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBoxQuantity.ReadOnly = !textBoxQuantity.ReadOnly;
            textBoxAmount.ReadOnly = !textBoxAmount.ReadOnly;

            if (radioButton1.Checked && double.TryParse(textBoxQuantity.Text.Replace(".", ","), out double n) && n == 0)
                textBoxQuantity.Text = "";
            else if (radioButton2.Checked && double.TryParse(textBoxAmount.Text.Replace(".", ","), out double m) && m == 0)
                textBoxAmount.Text = "";

            if (radioButton1.Checked)
                textBoxQuantity.Select();
            else
                textBoxAmount.Select();
        }

        private void textBoxQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) &&
                        !char.IsControl(e.KeyChar) &&
                        (e.KeyChar != '.' && e.KeyChar != ',' ||
                        (((e.KeyChar == '.') || (e.KeyChar == ',')) &&
                        (((sender as TextBox).Text.IndexOf('.') > -1) ||
                        (sender as TextBox).Text.IndexOf(',') > -1)));
        }

        private void textBoxQuantity_Validating(object sender, CancelEventArgs e)
        {
            var tb = sender as TextBox;
            errorProvider1.SetIconPadding(tb, -18);
            if (String.IsNullOrEmpty(tb.Text))
            {
                errorProvider1.SetError(tb, "");
                e.Cancel = false;
                //errorProvider1.SetError(tb, "Поле не заполнено!");
                //e.Cancel = true;
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
        }

        void textBoxQuantity_TextChanged(object sender, EventArgs e)
        {
            var tb = sender as TextBox;
            if (tb.Modified)
            {
                double.TryParse(tb.Text.Replace(".", ","), out double qty);
                textBoxAmount.Text = (((KeyValuePair<string, double>)comboBox1.SelectedItem).Value * qty).ToString("0.00");
            }
        }

        void textBoxAmount_TextChanged(object sender, EventArgs e)
        {
            double amount;
            var tb = sender as TextBox;
            if (tb.Modified)
            {
                double.TryParse(tb.Text.Replace(".", ","), out amount);
                textBoxQuantity.Text = (amount / ((KeyValuePair<string, double>)comboBox1.SelectedItem).Value).ToString("0.00");
            }
            double.TryParse(textBoxAmount.Text.Replace(".", ","), out amount);
            labelFuelTotal.Text = amount.ToString("0.00");
        }

        private void numericUpDownHotDogQty_ValueChanged(object sender, EventArgs e)
        {
            cafeSum();
        }

        private void numericUpDownHamburgerQty_ValueChanged(object sender, EventArgs e)
        {
            cafeSum();
        }

        private void numericUpDownFriesQty_ValueChanged(object sender, EventArgs e)
        {
            cafeSum();
        }

        private void numericUpDownColaQty_ValueChanged(object sender, EventArgs e)
        {
            cafeSum();
        }

        private void cafeSum()
        {
            double sum = 0;
            sum += checkBox1.Checked ? (double)numericUpDownHotDogQty.Value * double.Parse(textBoxHotDog.Text) : 0;
            sum += checkBox2.Checked ? (double)numericUpDownHamburgerQty.Value * double.Parse(textBoxHamburger.Text) : 0;
            sum += checkBox3.Checked ? (double)numericUpDownFriesQty.Value * double.Parse(textBoxFries.Text) : 0;
            sum += checkBox4.Checked ? (double)numericUpDownColaQty.Value * double.Parse(textBoxCola.Text) : 0;

            labelCafeTotal.Text = sum.ToString("0.00");
        }

        private void buttonTotalSum_Click(object sender, EventArgs e)
        {
            double.TryParse(labelFuelTotal.Text, out double n);
            double.TryParse(labelCafeTotal.Text, out double m);
            labelTotalSum.Text = (n + m).ToString("0.00");
            if (n + m != 0)
                timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            buttonTotalSum.Text = $"Порахувати ({s--})";
            if (s < 0)
            {
                timer1.Stop();
                buttonTotalSum.Text = $"Порахувати";
                using (Form2 child = new Form2())
                {
                    if (child.ShowDialog() == DialogResult.Yes)
                    {
                        totalSum += double.Parse(labelTotalSum.Text);
                        Text = $"BestOli - Сума виручки за день: {totalSum:0.00} грн.";
                        s = 10;
                        resetForm();
                    }
                    else
                    {
                        s = 10;
                        timer1.Start();
                    }
                }

            }
        }

        private void resetForm()
        {
            textBoxQuantity.Text = "";
            textBoxAmount.Text = "";
            comboBox1.SelectedIndex = 2;
            radioButton1.Checked = true;
            labelTotalSum.Text = "0,00";
            foreach (Control control in groupBox2.Controls)
            {
                if (control is CheckBox)
                    ((CheckBox)control).Checked = false;
                else if (control is NumericUpDown)
                {
                    ((NumericUpDown)control).Value = 0;
                    ((NumericUpDown)control).ReadOnly = true;
                    ((NumericUpDown)control).Increment = 0;
                }
            }
        }
    }
}
