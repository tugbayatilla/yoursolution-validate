namespace yoursolution_validate
{
    internal class YourSolution
    {
        internal static bool Validate(string v1, string v2)
        {
            var sign = new Tuple<char,char>(v2[0],v2[1]);

            int indexOfOpenChar = v1.IndexOf(sign.Item1);
            int indexOfCloseChar = v1.IndexOf(sign.Item2);

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