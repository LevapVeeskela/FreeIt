using System;
using System.Collections.Generic;

namespace FreeIt.Domain.Common.Extensions
{
    public static class ListExtenstion
    {
        public static List<T> Mixing<T>(this List<T> source)
        {
            var random = new Random();
            var data = new List<T>();
            foreach (var s in source)
            {
                int j = random.Next(data.Count + 1);
                if (j == data.Count)
                {
                    data.Add(s);
                }
                else
                {
                    data.Add(data[j]);
                    data[j] = s;
                }
            }

            return data;
        }
    }
}