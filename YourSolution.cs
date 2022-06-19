namespace yoursolution_validate
{
    internal class YourSolution
    {
        internal static bool Validate(string v1, string v2)
        {
            char openChar = v2[0];
            char closeChar = v2[1];

            int indexOfOpenChar = v1.IndexOf(openChar);
            int indexOfCloseChar = v1.IndexOf(closeChar);

            if (indexOfOpenChar != -1 && indexOfCloseChar != -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}