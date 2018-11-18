using System;
using System.Collections.Generic;
using System.IO;

namespace TextHandler {
 public class Concordance {
     private readonly SortedDictionary<string, ConcordanceWord> _words = new SortedDictionary<string, ConcordanceWord>();

        public void Input() {
            var file = new StreamWriter("../../Concordance.txt");
            var s = "";
            foreach (var i in _words) {
                try {
                    if (s != i.Key.Substring(0, 1)) {
                        if (s != "") {
                            file.WriteLine();
                            file.WriteLine();
                        }
                        file.Write(char.ToUpper(Convert.ToChar(i.Key.Substring(0, 1))));
                        file.WriteLine();
                        file.WriteLine();
                    }
                    file.Write("{0}............", i.Key);
                    i.Value.Output(file);
                    file.WriteLine();
                    s = i.Key.Substring(0, 1);
                }
                catch {
                    // ignored
                }
            }
            file.Close();
    }

        private bool Add(string key, int numofstr) {
            var c = new ConcordanceWord();
            if (!_words.ContainsKey(key)) {
                _words.Add(key, new ConcordanceWord()); 
                return true;
            }
            else {
                _words[key].IncrCount();
                _words[key].Add(numofstr); 
                return false;
            }
        }


        public Concordance(StreamReader reader) {
            var c = new ConcordanceWord();
            var wordoftext = "";
            var numofstring = 0;
            while ((!reader.EndOfStream)) {
                var ch = Convert.ToChar(reader.Read());
                wordoftext = wordoftext + ch;
                if ((ch == '.') || (ch == '!') || (ch == '?')) numofstring++;
                if (
                    ((((char.IsPunctuation(ch)) || (ch == ' ')) && (ch != '#')) && (ch != '-'))
                    && (wordoftext != " ") 
                    && (wordoftext != "\n"))
                {
                    wordoftext = wordoftext.Substring(0, wordoftext.Length - 1);
                    wordoftext = wordoftext.ToLower();
                    if (Add(wordoftext,numofstring)) { _words[wordoftext].Intialization(); _words[wordoftext].Add(numofstring);}
                    wordoftext = "";
                }
                if ((wordoftext == " ") || (ch == '\n')) wordoftext = "";
            }
        }

    }

    public class ConcordanceWord : Word {
        private int Count { get; set; }
        readonly List<int> _pageNumbers = new List<int>();

        public void Add(int val) {
            if (!_pageNumbers.Contains(val)) _pageNumbers.Add(val);
        }

        public void IncrCount() {
            Count = Count + 1;
        }

        public void Intialization() {
            Count = 1;
        }

        public void Output(StreamWriter file) {
            file.Write("{0}: ", Count);
            foreach (var i in _pageNumbers) {
                file.Write("{0} ", i);
            }
        }
    }
}