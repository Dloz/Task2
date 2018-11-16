using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
namespace TextHandler {
    
    
    public class Text {
        private readonly string _textInString;
        private List<Sentence> _sortedList;
        private List<Sentence> Sentences { get; } = new List<Sentence>();        
        
        public Text(TextReader file) {
            _textInString = file
                .ReadToEnd();
            SplitBySentences();
            SortByNumberOfWords();
            PrintInAscendingOrder();
        }
        private void SplitBySentences() {
            int currentLine;
            var regex1 = new Regex(@"[a-z|A-Z|\s|,|\-|0-9]*[\.|\?|\!]");
            var regex2 = new Regex(@"^\W+");
            var match = regex1.Matches(_textInString);
            
            foreach (Match match1 in match) {
                Sentences.Add(new Sentence(regex2.Replace(match1.Value, string.Empty)));
            }
        }     


        private void SortByNumberOfWords() {
            _sortedList = Sentences.OrderBy(o => o.Length).ToList();
        }

        private void PrintInAscendingOrder() {
            Console.WriteLine();
            Console.WriteLine("#####################################################################################");
            Console.WriteLine("Printing in ascending order...");
            foreach (var item in _sortedList) {
                Console.WriteLine();
                //item.Print();
            }
        }
        
        private string[] WordsFromImperativeSentences(int wordLength) {
            if (Sentences == null) {
                throw new ArgumentNullException(nameof(Sentences));
            }
            
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
        
        private void DeleteWords() { // TODO
            if (Sentences == null) {
                throw new ArgumentNullException(nameof(Sentences));
            }
            Console.WriteLine();
            Console.WriteLine("Deleting vowels words");
            Console.WriteLine("Enter the length: ");
            var wordLength = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            
            foreach (var sentence in Sentences) {
                foreach (var word in sentence.Words) {
                    char[] vowels = {'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'};
                    if (vowels.Contains(word.WordInString[0]) && word.WordInString.Length == wordLength) {
                        sentence.Words.Remove(word);
                    }
                }
            }
        }

        private void ReplaceSubstring() { // TODO
            Console.WriteLine();
            Console.WriteLine("Replace with substring");
            Console.WriteLine("Enter the length of word - ");
            var wordLength = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            Console.WriteLine("Enter substring");
            var substring = Console.ReadLine() ?? throw new ArgumentNullException(nameof(Sentences));
            foreach (var sentence in Sentences) {
                foreach (var word in sentence.Words.ToList()) {
                    if (word.WordInString.Length == wordLength) {
                        word.WordInString = substring;
                    }
                }
            }
        }
    }
}