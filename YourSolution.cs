namespace yoursolution_validate
{
    internal class YourSolution
    {
        // TODO: intermediate property. in the future, it can be removed. observe!
        internal List<Appereance> Appereances = new List<Appereance>();
        internal Appereance FirstAppereance;

        internal bool Validate(string v1, string v2)
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
                    var closeCharAppereance = FirstAppereance.GetEach().First(p => p.SignPair.CloseChar == nextChar);
                    closeCharAppereance.CloseSignIndex = i;

                    if(closeCharAppereance.GetEach().Any(p=>p.OpenSignIndex < i && !p.CloseSignIndex.HasValue)){
                        return false;
                    }
                }
            }

            return true;

        }

        private List<SignPair> ParseSignPairs(string v2)
        {
            var givenSignPairs = new List<SignPair>();
            for (int i = 0; i < v2.Length; i += 2)
            {
                var sign = new SignPair(v2[i], v2[i + 1]);
                givenSignPairs.Add(sign);
            }

            return givenSignPairs;
        }
    }
}