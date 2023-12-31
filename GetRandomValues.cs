using System;

namespace HomeTask23_09_2023_Ex1
{
    public class GetRandomValues
    {
        private static Random random = new Random();
        public static void GetValues()
        {
            Console.WriteLine("Введите количество измерений");
            int n = Convert.ToInt16(Console.ReadLine());
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Введите нижнюю границу");
                int low = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine("Введите верхнюю границу");
                int upper = Convert.ToInt16(Console.ReadLine());
                int value = random.Next(low, upper + 1);
                arr[i] = value;
            }

            for (int i = 0; i < n; i++)
            {
                Console.Write(arr[i] + " ");
            }
        }
    }
}