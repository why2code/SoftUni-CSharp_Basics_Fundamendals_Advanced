using System;
using System.Collections.Generic;
using System.Text;

namespace Generics
{
    internal class Tuple<T1, T2>
    {
        public Tuple(T1 type1, T2 type2)
        {
            Type1 = type1;
            Type2 = type2;
        }

        public T1 Type1 { get; }
        public T2 Type2 { get; }

        public override string ToString()
        {
            return $"{Type1} -> {Type2}";
        }
    }
}
