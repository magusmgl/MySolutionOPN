using System.Text;
using MyNamespace;
using MySolution;

Console.WriteLine("Программа калькулятор");
Console.WriteLine("Введите выражение для вычисления:");

var expression = Expression.GetExpressionFromConsole();
var resultExpression = Calculator.GetResultExpression(expression );
Console.WriteLine(resultExpression);