using System;
using System.Collections.Generic;
using System.Text;

namespace Generics
{
    public class Threeuple<T1, T2, T3>
    {
        public Threeuple(T1 firstInput, T2 secondInput, T3 thirdInput)
        {
            FirstInput = firstInput;
            SecondInput = secondInput;
            ThirdInput = thirdInput;
        }

        public T1 FirstInput { get; private set; }
        public T2 SecondInput { get; private set; }
        public T3 ThirdInput { get; private set; }

        public override string ToString()
        {
            return $"{FirstInput} -> {SecondInput} -> {ThirdInput}";
        }
    }
}
