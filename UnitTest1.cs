namespace yoursolution_validate;

public class UnitTest1
{
    [Fact]
    public void A_String_Between_Parenthesis()
    {
        Assert.True(YourSolution.Validate("(This looks great!)", "()"));
    }
}