using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardBattle
{
    public static class Sort
    {
        public static void Insertion<T>(List<T> list) where T : IComparable<T>
        {
            for (var i = 0; i < list.Count; i++)
            {
                for (var j = i + 1; j < list.Count; j++)
                {

                    SwapIfNeeded(list, i, j);
                }
            }
        }

        public static void Bubble<T>(List<T> list) where T : IComparable<T>
        {
            for (var i = list.Count - 1; i > 2; i--)
            {
                var sorted = true;
                for (var j = 0; j < i; j++)
                {
                    sorted &= !SwapIfNeeded(list, j, j + 1);
                }
                if (sorted)
                {
                    break;
                }
            }
        }

        public static void Shake<T>(List<T> list) where T : IComparable<T>
        {
            for (var i = 0; i < list.Count / 2; i++)
            {
                var sorted = true;

                for (var j = i; j < list.Count - i - 1; j++)
                {
                    sorted &= SwapIfNeeded(list, j, j + 1);
                }
                if (sorted)
                {
                    break;
                }
                sorted = true;
                for (var j = list.Count - i - 3; j >= i; j--)
                {
                    sorted &= SwapIfNeeded(list, j, j + 1);
                }
                if (sorted)
                {
                    break;
                }
            }
        }

        private static bool SwapIfNeeded<T>(List<T> list, int i, int j) where T : IComparable<T>
        {
            if (list[i].CompareTo(list[j]) > 0)
            {
                var temp = list[i];
                list[i] = list[j];
                list[j] = temp;
                return true;
            }
            return false;
        }


        public static List<T> MergeSort<T>(List<T> list) where T : IComparable<T>
        {
            if (list.Count < 2)
            {
                return list;
            }
            else
            {
                var halfLists = Cut(list);
                return Merge(MergeSort(halfLists.List1), MergeSort(halfLists.List2));
            }
        }

        private static List<T> Merge<T>(List<T> list1, List<T> list2) where T : IComparable<T>
        {
            var result = new List<T>();

            while (list1.Count > 0 && list2.Count > 0)
            {
                if (list1[0].CompareTo(list2[0]) < 0)
                {
                    result.Add(list1[0]);
                    list1.RemoveAt(0);
                }
                else
                {
                    result.Add(list2[0]);
                    list2.RemoveAt(0);
                }
            }

            result.AddRange(list1);
            result.AddRange(list2);

            return result;
        }

        private class ListPair<T>
        {
            public List<T> List1 { get; set; }
            public List<T> List2 { get; set; }
        }

        private static ListPair<T> Cut<T>(List<T> list) where T : IComparable<T>
        {
            var half = list.Count / 2;
            var l1 = list.GetRange(0, half);
            var l2 = list.GetRange(half, list.Count - half);

            return new ListPair<T> { List1 = l1, List2 = l2 };
        }
    }
}
