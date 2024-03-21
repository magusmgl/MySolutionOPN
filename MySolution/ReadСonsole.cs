using System.Text;

namespace MyNamespace;

public static class ReadСonsole
{
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
    public static Expression GetExpression()
    {
        string operation = String.Empty;
        int num1 = 0;
        int num2 = 0;

        bool isCorrectExp = false;

        do
        {
            string exp = Console.ReadLine();

            if (String.IsNullOrEmpty(exp))
            {
                Console.WriteLine("Пустое выражение. Введите еще раз:");
                continue;
            }

            int indexOfOperand = exp.IndexOfAny(operations);

            if (indexOfOperand < 0)
            {
                Console.WriteLine("Некорректное выражение. Введите еще раз: ");
                continue;
            }

            operation = exp.Substring(indexOfOperand, 1);
            var stringNumA = exp.Substring(0, indexOfOperand - 1);
            var stringNumB = exp.Substring(indexOfOperand + 1, exp.Length - indexOfOperand - 1);
            
            if (Int32.TryParse(stringNumA, out num1) == false || 
                Int32.TryParse(stringNumB, out num2) == false)
            {
                Console.WriteLine($"Некорректное значения числа.\nВведите еще раз: ");
                continue;
            }
            
            if (operation == "/" && num2 == 0)
            {
                Console.WriteLine("Некорректное выражение. На 0 делить нельзя");
                continue;
            }

            isCorrectExp = true;
        } while (isCorrectExp == false);

        Expression expressionObject = new Expression(num1, num2, operation);

        return expressionObject;
    }

    public static string GetExpressionInPolishNotation()
    {
        StringBuilder resultString = new StringBuilder();
        Stack<char> stackT = new Stack<char>();

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
                stackT.Push(sign);
            }
            else if (operations.Contains(sign))
            {
                while (stackT.Count != 0 &&
                       stackT.Peek() != '(' &&
                       GetPriorityOperation(stackT.Peek()) >= GetPriorityOperation(sign))
                {
                    resultString.Append($"{stackT.Peek()},");
                    stackT.Pop();
                } 
                stackT.Push(sign);
            }
            else if (sign == ')')
            {
                while (stackT.Peek() != '(')
                {
                    resultString.Append($"{stackT.Peek()},");
                    stackT.Pop();
                }
                stackT.Pop();
            }
        }

        while (stackT.Count != 0)
        {
            resultString.Append($"{stackT.Peek()},");
            stackT.Pop();
        }
        
        return resultString.ToString();
    }
}