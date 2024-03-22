using System.Text;
using MyNamespace;

Console.WriteLine("Программа калькулятор");
Console.WriteLine("Введите выражение для вычисления:");

var expression = Expression.GetExpressionFromConsole();
var polishNotationExpression = Expression.TransformExpressionToPolishNotation(expression);
Console.WriteLine(polishNotationExpression);

var resultExpression = Calculator.GetResultExpressionInPolishNotation(polishNotationExpression);
Console.WriteLine(resultExpression);