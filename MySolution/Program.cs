using System.Text;
using MyNamespace;

Console.WriteLine("Программа калькулятор");
Console.WriteLine("Введите выражение для вычисления:");
//
// Expression correctExp = ReadСonsole.GetExpression();
// int answer = Calculator.GetResultCalculation(correctExp.Number1, correctExp.Number2, correctExp.Operation);
// Console.WriteLine($"{correctExp} = {answer}");


string exp = "(5-6)/(7-9) + 3 * ((4-5)* 3 + 7 * (3-7/4))";
var answer = ReadСonsole.GetExpressionInPolishNotation();
Console.WriteLine(answer);
//(5-6)/(7-9) + 3 * ((4-5)* 3 + 7 * (3-7/4))
//5 6 - 7 9 - / 3 4 5 - 3 * 7 3 7 4 / - * + * +
//5,6,-,7,9,-,/,3,4,5,-,3,*,7,3,7,4,/,-,*,+,*,+,
