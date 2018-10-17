using System;

namespace Task1
{
    class DynamicArray<T>
    {
        T[] myArr;
        int length;
        int capacity;
 
        public DynamicArray()
        {
            myArr = new T[8];
            capacity = 8;
        }

        public DynamicArray(int newCapacity)
        {
            if (newCapacity < 1)
                throw new ArgumentException("Capacity cannot be less than 1");

            myArr = new T[newCapacity];

            capacity = newCapacity;
        }

        public DynamicArray(T[] array)
        {
            myArr = array;
            capacity = length = array.Length;
        }

        public void Add(T data)
        {
            if (length < capacity)
            {
                myArr[length] = data;
                length++;
            }
            else
            {
                T[] tempArr = myArr;
                capacity *= 2;

                myArr = new T[capacity];

                for (int i = 0; i < length; ++i)
                {
                    myArr[i] = tempArr[i];
                }

                myArr[length] = data;
                length++;
            }
        }

        // Доработать увеличение capacity единожды, а не при входе в Add(value)
        public void AddRange(T[] array)
        {
            foreach(var value in array)
            {
                Add(value);
            }
        }

        public bool Remove(T data)
        {
            throw new NotImplementedException();
        }

        public void Insert(T data, int position)
        {
            throw new NotImplementedException();
        }

        public int Length
        {
            get => length;
        }

        public int Capacity
        {
            set
            {
                foreach (var data in myArr)
                {
                    capacity++;
                }
            }

            get => capacity;
        }

        public T this[int index]
        {
            set
            {
                if (index > capacity)
                    throw new ArgumentOutOfRangeException("Calling unexisting object");

                myArr[index] = value;
            }
            get
            {
                /*if (index > capacity)
                    throw new ArgumentOutOfRangeException("Calling unexisting object");*/

                return myArr[index];
            }
        }
    }
}
