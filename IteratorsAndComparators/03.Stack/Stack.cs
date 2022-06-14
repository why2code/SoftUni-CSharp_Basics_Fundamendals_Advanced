using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.Stack
{
    public class Stack<T> : IEnumerable<T>
    {
        private List<T> elements;

        public Stack(params T[] data)
        {
            elements = new List<T>(data.ToList());
        }

        public void Push(params T[] data)
        {
            foreach (var item in data)
            {
                elements.Insert(elements.Count, item);
            }
        }

        public T Pop()
        {
            if (elements.Count == 0)
            {
                throw new ArgumentException("No elements");
            }

            T currElement = elements[elements.Count - 1];
            elements.RemoveAt(elements.Count - 1);
            return currElement;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = elements.Count - 1; i >= 0; i--)
            {
                yield return elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
