using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;

namespace HomeTask29_09_2023
{

    public enum Sign // определяет знак числа
    {
        Minus = -1,
        Plus = 1
    }

    public class LongNumber
    {
        private Sign signNumber;

        // будем разбивать длинное число на отдельные цифры,
        // которые будут хранится в списке:
        private List<byte> digits = new List<byte>();
        // Создадим набор конструкторов для инициализации больших чисел:

        //**** конструкторы
        public LongNumber(List<byte> bytes) // конструктор: лист цифр
        {
            digits = bytes.ToList(); // сделано для того, чтобы не менять входные параметры
            RemoveNulls();
        }

        public LongNumber(Sign sign, List<byte> bytes) // конструктор: знак и лист цифр
        {
            signNumber = sign;
            digits = bytes.ToList();
            RemoveNulls();
        }

        public LongNumber(int x)
        {
            if (x < 0)
            {
                signNumber = Sign.Minus;
            }
            else
            {
                signNumber = Sign.Plus;
            }

            digits.AddRange(GetBytes(Math.Abs(x)));
        }

        public LongNumber(string s) // преобразования из строки
        {
            try
            {
                if (s.StartsWith("-"))
                {
                    signNumber = Sign.Minus;
                    s = s.Substring(1);
                }
                else
                {
                    signNumber = Sign.Plus;
                }

                foreach (var c in s.Reverse())
                {
                    digits.Add(Convert.ToByte(c.ToString()));
                }

                RemoveNulls();
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }
        //****


        //**** вспомогательные методы
        private List<byte> GetBytes(int x) // получение списка цифр из целого беззнакового числа
        {
            var bytes = new List<byte>();
            while (x > 0)
            {
                bytes.Add((byte) (x % 10));
                x /= 10;
            }

            return bytes;
        }

        public static LongNumber Zero => new LongNumber(0);

        public int getSize() // возвращает длину числа, то есть количество цифр в LongNumber
        {
            return digits.Count;
        }

        public byte GetByte(int i) // получение цифры по индексу
        {
            return i < this.getSize() ? digits[i] : (byte) 0;
        }

        public override string ToString() // нормальный вывод в строку
        {
            var number = new StringBuilder(signNumber == Sign.Plus ? "" : "-");
            for (int i = digits.Count - 1; i >= 0; i--)
            {
                number.Append(digits[i]);
            }

            return number.ToString();
        }

        Boolean TryParse(string s, out LongNumber number) // метод преобразования из строки
        {
            try
            {
                number = new LongNumber(s);
            }
            catch (Exception e)
            {
                number = null;
                return false;
            }

            return true;
        }

        private void RemoveNulls() // метод для удаление лидирующих нулей длинного числа
        {
            for (var i = digits.Count - 1; i > 0; i--)
            {
                if (digits[i] == 0)
                {
                    digits.RemoveAt(i);
                }
                else
                {
                    break;
                }
            }
        }

        public static LongNumber
            Exp(byte val, int exp) // получение больших чисел формата val_0000( нулей ровно exp раз)
        {
            LongNumber result = Zero;
            result.setByte(exp, val); // будут получаться числа вида 0000_val
            result.RemoveNulls();
            return result;
        }

        public void setByte(int i, byte b) // установка цифры по индексу
        {
            while (digits.Count <= i)
            {
                digits.Add(0);
            }

            digits[i] = b;
        }

        // ****

        /*
        здесь будут реализованы методы для сравнения длинных чисел
        ***********
        */
        private static int Comparison(LongNumber first, LongNumber second, bool ignoreSign = false)
        {
            // по умолчанию сравниваем со знаком
            return CompareSign(first, second, ignoreSign);
        }

        private static int CompareSign(LongNumber first, LongNumber second, bool ignoreSign = false)
        {
            if (!ignoreSign)
            {
                // здесь мы сравниваем числа с учётом знака
                if (first.signNumber < second.signNumber)
                {
                    // число first меньше чем число second
                    return -1;
                }
                else if (first.signNumber > second.signNumber)
                {
                    // число first больше чем число second
                    return 1;
                }
            }

            // если знаки равны, или нам не интересен знак, то вызываем следующий метод
            return CompareSize(first, second);
        }

        private static int CompareSize(LongNumber first, LongNumber second)
        {
            if (first.getSize() < second.getSize())
            {
                // first < second
                return -1;
            }
            else if (first.getSize() > second.getSize())
            {
                // first > second
                return 1;
            }

            // если размеры равны, то нужно сравнивать по цифрам
            return CompareDigits(first, second);
        }

        private static int CompareDigits(LongNumber first, LongNumber second)
        {
            // раз длина одинаковая, то завёдм один счётчик
            for (int i = first.getSize() - 1; i >= 0; i--)
            {
                if (first.GetByte(i) > second.GetByte(i))
                {
                    return 1;
                }
                else if (first.GetByte(i) < second.GetByte(i))
                {
                    return -1;
                }
            }

            return 0;
        }

        //***********



        /*
        ***********
        Операторы сложения, умножения, деления, вычитания
        */

        public static LongNumber operator +(LongNumber first, LongNumber second) // оператор сложения
        {
            var digits = new List<Byte>(); // лист цифр, где будут лежать цифры получившегося числа
            var maxLength = Math.Max(first.getSize(), second.getSize());
            byte t = 0; // дополнение к сумме
            for (int i = 0; i < maxLength; i++)
            {
                byte sum = (byte) (first.GetByte(i) + second.GetByte(i) + t);
                if (sum > 10)
                {
                    sum -= 10;
                    t = 1;
                }
                else
                {
                    t = 0;
                }

                digits.Add(sum);
            }

            return new LongNumber(first.signNumber, digits);
        }

        public static LongNumber operator -(LongNumber first, LongNumber second) // вычитание чисел
        {
            var digits = new List<Byte>(); // лист цифр будущего числа
            // теперь нужно сравнить числа, игнорирую знак
            // далее из большего вычтем меньшее, а результату присвоим знак большего из чисел
            LongNumber max = null;
            LongNumber min = null;
            var compareResult = Comparison(first, second, ignoreSign: true);
            switch (compareResult)
            {
                case -1:
                    min = first;
                    max = second;
                    break;
                case 0:
                    // числа совпали
                    return new LongNumber("0");
                case 1:
                    min = second;
                    max = first;
                    break;
            }

            // из большего вычитаем меньшее
            var maxLentgh = Math.Max(first.getSize(), second.getSize());
            var t = (byte) 0;
            for (int i = 0; i < maxLentgh; i++)
            {
                var s = max.GetByte(i) - min.GetByte(i) - t;
                if (s < 0)
                {
                    s += 10;
                    t = 1;
                }
                else
                {
                    t = 0;
                }

                digits.Add((byte) s);
            }

            return new LongNumber(max.signNumber, digits);
        }

        public static LongNumber operator *(LongNumber first, LongNumber second) // оператор умножения
        {
            LongNumber result = Zero;
            for (int i = 0; i < first.getSize(); i++)
            {
                for (int j = 0, carry = 0; (j < second.getSize() || carry > 0); j++)
                {
                    int current = result.GetByte(i + j) + first.GetByte(i) * second.GetByte(j) + carry;
                    result.setByte(i + j, (byte) (current % 10));
                    carry = current / 10;
                }
            }

            result.signNumber = first.signNumber == second.signNumber ? Sign.Plus : Sign.Minus;
            return result;
        }

        public static LongNumber operator /(LongNumber first, LongNumber second)
        {
            // будем искать наибольшее число, результат умножения которого на второе число ближе всего к первому
            LongNumber resultValue = Zero;
            LongNumber currentValue = Zero;

            for (int i = first.getSize() - 1; i >= 0; i--)
            {
                //Console.WriteLine(currentValue);
                currentValue += Exp(first.GetByte(i), i);
                int x = 0; // искомая цифра на n-ом шаге
                int l = 0;
                int r = 10;
                // будем применять бин поиск для поиска текущей цифры в числе
                while (l <= r)
                {
                    // основная цель - найти текущую цифр и записать в m
                    int m = (l + r) / 2;
                    //Console.WriteLine(m);
                    var cur = second * Exp((byte) m, i);
                    //Console.WriteLine(cur);
                    if (cur <= currentValue)
                    {
                        x = m;
                        l = m + 1; // сдвигаем в бин поиске левую границу
                    }
                    else
                    {
                        r = m - 1; // сдвигаем в бин поиске правую границу
                    }
                }

                resultValue.setByte(i, (byte) (x % 10));
                //Console.WriteLine(resultValue);
                currentValue = currentValue - (second * Exp((byte) x, i));
            }
            
            
            resultValue.RemoveNulls();
            resultValue.signNumber = first.signNumber == second.signNumber ? Sign.Plus : Sign.Minus;
            return resultValue;
        }
        /*
        ***********
        */
        
        // переопределяем метод Equals
        public override bool Equals(object obj)
        {
            return !(obj is LongNumber) ? false : this == (LongNumber) obj;
        }
        /*
         
         
         
        *** Операторы сравнения 
        */
        public static bool operator <=(LongNumber a, LongNumber b)
        {
            return Comparison(a, b) <= 0;
        }

        public static bool operator >=(LongNumber a, LongNumber b)
        {
            return Comparison(a, b) >= 0;
        }

        public static bool operator >(LongNumber a, LongNumber b)
        {
            return Comparison(a, b) > 0;
        }

        public static bool operator <(LongNumber a, LongNumber b)
        {
            return Comparison(a, b) < 0;
        }

        public static bool operator ==(LongNumber a, LongNumber b)
        {
            return Comparison(a, b) == 0;
        }

        public static bool operator !=(LongNumber a, LongNumber b)
        {
            return Comparison(a, b) != 0;
        }
        //*****
    }
}