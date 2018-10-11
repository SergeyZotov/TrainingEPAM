using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    internal class MyString
    {
        private char[] newCharArr;

        public MyString(string str)
        {
            int index = 0;
            newCharArr = new char[str.Length];

            while(index < str.Length)
            {
                newCharArr[index] = str[index];
                index++;
            }
        }

        public static MyString operator +(MyString string1, MyString string2)
        {
            int firstStringLength = string1.Length;

            string resultString = string1.ToString();

            for (int i = 0; i < string2.Length; ++i)
            {
                resultString += string2[i];
            }

            return new MyString(resultString);
        }

        public static MyString operator -(MyString srcString, MyString substring)
        {
            int index = 0;

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < srcString.Length; ++i)
            {

            }

            return new MyString(sb.ToString());
        }

        public static bool operator ==(MyString string1, MyString string2)
        {
            if (string1.ToString() == string2.ToString())
                return true;
            else
                return false;
        }

        public static bool operator !=(MyString string1, MyString string2)
        {
            if (string1.ToString() == string2.ToString())
                return false;
            else
                return true;
        }

        public override string ToString()
        {

            StringBuilder sb = new StringBuilder();

            foreach(char value in newCharArr)
            {
                sb.Append(value);
            }

            return sb.ToString();
        }

        public char this[int index]
        {
            get
            {
                if (index >-1 && index < newCharArr.Length)
                    return newCharArr[index];
                else throw new ArgumentOutOfRangeException();
            }

            set
            {
                if (index > newCharArr.Length)
                    throw new ArgumentOutOfRangeException();

                newCharArr[index] = value;
            }
            
        }

        internal int Length { get => newCharArr.Length; }
    }    
}
