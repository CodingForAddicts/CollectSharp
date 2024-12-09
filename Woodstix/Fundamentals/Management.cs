namespace Woodstix.Fundamentals;

public class Management
{
    public static int[] NextGreaterPrice(int[] numbers)
    {
        Stack<int> manage = new Stack<int>();
        int[] managed = new int[numbers.Length];
        
        for (int i = 0; i < numbers.Length; i++)
        {
            managed[i] = -1; 
        }

        for (int i = 0; i < numbers.Length; i++)
        {
            while (manage.Count > 0 && numbers[manage.Peek()] < numbers[i])
            {
                int idx = manage.Pop();
                managed[idx] = numbers[i];
            }
            
            manage.Push(i);
        }

        return managed;
    }
}