using System.Diagnostics;
using Xunit.Abstractions;

namespace yoursolution_validate;

public class UnitTest1
{
    [Fact]
    public void A_String_Between_Parenthesis()
    {
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
    public void Square_brackets_sign_is_child_of_paranthesis()
    {
        YourSolution.Validate("(This [looks] great!)", "()[]");

        Assert.NotNull(YourSolution.FirstAppereance.ChildAppereance);
        Assert.Equal('[', YourSolution.FirstAppereance.ChildAppereance.SignPair.OpenChar);
        Assert.Equal(']', YourSolution.FirstAppereance.ChildAppereance.SignPair.CloseChar);
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

    [Fact]
    public void Last_appereance_sign_is_bracket()
    {
        YourSolution.FirstAppereance = new YourSolution.Appereance(new YourSolution.SignPair('(', ')'), 0, 18);
        YourSolution.FirstAppereance.ChildAppereance = new YourSolution.Appereance(new YourSolution.SignPair('(', ')'), 1, 17);
        YourSolution.FirstAppereance.ChildAppereance.ChildAppereance = new YourSolution.Appereance(new YourSolution.SignPair('[', ']'), 2, 16);

        Assert.Equal("[]", YourSolution.FirstAppereance.GetLastAppereance().SignPair.ToString());
    }

    [Fact]
    public void Last_appereance_sign_is_the_first_appereance()
    {
        YourSolution.FirstAppereance = new YourSolution.Appereance(new YourSolution.SignPair('(', ')'), 0, 18);

         var appereance = YourSolution.FirstAppereance.GetLastAppereance();

        Assert.Equal(YourSolution.FirstAppereance, appereance);
    }

}