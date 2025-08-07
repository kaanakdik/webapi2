namespace MyApi.Services;

public class MathService : IMathService
{
    public int Add(int a, int b) => a + b;

    public int Multiply(int a, int b) => a * b;
}
