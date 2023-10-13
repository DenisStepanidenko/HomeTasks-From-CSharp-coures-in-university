using System;

namespace HomeTask23_09_2023_Ex1
{
    public class ShiftCount
    {
        private static string englishLowerCase = "abcdefghijklmnopqrstuvwxyz";
        private static string englishUpperCase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static string russianLowerCase = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        private static string russianUpperCase = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        
        public static bool Shift(int shiftCount, ref char ch)
        {
            if (!Char.IsLetter(ch))
            {
                // если символ не является символом русского или английского алфавита
                return false;
            }

            if (shiftCount == 0)
            {
                return true;
            }
            // теперь нужно понять из какого алфавита символ 
            shiftCount = shiftCount * (-1);
            
            if (englishLowerCase.Contains(Convert.ToString(ch)))
            {
                
                // значит символ из английского ал
                int ostatok = GetOstatokEnglish(englishLowerCase.IndexOf(ch) - shiftCount);
                ch = englishLowerCase[ostatok];

            }
            else if (englishUpperCase.Contains(Convert.ToString(ch)))
            {
                int ostatok = GetOstatokEnglish(englishUpperCase.IndexOf(ch) - shiftCount);
                ch = englishUpperCase[ostatok];
            }
            else if (russianLowerCase.Contains(Convert.ToString(ch)))
            {
                int ostatok = GetOstatokRussian(russianLowerCase.IndexOf(ch) - shiftCount);
                ch = russianLowerCase[ostatok];

            }
            else
            {
                int ostatok = GetOstatokRussian(russianUpperCase.IndexOf(ch) - shiftCount);
                ch = russianUpperCase[ostatok];
            }
            
            return true;
        }

        public static int GetOstatokEnglish(int x) // для английских символов
        {
            // здесь метод для получения остатка
            for (int i = 0; i <= 25; i++)
            {
                if ((x - i) % 26 == 0)
                {
                    return i;
                }
            }
            return -1;
        }

        public static int GetOstatokRussian(int x)
        {
            for (int i = 0; i <= 32; i++)
            {
                if ((x - i) % 33 == 0)
                {
                    return i;
                }
            }
            return -1;
        }
        
    }
}