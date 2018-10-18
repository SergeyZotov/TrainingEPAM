using System;

namespace Task1
{
    class DynamicArray<T> where T : new()
    { 
        T[] myArr;
        int capacity;

        public int Length
        {
            private set;
            get;

 
        }

        public int Capacity
        {
            get => myArr.Length;
        }

        public DynamicArray()
        {
            myArr = new T[8];
            capacity = 8;
        }

        public DynamicArray(int newCapacity)
        {
            if (newCapacity < 0)
                throw new ArgumentException("Capacity cannot be less than 0");

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

        public void AddRange(T[] newArray)
        {
            int totalLength = Length + newArray.Length;

            if (totalLength == capacity)
            {
                capacity *= 2;
            }
            else  if (totalLength > capacity)
            { 
                T[] tempArray = myArr;
                int tempLength = Length ;
                capacity *= (newArray.Length / capacity) * 2;
                myArr = new T[capacity];

                Length = 0;

                for (int i = 0; i < tempLength; ++i)
                {
                    Add(tempArray[i]);
                }
            }

            foreach(var value in newArray)
            {
                Add(value);
            }
        }

        public bool Remove(T data)
        {
            int foundElementIndex = 0;
            int tempLength = Length;

            foundElementIndex = IndexOf(data, foundElementIndex);
            if (foundElementIndex != -1)
            {
                
                T[] tempArray = myArr;
                myArr = new T[capacity];

                Length = 0;

                RemoveAt(tempLength, foundElementIndex, tempArray);

                return true;
            }
            else
            {
                return false;
            }
        }

        private int IndexOf(T data, int foundElementIndex)
        {
            for (int i = 0; i < Length; ++i, ++foundElementIndex)
            {
                if (myArr[i].Equals(data))
                {
                    return foundElementIndex;
                }                
            }

            return -1;
        }

        private void RemoveAt(int tempLength, int foundElementIndex, T[] tempArray)
        {
            for (int i = 0; i < tempLength; ++i)
            {
                if (i == foundElementIndex)
                    continue;

                Add(tempArray[i]);
            }
        }

        public void Insert(T data, int position)
        {
            if (!IsCorrectPosition(position))
                throw new ArgumentOutOfRangeException($"Невозможно добавить элемент");
            
            if (position == Length + 1)
            {
                Add(data);
                return;
            }

            T[] tempArray;

            int firstLength = Length;

            if (Length < capacity)
            {
                tempArray = new T[capacity];

                int index = 0;

                for (int i = 0; i < Length; ++i, ++index)
                {
                    tempArray[index] = myArr[i];
                }

                FillMyArray(data, firstLength, position, tempArray);
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

                FillMyArray(data, firstLength, position, tempArray);

            }
        }

        private void FillMyArray(T data, int firstLength, int position, T[] tempArray)
        {
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

        private bool IsCorrectPosition(int position) => (position < 0 || position > Length + 1) == true ? false : true;

        public T this[int index]
        {
            set
            {
                if (!IsCorrectIndex(index))
                    throw new ArgumentOutOfRangeException("Calling unexisting object");

                myArr[index] = value;
            }

            get
            {
                if(!IsCorrectIndex(index))
                    throw new ArgumentOutOfRangeException("Calling unexisting object");

                return myArr[index];
            }
        }

        private bool IsCorrectIndex(int index) => (index > capacity || index < 0) == true ? false : true;
    }
}
