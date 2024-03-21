using System.Text.RegularExpressions;

namespace MyNamespace;

public static class Calculator
{

    public static int GetResultExpressionInPolishNotation(string expression)
    {
        Stack<int> stackForOperands = new Stack<int>();
        string[] elementsExpression = expression.Split(",", StringSplitOptions.RemoveEmptyEntries);
        Regex pattern = new Regex(@"\d+", RegexOptions.Compiled);


        foreach (var element in elementsExpression)
        {
            var match = pattern.Match(element);
            if (match.Success)
            {
                stackForOperands.Push(Int32.Parse(element));
            }
            else if (operations.Contains(char.Parse(element)))
            {
                CalculateIntermediateResult(stackForOperands, element);
            }
        }

        var result = stackForOperands.Peek();
        stackForOperands.Clear();
        return result;
    }

    private static char[] operations = { '-', '+', '*', '/' };

    private static int GetResultCalculation(int operand1, int operand2, string operation)
    {
        int res = 0;
        switch (operation)
        {
            case "+":
                res = operand1 + operand2;
                break;
            case "-":
                res = operand1 - operand2;
                break;
            case "*":
                res = operand1 * operand2;
                break;
            case "/":
                res = operand1 / operand2;
                break;
        }

        return res;
    }

    private static void CalculateIntermediateResult(Stack<int> stackForOperands, string element)
    {
        var b = stackForOperands.Peek();
        stackForOperands.Pop();

        var a = stackForOperands.Peek();
        stackForOperands.Pop();

        var curentResult = GetResultCalculation(a, b, element);
        stackForOperands.Push(curentResult);
    }
}
