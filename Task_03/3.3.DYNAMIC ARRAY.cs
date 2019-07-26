//Реализовал некоторые методы из 3.4.
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace _3._3.DYNAMIC_ARRAY
{
    class DinamicArray<T>
    {
        private T[] myArray;
        private int length, capacity;
        public int Length
        {
            get => length;
        }
        public int Capacity
        {
            get => capacity;
            set
            {
                if(value > 0)//Возможность ручного изменения значения Capacity
                {
                    T[] myArrayHelp = myArray;
                    myArray = new T[value];
                    for(int i = 0; i < value; i++)
                    {
                        myArray[i] = myArrayHelp[i];
                    }
                }
                capacity = value;
                if (value < length) length = value;
            }
        }
        public DinamicArray()//Конструктор без параметров 
        {
            length = 0;
            capacity = 8;
            T[] myArray = new T[8];
        }
        public DinamicArray(int sizeArray)//Конструктор с одним целочисленным параметром
        {
            length = 0;
            capacity = sizeArray;
            T[] myArray = new T[sizeArray];
        }
        
        public DinamicArray(IEnumerable<T> myCollection)//Конструктор, который в качестве параметра принимает коллекцию
        {
            for(int i = 2;; i *= 2)
            {
                if(i >= myCollection.Count())
                {
                    capacity = i;
                    break;
                }
            }
            myArray = new T[capacity];
            foreach(T item in myCollection)
            {
                myArray[length++] = item;
            }
        }
        public T this[int id]//Индексатор, позволяющий работать с элементом с указанным номером
        {
            get
            {
                if (id >= 0)
                {
                    try
                    {
                        return myArray[id];
                    }
                    catch (IndexOutOfRangeException ex)
                    {
                        Console.WriteLine(ex);
                        return myArray[0];
                    }
                }
                else//Доступ к элементам с конца при использовании отрицательного индекса
                {
                    try
                    {
                        return myArray[length + id];
                    }
                    catch (IndexOutOfRangeException ex)
                    {
                        Console.WriteLine(ex);
                        return myArray[0];
                    }
                }
            }
            set
            {
                if (id >= 0)
                {
                    try
                    {
                        if (id < length) myArray[id] = value;
                    }
                    catch (IndexOutOfRangeException ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
                else//Доступ к элементам с конца при использовании отрицательного индекса
                {
                    try
                    {
                        if (-id < length) myArray[length + id] = value;
                    }
                    catch (IndexOutOfRangeException ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
            }
        }

        public void Add(T element)//Метод Add, добавляющий в конец массива один элемент
        {
            if(length >= capacity)
            {
                capacity *= 2;
                T[] myArrayHelp = myArray;
                myArray = new T[capacity];
                for(int i = 0; i < myArrayHelp.Length; i++)
                {
                    myArray[i] = myArrayHelp[i];
                }
            }
            myArray[length] = element;
            length ++;
        }
        public void AddRange(IEnumerable<T> myCollection)//Метод AddRange, добавляющий в конец массива содержимое коллекции
        {
            while((length + myCollection.Count()) > capacity)
            {
                capacity *= 2;
            }
            T[] myArrayHelp = myArray;
            myArray = new T[capacity];
            for (int i = 0; i < myArrayHelp.Length; i++)
            {
                myArray[i] = myArrayHelp[i];
            }
            foreach (T item in myCollection)
            {
                myArray[length++] = item;
            }
        }
        public bool Remove(int elementNumber)//Метод Remove, удаляющий из коллекции указанный элемент
        {
            if (elementNumber >= length) return false;
            T[] myArrayHelp = myArray;
            myArray = new T[capacity];
            int count = 0;
            for (int i = 0; i  < capacity; i++)
            {
                if (i == elementNumber) continue;
                myArray[count++] = myArrayHelp[i];
            }
            length--;
            return true;
        }
        public bool Insert(int elementNumber, T element)//Метод Insert, позволяющий добавить элемент в произвольную позицию массива
        {
            if (length == capacity) capacity *= 2;
            if (elementNumber > length) return false;
            T[] myArrayHelp = myArray;
            myArray = new T[capacity];
            int count = 0;
            for (int i = 0; i < length; i++)
            {
                if (i == elementNumber)
                {
                    myArray[count++] = element;
                }
                myArray[count++] = myArrayHelp[i];
            }
            length++;
            return true;
        }
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < length; i++)
                yield return myArray[i];
        }

        public T[] ToArray()//метод ToArray, возвращающий новый массив (обычный)
        {
            T[] returnArray = new T[length];
            for(int i = 0; i < length; i++)
            {
                returnArray[i] = myArray[i];
            }
            return returnArray;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] Arr = new string[9] { "Index_0", "Index_1", "Index_2", "Index_3", "Index_4", "Index_5", "Index_6", "Index_7", "Index_8" };
            DinamicArray<string> myArray = new DinamicArray<string>(Arr);
            myArray.Add("dqwad");
            myArray.AddRange(Arr);
            myArray.Remove(2);
            myArray.Insert(3, "faf");
            foreach(var item in myArray) Console.WriteLine(item);
            Console.WriteLine(myArray.Length);
            Console.WriteLine(myArray.Capacity);
            Console.WriteLine(myArray[-10]);
            myArray.Capacity = 30;
            foreach (var item in myArray) Console.WriteLine(item);
            Console.WriteLine(myArray.Length);
            Console.WriteLine(myArray.Capacity);
            Console.ReadLine();
        }
    }
}
