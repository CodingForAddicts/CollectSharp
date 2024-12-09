namespace Woodstix.Fundamentals;

public class Encryptions
{
    public static bool AreValidParentheses(string s)
    {
        var myStack = new Stack<char>();
        char match;
        for (var i = 0; i < s.Length; i++)
        {
            if (i == 0 && (s[i] == ']' || s[i] == '}' || s[i] == ')')) return false;

            if (s[i] == '[' || s[i] == '{' || s[i] == '(') myStack.Push(s[i]);
            if (s[i] == ']' || s[i] == '}' || s[i] == ')')
            {
                match = myStack.Pop();
                if (match == '(')
                    if (s[i] == ')') return true;
                    else if (match + 2 != s[i]) return false;
            }
        }

        if (myStack.Count != 0) return false;
        return true;
    }

    public static (int number, int endIndex) GetRepetitionNumber(string s, int startIndex)
    {
        var number = 0;
        var index = startIndex;
        for (var i = startIndex; i < s.Length; i++)
            if (char.IsDigit(s[i]))
            {
                number = (number + (s[i] - '0')) * 10;
                index++;
            }
            else if (s[i] == '[')
            {
                number = number / 10;
                break;
            }
            else
            {
                throw new ArgumentException();
            }

        return (number, index);
    }

    public static string DecodeString(string s)
    {
        var stringStack = new Stack<string>();
        var numberStack = new Stack<int>();
        var result = "";
        var decoded = "";
        int nested = 0;
        (int number, int endIndex) = (0, 0);

        for (int i = 0; i < s.Length; i++)
        {
            if (char.IsDigit(s[i]))
            {
                (number, endIndex) = GetRepetitionNumber(s, i);
                i = endIndex-1;
            }

            else if (s[i] == '[')
            {
                i++;
                while ((s[i] >= 97) && (s[i] <= 122))
                {
                    decoded += s[i];
                    i++;
                }

                if (char.IsDigit(s[i]))
                {
                    nested += 1;
                    stringStack.Push(decoded);
                    decoded = "";
                }
                else
                {
                    stringStack.Push(decoded);
                    decoded = "";
                }
                i--;
                numberStack.Push(number);

            }

            else if (s[i] == ']')
            {
                int repetNum = numberStack.Pop();
                string repetString = stringStack.Pop();
                for (int j = 0; j < repetNum; j++)
                {
                    if (nested > 0)
                    {
                        decoded += repetString;
                        
                    }
                    else result += repetString;
                    
                }

                if (nested > 0)
                {
                    decoded = stringStack.Pop() + decoded;
                    stringStack.Push(decoded);
                    decoded = "";
                    nested--;
                }

            }
            else
            {
                result += s[i];
            }
        }

        return result;
    }
}