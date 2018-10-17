using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class DynamicArray<T>
    {
        T[] myArr;
        int length;
        int capacity;
        int currentIndex = 0;
 
        public DynamicArray()
        {
            myArr = new T[8];
            capacity = 8;
        }

        public DynamicArray(int capacity)
        {
            if (capacity < 1)
                throw new ArgumentException("Capacity cannot be less than 1");

            myArr = new T[capacity];

            this.capacity = capacity;
        }

        public DynamicArray(T[] array)
        {
            myArr = array;
            capacity = length = array.Length;
        }

        public void Add(T data)
        {
            if (currentIndex <= capacity - 1)
            {
                myArr[currentIndex] = data;
                currentIndex++;
                length++;
            }
            else
            {
                T[] temp = new T[capacity];
                int index = 0;

                foreach(var value in myArr)
                {
                    temp[index] = myArr[index];
                    index++;
                }

                myArr = new T[capacity * 2];
                capacity *= 2;
                currentIndex = 0;
                length = 0;

                foreach(var value in temp)
                {
                    myArr[currentIndex] = temp[currentIndex];
                    currentIndex++;
                    length++;
                }

                myArr[currentIndex] = data;
                currentIndex++;
            }

        }

        public void AddRange(T[] array)
        {
            foreach(var value in array)
            {
                Add(value);
            }
        }

        public bool Remove(T data)
        {
            bool removed = false;
            int index = 0;

            T[] tempArr = new T[length];

            for (int i = 0; i < length; ++i, ++index)
            {
                if (myArr[i].Equals(data))
                {
                    i++;
                    removed = true;
                }

                if (i == length && removed)
                {
                    break;
                }

                tempArr[index] = myArr[i];
            }

            myArr = new T[capacity];
            currentIndex = 0;
            length = 0;

            for (int i = 0; i < index; ++i)
            {
                Add(tempArr[i]);
            }

            return removed;
        }

        public void Insert(T data, int position)
        {
            throw new NotImplementedException();
        }

        public int Length
        {
            set
            {
                length = currentIndex;
            }

            get => length;
        }

        public int Capacity
        {
            set
            {
                int capacity = 0;

                foreach (var data in myArr)
                {
                    capacity++;
                }

                this.capacity = capacity;
            }

            get => capacity;
        }

        public T this[int index]
        {
            set
            {
                myArr[index] = value;
            }
            get
            {
                return myArr[index];
            }
        }
    }
}
