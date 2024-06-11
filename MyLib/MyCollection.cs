using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    public class MyCollection<T> : ICollection<T>
    {
        private T[] items = new T[0];

        public int Count => items.Length;
        public bool IsReadOnly => false;

        public void Add(T item)
        {
            Array.Resize(ref items, items.Length + 1);
            items[items.Length - 1] = item;
        }

        public void Clear()
        {
            items = new T[0];
        }

        public bool Contains(T item)
        {
            return items.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            Array.Copy(items, 0, array, arrayIndex, items.Length);
        }

        public bool Remove(T item)
        {
            int index = Array.IndexOf(items, item);
            if (index >= 0)
            {
                RemoveAt(index);
                return true;
            }
            return false;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= items.Length)
                throw new IndexOutOfRangeException();

            T[] newArray = new T[items.Length - 1];
            Array.Copy(items, 0, newArray, 0, index);
            Array.Copy(items, index + 1, newArray, index, items.Length - index - 1);
            items = newArray;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)items).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public void MergeSort()
        {
            if (items.Length <= 1)
                return;

            T[] left = new T[items.Length / 2];
            T[] right = new T[items.Length - items.Length / 2];

            Array.Copy(items, 0, left, 0, left.Length);
            Array.Copy(items, left.Length, right, 0, right.Length);

            MyCollection<T> leftCollection = new MyCollection<T>();
            leftCollection.items = left;
            leftCollection.MergeSort();

            MyCollection<T> rightCollection = new MyCollection<T>();
            rightCollection.items = right;
            rightCollection.MergeSort();

            Merge(leftCollection, rightCollection);
        }

        private void Merge(MyCollection<T> leftCollection, MyCollection<T> rightCollection)
        {
            T[] left = leftCollection.items;
            T[] right = rightCollection.items;
            int leftIndex = 0;
            int rightIndex = 0;
            int mergedIndex = 0;

            while (leftIndex < left.Length && rightIndex < right.Length)
            {
                if (Comparer<T>.Default.Compare(left[leftIndex], right[rightIndex]) <= 0)
                {
                    items[mergedIndex] = left[leftIndex];
                    leftIndex++;
                }
                else
                {
                    items[mergedIndex] = right[rightIndex];
                    rightIndex++;
                }
                mergedIndex++;
            }

            while (leftIndex < left.Length)
            {
                items[mergedIndex] = left[leftIndex];
                leftIndex++;
                mergedIndex++;
            }

            while (rightIndex < right.Length)
            {
                items[mergedIndex] = right[rightIndex];
                rightIndex++;
                mergedIndex++;
            }
        }
    }
}