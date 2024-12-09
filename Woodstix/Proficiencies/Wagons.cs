namespace Woodstix.Proficiencies;

public class Wagons
{
    public static Stack<int> WagonsCollision(List<int> wagons)
    {
        Stack<int> Bob = new Stack<int>();

        foreach (int wagon in wagons)
        {
            bool destroyed = false;

            while (Bob.Count > 0 && wagon < 0 && Bob.Peek() > 0)
            {
                if (Bob.Peek() < -wagon) 
                {
                    Bob.Pop();
                }
                else if (Bob.Peek() == -wagon) 
                {
                    Bob.Pop();
                    destroyed = true;
                    break;
                }
                else 
                {
                    destroyed = true;
                    break;
                }
            }

            if (!destroyed)
            {
                Bob.Push(wagon);
            }
        }
        
        return Bob; // Inverser la pile pour retourner dans l'ordre initial

    }
    
}