using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caesar
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form1 f = new Form1();
            f.TopLevel = true;
            f.Show();
            f.Activate();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if((string)this.comboBox1.SelectedItem == "rus")
            {
                this.button2.Text = "Далее";
                this.button1.Text = "Выход";
                this.label1.Text = "Проект Цезарь";
                this.label2.Text = "Приложение для шифрования/дешифрования";
                this.label3.Text = "текстов методом Цезаря";
                this.label4.Text = "Авторы проекта:";
                this.label5.Text = "Бездетный Николай";
                this.label6.Text = "Коврик Кирилл";
            }
            else
            {
                this.button2.Text = "Next";
                this.button1.Text = "Exit";
                this.label1.Text = "Project Caesar";
                this.label2.Text = "Application for enryption/decryption";
                this.label3.Text = "of texts by Caesar cipher";
                this.label4.Text = "Project's authors:";
                this.label5.Text = "Bezdetny Nikolay";
                this.label6.Text = "Kovrik Kirill";
            }
            this.Refresh();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.comboBox1.SelectedItem = "rus";
        }
    }
}
