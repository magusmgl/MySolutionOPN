namespace MyNamespace;

public class Expression
{
    public int Number1 { get; }
    public int Number2 { get; }
    public string Operation { get; }

    public Expression(int number1, int number2, string operation)
    {
        this.Number1 = number1;
        this.Number2 = number2;
        this.Operation = operation;
    }

}