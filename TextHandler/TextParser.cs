using System;
using System.IO;
using System.Text.RegularExpressions;

namespace TextHandler {
    public static class TextParser {
        public static Text Parse(string path) {
            using (TextReader thread = new StreamReader(path)) {
                var text = new Text();
                var textInString = thread.ReadToEnd();
                int currentLine;
                
                var splitSentences = Regex.Split(textInString, @"(?<=['""A-Za-z0-9][\.\!\?]+)\s+(?=[A-Z])");
            
                foreach (var match1 in splitSentences) {
                    text.Sentences.Add(new Sentence(match1));
                }
                return text;
            }
        }
    }
}