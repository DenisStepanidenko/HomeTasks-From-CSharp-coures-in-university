using System;

namespace HomeTask23_09_2023_Ex1
{
    public class CalculationPI
    {
        public static void Input()
        {
            var current = ' ';
            // код символа enter - 13
            while ((int) current != 13)
            {
                Console.WriteLine("На выбор два метода ");
                Console.WriteLine("1 - Вычисление c помощью кратного ряда");
                Console.WriteLine("2 - Вычисление с помощью формулы Бэйли-Боруэйна-Плаффа");
                byte choice = Convert.ToByte(Console.ReadLine());
                Console.WriteLine("Введите заданную точностью( количество знаков после запятой )");
                int y = Convert.ToInt16(Console.ReadLine());
                int count;
                double pi = MultilpleSerius(y, out count);
                Console.WriteLine("Вычисленое значение числа pi - " + pi);
                Console.WriteLine("Количетсво итераций - " + count);
                
            }
        }

        public static double MultilpleSerius(int accuracy, out int count)
        {
            // accuracy ( 0.01 , 0.001 , 0.0001)
            long start = 1;
            long finish = 300;
            double pi = 0;
            count = 0;
            while (true)
            {
                bool flag = FunctionMultiple(accuracy, start, finish, ref pi, ref count);
                if (flag)
                {
                    break;
                }
                Console.WriteLine("Начинается новая эпоха");
                Console.WriteLine("---------");
                start = finish + 1;
                finish = finish + 50;


            }
            return pi;
        }

        public static bool FunctionMultiple(int accuracy , long start, long finish, ref double pi , ref int count)
        {
            for (long i = start; i <= finish; i++)
            {
                for (long j = start; j <= finish; j++)
                {
                    pi += 8.0 * ( 1 /  Math.Pow(4 * j - 2, 2 * i));
                    Console.WriteLine(pi + ", " + i + ", " + j);
                    count++;
                    // теперь нужно проверить количество знаков после запятой
                    bool flag = Check(accuracy, pi);
                    if (flag)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool Check(int accuracy, double pi)
        {
            Decimal test = new Decimal(3.1415926535897932384626433832795028841971693993751058209749445923078164062862089986280348253421170679);
            string realPI = test.ToString();
            int currentAccuracy = 0;
            // проверяем какая точность у вычисленного числа PI
            string s = pi.ToString();
            Console.WriteLine("Сравнение");
            Console.WriteLine("---");
            Console.WriteLine(s);
            Console.WriteLine(realPI);
            Console.WriteLine("---");
            for (int i = 0; i < s.Length; i++)
            {
                if (realPI[i] == s[i] && !s[i].Equals(','))
                {
                    currentAccuracy++;
                }
                else
                {
                    break;
                }
            }

            if ( (currentAccuracy - 2) >= accuracy)
            {
                return true;
            }
            return false;

        }
        
    }
}