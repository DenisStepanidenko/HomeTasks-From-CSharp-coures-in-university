using System;

namespace HomeTask23_09_2023_Ex1.HomeWork6
{
    public class FourthHomeWork6
    {
        public static void SumMainDiagonal(int[,] arr)
        {
            var m = arr.GetLength(0); // количество строк
            var n = arr.GetLength(1); // количество столбцов
            var sum = 0;
            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    if (i == j)
                    {
                        sum += arr[i, j];
                    }
                }
            }

            Console.WriteLine("Сумма элементов главной матрицы");
            Console.WriteLine(sum);
        }

        public static void AverageOfElement(int[,] arr)
        {
            var m = arr.GetLength(0); // количество строк
            var n = arr.GetLength(1); // количество столбцов
            var count = arr.Length; // количество всех элементов
            var sum = 0;
            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    sum += arr[i, j];
                }
            }

            Console.WriteLine(sum / (double) count);
        }

        public static void AverageOfColumn(int[,] arr)
        {
            var m = arr.GetLength(0); // количество строк
            var n = arr.GetLength(1); // количество столбцов
            var arrAverage = new double[n];
            for (var j = 0; j < n; j++)
            {
                var sum = 0;
                for (var i = 0; i < m; i++)
                {
                    sum += arr[i, j];
                }

                arrAverage[j] = (sum / (double) m);
            }

            FirstHomeWork6.PrintArr(arrAverage);
        }


        public static void AverageOfColumnEven(int[,] arr)
        {
            var m = arr.GetLength(0); // количество строк
            var n = arr.GetLength(1); // количество столбцов
            var arrAverage = new double[n];
            for (var j = 0; j < n; j++)
            {
                if ((j + 1) % 2 == 0)
                {
                    var sum = 0;

                    for (var i = 0; i < m; i++)
                    {
                        sum += arr[i, j];
                    }

                    arrAverage[j] = (sum / (double) m);
                }
            }

            FirstHomeWork6.PrintArrOnlyEvenIndex(arrAverage);
        }

        public static void FindMaxElement(int[,] arr)
        {
            var m = arr.GetLength(0); // количество строк
            var n = arr.GetLength(1); // количество столбцов
            var maxElement = Int32.MinValue;
            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    if (arr[i, j] > maxElement)
                    {
                        maxElement = arr[i, j];
                    }
                }
            }

            Console.WriteLine(maxElement);
        }

        public static void FindMinElement(int[,] arr)
        {
            var m = arr.GetLength(0); // количество строк
            var n = arr.GetLength(1); // количество столбцов
            var minElement = Int32.MaxValue;
            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    if (arr[i, j] < minElement)
                    {
                        minElement = arr[i, j];
                    }
                }
            }

            Console.WriteLine(minElement);
        }

        public static void SumElementOfFirstColumn(int[,] arr)
        {
            var m = arr.GetLength(0); // количество строк
            var n = arr.GetLength(1); // количество столбцов
            var sum = 0;
            for (var i = 0; i < m; i++)
            {
                sum += arr[i, 0];
            }

            Console.WriteLine("Сумма элементов первого столбца равна " + sum);
        }

        public static void FindSumOfRowWhereMinElementExist(int[,] arr)
        {
            var m = arr.GetLength(0); // количество строк
            var n = arr.GetLength(1); // количество столбцов

            var indexMin = 0;
            var minElem = Int32.MaxValue;

            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    if (arr[i, j] < minElem)
                    {
                        minElem = arr[i, j];
                        indexMin = i;
                    }
                }
            }

            var sum = 0;
            for (var i = 0; i < n; i++)
            {
                sum += arr[indexMin, i];
            }

            Console.WriteLine("Сумма элементов, где хранится минимальный элемент равен : " + sum);
        }

        public static void FindMaxAbsoluteElem(int[,] arr)
        {
            var n = arr.GetLength(0);
            var m = arr.GetLength(1);

            var maxELem = Int32.MinValue;

            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    if (Math.Abs(arr[i, j]) > maxELem)
                    {
                        maxELem = Math.Abs(arr[i, j]);
                    }
                }
            }

            Console.WriteLine("Максимальный элемент по модулю : " + maxELem);
        }

        public static void FindMaxElemFromKRow(int[,] arr, int k)
        {
            var m = arr.GetLength(0);
            var n = arr.GetLength(1);
            var maxElem = Int32.MinValue;


            for (var j = 0; j < n; j++)
            {
                if (arr[k, j] > maxElem)
                {
                    maxElem = arr[k, j];
                }
            }

            Console.WriteLine("Максимальное значение строки :" + k + " равняется " + maxElem);
        }


        public static void CountNegativeElementFromKRow(int[,] arr, int k)
        {
            var m = arr.GetLength(0);
            var n = arr.GetLength(1);
            var count = 0;


            for (var j = 0; j < n; j++)
            {
                if (arr[k, j] < 0)
                {
                    count++;
                }
            }


            Console.WriteLine("Количество отрицательный элементов строки " + k + " равняется " + count);
        }


        public static void CountComposition(int[,] arr)
        {
            var m = arr.GetLength(0);
            var n = arr.GetLength(1);
            var count = 1;


            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    count *= arr[i, j];
                }
            }

            Console.WriteLine("Произведение всех элементов матрицы " + count);
        }

        public static void CountCompositionFromKRowWhereElemQuels2(int[,] arr, int k)
        {
            var n = arr.GetLength(1);
            var count = 1;


            for (var j = 0; j < n; j++)
            {
                if (arr[k, j] == 2)
                {
                    count *= (int) Math.Pow(arr[k, j], 2);
                }
            }


            Console.WriteLine("Произведение элементов k строки  " + count);
        }

        public static void CountAbsoluteCompositionFromKRow(int[,] arr, int k)
        {
            var m = arr.GetLength(0);
            var n = arr.GetLength(1);
            var count = 1;


            for (var j = 0; j < n; j++)
            {
                count *= Math.Abs(arr[k, j]);
            }

            Console.WriteLine("Произведение  элементов строки " + k + " матрицы равняется " + count);
        }
    }
}