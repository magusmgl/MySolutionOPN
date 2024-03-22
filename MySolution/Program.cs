using System.Text;
using MyNamespace;

Console.WriteLine("Программа калькулятор");
Console.WriteLine("Введите выражение для вычисления:");

var expression = ReadСonsole.CheckInputExpression();
Console.WriteLine(expression);

// var polishNotationExpression = ReadСonsole.GetExpressionInPolishNotation();
// var resultExpression = Calculator.GetResultExpressionInPolishNotation(polishNotationExpression);
// Console.WriteLine(resultExpression);