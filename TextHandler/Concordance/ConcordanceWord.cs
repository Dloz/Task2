using System.Collections.Generic;
using System.IO;
using TextHandler.TextModules;

namespace TextHandler.Concordance {
    public class ConcordanceWord : Word {
        private int Count { get; set; }
        readonly List<int> _pageNumbers = new List<int>();

        public void Add(int val) {
            if (!_pageNumbers.Contains(val)) _pageNumbers.Add(val);
        }

        public void IncrCount() {
            Count = Count + 1;
        }

        public void Intialization() {
            Count = 1;
        }

        public void Output(StreamWriter file) {
            file.Write("{0}: ", Count);
            foreach (var i in _pageNumbers) {
                file.Write("{0} ", i);
            }
        }
    }
}