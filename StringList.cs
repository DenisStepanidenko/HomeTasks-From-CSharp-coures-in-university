using System;
using System.Linq;
using System.Text;
using HomeTask29_09_2023;


namespace HomeTask23_09_2023_Ex1
{
    public class StringList
    {
        private string[] list;
        public int count;
        public override string ToString()
        {
            string output = "";
            foreach (var current in list)
            {
                //Console.Write(current + " ");
                if (current != null)
                {
                    output += current + " ";
                }
            }
            return output;
        }

        public StringList(string[] list)
        {
            this.list = list;
            count = -1;
        }

        public int Insert(string current)
        {
            if (count >= list.Length)
            {
                // значит у нас уже нет в массиве места, чтобы добавить элементы
                Console.WriteLine("Массив заполнен");
                return -1;
            }
            count++;
            list[count] = current;
            Console.WriteLine("Элемент {0} был успешно вставлен под индексом {1}", current, count);
            return count;
        }
        
        public void Delete(int index)
        {
            if (index < 0 || index > count)
            {
                Console.WriteLine("Недопустимое значение index");
                return;
            }
            // если index - допустимое значение, то нужно сдвинуть элементы
            // a1 a2 .... a_(index-1) a_(index) a_(index+1) .... a_(count-1)
            if (index == count)
            {
                list[index] = null;
                count--;
                return;
            }
            for (int i = index; i <= count; i++)
            {
                if (i == count)
                {
                    list[i] = null;
                    continue;
                }
                list[i] = list[i + 1];
            }
            count--; // не забываем уменьшать количество элементов
        }

        public int Search(string current)
        {
            for (int i = 0; i < count; i++)
            {
                if (list[i] == current)
                {
                    return i;
                }
            }

            Console.WriteLine("Элемент {0} не найден в массиве", current);
            return -1;
        }

        public void Update(int index, string current)
        {
            if (index < 0 || index > count)
            {
                Console.WriteLine("Недопустимое значение index");
                return;
            }

            list[index] = current;
        }

        public string GetAt(int index)
        {
            if (index < 0 || index >= count)
            {
                Console.WriteLine("Недопустимое значение index");
                return null;
            }
            return list[index];
            
        }
        
        // метод преобразования из строки в LongNumber
        public bool TryParse(string str, out LongNumber x)
        {
            // попробуем создать из строки - длинное число
            try
            {
                if (count <= -1)
                {
                    throw new ArgumentException("В StringList нет строк");
                }
                StringBuilder currentNumber = new StringBuilder();
                for (int i = 0; i <= count; i++)
                {
                    currentNumber.Append(list[i]);
                }
                
                // пользуемся уже созданным методом из строки
                x = new LongNumber(currentNumber.ToString());
            }
            catch
            {
                x = null;
                return false;
                throw new Exception();
            }
            return true;
        }
    }
}