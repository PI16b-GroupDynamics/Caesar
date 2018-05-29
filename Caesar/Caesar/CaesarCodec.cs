using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caesar
{
    class CaesarCodec : List<Strip>
    {
        public string r;
        public string text;
        public int key;
        public bool status;

        public CaesarCodec()
        { //формирование коллекций лент 
            this.Add(new Strip("абвгдеёжзийклмнопрстуфхцчшщъыьэюя"));
            this.Add(new Strip("АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ"));
            this.Add(new Strip("abcdefghijklmnopqrstuvwxyz"));
            this.Add(new Strip("ABCDEFGHIJKLMNOPQRSTUVWXYZ"));
            this.Add(new Strip("0123456789"));
            this.Add(new Strip("!\"#$%^&*()+=-_'?.,|/`~№:;@[]{}"));
        }

        public void Codeс() //кодирование и декодирование в зависимости от знака ключа 
        {
            string result = "", tmp = "";
            for (int i = 0; i < text.Length; i++)
            {
                foreach (Strip v in this)
                {
                    tmp = v.Repl(text.Substring(i, 1), key);
                    if (tmp != "") //нужная лента найдена, замена символу определена 
                    {
                        result += tmp;
                        break; // прерывается foreach (перебор лент) 
                    }
                }
                if (tmp == "") result += text.Substring(i, 1); //незнакомый символ оставляю без изменений 
            }
            r = result;


            if (status == true)
            {
                (Application.OpenForms[1] as Form1).richTextBox2.Invoke(new Action(() => { (Application.OpenForms[1] as Form1).richTextBox2.Text = r; }));
            }
            else
            {
                (Application.OpenForms[1] as Form1).richTextBox1.Invoke(new Action(() => { (Application.OpenForms[1] as Form1).richTextBox1.Text = r; }));
            }
            (Application.OpenForms[1] as Form1).menuStrip1.Invoke(new Action(() => { (Application.OpenForms[1] as Form1).menuStrip1.Enabled = true; }));
            (Application.OpenForms[1] as Form1).button1.Invoke(new Action(() => { (Application.OpenForms[1] as Form1).button1.Enabled = true; }));
            (Application.OpenForms[1] as Form1).button2.Invoke(new Action(() => { (Application.OpenForms[1] as Form1).button2.Enabled = true; }));

            MessageBox.Show("Успешно!");

        }
    }
}
