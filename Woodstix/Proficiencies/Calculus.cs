namespace Woodstix.Proficiencies;

public class Calculus
{
    public static Queue<string> ConvertToRPN(string infix)
    {
        if (string.IsNullOrWhiteSpace(infix)) return new Queue<string>();

            var outputQueue = new Queue<string>();
            var operatorStack = new Stack<string>();
            var tokens = infix.Split(' ');

            var operators = new HashSet<string> { "+", "-" };
            bool notnumber= false;
            var leftParenthesis = "(";
            var rightParenthesis = ")";

            foreach (var token in tokens)
            {
                foreach (char c in token)
                {
                    notnumber = (c < 48 || c > 57);
                }
                if (!notnumber)
                {
                    outputQueue.Enqueue(token);
                }
                else if (operators.Contains(token))
                {
                    while (operatorStack.Count > 0 && operatorStack.Peek() != leftParenthesis)
                    {
                        outputQueue.Enqueue(operatorStack.Pop());
                    }
                    operatorStack.Push(token);
                }
                else if (token == leftParenthesis)
                {
                    operatorStack.Push(token);
                }
                else if (token == rightParenthesis)
                {
                    bool leftParenthesisFound = false;
                    while (operatorStack.Count > 0)
                    {
                        if (operatorStack.Peek() == leftParenthesis)
                        {
                            leftParenthesisFound = true;
                            operatorStack.Pop();
                            break;
                        }
                        outputQueue.Enqueue(operatorStack.Pop());
                    }

                    if (!leftParenthesisFound)
                        throw new ArgumentException("Parentheses are not balanced.");
                }
                else
                {
                    throw new ArgumentException($"Invalid token: {token}");
                }
            }

            while (operatorStack.Count > 0)
            {
                var top = operatorStack.Pop();
                if (top == leftParenthesis || top == rightParenthesis)
                    throw new ArgumentException("Parentheses are not balanced.");
                outputQueue.Enqueue(top);
            }

            return outputQueue;
        
    }
    
    public static int EvaluateRPN(Queue<string> rpnExpression)
    {
        Stack<int> stack = new Stack<int>();

        while (rpnExpression.Count > 0)
        {
            var token = rpnExpression.Dequeue();

            if (IsOperand(token)) 
            {
                stack.Push(ConvertToInt(token)); 
            }
            else if (IsOperator(token)) 
            {
                if (stack.Count < 2)
                    throw new ArgumentException("Invalid RPN expression");

                int right = stack.Pop();  
                int left = stack.Pop();  
                
                int result = PerformOperation(left, right, token);
                stack.Push(result);
            }
            else
            {
                throw new ArgumentException($"Invalid token: {token}");
            }
        }

        if (stack.Count != 1)
            throw new ArgumentException("Invalid RPN expression");

        return stack.Pop(); 
    }
    
    private static bool IsOperator(string token)
    {
        return token == "+" || token == "-";
    }
    
    private static bool IsOperand(string token)
    {
        for (int i = 0; i < token.Length; i++)
        {
            if (!Char.IsDigit(token[i]))
                return false;
        }
        return true;
    }
    
    private static int ConvertToInt(string token)
    {
        int result = 0;
        int sign = 1;
        int startIndex = 0;
        
        
        for (int i = startIndex; i < token.Length; i++)
        {
            result = result * 10 + (token[i] - '0');
        }

        return result * sign;
    }
    
    private static int PerformOperation(int left, int right, string operatorToken)
    {
        switch (operatorToken)
        {
            case "+":
                return left + right;
            case "-":
                return left - right;
            default:
                throw new ArgumentException($"Invalid operator: {operatorToken}");
        }
    }
    
}