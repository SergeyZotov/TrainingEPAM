using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    internal class MyString
    {
        private char[] myString;

        public MyString(string str)
        {
            int index = 0;
            myString = new char[str.Length];

            while(index < str.Length)
            {
                myString[index] = str[index];
                index++;
            }
        }

        public static MyString operator +(MyString string1, MyString string2)
        {
            StringBuilder resultString = new StringBuilder(string1.ToString());       

            for (int i = 0; i < string2.Length; ++i)
            {
                resultString.Append(string2[i]);
            }

            return new MyString(resultString.ToString());
        }

        public static MyString operator -(MyString mainString, MyString subString)
        {
            /*MyString myString = new MyString("");

            for (int i = 0; i < mainString.Length - subString.Length; ++i)
            {
                myString = GetString(mainString, subString, myString, ref i);
            }*/

            return new MyString(mainString.ToString().Replace(subString.ToString(), ""));
            //return myString;
        }
        
        private static MyString GetString(MyString mainString, MyString subString, MyString myString, ref int index)
        {
            MyString temp = new MyString("");

            int index1 = 0;


            if (index + subString.Length > mainString.Length)
            {
                int helper = myString.Length;

                for (int i = index; i < mainString.Length; ++i, ++helper)
                {
                    myString[helper] = mainString[i];
                }

                index = mainString.Length;
            }

            for (int i = index; i < index + subString.Length; ++i, ++index1)
            {
                temp[index1] = mainString[i];
            }

            if (temp == subString)
            {
                index += subString.Length;
                return mainString;
            }
            else
            {
                int helper = myString.Length;

                for (int i = 0; i < subString.Length; ++i, ++helper)
                {
                    myString[helper] = temp[i];
                    index++;
                }

                return myString;
            }
        }

        public static bool operator ==(MyString string1, MyString string2)
        {
            if (string1.Length == string2.Length)
            {
                for (int i = 0; i < string1.Length; ++i)
                {
                    if (string1[i] != string2[i])
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator !=(MyString string1, MyString string2)
        {
            if (string1 == string2)
                return false;
            else
                return true;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach(char value in myString)
            {
                sb.Append(value);
            }

            return sb.ToString();
        }

        public char this[int index]
        {
            get
            {
                if (index >-1 && index < myString.Length)
                    return myString[index];
                else throw new ArgumentOutOfRangeException("Вы вышли за пределы строки");
            }

            set
            {
                if (index > myString.Length || index < 0)
                    throw new IndexOutOfRangeException("Размер строки меньше, чем номер индекса");

                myString[index] = value;
            }
            
        }

        internal int Length { get => myString.Length; }
    }    
}
