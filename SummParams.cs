namespace HomeTask23_09_2023_Ex1
{
    public class SummParams
    {
        public static int Summ(params int[] parametrs){
            // так как мы не знаем, какие элементы нам придут, то нужно
            // использовать generic, параметризуем типом T
            int result = 0;
            foreach (var currentValue in parametrs)
            {
                result += currentValue;
            }
            return result;
        }
        
        
    }
   
}