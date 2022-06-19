namespace yoursolution_validate
{
    internal class YourSolution
    {
        internal static bool Validate(string v1, string v2)
        {
            char openChar = v2[0];
            char closeChar = v2[1];
            return v1.Contains(openChar) && v1.Contains(closeChar);
        }
    }
}