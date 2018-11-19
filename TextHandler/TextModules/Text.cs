using System.Collections.Generic;
using System.Linq;

namespace TextHandler.TextModules {
    
    
    public class Text: IText {
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
                if (!item.Type.Contains("Imperative")) continue;
                foreach (var word in item.Words) {
                    if (word.Length != wordLength || printed.Contains(word.WordInString.ToLower())) continue;
                    printed = printed.Concat(new string[] { word.WordInString.ToLower() }).ToArray();
                }
            }
            return printed;
        }
        
        public void DeleteWords(int wordLength) { 
            foreach (var sentence in Sentences) {
                foreach (var word in sentence.Words.ToList()) {
                    char[] vowels = {'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'};
                    if (word.WordInString != null 
                        && vowels.Contains(word.WordInString[0]) 
                        && word.WordInString.Length == wordLength) {
                            sentence.Words.Remove(word);
                    }
                }
            }
        }

        public void ReplaceSubstring(int wordLength, string substring) { 
            foreach (var sentence in Sentences) {
                foreach (var word in sentence.Words.ToList()) {
                    if (word.WordInString != null && word.WordInString.Length == wordLength) {
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