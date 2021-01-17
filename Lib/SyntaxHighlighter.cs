using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using static Franklin.Lib.ANSI.ANSIForegroundColor;

namespace Franklin.Lib
{
    // This only recognizes method signatures
    //  Note: It will probably work for a few other things too, but that's untested
    public static class SyntaxHighlighter
    {
        public static string Highlight(string input) =>
            string.Join("",
                Tokenize(input)
                    .Select(token => 
                        _typeColorMap[token.type](token.lexeme)));

        private static (TokenType type, string lexeme)[] Tokenize(string code) =>
            Regex.Split(code, @"\b")
                .Where(lexeme => lexeme != string.Empty)
                .Select(lexeme =>
                    lexeme switch
                    {
                        _ when IsKeyword(lexeme) =>
                            (TokenType.Keyword, lexeme),
                        _ when IsBuiltInType(lexeme) =>
                            (TokenType.BuiltInType, lexeme),
                        _ when IsSymbol(lexeme) =>
                            (TokenType.Symbol, lexeme),
                        _ when IsClassOrMethodOrProperty(lexeme) =>
                            (TokenType.ClassOrMethodOrProperty, lexeme),
                        _ when IsWhitespace(lexeme) =>
                            (TokenType.Whitespace, lexeme),
                        _ => (TokenType.Other, lexeme),
                    })
                .ToArray();

        private static bool IsKeyword(string lexeme) => _keywords.Contains(lexeme);
        private static bool IsBuiltInType(string lexeme) => _builtInTypes.Contains(lexeme);
        private static bool IsSymbol(string lexeme) => _symbols.Contains(lexeme);
        private static bool IsClassOrMethodOrProperty(string lexeme) => char.IsUpper(lexeme[0]);
        private static bool IsWhitespace(string lexeme) => lexeme.Trim() == string.Empty;

        private static string[] _keywords =
            { "public", "private", "new", "if", "else", "while" };
        public static string[] _builtInTypes =
            { "int", "long", "float", "double", "bool", "string" };
        public static string[] _symbols =
            { "(", ")", "()", "{", "}", "{}", "[", "]", "[]",
              ";", ",", "+", "-", "*", "/", "=", "++", "--",
              "!", "==", "!=", "<", ">", "<=", ">=" };

        private enum TokenType { Keyword, BuiltInType, Symbol, ClassOrMethodOrProperty, Other, Whitespace }

        private static Dictionary<TokenType, Func<string, string>> _typeColorMap = new()
        {
            { TokenType.Keyword, Magenta },
            { TokenType.BuiltInType, Green },
            { TokenType.Symbol, Yellow },
            { TokenType.ClassOrMethodOrProperty, Cyan },
            { TokenType.Other, x => x },
            { TokenType.Whitespace, x => x },
        };
    }
}