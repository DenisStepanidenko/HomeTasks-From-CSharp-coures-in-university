namespace HomeTask29_09_2023
{
    public class Problem2
    {
        public static void ChangeDigits(ref int x)
        {
            int xNew = (x < 0) ? x * (-1) : x;
            int first = xNew / 10;
            int second = xNew % 10;
            int newNumber = second * 10 + first;
            x = (x < 0) ? newNumber * (-1) : newNumber;
        }
    }
}