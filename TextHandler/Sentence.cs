using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TextHandler {
    public class Sentence {
        internal List<Word> Words { get; } = new List<Word>();
        public string Type { get; private set; }
        public int Length { get; }

        public Sentence(string sentence) {
            sentence = Regex.Replace(sentence, "[ ]+", " ");
            sentence = sentence.Replace("\t", " "); // Spaces has been deleted
            
            var wordsArr = Regex.Split(sentence, @" ");
            foreach (var word in wordsArr) {
                if (word[word.Length - 1] == ',' || word[word.Length - 1] == ';' || word[word.Length - 1] == ':') {
                    Words.Add(new Word(word.Trim(word[word.Length - 1])));
                    Words.Add(new Punctuation(word[word.Length - 1]));
                }
                else if (word.Contains('-')) {
                    foreach (var item in word.SplitBySeparatorInTheMiddle('-')) {
                        Words.Add(new Word(item));
                    }
                }
                else {
                    Words.Add(new Word(word));
                }
            }
            DetermineType();
            Length = Words.Count;
        }

        private void DetermineType() { // TODO
            if (Words.Last().Punctuation[0] == '.') {
                Type = $"Declarative";
            }
            else {
                Type = Words.Last().Punctuation[0] == '?' ? "Imperative" : "Interrogative";
           }
        }

        public override string ToString() {
            var str = "";
            foreach (var word in Words) {
                str += word.ToString();
            }

            return str;
        }
    }
}