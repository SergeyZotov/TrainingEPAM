using System;

namespace Task1
{
    class DynamicArray<T>
    {
        T[] myArr;
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
            capacity = Length = array.Length;
        }

        public void Add(T data)
        {
            if (Length < capacity)
            {
                myArr[Length] = data;
                Length++;
            }
            else
            {
                T[] tempArray = myArr;
                capacity *= 2;

                myArr = new T[capacity];

                for (int i = 0; i < Length; ++i)
                {
                    myArr[i] = tempArray[i];
                }

                myArr[Length] = data;
                Length++;
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
            if (position < 0 || position > Length + 1)
                throw new ArgumentOutOfRangeException($"Невозможно добавить элемент");
            
            if (position == Length + 1)
            {
                Add(data);
                return;
            }

            T[] tempArray;

            int firstLength = Length;

            if (Length != capacity)
            {
                tempArray = new T[capacity];

                int index = 0;

                for (int i = 0; i < Length; ++i, ++index)
                {
                    tempArray[index] = myArr[i];

                }

                myArr = new T[capacity];

                Length = 0;

                for (int i = 0, j = 0; i < firstLength + 1; ++i)
                {
                    if (i == position)
                    {
                        Add(data);
                        continue;
                    }

                    Add(tempArray[j]);
                    j++;
                }
            }
            else
            {
                capacity *= 2;
                tempArray = new T[capacity];

                int index = 0;

                for (int i = 0; i < Length; ++i, ++index)
                {
                    tempArray[index] = myArr[i];

                }

                myArr = new T[capacity];

                Length = 0;

                for (int i = 0, j = 0; i < firstLength + 1; ++i)
                {
                    if (i == position)
                    {
                        Add(data);
                        continue;
                    }

                    Add(tempArray[j]);
                    j++;
                }
            }
        }

        public int Length { get; private set; }

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
                if (index > capacity && index < 0)
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
