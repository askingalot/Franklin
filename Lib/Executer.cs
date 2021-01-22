using static System.Console;
using Franklin.Lib.Exercise;
using static Franklin.Lib.ArgumentReader;
using static Franklin.Lib.SyntaxHighlighter;

namespace Franklin.Lib
{
    public static class Executer
    {
        public static void Execute(ExerciseMethod method)
        {
            WriteLine("================================================================================");
            WriteLine($" Arguments for {Highlight(method.ToString())}");
            WriteLine("--------------------------------------------------------------------------------"); 
            var args = ReadArguments(method);
            var result = method.Invoke(args);
            WriteLine("--------------------------------------------------------------------------------"); 
            WriteLine();
            WriteLine($" Result: {result}");
            WriteLine();
            WriteLine("================================================================================");
        }
    }
}