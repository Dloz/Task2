using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TextHandler.Extensions;

namespace TextHandler.TextModules {
    public class Sentence {
        internal List<Word> Words { get; } = new List<Word>();
        public string[] Type { get; private set; } = new List<string>().ToArray();
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
                    foreach (var item in word.SplitBySeparator('-')) {
                        Words.Add(new Word(item));
                    }
                }
                else if (Regex.IsMatch(word, @"[.?!]+")) {
                    var str = Regex.Matches(word, @"[\.\!\?]+");
                    var punctuation = new List<char>().ToArray();
                    for (var i = word.Length - 1; i >= 0; i--) {
                        if (word[i] == '!' || word[i] == '.' || word[i] == '?') {
                            punctuation = punctuation.Concat(new char[] {word[i]}).ToArray();
                        }
                    }
                    Words.Add(new Word(word.Trim(punctuation)));
                    Words.Add(new Punctuation(punctuation));
                }
                else {
                    Words.Add(new Word(word));
                }
            }
            DetermineType();
            Length = Words.Count;
        }

        private void DetermineType() { 
            if (Regex.IsMatch(Words.Last().ToString(),@"[\.]+")) {
                Type = Type.Concat(new[]{$"Declarative"}).ToArray();
            }
            else if (Regex.IsMatch(Words.Last().ToString(),@"[\?]+")) {
                Type = Type.Concat(new[]{$"Imperative"}).ToArray();
            }
            else if (Regex.IsMatch(Words.Last().ToString(),@"[\!]+")) {
                Type = Type.Concat(new[]{$"Interrogative"}).ToArray();
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