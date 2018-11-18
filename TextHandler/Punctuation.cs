using System.Collections.Generic;
using System.Linq;

namespace TextHandler {
    public class Punctuation: Word {
        public char[] Punctuations { get; set; } = {' '};

        public Punctuation(char[] punctuations) {
            Punctuations = punctuations;
        }

        public Punctuation(char punctuation) {
            Punctuations[0] = punctuation;
        }
        public override string ToString() {
            return new string(Punctuations);
        }
    }
}