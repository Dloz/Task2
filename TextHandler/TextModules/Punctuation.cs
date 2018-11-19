namespace TextHandler.TextModules {
    public class Punctuation: Word {
        private char[] Punctuations { get; set; } = {' '};

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