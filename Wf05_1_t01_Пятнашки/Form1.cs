using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace Wf05_1_t01
{
    public partial class Form1 : Form
    {
        private string fnamePlayers = "players.bin";
        private string fnameGame = "save.bin";
        private Piece[,] puzzle = new Piece[4, 4];
        private List<Player> players = new List<Player>();
        private Player player;
        private bool puzzleCompleted = false;
        private bool recordsShowed = false;

        public Form1()
        {
            InitializeComponent();
            menuStrip1.Renderer = new MyRenderer();
            statusStrip1.Padding = new Padding(statusStrip1.Padding.Left,
                statusStrip1.Padding.Top, statusStrip1.Padding.Left, statusStrip1.Padding.Bottom);
            int i = 0;
            foreach (Button button in Controls.OfType<Button>().OrderBy(b => b.Name))
            {
                //button.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 204, 228, 247);
                button.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 192, 192, 192);
                //button.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 229, 241, 251);
                button.FlatAppearance.MouseOverBackColor = Color.FromArgb(60, 192, 192, 192);
                //button.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
                button.FlatAppearance.BorderSize = 0;
                button.Click += button_Click;
                puzzle[i / 4, i - (i / 4 * 4)] = new Piece();
                puzzle[i / 4, i - (i / 4 * 4)].Btn = button;
                i++;
            }
            generate();
            textBox1.Select();
            loadList(fnamePlayers);

            CustomRTB richTextBox1 = new CustomRTB();

            richTextBox1.Location = new System.Drawing.Point(12, 8);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new System.Drawing.Size(336, 347);
            richTextBox1.TabIndex = 0;
            richTextBox1.ReadOnly = true;
            richTextBox1.BorderStyle = BorderStyle.None;
            richTextBox1.ForeColor = Color.FromArgb(200, 203, 213);
            richTextBox1.Dock = DockStyle.Fill;
            richTextBox1.SelectionTabs = new int[] { 13, 190, 270 };
            panel2.Controls.Add(richTextBox1);

            if (File.Exists(fnameGame))
            {
                ToolStripMenuLoadGame.Enabled = true;
            }
        }

        private class MyRenderer : ToolStripProfessionalRenderer
        {
            public MyRenderer() : base(new MyColors()) { }
        }

        private class MyColors : ProfessionalColorTable
        {
            public override Color MenuItemSelected
            {
                get { return Color.FromArgb(50, 229, 241, 251); }
            }
            public override Color MenuItemSelectedGradientBegin
            {
                get { return Color.FromArgb(50, 229, 241, 251); }
            }
            public override Color MenuItemSelectedGradientEnd
            {
                get { return Color.FromArgb(50, 229, 241, 251); }
            }
            public override Color MenuItemBorder
            {
                get { return Color.FromArgb(48, 48, 48); }
            }
        }

        public class CustomRTB : RichTextBox
        {
            protected override CreateParams CreateParams
            {
                get
                {
                    //This makes the control's background transparent
                    CreateParams CP = base.CreateParams;
                    CP.ExStyle |= 0x20;
                    return CP;
                }
            }
        }

        private void saveList<T>(string fname, T s)
        {
            try
            {
                using (Stream stream = File.Create(fname))
                {
                    BinaryFormatter format = new BinaryFormatter();
                    format.Serialize(stream, s);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadList(string fname)
        {
            if (File.Exists(fname))
            {
                try
                {
                    using (Stream stream = File.OpenRead(fname))
                    {
                        BinaryFormatter format = new BinaryFormatter();
                        players = (List<Player>)format.Deserialize(stream);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void generate(int[] invariants = null)
        {
            if (invariants == null || invariants.Length != 16)
            {
                Random rnd = new Random();
                invariants = Enumerable.Range(0, 16).ToArray();
                
                do
                {
                    for (int i = 0; i < invariants.Length - 1; ++i)
                    {
                        int k = rnd.Next(i, invariants.Length);
                        int tmp = invariants[i];
                        invariants[i] = invariants[k];
                        invariants[k] = tmp;
                    }
                }
                while (!canBeSolved(invariants));
            }
            
            int c = 0;
            foreach (var item in puzzle)
            {
                item.Int = invariants[c];
                item.Btn.Text = item.Int.ToString();
                if (item.Int == 0)
                {
                    item.Btn.Visible = false;
                }
                if (item.Int == 1 + c++)
                {
                    item.Btn.Visible = true;
                    item.Btn.BackColor = Color.FromArgb(70, 204, 228, 247);
                    item.Btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(50, 229, 241, 251);
                    item.Btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 229, 241, 251);
                }
            }
        }

        private bool canBeSolved(int[] invariants)
        {
            int sum = 0;
            for (int i = 0; i < 16; i++)
            {
                if (invariants[i] == 0)
                {
                    sum += i / 4;
                    continue;
                }

                for (int j = i + 1; j < 16; j++)
                {
                    if (invariants[j] < invariants[i])
                        sum++;
                }
            }
            return sum % 2 == 0;
        }

        private void turn(int num)
        {
            int i = 0, j = 0;
            for (int k = 0; k < 4; k++)
            {
                for (int l = 0; l < 4; l++)
                {
                    if (puzzle[k, l].Int == num)
                    {
                        i = k;
                        j = l;
                    }
                }
            }
            if (i > 0)
            {
                if (puzzle[i - 1, j].Int == 0)
                {
                    puzzle[i - 1, j].Int = num;
                    puzzle[i, j].Int = 0;
                    afterTurn(ref num);
                }
            }
            if (i < 3)
            {
                if (puzzle[i + 1, j].Int == 0)
                {
                    puzzle[i + 1, j].Int = num;
                    puzzle[i, j].Int = 0;
                    afterTurn(ref num);
                }
            }
            if (j > 0)
            {
                if (puzzle[i, j - 1].Int == 0)
                {
                    puzzle[i, j - 1].Int = num;
                    puzzle[i, j].Int = 0;
                    afterTurn(ref num);
                }
            }
            if (j < 3)
            {
                if (puzzle[i, j + 1].Int == 0)
                {
                    puzzle[i, j + 1].Int = num;
                    puzzle[i, j].Int = 0;
                    afterTurn(ref num);
                }
            }
        }

        private void afterTurn(ref int num)
        {
            repaintField(num);
            timer1.Enabled = true;
            toolStripStatusLabel3.Text = "Ходiв: " + (++player.Turn);

            if (checkPuzzleCompleted())
            {
                puzzleCompleted = true;
                timer1.Enabled = false;
                player.Date = DateTime.Now;
                players.Add(player);
                saveList(fnamePlayers, players);
                toolStripStatusLabel2.Text = "Рекорд: " + players.Where(p => p.Name == player.Name).Min(p => p.Turn);
                ToolStripMenuSaveGame.Enabled = false;
                recordsShowed = false;
            }
        }

        private void repaintField(int num = 0)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    puzzle[i, j].Btn.Text = puzzle[i, j].Int.ToString();
                    
                    if (puzzle[i, j].Int == 0)
                        puzzle[i, j].Btn.Visible = false;
                    else
                        puzzle[i, j].Btn.Visible = true;

                    if (puzzle[i, j].Int == i * 4 + j + 1)
                    { 
                        puzzle[i, j].Btn.BackColor = Color.FromArgb(70, 204, 228, 247);
                        puzzle[i, j].Btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(50, 229, 241, 251);
                        puzzle[i, j].Btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 229, 241, 251);
                    }
                    else
                    {
                        puzzle[i, j].Btn.BackColor = Color.FromArgb(70, 192, 192, 192);
                        puzzle[i, j].Btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 192, 192, 192);
                        puzzle[i, j].Btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(60, 192, 192, 192);
                    }

                    if (puzzle[i, j].Int == num)
                        puzzle[i, j].Btn.Select();
                }
            }
        }

        public bool checkPuzzleCompleted()
        {
            int i = 1;
            foreach (var item in puzzle)
            {
                if (item.Int == i || i == 16)
                    i++;
                else
                    return false;
            }
            return true;
        }

        private void button_Click(object sender, EventArgs e)
        {
            if (!puzzleCompleted)
                turn(int.Parse((sender as Button).Text));
        }

        private void bStart_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != "")
            {
                player = new Player { Name = textBox1.Text.Trim(), Date = DateTime.Now, Time = TimeSpan.Zero, Turn = 0 };
                toolStripStatusLabel1.Text = textBox1.Text.Trim();
                toolStripStatusLabel2.Text = "Рекорд: " + 
                    players.Where(p => p.Name == player.Name).Min(p => (int?)p.Turn).GetValueOrDefault(0);
                ToolStripMenuNewPlayer.Enabled = true;
                ToolStripMenuNewGame.Enabled = true;
                ToolStripMenuSaveGame.Enabled = true;
                panel1.Visible = false;
                statusStrip1.Visible = true;
            }
            else
                textBox1.Select();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && panel1.Visible)
            {
                bStart_Click(this, new EventArgs());
            }
        }

        // new game
        private void ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            generate();
            repaintField();
            timer1.Enabled = false;
            player.Turn = 0;
            toolStripStatusLabel3.Text = "Ходiв: 0";
            player.Time = TimeSpan.Zero;
            toolStripStatusLabel4.Text = "00:00";
            panel2.Visible = false;
            ToolStripMenuItem6.BackColor = Color.FromArgb(48, 48, 48);
            statusStrip1.Visible = true;
        }

        // new player
        private void ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            panel1.Visible = true;
            ToolStripMenuNewGame.PerformClick();
            ToolStripMenuNewPlayer.Enabled = false;
            ToolStripMenuNewGame.Enabled = false;
            ToolStripMenuSaveGame.Enabled = false;
            textBox1.Select();
            statusStrip1.Visible = false;
            panel2.Visible = false;
            ToolStripMenuItem6.BackColor = Color.FromArgb(48, 48, 48);
        }

        // load game
        private void ToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (File.Exists(fnameGame))
            {
                try
                {
                    int[] tmp;
                    using (Stream stream = File.OpenRead(fnameGame))
                    {
                        BinaryFormatter format = new BinaryFormatter();
                        tmp = (int[])format.Deserialize(stream);
                        player = (Player)format.Deserialize(stream);
                    }
                    generate(tmp);
                    repaintField();
                    timer1.Enabled = false;
                    toolStripStatusLabel1.Text = player.Name;
                    toolStripStatusLabel2.Text = "Рекорд: " +
                        players.Where(p => p.Name == player.Name).Min(p => (int?)p.Turn).GetValueOrDefault(0);
                    toolStripStatusLabel3.Text = "Ходiв: " + (player.Turn);
                    toolStripStatusLabel4.Text = player.Time.ToString(@"mm\:ss");
                    ToolStripMenuNewPlayer.Enabled = true;
                    ToolStripMenuNewGame.Enabled = true;
                    ToolStripMenuSaveGame.Enabled = true;
                    panel1.Visible = false;
                    statusStrip1.Visible = true;
                    panel2.Visible = false;
                    ToolStripMenuItem6.BackColor = Color.FromArgb(48, 48, 48);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        // save game
        private void ToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            try
            {
                using (Stream stream = File.Create(fnameGame))
                {
                    BinaryFormatter format = new BinaryFormatter();

                    int width = puzzle.GetLength(0);
                    int height = puzzle.GetLength(1);
                    int[] tmp = new int [width * height];

                    for (int i = 0; i < width; i++)
                    {
                        for (int j = 0; j < height; j++)
                        {
                            tmp[i * 4 + j] = puzzle[i, j].Int;
                        }
                    }
                    format.Serialize(stream, tmp);
                    format.Serialize(stream, player);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            panel2.Visible = false;
            ToolStripMenuItem6.BackColor = Color.FromArgb(48, 48, 48);
            statusStrip1.Visible = true;
            toolStripStatusLabel1.Text = "Гру збережено";
            
            var t = new Timer();
            t.Interval = 2000;
            t.Tick += (s, ev) =>
            {
                toolStripStatusLabel1.Text = player.Name;
                t.Stop();
            };
            t.Start();
        }

        // show records
        private void ToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            panel2.Visible = !panel2.Visible;
            ToolStripMenuItem6.BackColor = panel2.Visible ?
                Color.FromArgb(50, 229, 241, 251) : Color.FromArgb(48, 48, 48);
            statusStrip1.Visible = (!panel2.Visible && !panel1.Visible);

            if (!recordsShowed)
            {
                recordsShowed = true;
                panel2.Controls.OfType<RichTextBox>().First().Clear();

                players.GroupBy(x => x.Name).SelectMany(y => y.Where(z => z.Turn == y.Min(i => i.Turn))).OrderBy(i => i.Turn).ToList().ForEach(i =>
                {
                    string rtf = @"{\rtf1\ansi \b " + i.Name + @"\b0\line " + "\t" +
                    i.Date.ToString("dd.MM.yyyy  HH:mm:ss") + "\t" + i.Turn + "\t" +
                    i.Time.ToString(@"mm\:ss") + @"\line \line ";
                    panel2.Controls.OfType<RichTextBox>().First().SelectedRtf = rtf;
                });
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            player.Time += TimeSpan.FromSeconds(1);
            toolStripStatusLabel4.Text = player.Time.ToString(@"mm\:ss");
        }

        private class Piece
        {
            public int Int { get; set; }
            public Button Btn { get; set; }
        }

        [Serializable]
        public class Player
        {
            public string Name { get; set; }
            public DateTime Date { get; set; }
            public TimeSpan Time { get; set; }
            public int Turn { get; set; }
        }
    }
}