namespace MyNamespace;

public static class ReadСonsole
{
    public static Expression GetExpression()
    {
        char[] operations = { '-', '+', '*', '/' };
        string operation = String.Empty;
        int num1 = 0;
        int num2 = 0;

        bool isCorrectExp = false;

        do
        {
            string exp = Console.ReadLine();

            if (String.IsNullOrEmpty(exp))
            {
                Console.WriteLine("Пустое выражение. Введите еще раз:");
                continue;
            }

            int indexOfOperand = exp.IndexOfAny(operations);

            if (indexOfOperand < 0)
            {
                Console.WriteLine("Некорректное выражение. Введите еще раз: ");
                continue;
            }

            operation = exp.Substring(indexOfOperand, 1);
            var stringNumA = exp.Substring(0, indexOfOperand - 1);
            var stringNumB = exp.Substring(indexOfOperand + 1, exp.Length - indexOfOperand - 1);
            
            if (Int32.TryParse(stringNumA, out num1) == false || 
                Int32.TryParse(stringNumB, out num2) == false)
            {
                Console.WriteLine($"Некорректное значения числа.\nВведите еще раз: ");
                continue;
            }
            
            if (operation == "/" && num2 == 0)
            {
                Console.WriteLine("Некорректное выражение. На 0 делить нельзя");
                continue;
            }

            isCorrectExp = true;
        } while (isCorrectExp == false);

        Expression expressionObject = new Expression(num1, num2, operation);

        return expressionObject;
    }
}