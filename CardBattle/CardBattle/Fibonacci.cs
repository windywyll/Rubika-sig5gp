using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardBattle
{
    class FibonacciFuncs
    {
        public static IEnumerable<ulong> Fibonacci()
        {
            yield return 1;

            ulong previous = 0;
            ulong current = 1;

            while (true)
            {
                ulong next = previous + current;
                previous = current;
                current = next;
                yield return next;
            }
        }

        public static IEnumerable<ulong> FirstNFibo(int count)
        {
            return Fibonacci().Take(count);
        }

        public static ulong NthMultipleFibo(int n, int multiple)
        {
            return Fibonacci().Where( x => x%(ulong)multiple == 0).ElementAt(n);
        }

        public static IEnumerable<ulong> Divisors(ulong n)
        {
            for(ulong i = 2; i*i <= n ; i++)
            {
                if(n%i==0)
                {
                    yield return i;

                    do
                    {
                        n = n / i;
                    } while (n % i == 0);
                }
            }

            if (n != 1)
            {
                yield return n;
            }
        }

        public static IEnumerable<ulong> DivisorsFromFibo(int n, ulong multiple)
        {
            return Fibonacci().Where(f => f%multiple == 0).Take(n).SelectMany(Divisors).Distinct().OrderBy(d => d);
        }
    }
}
