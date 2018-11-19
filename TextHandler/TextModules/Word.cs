using System.Text.RegularExpressions;

namespace TextHandler.TextModules {
    public class Word  {
        public string WordInString { get; set; }
        public char[] Punctuation { get; private set; } = {' '};
        public int Length { get; }

        protected Word() {
                
        }
        public Word (string item) {
            WordInString = item;
            var charArr = item.ToCharArray();
            DeterminePunctuation();
            Length = charArr.Length;
        }

        private void DeterminePunctuation () {
            Punctuation = Regex.Match(WordInString, @"[\.\!\?]+").ToString().ToCharArray();
        }
        
        public override string ToString() {
            return WordInString + ' ';
        }
    }
}