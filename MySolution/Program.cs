using System.Text;
using MyNamespace;

Console.WriteLine("Программа калькулятор");
Console.WriteLine("Введите выражение для вычисления:");

Expression correctExp = ReadСonsole.GetExpression();
int answer = Calculator.GetResultCalculation(correctExp.Number1, correctExp.Number2, correctExp.Operation);
Console.WriteLine($"{correctExp} = {answer}");


string exp = "(2 + 3) * (5 - 8)";

char[] operations = { '-', '+', '*', '/' };
char[] operands = { '1', '2', '3' };

StringBuilder res = new StringBuilder();


Stack<char> stackT = new Stack<char>();

foreach (char sign in exp)
{
    if (char.IsDigit(sign))
    {
        res.Append(sign);
    }
    else if (sign == '(')
    {
        stackT.Push(sign);
    }
    else if (operations.Contains(sign))
    {
        if (stackT.Count != 0 && stackT.Peek() != '(')
        {
            
        }
        else
        {
            stackT.Push(sign);
        }
    }
}



