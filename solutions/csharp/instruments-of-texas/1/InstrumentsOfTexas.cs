public class CalculationException : Exception
{
    private int _operand1;
    private int _operand2;
    
    public CalculationException(int operand1, int operand2, string message, Exception inner) : base(message, inner)
    {
        _operand1 = operand1;
        _operand2 = operand2;
    }

    public int Operand1 => _operand1;
    public int Operand2 => _operand2;
}

public class CalculatorTestHarness
{
    private Calculator calculator;

    public CalculatorTestHarness(Calculator calculator)
    {
        this.calculator = calculator;
    }

    public string TestMultiplication(int x, int y)
    {
        try
        {
            Multiply(x, y);
            return "Multiply succeeded";
        }
        catch (CalculationException ex) when (ex.Operand1 < 0 && ex.Operand2 < 0)
        {
            return "Multiply failed for negative operands. " + ex.InnerException.Message;
        }
        catch(CalculationException calculationException)
        {
            return "Multiply failed for mixed or positive operands. " + calculationException.InnerException.Message;
        }
    }

    public void Multiply(int x, int y)
    {
        try
        {
            calculator.Multiply(x, y);
        }
        catch(OverflowException overflowException)
        {
            throw new CalculationException(x, y, "", overflowException);
        }
    }
}


// Please do not modify the code below.
// If there is an overflow in the multiplication operation
// then a System.OverflowException is thrown.
public class Calculator
{
    public int Multiply(int x, int y)
    {
        checked
        {
            return x * y;
        }
    }
}
