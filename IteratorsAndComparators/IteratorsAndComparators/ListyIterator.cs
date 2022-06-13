using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IteratorsAndComparators
{
    public class ListyIterator :IEnumerable<string>
    {
        private List<string> elements;
        private static int internalIndex = 0;
        public List<string> Elements
        {
            get { return elements; }
            private set { elements = value; }
        }

        public ListyIterator(params string[] elements)
        {
            this.Elements = elements.ToList();
        }

        public bool Move()
        {
            if (HasNext())
            {
                internalIndex++;
                return true;
            }
            return false;
        }

        public void Print()
        {
            if (this.Elements.Count == 0)
            {
                Console.WriteLine("Invalid Operation!");
            }
            else
            {
                Console.WriteLine(this.Elements[internalIndex]);
            }
        }

        public bool HasNext()
        {
            if (internalIndex + 1 < this.elements.Count)
                return true;

            return false;
        }

        bool MoveNext()
        {
            return Move();
        }

        void Reset()
        {
            internalIndex = 0;
        }

        object? Current { get
            {
                return this.Elements[internalIndex];
            } }

        public void PrintAll()
        {
            foreach (var item in this.Elements)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }
        public IEnumerator<string> GetEnumerator()
        {
            for (int i = 0; i < this.Elements.Count; i++)
            {
                yield return this.Elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
