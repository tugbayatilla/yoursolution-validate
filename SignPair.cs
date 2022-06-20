namespace yoursolution_validate
{
    internal partial class YourSolution
    {
        internal class SignPair
        {
            public SignPair(char openChar, char closeChar)
            {
                this.OpenChar = openChar;
                this.CloseChar = closeChar;
            }
            public char OpenChar { get; set; }
            public char CloseChar { get; set; }

            public override string ToString()
            {
                return string.Concat(OpenChar, CloseChar);
            }
        }
    }
}