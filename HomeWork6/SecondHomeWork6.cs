using System;

namespace HomeTask23_09_2023_Ex1.HomeWork6
{
    public class SecondHomeWork6
    {
        public static void ReverseArr(int[] arr)
        {
            for (var i = arr.Length - 1; i >= 0; i--)
            {
                Console.Write(arr[i] + " ");
            }
        }

        public static void Even(int[] arr)
        {
            for (var i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == 0)
                {
                    Console.Write(arr[i] + " ");
                }
            }
        }

        public static void AfterOne(int[] arr)
        {
            for (var i = 0; i < arr.Length; i += 2)
            {
                Console.Write(arr[i] + " ");
            }
        }

        public static void WhileMinusOne(int[] arr)
        {
            var i = 0;
            while (i < arr.Length)
            {
                if (arr[i] == -1)
                {
                    break;
                }
                Console.Write(arr[i] + " ");
                i++;
            }
        }
    }
}