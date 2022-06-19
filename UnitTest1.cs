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
}