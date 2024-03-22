using System.Text;

namespace MyNamespace;

public static class Expression
{
    private const string EmptyExpression = "Введена пустая строка! Повоторите ввод: ";
    private const string WrongExpression = "Введено  некорректное выражение! Повоторите ввод: ";
    private static readonly char[] Operations = { '-', '+', '*', '/' };

    public static string GetExpressionFromConsole()
    {
        bool isCorrectInput = false;
        string expression = String.Empty;

        while (isCorrectInput == false)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            string input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(EmptyExpression);
                continue;
            }

            if (!CheckNumberOfBrackets(input))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(WrongExpression);
                continue;
            }

            expression = input;
            isCorrectInput = true;
        }

        return expression;
    }

    public static string TransformExpressionToPolishNotation(string inputExpression)
    {
        StringBuilder resultString = new StringBuilder();
        Stack<char> stackForOperations = new Stack<char>();

        foreach (char sign in inputExpression)
        {
            if (sign == ' ') continue;

            if (char.IsDigit(sign))
            {
                resultString.Append($"{sign},");
            }
            else if (sign == '(')
            {
                stackForOperations.Push(sign);
            }
            else if (Operations.Contains(sign))
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

    private static bool CheckNumberOfBrackets(string brackets)
    {
        Stack<char> stackOfBrackets = new Stack<char>();
        foreach (var bracket in brackets)
        {
            if (stackOfBrackets.Count == 0 && bracket == ')')
            {
                return false;
            }

            if (bracket == '(')
            {
                stackOfBrackets.Push(bracket);
            }
            else if (stackOfBrackets.Count != 0 && bracket == ')')
            {
                if (stackOfBrackets.Peek() == '(')
                {
                    stackOfBrackets.Pop();
                }
            }
        }

        return stackOfBrackets.Count == 0;
    }

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