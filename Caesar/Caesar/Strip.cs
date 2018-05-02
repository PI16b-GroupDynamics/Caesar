using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caesar
{
    class Strip
    {
        string le;

        public Strip(string letter)
        {
            le = letter;
        }

        public string Repl(string letter, int key) //замена символа m на символ со смещением 
        {
            int pos = le.IndexOf(letter);
            if (pos == -1) return ""; //символ в этой ленте не найден 
            pos = (pos + key) % le.Length; //если смещение больше одного круга 
            if (pos < 0) pos += le.Length;
            return le.Substring(pos, 1);
        }
    }
}
