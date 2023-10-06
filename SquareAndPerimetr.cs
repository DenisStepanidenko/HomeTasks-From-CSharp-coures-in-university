using System;

namespace HomeTask23_09_2023_Ex1
{
    public class SquareAndPerimetr
    {
        
        // вычисление периметра
        public static bool Perimetr(Point A, Point B ,  Point C, Point D , out double? result)
        {
            // проверим - существует ли такой четырёхугольник вначале
            bool flag = IsExist(A, B, C, D);
            if (!flag)
            {
                result = null;
                return false;
            }
            // иначе считаем расстояние с помощью векторов
            double sideAB = GetDistance(A, B);
            double sideBC = GetDistance(B, C);
            double sideCD = GetDistance(C, D);
            double sideAD = GetDistance(A, D);
            result =  sideAB + sideBC + sideCD + sideAD;
            return true;
        }

        public static bool Square(Point A, Point B, Point C, Point D, out double? result)
        {
            // проверяем существует ли такой четырёхугольник
            bool flag = IsExist(A, B, C, D);
            if (!flag)
            {
                result = null;
                return false;
            }
            double sideAB = GetDistance(A, B);
            double sideBC = GetDistance(B, C);
            double sideCD = GetDistance(C, D);
            double sideAD = GetDistance(A, D);
            double sideBD = GetDistance(B, D);
            double squareFirst = Heron(sideAB, sideBD, sideAD);
            double squareSecond = Heron(sideBC, sideCD, sideBD);
            result = squareFirst + squareSecond;
            return true;
            // находим площадь через сумму площадей двух треугольников 
            // их площади находим по теореме Герона
        }

        public static double Heron(double a, double b, double c)
        {
            double halfPemiter = (a + b + c) / 2;
            return Math.Sqrt(halfPemiter * (halfPemiter - a) * (halfPemiter - b) * (halfPemiter - c));
        }

        public static double GetDistance(Point x, Point y) // метод для вычисления расстояния между точками
        {
            return Math.Sqrt((x.X - y.X) * (x.X - y.X) + (x.Y - y.Y) * (x.Y - y.Y));
        }

        public static bool IsExist(Point A, Point B, Point C, Point D)
        {
            // найдём диагональ например BD 
            double sideAB = GetDistance(A, B);
            double sideBC = GetDistance(B, C);
            double sideCD = GetDistance(C, D);
            double sideAD = GetDistance(A, D);
            double sideBD = GetDistance(B, D);
            // теперь нужно проверить два неравенства треугольника
            bool flag1 = CheckTriangleRule(sideAB, sideBD, sideAD);
            bool flag2 = CheckTriangleRule(sideBC, sideCD, sideBD);
            return flag1 && flag2;
        }

        public static bool CheckTriangleRule(double a, double b, double c)
        {
            // надо проверить три неравенства
            if (a + b < c)
            {
                return false;
            }

            if (a + c < b)
            {
                return false;
            }

            if (b + c < a)
            {
                return false;
            }

            return true;
        }
    }

   
}