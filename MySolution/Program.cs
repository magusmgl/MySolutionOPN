using System.Text;
using MyNamespace;

Console.WriteLine("Программа калькулятор");
Console.WriteLine("Введите выражение для вычисления:");

// Expression correctExp = ReadСonsole.GetExpression();
// int answer = Calculator.GetResultCalculation(correctExp.Number1, correctExp.Number2, correctExp.Operation);
// Console.WriteLine($"{correctExp} = {answer}");


var polishNotationExpression = ReadСonsole.GetExpressionInPolishNotation();
var resultExpression = Calculator.GetResultExpressionInPolishNotation(polishNotationExpression);
Console.WriteLine(resultExpression);