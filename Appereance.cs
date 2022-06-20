using System.Collections;

namespace yoursolution_validate
{
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
            if (ChildAppereance != null)
            {
                return ChildAppereance.GetLastAppereance();
            }
            return this;
        }

        public IEnumerable<Appereance> GetEach()
        {
            if (ChildAppereance != null)
            {
                foreach (var item in ChildAppereance.GetEach())
                {
                    yield return item;
                }
            }
            yield return this;
        }
    }
}