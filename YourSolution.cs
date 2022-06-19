namespace yoursolution_validate
{
    internal class YourSolution
    {
        internal static Action<string>? _logger;

        internal static bool Validate(string v1, string v2)
        {
            var signs = new List<Sign>();
            for (int i = 0; i < v2.Length; i += 2)
            {
                var sign = new Sign(v2[i], v2[i + 1]);
                _logger?.Invoke($"{sign.OpenChar}{sign.CloseChar}");
                signs.Add(sign);
            }

            foreach (var s in signs)
            {
                int indexOfOpenChar = v1.IndexOf(s.OpenChar);
                int indexOfCloseChar = v1.IndexOf(s.CloseChar);

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

        class Sign
        {
            public Sign(char openChar, char closeChar)
            {
                this.OpenChar = openChar;
                this.CloseChar = closeChar;
            }
            public char OpenChar { get; set; }
            public char CloseChar { get; set; }
        }
    }
}