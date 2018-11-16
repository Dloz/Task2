using System;
using System.Text.RegularExpressions;

namespace TextHandler {
    public class Word  {
        public string WordInString { get; set; }
        public char Punctuation { get; private set; }
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
            var regex = new Regex(@"\W$", RegexOptions.Compiled);
            if (regex.IsMatch(WordInString)) {
                Punctuation = WordInString[WordInString.Length - 1];
            }
        }
        
        public override string ToString() {
            return WordInString + ' ';
        }
    }
}