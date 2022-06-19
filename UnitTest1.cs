using System.Diagnostics;
using Xunit.Abstractions;

namespace yoursolution_validate;

public class UnitTest1
{
    private readonly ITestOutputHelper output;

    public UnitTest1(ITestOutputHelper output)
    {
        this.output = output;
        YourSolution._logger = (s)=> {
            output.WriteLine(s);
        };
    }

    [Fact]
    public void A_String_Between_Parenthesis()
    {
        output.WriteLine("teset 1");
        Assert.True(YourSolution.Validate("(This looks great!)", "()"));
    }

    [Fact]
    public void Closing_paranthesis_is_missing()
    {
        Assert.False(YourSolution.Validate("(This looks bad!", "()"));
    }

    [Fact]
    public void Valid_square_brackets_and_paranthesis()
    {
        Assert.True(YourSolution.Validate("(This [looks] great!)", "()[]"));
    }

    [Fact]
    public void Invalid_square_brackets_and_paranthesis()
    {
        Assert.False(YourSolution.Validate("(This [looks) bad!]", "()[]"));
    }
}