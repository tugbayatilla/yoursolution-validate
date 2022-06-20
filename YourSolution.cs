namespace yoursolution_validate
{
    internal class YourSolution
    {
        internal static Action<string>? _logger;

        // TODO: intermediate property. in the future, it can be removed. observe!
        internal static List<Appereance> Appereances = new List<Appereance>();
        internal static Appereance FirstAppereance;

        internal static bool Validate(string v1, string v2)
        {
            var givenSignPairs = ParseSignPairs(v2);

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
                var givenOpenCharSignPair = givenSignPairs.FirstOrDefault(p => p.OpenChar == nextChar);
                if (givenOpenCharSignPair != null)
                {
                    var newAppereance = new Appereance(givenOpenCharSignPair, i, null);
                    if (FirstAppereance == null)
                    {
                        FirstAppereance = newAppereance;
                    }
                    else
                    {
                    var lastAppereance = FirstAppereance.GetLastAppereance();
                    lastAppereance.ChildAppereance = newAppereance;
                    }
                        Appereances.Add(newAppereance);
                }

                // TODO: recursively find the appereance
                var givenCloseCharSignPair = givenSignPairs.FirstOrDefault(p => p.CloseChar == nextChar);
                if (givenCloseCharSignPair != null)
                {
                    var closeCharAppereance = Appereances.FirstOrDefault(p => p.SignPair.CloseChar == nextChar);
                    if (closeCharAppereance == null)
                    {
                        closeCharAppereance = Appereances.Select(p => p.ChildAppereance).FirstOrDefault(p => p.SignPair.CloseChar == nextChar);
                    }
                    closeCharAppereance.CloseSignIndex = i;
                }
            }

            return true;

        }

        private static List<SignPair> ParseSignPairs(string v2)
        {
            var givenSignPairs = new List<SignPair>();
            for (int i = 0; i < v2.Length; i += 2)
            {
                var sign = new SignPair(v2[i], v2[i + 1]);
                _logger?.Invoke($"{sign.OpenChar}{sign.CloseChar}");
                givenSignPairs.Add(sign);
            }

            return givenSignPairs;
        }

        internal class Appereance
        {
            public Appereance()
            {

            }
            public Appereance(SignPair signPair, int? openSignIndex, int? closeSignIndex)
            {
                SignPair = signPair;
                OpenSignIndex = openSignIndex;
                CloseSignIndex = closeSignIndex;
            }

            public SignPair SignPair { get; set; }
            public int? OpenSignIndex { get; set; }
            public int? CloseSignIndex { get; set; }

            public Appereance? ChildAppereance { get; set; }

            public Appereance GetLastAppereance()
            {
                if(ChildAppereance != null)
                {
                    return ChildAppereance.GetLastAppereance();
                }
                return this;
            }

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

            public override string ToString()
            {
                return string.Concat(OpenChar, CloseChar);
            }
        }
    }
}