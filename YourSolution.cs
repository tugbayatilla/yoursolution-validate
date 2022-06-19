namespace yoursolution_validate
{
    internal class YourSolution
    {
        internal static Action<string>? _logger;

        internal static bool Validate(string v1, string v2)
        {
            var givenSignPairs = new List<SignPair>();
            for (int i = 0; i < v2.Length; i += 2)
            {
                var sign = new SignPair(v2[i], v2[i + 1]);
                _logger?.Invoke($"{sign.OpenChar}{sign.CloseChar}");
                givenSignPairs.Add(sign);
            }

            foreach (var signPair in givenSignPairs)
            {
                int indexOfOpenChar = v1.IndexOf(signPair.OpenChar);
                int indexOfCloseChar = v1.IndexOf(signPair.CloseChar);

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

        internal class SignPair
        {
            public SignPair(char openChar, char closeChar)
            {
                this.OpenChar = openChar;
                this.CloseChar = closeChar;
            }
            public char OpenChar { get; set; }
            public char CloseChar { get; set; }
        }
    }
}