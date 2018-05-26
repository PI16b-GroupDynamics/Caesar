using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Caesar
{
    public partial class Form1 : Form
    {
        CaesarCodec Caesar = new CaesarCodec();

        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = string.Empty;
            s = richTextBox2.Text;
            if (s.Length > 1000000)
            {
                MessageBox.Show("Количество кодируемых символов не должно превышать 1000000!");
            }
            else
            {
                файлToolStripMenuItem.Enabled = false;
                выходToolStripMenuItem.Enabled = false;
                настройкиToolStripMenuItem.Enabled = false;
                справкаToolStripMenuItem.Enabled = false;
                richTextBox2.Text = Caesar.Codeс(richTextBox1.Text, (int)numericUpDown1.Value);
                MessageBox.Show("Успешно!");
                файлToolStripMenuItem.Enabled = true;
                выходToolStripMenuItem.Enabled = true;
                настройкиToolStripMenuItem.Enabled = true;
                справкаToolStripMenuItem.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string s = string.Empty;
            s = richTextBox2.Text;
            if (s.Length > 1000000)
            {
                MessageBox.Show("Количество декодируемых символов не должно превышать 1000000!");
            }
            else
            {
                файлToolStripMenuItem.Enabled = false;
                выходToolStripMenuItem.Enabled = false;
                настройкиToolStripMenuItem.Enabled = false;
                справкаToolStripMenuItem.Enabled = false;
                richTextBox1.Text = Caesar.Codeс(richTextBox2.Text, -(int)numericUpDown1.Value);
                MessageBox.Show("Успешно!");
                файлToolStripMenuItem.Enabled = true;
                выходToolStripMenuItem.Enabled = true;
                настройкиToolStripMenuItem.Enabled = true;
                справкаToolStripMenuItem.Enabled = true;
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {

            richTextBox1.Clear();
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            FileInfo fi1 = new FileInfo(filename);
            if (fi1.Length > 1000000)
            {
                MessageBox.Show("Размер открываемого файла не должен превышать 1мб !");
            }
            else
            {
            // читаем файл в строку
                string fileText = File.ReadAllText(filename, Encoding.Default);
                richTextBox1.Text = fileText;
                MessageBox.Show("Файл открыт");
            }
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt";
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = saveFileDialog1.FileName;
            // сохраняем текст в файл
            System.IO.File.WriteAllText(filename, richTextBox2.Text, Encoding.UTF8);
            MessageBox.Show("Файл сохранен");
        }

        private void открытьНаРасшифровкуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox2.Clear();
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            FileInfo fi1 = new FileInfo(filename);
            if (fi1.Length > 1000000)
            {
                MessageBox.Show("Размер открываемого файла не должен превышать 1мб !");
            }
            else
            {
                string fileText = File.ReadAllText(filename, Encoding.Default);
                richTextBox2.Text = fileText;
                MessageBox.Show("Файл открыт");
            }
        }

        private void сохранитьРасшифрованныйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt";
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = saveFileDialog1.FileName;
            // сохраняем текст в файл
            System.IO.File.WriteAllText(filename, richTextBox1.Text, Encoding.UTF8);
            MessageBox.Show("Файл сохранен");

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.B && e.Control)
            {
                button1.PerformClick();// имитируем нажатие button1
            }
            if (e.KeyCode == Keys.N && e.Control)
            {
                button2.PerformClick();// имитируем нажатие button1
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
