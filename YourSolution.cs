namespace yoursolution_validate
{
    internal class YourSolution
    {
        internal static Action<string>? _logger;
        
        internal static bool Validate(string v1, string v2)
        {
            var signs = new List<Tuple<char, char>>();
            for (int i = 0; i < v2.Length; i+=2)
            {
                var sign = new Tuple<char, char>(v2[i], v2[i+1]);
                _logger?.Invoke($"{sign.Item1}{sign.Item2}");        
                signs.Add(sign);
            }
            
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