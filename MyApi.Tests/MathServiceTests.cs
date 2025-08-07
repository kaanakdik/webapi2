using MyApi.Services;
using Xunit;

namespace MyApi.Tests;

public class MathServiceTests
{
    private readonly MathService _mathService = new();

    [Fact]
    public void Add_ReturnsCorrectSum()
    {
        var result = _mathService.Add(3, 5);
        Assert.Equal(8, result);
    }

    [Fact]
    public void Multiply_ReturnsCorrectProduct()
    {
        var result = _mathService.Multiply(4, 6);
        Assert.Equal(24, result);
    }
}
