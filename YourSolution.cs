namespace yoursolution_validate
{
    internal class YourSolution
    {
        internal static Action<string>? _logger;

        // TODO: intermediate property. in the future, it can be removed. observe!
        internal static List<Appereance> UsedSignPairs = new List<Appereance>();

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

            for (int i = 0; i < v1.Length; i++)
            {
                char nextChar = v1[i];
                var usedOpenSignPair = givenSignPairs.FirstOrDefault(p => p.OpenChar == nextChar);
                if (usedOpenSignPair != null)
                {
                    UsedSignPairs.Add(new Appereance(usedOpenSignPair, i, null));
                }

                var usedClosedSignPair = givenSignPairs.FirstOrDefault(p => p.CloseChar == nextChar);
                if (usedClosedSignPair != null)
                {
                    var findUsedSignPair = UsedSignPairs.First(p => p.SignPair.CloseChar == nextChar);
                    findUsedSignPair.CloseSignIndex = i;
                }
            }

            return true;

        }

        internal class Appereance
        {
            public Appereance(SignPair signPair, int? openSignIndex, int? closeSignIndex)
            {
                SignPair = signPair;
                OpenSignIndex = openSignIndex;
                CloseSignIndex = closeSignIndex;
            }

            public SignPair SignPair { get; set; }
            public int? OpenSignIndex { get; set; }
            public int? CloseSignIndex { get; set; }
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