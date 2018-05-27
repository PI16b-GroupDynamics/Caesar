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

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void русскийToolStripMenuItem_Click(object sender, EventArgs e)
        {
                this.button1.Text = "Зашифровать";
                this.toolTip1.SetToolTip(this.button1, "Зашифровать методом Цезаря");

                this.button2.Text = "Расшифровать";
                this.toolTip1.SetToolTip(this.button2, "Расшифровать текст, зашифрованный методом Цезаря");


                this.файлToolStripMenuItem.Text = "Файл";

                this.открытьToolStripMenuItem.Text = "Открыть на шифрование";

                this.сохранитьКакToolStripMenuItem.Text = "Сохранить зашифрованный";

                this.открытьНаРасшифровкуToolStripMenuItem.Text = "Открыть на расшифровку";

                this.сохранитьРасшифрованныйToolStripMenuItem.Text = "Сохранить расшифрованный";

                this.настройкиToolStripMenuItem.Text = "Настройки";

                this.справкаToolStripMenuItem.Text = "Справка";

                this.оПрограммеToolStripMenuItem.Text = "О программе";

                this.помощьToolStripMenuItem.Text = "Помощь";

                this.обАвторахToolStripMenuItem.Text = "Об авторах";

                this.выходToolStripMenuItem.Text = "Выход";

                this.label1.Text = "Обычный текст";

                this.label2.Text = "Зашифрованный текст";

                this.label3.Text = "Ключ";

                this.toolTip1.SetToolTip(this.numericUpDown1, "Размер смещения для шифрования/дешифрования");

                this.toolTip1.ToolTipTitle = "Подсказка";

                this.языкToolStripMenuItem.Text = "Язык";

                this.русскийToolStripMenuItem.Text = "Русский";

                this.английскийToolStripMenuItem.Text = "Английский";

                 this.Refresh();
        }

        private void английскийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.button1.Text = "Encrypt";
            this.toolTip1.SetToolTip(this.button1, "Encrypt by Caesar method");

            this.button2.Text = "Decrypt";
            this.toolTip1.SetToolTip(this.button2, "Decrypt by Caesar method");


            this.файлToolStripMenuItem.Text = "File";

            this.открытьToolStripMenuItem.Text = "Open to encrypt";

            this.сохранитьКакToolStripMenuItem.Text = "Save encrypted";

            this.открытьНаРасшифровкуToolStripMenuItem.Text = "Open to decrypt";

            this.сохранитьРасшифрованныйToolStripMenuItem.Text = "Save decrypted";

            this.настройкиToolStripMenuItem.Text = "Settings";

            this.справкаToolStripMenuItem.Text = "Help";

            this.оПрограммеToolStripMenuItem.Text = "About";

            this.помощьToolStripMenuItem.Text = "Help";

            this.обАвторахToolStripMenuItem.Text = "About authors";

            this.выходToolStripMenuItem.Text = "Exit";

            this.label1.Text = "Normal text";

            this.label2.Text = "Encrypted text";

            this.label3.Text = "Key";

            this.toolTip1.SetToolTip(this.numericUpDown1, "The size of the offset for encryption / decryption");

            this.toolTip1.ToolTipTitle = "Hint";

            this.языкToolStripMenuItem.Text = "Language";

            this.русскийToolStripMenuItem.Text = "Russian";

            this.английскийToolStripMenuItem.Text = "English";

            this.Refresh();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (this.button1.Text == "Encrypt") {
                Form3 f = new Form3(1,1);
                f.Show();
            }
            else
            {
                Form3 f = new Form3(0,1);
                f.Show();
            }
        }

        private void обАвторахToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.button1.Text == "Encrypt")
            {
                Form3 f = new Form3(1,2);
                f.Show();
            }
            else
            {
                Form3 f = new Form3(0,2);
                f.Show();
            }
        }

        private void помощьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.button1.Text == "Encrypt")
            {
                Form3 f = new Form3(1, 3);
                f.Show();
            }
            else
            {
                Form3 f = new Form3(0, 3);
                f.Show();
            }
        }
    }
}
