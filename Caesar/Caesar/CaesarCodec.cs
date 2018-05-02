using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caesar
{
    class CaesarCodec:List<Strip>
    {
        public CaesarCodec()
        { //формирование коллекций лент 
            this.Add(new Strip("абвгдеёжзийклмнопрстуфхцчшщъыьэюя"));
            this.Add(new Strip("АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ"));
            this.Add(new Strip("abcdefghijklmnopqrstuvwxyz"));
            this.Add(new Strip("ABCDEFGHIJKLMNOPQRSTUVWXYZ"));
            this.Add(new Strip("0123456789"));
            this.Add(new Strip("!\"#$%^&*()+=-_'?.,|/`~№:;@[]{}"));
        }

        public string Codeс(string text, int key) //кодирование и декодирование в зависимости от знака ключа 
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
            return result;
        }
    }
}
