namespace HomeTask23_09_2023_Ex1
{
    public class MethodToChange
    {
        public static void ChangeRef(ref int first, ref int second)
        {
            int temp = first;
            first = second;
            second = temp;
        }
    }
}