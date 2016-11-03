using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardBattle
{
    public static class Sort
    {
        public static void Insertion<T>(List<T> list) where T:IComparable<T>
        {
            for(var i = 0; i<list.Count; i++)
            {
                for(var j = i+1; j<list.Count; j++)
                {
                    if(list[i].CompareTo(list[j]) > 0)
                    {
                        var temp = list[i];
                        list[i] = list[j];
                        list[j] = temp;
                    }
                }
            }
        }
    }
}
