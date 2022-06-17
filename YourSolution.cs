namespace yoursolution_validate
{
    internal class YourSolution
    {
        internal static bool Validate(string v1, string v2)
        {
            return v1.Contains(v2[0]) && v1.Contains(v2[1]);
        }
    }
}