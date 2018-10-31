using dystopia_sharp.Types;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dystopia_sharp
{
    public static class Helpers
    {
        public static void PurgeWhiteSpace(this StringReader sr)
        {
            while (true)
            {
                var curChar = (char)sr.Peek();
                if (!char.IsWhiteSpace(curChar)) return;
                sr.Read();
            }
        }
        public static string ReadWord(this StringReader sr)
        {
            var curChar = sr.ReadLetter();

            string word = string.Empty;
            char? quote = null;
            if (curChar == '\'' || curChar == '"')
            {
                quote = curChar;
            }
            else
            {
                word += curChar;
            }

            while (true)
            {
                curChar = (char)sr.Peek();
                if ((quote.HasValue && curChar == quote))
                {
                    sr.Read();
                    break;
                }
                if (!quote.HasValue && char.IsWhiteSpace(curChar)) break;
                if (curChar == 65535) break;
                sr.Read();

                word += curChar;
            }
            return word;
        }

        //public static string ReadString(this StringReader sr)
        //{
        //    var word = sr.ReadWord();
        //    if (word == "~") return string.Empty;
        //    return word;
        //}

        public static string ReadString(this StringReader sr)
        {
            sr.PurgeWhiteSpace();
            string retVal = string.Empty;
            while (true)
            {
                var curChar = (char)sr.Read();
                if (curChar == '~') return retVal;
                retVal += curChar;
            }
        }

        public static short ReadShort(this StringReader sr)
        {
            var num = sr.ReadNumber();
            if (num > short.MaxValue)
            {
                throw new ArgumentOutOfRangeException("ReadShort");
            }
            return (short)num;
        }

        public static void ReadToEOL(this StringReader sr)
        {
            while (true)
            {
                var curChar = (char)sr.Read();
                if (curChar == '\n' || curChar == '\r') break;
            }
        }

        public static int ReadNumber(this StringReader sr)
        {
            var curChar = sr.ReadLetter();
            bool negative = curChar == '-';
            if (curChar == '-' || curChar == '+') curChar = (char)sr.Read();

            // There's some subtle differences here with the original OLC reader
            // I believe the C reader would handle an empty string for the numeric value
            // since I did this with a StringReader and was lazy, I don't Peek()
            // everywhere I should.

            int number = int.Parse(curChar.ToString());
            while (true)
            {
                // We don't know if this character is a number or a special character
                // or a terminator.  So we peek and then process.  Requires you to keep
                // up with whether you've actually pulled it from the stream or not.
                curChar = (char)sr.Peek();

                // If it's not whitespace or a pipe we need to leave it on the stream
                if (!char.IsNumber(curChar)) break;

                // Pop our char off the stream
                sr.Read();
                number *= 10;
                number += int.Parse(curChar.ToString());
            }
            if (negative) number *= -1;

            if (curChar == '|')
            {
                sr.Read();
                number += sr.ReadNumber();
            }
            return number;
        }

        public static Vnum ReadVnum(this StringReader sr)
        {
            return (Vnum)sr.ReadNumber();
        }

        public static char ReadLetter(this StringReader sr)
        {
            sr.PurgeWhiteSpace();
            return (char)sr.Read();
        }

        public static char PeekLetter(this StringReader sr)
        {
            sr.PurgeWhiteSpace();
            return (char)sr.Peek();
        }

        public static int RandBits(this Random r, int numBits)
        {
            return r.Next() & ((1 << numBits) - 1);
        }

        public static int Fuzzy(this Random r, int number)
        {
            switch (r.RandBits(2))
            {
                case 0: number -= 1; break;
                case 3: number += 1; break;
            }

            return Math.Max(1, number);

        }
    }
}
