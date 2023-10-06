using System;
using System.Collections.Generic;
using HomeTask23_09_2023_Ex1;
using System.Linq;

namespace HomeTask29_09_2023
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            /*
            String s = "55";
            String b = "55";
            LongNumber first = new LongNumber(s);
            LongNumber second = new LongNumber(b);
            //LongNumber summa = second / first;
            //Console.WriteLine(first == second);
            int мояпеременная = -15;
            Problem2.ChangeDigits(ref мояпеременная);
            Console.WriteLine(мояпеременная);
            //Console.WriteLine(-12 % 10);
            */
            //String s = "54354355345345435354";
            //LongNumber test = s.ToLongNumber();
            //Console.WriteLine(test);

            //int result = SummParams.Summ(1, 2, 3, 4, 5, 6);
            //Console.WriteLine(result);

            int first = 15;
            int second = 17;
            MethodToChange.ChangeRef(ref first , ref second);
            Console.WriteLine(first);
            Console.WriteLine(second);
        }

    }
}