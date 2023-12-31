using System;

namespace HomeTask23_09_2023_Ex1.HomeWork6
{
    public class FirstHomeWork6
    {
        public static void Ex1()
        {
            int n = Convert.ToInt16(Console.ReadLine());
            var arr = new int[n];
            for (var i = 0; i < n; i++)
            {
                Console.WriteLine("Верхняя границы");
                var up = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine("Нижняя граница");
                var down = Convert.ToInt16(Console.ReadLine());
                var random = new Random();
                arr[i] = random.Next(down, up + 1);
            }

            Console.WriteLine("Получившийся массив");
            PrintArr(arr);
        }

        public static void PrintArr(int[] arr)
        {
            for (var i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
        } 
        public static void PrintArr(double[] arr)
        {
            for (var i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
        }

        public static void PrintArrOnlyEvenIndex(double[] arr)
        {
            for (var i = 0; i < arr.Length; i++)
            {
                if ((i + 1) % 2 == 0)
                {
                    Console.Write(arr[i] + " ");
                }
            }
        }
    }
}