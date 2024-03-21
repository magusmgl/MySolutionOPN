using System.Text;

namespace MyNamespace;

public static class ReadСonsole
{
    public static string GetExpressionInPolishNotation()
    {
        StringBuilder resultString = new StringBuilder();
        Stack<char> stackForOperations = new Stack<char>();

        string input = Console.ReadLine();

        foreach (char sign in input)
        {
            if (sign == ' ') continue;

            else if (char.IsDigit(sign))
            {
                resultString.Append($"{sign},");
            }
            else if (sign == '(')
            {
                stackForOperations.Push(sign);
            }
            else if (operations.Contains(sign))
            {
                while (stackForOperations.Count != 0 &&
                       stackForOperations.Peek() != '(' &&
                       GetPriorityOperation(stackForOperations.Peek()) >= GetPriorityOperation(sign))
                {
                    resultString.Append($"{stackForOperations.Peek()},");
                    stackForOperations.Pop();
                }
                stackForOperations.Push(sign);
            }
            else if (sign == ')')
            {
                while (stackForOperations.Peek() != '(')
                {
                    resultString.Append($"{stackForOperations.Peek()},");
                    stackForOperations.Pop();
                }
                stackForOperations.Pop();
            }
        }

        while (stackForOperations.Count != 0)
        {
            resultString.Append($"{stackForOperations.Peek()},");
            stackForOperations.Pop();
        }

        return resultString.ToString();
    }

    private static char[] operations = { '-', '+', '*', '/' };
    private static int GetPriorityOperation(char sign)
    {
        return sign switch
        {
            '-' => 0,
            '+' => 0,
            '/' => 1,
            '*' => 1,
        };
    }
   
}