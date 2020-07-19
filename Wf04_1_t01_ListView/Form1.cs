using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Wf04_1_t01
{
    public partial class Form1 : Form
    {
        private string fname = "list.bin";
        private List<Student> students = new List<Student>();
        private Color shadeColor = Color.FromArgb(240, 240, 240);
        private bool shouldShade = false;

        public Form1()
        {
            Student.sortOrder = SortOrder.None;
            InitializeComponent();
        }

        private void colorizeListView()
        {
            shouldShade = false;
            foreach (ListViewItem item in listView1.Items)
            {
                item.BackColor = shouldShade == true ? shadeColor : SystemColors.Window;
                shouldShade = !shouldShade;
            }
        }

        static void saveList<T>(string fname, T s)
        {
            try
            {
                using (Stream stream = File.Create(fname))
                {
                    BinaryFormatter format = new BinaryFormatter();
                    format.Serialize(stream, s);
                    format.Serialize(stream, Student.sortOrder);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists(fname))
            {
                try
                {
                    using (Stream stream = File.OpenRead(fname))
                    {
                        BinaryFormatter format = new BinaryFormatter();
                        students = (List<Student>)format.Deserialize(stream);
                        Student.sortOrder = (SortOrder)format.Deserialize(stream);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                students.ForEach(s => {
                    ListViewItem listViewItem = new ListViewItem(s.ToStringArray());
                    listView1.Items.Add(listViewItem);
                });
                colorizeListView();
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            using (Form2 child = new Form2())
            {
                if (child.ShowDialog() == DialogResult.OK)
                {
                    students.Add(child.Stud);
                    ListViewItem listViewItem = new ListViewItem(child.Stud.ToStringArray());
                    if (shouldShade == true)
                        listViewItem.BackColor = shadeColor;
                    listView1.Items.Add(listViewItem);
                    shouldShade = !shouldShade;
                    listView1.SelectedIndices.Clear();
                    listView1.SelectedIndices.Add(listView1.Items.IndexOf(listViewItem));
                    listView1.Select();
                    saveList(fname, students);
                }
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count != 0)
            {
                int n = listView1.SelectedIndices[0];
                for (int i = listView1.SelectedIndices.Count - 1; i >= 0; i--)
                {
                    students.RemoveAt(listView1.SelectedIndices[i]);
                    listView1.Items.RemoveAt(listView1.SelectedIndices[i]);
                }
                listView1.SelectedIndices.Clear();
                if (n < listView1.Items.Count)
                    listView1.SelectedIndices.Add(n);
                else if (listView1.Items.Count != 0)
                    listView1.SelectedIndices.Add(listView1.Items.Count - 1);
                colorizeListView();
                listView1.Select();
                saveList(fname, students);
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count == 1)
            {
                int n = listView1.SelectedIndices[0];
                using (Form2 child = new Form2())
                {
                    child.Stud = students[n];
                    if (child.ShowDialog() == DialogResult.OK)
                    {
                        students[n] = child.Stud;
                        listView1.Items[n].SubItems[0].Text = child.Stud.PIB;
                        listView1.Items[n].SubItems[1].Text = child.Stud.Bday.ToShortDateString();
                        listView1.Items[n].SubItems[2].Text = child.Stud.Avg.ToString();
                    }
                }
                listView1.Select();
                saveList(fname, students);
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            using (Form3 child = new Form3())
            {
                if (child.ShowDialog() == DialogResult.Yes)
                {
                    students.Clear();
                    listView1.Items.Clear();
                    saveList(fname, students);
                }
            }
        }

        private void listView1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                buttonDel_Click(sender, e);
            }
            if (e.KeyCode == Keys.Enter)
            {
                buttonEdit_Click(sender, e);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                buttonAdd_Click(sender, e);
            }
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            switch (e.Column)
            {
                case 0:
                    if (Student.sortOrder == SortOrder.None || Student.sortOrder == SortOrder.Descending)
                    {
                        students.Sort((st1, st2) => st1.PIB.CompareTo(st2.PIB));
                        Student.sortOrder = SortOrder.Ascending;
                    }
                    else
                    {
                        students.Sort((st1, st2) => st2.PIB.CompareTo(st1.PIB));
                        Student.sortOrder = SortOrder.Descending;
                    }
                    break;
                case 1:
                    if (Student.sortOrder == SortOrder.None || Student.sortOrder == SortOrder.Descending)
                    {
                        students.Sort((st1, st2) => st1.Bday.CompareTo(st2.Bday));
                        Student.sortOrder = SortOrder.Ascending;
                    }
                    else
                    {
                        students.Sort((st1, st2) => st2.Bday.CompareTo(st1.Bday));
                        Student.sortOrder = SortOrder.Descending;
                    }
                    break;
                case 2:
                    if (Student.sortOrder == SortOrder.None || Student.sortOrder == SortOrder.Descending)
                    {
                        students.Sort((st1, st2) => st1.Avg.CompareTo(st2.Avg));
                        Student.sortOrder = SortOrder.Ascending;
                    }
                    else
                    {
                        students.Sort((st1, st2) => st2.Avg.CompareTo(st1.Avg));
                        Student.sortOrder = SortOrder.Descending;
                    }
                    break;
                default:
                    break;
            }
            listView1.Items.Clear();
            students.ForEach(s => {
                ListViewItem listViewItem = new ListViewItem(s.ToStringArray());
                listView1.Items.Add(listViewItem);
            });
            colorizeListView();
            saveList(fname, students);
        }
    }
}
