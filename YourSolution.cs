namespace yoursolution_validate
{
    internal class YourSolution
    {
        internal static bool Validate(string v1, string v2)
        {
            var signs = new List<Tuple<char, char>>();
            var sign = new Tuple<char, char>(v2[0], v2[1]);

            signs.Add(sign);

            foreach (var s in signs)
            {
                int indexOfOpenChar = v1.IndexOf(s.Item1);
                int indexOfCloseChar = v1.IndexOf(s.Item2);

                if (indexOfOpenChar != -1 && indexOfCloseChar != -1)
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }

            return true;

        }
    }
}