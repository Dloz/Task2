using System;
using TextHandler.Parser;
using TextHandler.TextModules;

namespace TextHandler {
    internal class Program {
        public static void Main(string[] args) {
            var substring = "";
            var text = TextParser.Parse("../../text.txt");
            Console.WriteLine(text.ToString());
            try {
                Console.WriteLine("Enter substring - ");
                substring = Console.ReadLine();
                Console.WriteLine("Enter word length - ");

                text.ReplaceSubstring(int.Parse(Console.ReadLine() ?? throw new InvalidOperationException()),
                    substring);
                Console.WriteLine(text.ToString());

                Console.WriteLine("Enter word length - ");
                text.DeleteWords(int.Parse(Console.ReadLine() ?? throw new InvalidOperationException()));
                Console.WriteLine(text.ToString());
                Console.WriteLine();
                Console.WriteLine(text.InAscendingOrder());

                Console.WriteLine("Enter word length to print from imperative");
                foreach (var word in text.WordsFromImperativeSentences(int.Parse(Console.ReadLine() ?? throw new InvalidOperationException()))) {
                    Console.WriteLine(word);
                }
                
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}