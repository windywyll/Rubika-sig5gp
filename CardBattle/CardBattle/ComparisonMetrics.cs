using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardBattle
{
    public class ComparisonMetrics
    {
        private ComparisonMetrics()
        {
        }

        private static readonly ComparisonMetrics _instance = new ComparisonMetrics();

        public static ComparisonMetrics Instance
        {
            get
            {
                return _instance;
            }
        }

        public void Signal()
        {
            ComparisonCount++;
        }

        public int ComparisonCount { get; private set; }

        public void Reset()
        {
            ComparisonCount = 0;
        }
    }
}
