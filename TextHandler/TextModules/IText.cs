namespace TextHandler.TextModules {
    public interface IText {
        string InAscendingOrder();
        string[] WordsFromImperativeSentences(int wordLength);
        void DeleteWords(int wordLength);
        void ReplaceSubstring(int wordLength, string substring);
    }
}