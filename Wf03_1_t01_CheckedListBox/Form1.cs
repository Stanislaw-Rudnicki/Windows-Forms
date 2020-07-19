// Створити програму за поданим зразком
// Для програми розробити клас Студент з полями ПІБ та Вік.
// При натисканні на кнопку додати створюється новий студент
// з полями з відповідних компонентів, який зберігається у список.
// У компоненті CheckedListbox відображаються всі прізвища доданих студентів.
// При виборі студентів автоматично підраховується середній вік вибраних.
// При натисканні на кнопку ВИДАЛИТИ – зі списку видаляють позначенні студенти.
// Кнопка ОЧИСТИТИ – очищує весь список студентів.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wf03_1_t01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            Font = new Font(SystemFonts.DialogFont.Name, Font.Size + 1.0F, Font.Style, Font.Unit);
            InitializeComponent();
            groupBox1.Font = groupBox2.Font = new Font(SystemFonts.DialogFont.Name, Font.Size - 1.0F, Font.Style, Font.Unit);
            foreach (Control item in groupBox1.Controls)
            {
                item.Font = Font;
            }
            label3.Font = new Font(SystemFonts.DialogFont.Name, Font.Size + 24.0F, FontStyle.Bold, Font.Unit);
            label3.Location = new Point(groupBox2.Width / 2 - label3.Width / 2, groupBox2.Height / 2 - label3.Height / 2);
            textBox1.Validating += tb1Validating;
            textBox2.Validating += tb2Validating;
            textBox2.KeyPress += textBox2_KeyPress;
            buttonAdd.Click += buttonAdd_Click;
            buttonDel.Click += buttonDel_Click;
            buttonClear.Click += buttonClear_Click;
            checkedListBox1.DataSource = students;
            checkedListBox1.DisplayMember = "PIB";
        }

        private Control firstInvalidControl;

        private List<Student> students = new List<Student>() {
            new Student { PIB = "Устименко Я.І.", Age = 11},
            new Student { PIB = "Устименко Л.М.", Age = 22},
            new Student { PIB = "Устименко Т.Я.", Age = 33},
            new Student { PIB = "Устименко С.Я.", Age = 44},
            new Student { PIB = "Устименко І.О.", Age = 55},
            new Student { PIB = "Устименко Л.В.", Age = 66},
            new Student { PIB = "Устименко І.І.", Age = 77},
            new Student { PIB = "Устименко М.І.", Age = 88},
            };
        
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void tb1Validating(object sender, CancelEventArgs e)
        {
            var tb = sender as TextBox;
            errorProvider1.SetIconPadding(tb, 2);
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

        private void tb2Validating(object sender, CancelEventArgs e)
        {
            var tb = sender as TextBox;
            errorProvider1.SetIconPadding(tb, 2);
            if (String.IsNullOrEmpty(tb.Text))
            {
                errorProvider1.SetError(tb, "Поле не заполнено!");
                e.Cancel = true;
            }
            else if (!tb.Text.All(char.IsDigit))
            {
                errorProvider1.SetError(tb, "Поле заполнено некорректно!");
                e.Cancel = true;
            }
            else if (int.Parse(tb.Text) < 6 || int.Parse(tb.Text) > 120)
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

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            firstInvalidControl = null;
            if (!ValidateChildren())
                firstInvalidControl?.Select();
            else
            {
                checkedListBox1.DataSource = null;
                students.Add(new Student { PIB = textBox1.Text, Age = int.Parse(textBox2.Text)} );
                checkedListBox1.DataSource = students;
                checkedListBox1.DisplayMember = "PIB";
                textBox1.Text = textBox2.Text = "";
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Ви впевнені, що хочете видалити всіх?",
                "Очистка списку",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                checkedListBox1.DataSource = null;
                students.Clear();
                label3.Text = "--";
                label3.Location = new Point(groupBox2.Width / 2 - label3.Width / 2, groupBox2.Height / 2 - label3.Height / 2);
            }
        }

        //private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        //{
            //if (checkedListBox1.CheckedItems.Count != 0)
            //{
            //    label3.Text = checkedListBox1.CheckedItems.Cast<Student>().Average(s => s.Age).ToString("#.##");
            //}
            //else
            //{
            //    label3.Text = "--";
            //}
            //label3.Location = new Point(groupBox2.Width / 2 - label3.Width / 2, groupBox2.Height / 2 - label3.Height / 2);
        //}

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Unchecked)
            {
                var res = checkedListBox1.CheckedItems
                    .Cast<Student>().Where(s => s != (checkedListBox1.Items[e.Index] as Student))
                    .Select(s => s.Age).ToArray();
                
                if (res.Length != 0)
                    label3.Text = res.Average().ToString("#.##");
                else
                    label3.Text = "--";
            }
            else if (e.NewValue == CheckState.Checked)
            {
                label3.Text = checkedListBox1.CheckedItems
                    .Cast<Student>()
                    .Select(s => s.Age)
                    .Append((checkedListBox1.Items[e.Index] as Student).Age)
                    .Average().ToString("#.##");
            }
            label3.Location = new Point(groupBox2.Width / 2 - label3.Width / 2, groupBox2.Height / 2 - label3.Height / 2);
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.CheckedItems.Count != 0)
            {
                checkedListBox1.CheckedItems
                    .OfType<Student>()
                    .ToList()
                    .ForEach(i => students.Remove(i));
                checkedListBox1.DataSource = null;
            checkedListBox1.DataSource = students;
            checkedListBox1.DisplayMember = "PIB";
            label3.Text = "--";
            label3.Location = new Point(groupBox2.Width / 2 - label3.Width / 2, groupBox2.Height / 2 - label3.Height / 2);
            }
        }

        private void form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }
    }
}
