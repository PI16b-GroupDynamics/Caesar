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
using System.Threading;

namespace Caesar
{
    public partial class Form1 : Form
    {
        CaesarCodec Caesar = new CaesarCodec();
        string s;
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
            s = string.Empty;
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
                if (checkBox1.Checked == true)
                {
                    if (backgroundWorker1.IsBusy != true)
                    {
                        backgroundWorker1.RunWorkerAsync();
                    }
                    //Hacking();
                }
                else
                {
                    richTextBox1.Text = Caesar.Codeс(richTextBox2.Text, -(int)numericUpDown1.Value);
                    MessageBox.Show("Успешно!");
                }

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
                int key = shift.ElementAt(0).Key;

                richTextBox1.Invoke(new Action(() => { richTextBox1.Text = Caesar.Codeс(richTextBox2.Text, -(int)key); }));
                //richTextBox1.Text = Caesar.Codeс(richTextBox2.Text, -(int)key);
                MessageBox.Show("Взлом! Ключ: " + key);
            }
        

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            // Do not access the form's BackgroundWorker reference directly.
            // Instead, use the reference provided by the sender parameter.
            BackgroundWorker bw = sender as BackgroundWorker;

            // Extract the argument.
            // Start the time-consuming operation.
            
            //e.Result = Hacking();

            // If the operation was canceled by the user, 
            // set the DoWorkEventArgs.Cancel property to true.
            if (bw.CancellationPending)
            {
                e.Cancel = true;
            }
            else
            {
                Hacking();
            }
        }

        

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // This event handler is called when the background thread finishes. 
            // This method runs on the main thread. 
            if (e.Error != null)
                MessageBox.Show("Error: " + e.Error.Message);
            else if (e.Cancelled)
                MessageBox.Show("Word counting canceled.");
            else
                MessageBox.Show("Finished counting words.");
        }
    }

       
    
}
