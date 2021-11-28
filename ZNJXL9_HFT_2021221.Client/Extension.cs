using System;
using System.Collections.Generic;

namespace ZNJXL9_HFT_2021221.Client
{
    static class Extension
    {
        public static void ToConsole<T>(this IEnumerable<T> input, string str)
        {
            Console.WriteLine("*** BEGIN " + str);
            foreach (T item in input)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("*** END " + str);
            Console.ReadLine();
        }
        
    }
}
