using Shared.Result;
namespace UnitTest.Shared;

public class ResultPatternTest
{
    public Result<string> concatString(string a, string b)
    {
        if (string.IsNullOrEmpty(a) || string.IsNullOrEmpty(b))
        {
            return Result.Failure<string>(new Error("string.empty", "String is null or empty"));
        }
        return Result.Success(a + b);
    }
    [Fact]
    public void TestConcatString()
    {
        var result = concatString("Hello", "World");
        Assert.True(result.IsSuccess);
        Assert.Equal("HelloWorld", result.Value);
        var result2 = concatString("", "World");
        Assert.False(result2.IsSuccess);
        Assert.Equal("string.empty", result2.Error.Code);
        Assert.Equal("String is null or empty", result2.Error.Message);
        var result3 = concatString("Hello", "");
        Assert.False(result3.IsSuccess);
        Assert.Equal("string.empty", result3.Error.Code);
        Assert.Equal("String is null or empty", result3.Error.Message);
    }
}
