namespace Franklin.Lib.ANSI
{
    public static class ANSIForegroundColor
    {
        public static string ResetCode => "\u001b[0m";

        public static string BlackCode => "\u001b[30m";
        public static string RedCode => "\u001b[31m";
        public static string GreenCode => "\u001b[32m";
        public static string YellowCode => "\u001b[33m";
        public static string BlueCode => "\u001b[34m";
        public static string MagentaCode => "\u001b[35m";
        public static string CyanCode => "\u001b[36m";
        public static string WhiteCode => "\u001b[37m";

        public static string Color(string code, string text) => $"{code}{text}{ResetCode}";

        public static string Black(string text) => Color(BlackCode, text);
        public static string Red(string text) => Color(RedCode, text);
        public static string Green(string text) => Color(GreenCode, text);
        public static string Yellow(string text) => Color(YellowCode, text);
        public static string Blue(string text) => Color(BlueCode, text);
        public static string Magenta(string text) => Color(MagentaCode, text);
        public static string Cyan(string text) => Color(CyanCode, text);
        public static string White(string text) => Color(WhiteCode, text);
    }
}