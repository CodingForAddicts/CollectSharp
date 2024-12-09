namespace Woodstix.Proficiencies;

public class VIP
{
    public static List<int> TicketsVIP(Queue<int> queue, int amountVIP)
    {
        if (amountVIP == 0) return new List<int>();

        List<int> result = new List<int>();

        Stack<int> stack = new Stack<int>();

        int target = 1;

        int minPriorityOnStack = int.MaxValue;

        int operationCount = 0;

        while (target <= amountVIP)
        {
            if (queue.Count == 0) break;

            int current = queue.Dequeue();
            operationCount++;

            if (current == 0)
            {
                queue.Enqueue(current);
                continue;
            }
            if (current != target)
            {
                stack.Push(current);

                // Replace Math.Min with a conditional check
                if (current < minPriorityOnStack)
                {
                    minPriorityOnStack = current;
                }
                continue;
            }

            result.Add(operationCount);
            target++;
            while (stack.Count > 0)
            {
                if (stack.Peek() == target)
                {
                    int stackTop = stack.Pop();
                    result.Add(operationCount);
                    target++;
                }
                else
                {
                    int stackTop = stack.Pop();
                    queue.Enqueue(stackTop);
                }
            }
            minPriorityOnStack = int.MaxValue;
        }

        return result;
        
    }
}