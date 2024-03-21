namespace MyNamespace;

public static class Calculator
{
    public static int GetResultCalculation(int operand1, int operand2, string operation)
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
}