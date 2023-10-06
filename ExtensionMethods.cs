using System.Text;
using HomeTask29_09_2023;

namespace HomeTask23_09_2023_Ex1
{
    static class ExtensionMethods
    {
        public static LongNumber ToLongNumber(this string current)
        {
            // метод расширитель, который можно вызывать на строке - преобразует в длинное число
            return new LongNumber(current);
        }

        public static LongNumber ToLongNumber(this StringBuilder current)
        {
            // метод расширитель из string билдера
            return new LongNumber(current.ToString());
        }
    }
}