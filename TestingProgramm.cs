using System;
using System.Collections.Generic;
using HomeTask23_09_2023_Ex1;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.AccessControl;

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

            //int first = 15;
            //int second = 17;
            //MethodToChange.ChangeRef(ref first , ref second);
            //Console.WriteLine(first);
            //Console.WriteLine(second);

            //Console.WriteLine("Введите номер дня недели");
            //var n = Convert.ToByte(Console.ReadLine());
            //Console.WriteLine((WeekDay) n);

            // пример работы с флаговым enum
            //var n = FlagEnum.Blue | FlagEnum.Green;
            //Console.WriteLine(n);

            //string s = "blue";
            //FlagEnum flagEnum = (FlagEnum) Enum.Parse(typeof(FlagEnum), s , ignoreCase:true);
            //Console.WriteLine(flagEnum);
            //char current = Convert.ToChar(Console.Read());
            //if ((int) current == 13)
            //{
            //    Console.WriteLine("Вы нажали enter");
            //}
            //Console.WriteLine(Math.PI);
            //Decimal test = new Decimal(3.1415926535897932384626433832795028841971693993751058209749445923078164062862089986280348253421170679);
            //Console.WriteLine(test + );
            //CalculationPI.Input();
            //Console.WriteLine(Char.isC);
            char test = 'Z';
            bool flag = ShiftCount.Shift(53, ref test);
            Console.WriteLine(test);
        }
        
        

    }
}