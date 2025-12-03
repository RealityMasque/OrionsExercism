public static class SimpleCalculator
{
    public static string Calculate(int operand1, int operand2, string? operation)
    {
        if(operation == null)
        {
            throw new ArgumentNullException("operation cannot be null.");
        }

        if(operation == "")
        {
            throw new ArgumentException("operation cannot be empty.");
        }
        
        if(operation != "+" && operation != "*" && operation != "/")
        {
            throw new ArgumentOutOfRangeException($"{operation} is not an allowed operation.");
        }

        if(operation == "/" && operand2 == 0)
        {
            return "Division by zero is not allowed.";
        }

        switch(operation)
        {
            case "+": return $"{operand1} {operation} {operand2} = {Add(operand1, operand2)}";
            case "*": return $"{operand1} {operation} {operand2} = {Multiply(operand1, operand2)}";
            case "/": return $"{operand1} {operation} {operand2} = {Divide(operand1, operand2)}";
            default: throw new ArgumentOutOfRangeException($"{operation} is not an allowed operation.");
        }
    }

    private static int Add(int operand1, int operand2) => operand1 + operand2;

    private static int Multiply(int operand1, int operand2) => operand1 * operand2;

    private static int Divide(int operand1, int operand2) => operand1 / operand2;
}
