using System;

namespace TextHandler {
    internal class Program {
        public static void Main(string[] args) {
            var text = new Text();
            text = TextParser.Parse("../../text.txt");

            Console.WriteLine(text.ToString());
        }
    }
}