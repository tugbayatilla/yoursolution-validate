using System.Diagnostics;
using Xunit.Abstractions;

namespace yoursolution_validate;

public class UnitTest1
{
    YourSolution _yourSolution;

    public UnitTest1()
    {
        _yourSolution = new YourSolution();
    }

    [Fact]
    public void A_String_Between_Parenthesis()
    {
        Assert.True(_yourSolution.Validate("(This looks great!)", "()"));
    }

    [Fact]
    public void Closing_paranthesis_is_missing()
    {
        Assert.False(_yourSolution.Validate("(This looks bad!", "()"));
    }

    [Fact]
    public void Valid_square_brackets_and_paranthesis()
    {
        Assert.True(_yourSolution.Validate("(This [looks] great!)", "()[]"));
    }

    [Fact]
    public void Invalid_square_brackets_and_paranthesis()
    {
        Assert.False(_yourSolution.Validate("(This [looks) bad!]", "()[]"));
    }

    [Fact]
    public void Square_brackets_sign_is_child_of_paranthesis()
    {
        _yourSolution.Validate("(This [looks] great!)", "()[]");

        Assert.NotNull(_yourSolution.FirstAppereance.ChildAppereance);
        Assert.Equal('[', _yourSolution.FirstAppereance.ChildAppereance.SignPair.OpenChar);
        Assert.Equal(']', _yourSolution.FirstAppereance.ChildAppereance.SignPair.CloseChar);
    }

    [Fact]
    public void First_appereance_is_avaiable_and_its_signpair_is_open_close_paranthesis()
    {
        _yourSolution.Validate("(This looks great!)", "()");

        Assert.Equal("()", _yourSolution.FirstAppereance.SignPair.ToString());
    }

    [Fact]
    public void Open_paranthesis_index_is_zero_and_close_paranthesis_index_is_eighteen_using_FirstAppereance()
    {
        _yourSolution.Validate("(This looks great!)", "()");

        Assert.Equal(0, _yourSolution.FirstAppereance.OpenSignIndex);
        Assert.Equal(18, _yourSolution.FirstAppereance.CloseSignIndex);
    }

    [Fact]
    public void Last_appereance_sign_is_bracket()
    {
        _yourSolution.FirstAppereance = new Appereance(new SignPair('(', ')'), 0, 18);
        _yourSolution.FirstAppereance.ChildAppereance = new Appereance(new SignPair('(', ')'), 1, 17);
        _yourSolution.FirstAppereance.ChildAppereance.ChildAppereance = new Appereance(new SignPair('[', ']'), 2, 16);

        Assert.Equal("[]", _yourSolution.FirstAppereance.GetLastAppereance().SignPair.ToString());
    }

    [Fact]
    public void Last_appereance_sign_is_the_first_appereance()
    {
        _yourSolution.FirstAppereance = new Appereance(new SignPair('(', ')'), 0, 18);

         var appereance = _yourSolution.FirstAppereance.GetLastAppereance();

        Assert.Equal(_yourSolution.FirstAppereance, appereance);
    }

}