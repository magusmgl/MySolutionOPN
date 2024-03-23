using System.Text.RegularExpressions;

namespace MySolution;

public static class Calculator
{
    private static readonly char[] Operations = { '-', '+', '*', '/' };

    public static int GetResultExpression(string expression)
    {
        var stackForOperands = new Stack<int>();
        var elementsExpression = expression.Split(",", StringSplitOptions.RemoveEmptyEntries);
        var pattern = new Regex(@"\d+", RegexOptions.Compiled);


        foreach (var element in elementsExpression)
        {
            var match = pattern.Match(element);
            if (match.Success)
            {
                stackForOperands.Push(int.Parse(element));
            }
            else if (Operations.Contains(char.Parse(element)))
            {
                CalculateIntermediateResult(stackForOperands, element);
            }
        }

        var result = stackForOperands.Peek();
        stackForOperands.Clear();
        return result;
    }

    private static int Calculate(int operand1, int operand2, string operation)
    {
        var res = operation switch
        {
            "+" => operand1 + operand2,
            "-" => operand1 - operand2,
            "*" => operand1 * operand2,
            "/" => operand1 / operand2,
            _ => 0
        };

        return res;
    }

    private static void CalculateIntermediateResult(Stack<int> stackForOperands, string element)
    {
        var b = stackForOperands.Peek();
        stackForOperands.Pop();

        var a = stackForOperands.Peek();
        stackForOperands.Pop();

        var currentResult = Calculate(a, b, element);
        stackForOperands.Push(currentResult);
    }
}