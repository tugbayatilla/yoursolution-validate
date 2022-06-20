using System.Diagnostics;
using Xunit.Abstractions;

namespace yoursolution_validate;

public class UnitTest1
{
    private readonly ITestOutputHelper output;

    public UnitTest1(ITestOutputHelper output)
    {
        this.output = output;
        YourSolution._logger = (s) =>
        {
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

    [Fact(Skip = "Refactoring code to make this test available!")]
    public void Invalid_square_brackets_and_paranthesis()
    {
        Assert.False(YourSolution.Validate("(This [looks) bad!]", "()[]"));
    }

    [Fact]
    public void Open_paranthesis_index_is_zero_and_close_paranthesis_index_is_eighteen()
    {
        YourSolution.Validate("(This looks great!)", "()");
        var paranthesisSignPair = YourSolution.Appereances.First(p => p.SignPair.OpenChar == '(' && p.SignPair.CloseChar == ')');

        Assert.Equal(0, paranthesisSignPair.OpenSignIndex);
        Assert.Equal(18, paranthesisSignPair.CloseSignIndex);

    }

    [Fact]
    public void Square_brackets_sign_is_child_of_paranthesis()
    {
        YourSolution.Validate("(This [looks] great!)", "()[]");
        var paranthesisSignPair = YourSolution.Appereances.First(p => p.SignPair.OpenChar == '(' && p.SignPair.CloseChar == ')');

        Assert.NotNull(paranthesisSignPair.ChildAppereance);
        Assert.Equal('[', paranthesisSignPair.ChildAppereance.SignPair.OpenChar);
        Assert.Equal(']', paranthesisSignPair.ChildAppereance.SignPair.CloseChar);
    }

    [Fact]
    public void First_appereance_is_avaiable_and_its_signpair_is_open_close_paranthesis()
    {
        YourSolution.Validate("(This looks great!)", "()");

        Assert.Equal("()", YourSolution.FirstAppereance.SignPair.ToString());
    }

    [Fact]
    public void Open_paranthesis_index_is_zero_and_close_paranthesis_index_is_eighteen_using_FirstAppereance()
    {
        YourSolution.Validate("(This looks great!)", "()");

        Assert.Equal(0, YourSolution.FirstAppereance.OpenSignIndex);
        Assert.Equal(18, YourSolution.FirstAppereance.CloseSignIndex);
    }


}