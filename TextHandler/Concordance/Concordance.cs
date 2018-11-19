using System;
using System.Collections.Generic;
using System.IO;

namespace TextHandler.Concordance {
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

        private bool Add(string key, int numOfString) {
            var c = new ConcordanceWord();
            if (!_words.ContainsKey(key)) {
                _words.Add(key, new ConcordanceWord()); 
                return true;
            }
            else {
                _words[key].IncrCount();
                _words[key].Add(numOfString); 
                return false;
            }
        }


        public Concordance(StreamReader reader) {
            var c = new ConcordanceWord();
            var wordOfText = "";
            var numOfString = 0;
            while ((!reader.EndOfStream)) {
                var ch = Convert.ToChar(reader.Read());
                wordOfText = wordOfText + ch;
                if ((ch == '.') || (ch == '!') || (ch == '?')) numOfString++;
                if (
                    ((((char.IsPunctuation(ch)) || (ch == ' ')) && (ch != '#')) && (ch != '-'))
                    && (wordOfText != " ") 
                    && (wordOfText != "\n"))
                {
                    wordOfText = wordOfText.Substring(0, wordOfText.Length - 1);
                    wordOfText = wordOfText.ToLower();
                    if (Add(wordOfText,numOfString)) { _words[wordOfText].Intialization(); _words[wordOfText].Add(numOfString);}
                    wordOfText = "";
                }
                if ((wordOfText == " ") || (ch == '\n')) wordOfText = "";
            }
        }

    }
}