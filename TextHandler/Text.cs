using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
namespace TextHandler {
    
    
    public class Text {
        private List<Sentence> _sortedList;
        public List<Sentence> Sentences { get; } = new List<Sentence>();        
        
        public Text() {
        }    


        private void SortByNumberOfWords() {
            _sortedList = Sentences.OrderBy(o => o.Length).ToList();
        }

        public string InAscendingOrder() {
            SortByNumberOfWords();
            var str = "";
            foreach (var item in _sortedList) {
                str += item.ToString();
            }

            return str;
        }
        
        public string[] WordsFromImperativeSentences(int wordLength) {
            string[] printed = { };
            
            foreach (var item in Sentences) {
                if (item.Type != "Imperative") continue;
                foreach (var word in item.Words) {
                    if (word.Length != wordLength || printed.Contains(word.WordInString)) continue;
                    printed = printed.Concat(new string[] { word.WordInString }).ToArray();
                }
            }
            return printed;
        }
        
        public void DeleteWords(int wordLength) { 
            foreach (var sentence in Sentences) {
                foreach (var word in sentence.Words) {
                    char[] vowels = {'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'};
                    if (vowels.Contains(word.WordInString[0]) && word.WordInString.Length == wordLength) {
                        sentence.Words.Remove(word);
                    }
                }
            }
        }

        public void ReplaceSubstring(int wordLength, string substring) { 
            foreach (var sentence in Sentences) {
                foreach (var word in sentence.Words.ToList()) {
                    if (word.WordInString.Length == wordLength) {
                        word.WordInString = substring;
                    }
                }
            }
        }

        public override string ToString() {
            var str = "";
            foreach (var sentence in Sentences) {
                str += sentence.ToString();
            }

            return str;
        }
    }
}