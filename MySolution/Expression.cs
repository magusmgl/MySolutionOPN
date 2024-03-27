using System.Text;
using System.Text.RegularExpressions;

namespace MyNamespace;

public static class Expression
{
    private const string EmptyExpression = "Введена пустая строка! Повоторите ввод: ";
    private const string WrongBracketsInExpression = "Введено  некорректное выражение (проверь скобки)! Повоторите ввод: ";
    private const string WrongExpressionInBrackets = "Введено  некорректное выражение в скобках! Повоторите ввод: ";
    private const string WrongElementsInExpression = "Введено  некорректное выражение (в выражении есть недопустимые символы)! Повоторите ввод: ";
    private static readonly string[] Operations = { "-", "+", "*", "/" };
    private static readonly char[] Brackets = { '(', ')' };

    public static string GetExpressionFromConsole()
    {
        var isCorrectInput = false;
        var expression = string.Empty;

        while (isCorrectInput == false)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            var input = Console.ReadLine();
            var inputWithoutWhiteSpaces = string.Concat(input.Where(c => !char.IsWhiteSpace(c)));


            if (string.IsNullOrEmpty(inputWithoutWhiteSpaces))
            {
                WriteError(EmptyExpression);
                continue;
            }

            if (CheckBalanceBrackets(inputWithoutWhiteSpaces) == false)

            {
                WriteError(WrongBracketsInExpression);
                continue;
            }

            if (CheckExpressionIntoBrackets(inputWithoutWhiteSpaces) == false)
            {
                WriteError(WrongExpressionInBrackets);
                continue;
            }

            if (CheckExpressionElements(inputWithoutWhiteSpaces))
            {
                WriteError(WrongElementsInExpression);
                continue;
            }

            expression = TransformExpressionToPolishNotation(inputWithoutWhiteSpaces);
            isCorrectInput = true;
        }

        return expression;
    }

    private static bool CheckExpressionElements(string input)
    {
        var pattern = new Regex(@"[^\d-+*/()]", RegexOptions.Compiled);
        return pattern.Match(input).Success;
    }

    private static bool CheckExpressionIntoBrackets(string input)
    {
        if (input.IndexOfAny(Brackets) == -1) return true;
        var pattern = new Regex(@"\(\d*[+-/*]\)|\([+-/*]\d*\)|\(\)", RegexOptions.Compiled);
        return !pattern.Match(input).Success;
    }

    private static string TransformExpressionToPolishNotation(string inputExpression)
    {
        var listExp = ConvertExpressionToList(inputExpression);

        var resultString = new StringBuilder();
        var stackForOperations = new Stack<string>();
        var pattern = new Regex(@"\d+", RegexOptions.Compiled);

        foreach (var element in listExp)
        {
            if (pattern.Match(element).Success)
            {
                resultString.Append($"{element},");
            }
            else if (element == "(")
            {
                stackForOperations.Push(element);
            }
            else if (Operations.Contains(element))
            {
                while (stackForOperations.Count != 0 &&
                       stackForOperations.Peek() != "(" &&
                       GetPriorityOperation(stackForOperations.Peek()) >= GetPriorityOperation(element))
                {
                    resultString.Append($"{stackForOperations.Peek()},");
                    stackForOperations.Pop();
                }

                stackForOperations.Push(element);
            }
            else if (element == ")")
            {
                while (stackForOperations.Peek() != "(")
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

    private static void WriteError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
    }

    public static List<string> ConvertExpressionToList(string input)
    {
        var listExpression = new List<string>();

        string pattern = @"(?<=\()([-]?\d+)|[()]|(?<=[-+*\/])([-]?\d+)|[-+*\/]|^[-]?\d";
        foreach (Match match in Regex.Matches(input, pattern, RegexOptions.IgnoreCase))
        {
            if (match.Success)
            {
                Console.WriteLine($"{match.Value}");
                listExpression.Add(match.Value);
            }
        }
        return listExpression;
    }

    private static bool CheckBalanceBrackets(string brackets)
    {
        var stackOfBrackets = new Stack<char>();
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

    private static int GetPriorityOperation(string sign)
    {
        return sign switch
        {
            "-" => 0,
            "+" => 0,
            "/" => 1,
            "*" => 1,
        };
    }
}