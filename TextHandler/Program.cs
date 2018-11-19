using System;
using TextHandler.Parser;
using TextHandler.TextModules;

namespace TextHandler {
    internal class Program {
        public static void Main(string[] args) {
            var text = TextParser.Parse("../../text.txt");

            Console.WriteLine(text.ToString());
        }
    }
}