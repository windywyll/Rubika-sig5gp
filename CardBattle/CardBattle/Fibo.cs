using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardBattle
{
    public static class Fibo
    {
        public static IEnumerable<ulong> Fibonacci()
        {
            ulong current = 1;
            ulong previous = 1;

            yield return previous;
            while (true)
            {
                yield return current;

                checked
                {
                    var next = current + previous;

                    previous = current;
                    current = next;
                }
            }
        }

        public static IEnumerable<ulong> FirstFibos(int count)
        {
            return Fibonacci().Take(count);
        }

        public static ulong NthMultipleFibo(int n, ulong multiple)
        {
            return Fibonacci().Where(f => f % multiple == 0).ElementAt(n);
        }

        public static IEnumerable<ulong> Divisors(ulong n)
        {
            for (ulong i = 2; i * i <= n; i++)
            {
                if (n % i == 0)
                {
                    yield return i;
                   
                    do
                    {
                        n = n / i;
                    }
                    while (n % i == 0);
                }
            }

            if(n != 1)
            {
                yield return n;
            }
        }

        public static IEnumerable<ulong> DivisorsFromFibo(int n, ulong multiple)
        {
            return Fibonacci().Where(f => f % multiple == 0).Take(n).SelectMany(Divisors).Distinct().OrderBy(d => d);
        }
    }
}
