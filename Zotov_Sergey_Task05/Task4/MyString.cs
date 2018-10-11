﻿using System;
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
            StringBuilder sb = new StringBuilder(string1.ToString());

            for (int i = 0; i < string2.Length; ++i)
            {
                sb.Append(string2[i]);
            }

            return new MyString(sb.ToString());
        }

        public static MyString operator -(MyString mainString, MyString subString)
        {
            string mainStr;

            if (mainString.Length < subString.Length || subString == null)
                return mainString;


            return new MyString(mainString.ToString());
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
                else throw new ArgumentOutOfRangeException("Вы вышли за пределы строки");
            }

            set
            {
                if (index > newCharArr.Length)
                    throw new ArgumentOutOfRangeException("Размер строки меньше, чем номер индекса");

                newCharArr[index] = value;
            }
            
        }

        internal int Length { get => newCharArr.Length; }
    }    
}