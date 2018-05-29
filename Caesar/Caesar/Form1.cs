﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace Caesar
{
    public partial class Form1 : Form
    {
        CaesarCodec Caesar = new CaesarCodec();
        string s;
        int Key;
        Thread Thr;
        Thread Thread1;
        Thread Thread2;
        Thread Thread3;
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string s = string.Empty;
            s = richTextBox1.Text;
            if (s.Length > 1000000)
            {
                MessageBox.Show("Количество кодируемых символов не должно превышать 1000000!");
            }
            else
            {
                menuStrip1.Enabled = false;
                button1.Enabled = false;
                button2.Enabled = false;

                Caesar.text = s;
                Caesar.key = (int)numericUpDown1.Value;
                Caesar.status = true;
                Thr = new Thread(Caesar.Codeс);
                Thr.IsBackground = true;
                Thr.Start();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            s = string.Empty;
            s = richTextBox2.Text;
            if (s.Length > 1000000)
            {
                MessageBox.Show("Количество декодируемых символов не должно превышать 1000000!");
            }
            else
            {
                menuStrip1.Enabled = false;
                button1.Enabled = false;
                button2.Enabled = false;
                Caesar.text = s;
                Caesar.key = -(int)numericUpDown1.Value;
                Caesar.status = false;


                if (checkBox1.Checked == true)
                {
                    Thread1 = new Thread(Hacking);
                    Thread1.IsBackground = true;
                    Thread1.Start();


                    Caesar.key = -Key;
                    Thread2 = new Thread(Caesar.Codeс);
                    Thread2.IsBackground = true;
                    Thread2.Start();

                }
                else
                {

                    Thread3 = new Thread(Caesar.Codeс);
                    Thread3.IsBackground = true;
                    Thread3.Start();
                }

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


        public void Hacking()
        {
            s = s.ToLower();
            string freqrus = "оаеинтрслвкпмудяыьзбгйчюхжшцщфэъ";
            string alf = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            Dictionary<string, int> freq = new Dictionary<string, int>();
            Dictionary<int, int> shift = new Dictionary<int, int>();
            for (int i = 0; i < s.Length; i++)
            {
                string newl = s.Substring(i, 1);
                int newpos = alf.IndexOf(newl);
                if (newpos != -1)
                {
                    if (freq.ContainsKey(newl))
                    {
                        freq[newl]++;
                    }
                    else
                    {
                        freq.Add(newl, 1);
                    }
                }
            }


            for (int i = 0; i < freq.LongCount() - 1; i++)
            {
                for (int j = 0; j < freq.LongCount() - i - 1; j++)
                {
                    if (freq.ElementAt(j).Value <= freq.ElementAt(j + 1).Value)
                    {
                        // меняем элементы местами
                        var temp = freq[freq.ElementAt(j).Key];
                        freq[freq.ElementAt(j).Key] = freq[freq.ElementAt(j + 1).Key];
                        freq[freq.ElementAt(j + 1).Key] = temp;
                    }
                }
            }

            for (int i = 0; i < freq.LongCount() - 1; i++)
            {
                string emperical = freqrus.Substring(i, 1);
                string theoretical = freq.ElementAt(i).Key;
                int count = 0;
                for (int p = 0; p < alf.Length; p++)
                {
                    if (alf.Substring(p, 1) == emperical)
                    {
                        while (alf.Substring(p, 1) != theoretical)
                        {
                            p++;
                            count++;
                        }
                        break;
                    }
                    if (alf.Substring(p, 1) == theoretical)
                    {
                        while (alf.Substring(p, 1) != emperical)
                        {
                            p++;
                            count++;
                        }
                        break;
                    }
                }
                if (shift.ContainsKey(count))
                {
                    shift[count]++;
                }
                else
                {
                    shift.Add(count, 1);
                }
            }


            for (int i = 0; i < shift.LongCount() - 1; i++)
            {
                for (int j = 0; j < shift.LongCount() - i - 1; j++)
                {
                    if (shift.ElementAt(j).Value <= shift.ElementAt(j + 1).Value)
                    {
                        // меняем элементы местами
                        var temp = shift[shift.ElementAt(j).Key];
                        shift[shift.ElementAt(j).Key] = shift[shift.ElementAt(j + 1).Key];
                        shift[shift.ElementAt(j + 1).Key] = temp;
                    }
                }
            }
            Key = 3;
            if (shift.Count != 0)
            {
                Key = shift.ElementAt(0).Key;
            }

            MessageBox.Show("Взлом! Ключ: " + Key);
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

            this.checkBox1.Text = "Взлом шифра";
            this.toolTip1.SetToolTip(this.checkBox1, "Взлом шифра происходит только на русском языке");

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

            this.checkBox1.Text = "Hack cipher";
            this.toolTip1.SetToolTip(this.checkBox1, "Hacking the cipher is only in Russian");

            this.Refresh();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (this.button1.Text == "Encrypt")
            {
                Form3 f = new Form3(1, 1);
                f.Show();
            }
            else
            {
                Form3 f = new Form3(0, 1);
                f.Show();
            }
        }

        private void обАвторахToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.button1.Text == "Encrypt")
            {
                Form3 f = new Form3(1, 2);
                f.Show();
            }
            else
            {
                Form3 f = new Form3(0, 2);
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

        private void отменаToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Thr != null)
            {
                Thr.Abort();
            }
            if (Thread1 != null)
            {
                Thread1.Abort();
            }
            if (Thread2 != null)
            {
                Thread2.Abort();
            }
            if (Thread3 != null)
            {
                Thread3.Abort();
            }
            menuStrip1.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = true;
        }
    }



}
