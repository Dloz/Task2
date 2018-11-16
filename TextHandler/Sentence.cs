using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TextHandler {
    internal class Sentence {
        internal List<Word> Words { get; } = new List<Word>();
        public string Type { get; private set; }
        public int Length { get; }

        public Sentence(string sentence) {
            sentence = Regex.Replace(sentence, "[ ]+", " ");
            sentence = sentence.Replace("\t", " "); // Spaces has been deleted
            
            var wordsArr = Regex.Split(sentence, @"[^\p{L}]*\p{Z}[^\p{L}]*");
            foreach (var item in wordsArr) {
                Words.Add(new Word(item));
            }
            DetermineType();
            Length = Words.Count;
        }

        private void DetermineType() {
            if (Words.Last().Punctuation == '.') {
                Type = $"Declarative";

            }
            else { // ?! !? symbols
                Type = Words.Last().Punctuation == '?' ? "Imperative" : "Interrogative";
            }
        }
    }
}