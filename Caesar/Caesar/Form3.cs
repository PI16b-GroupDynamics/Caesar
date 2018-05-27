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
    public partial class Form3 : Form
    {
        private int lang;
        private int num;
        public Form3()
        {
            InitializeComponent();
        }
        public Form3(int a, int b)
        {
            InitializeComponent();
            lang = a;
            num = b;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            string filename = string.Empty;
            richTextBox1.Clear();
            if (num == 1)
            {
                if (lang == 1)
                {
                    filename = "about_eng.txt";
                }
                else
                {
                    filename = "about_rus.txt";
                }
            }
            else
            {
                if(num == 2)
                {
                    if (lang == 1)
                    {
                        filename = "authors_eng.txt";
                    }
                    else
                    {
                        filename = "authors_rus.txt";
                    }
                }
                else
                {
                    if (lang == 1)
                    {
                        filename = "help_eng.txt";
                    }
                    else
                    {
                        filename = "help_rus.txt";
                    }
                }
            }
            string fileText = File.ReadAllText(filename, Encoding.Default);
            richTextBox1.Text = fileText;  
        }

    }
}
