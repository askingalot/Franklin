using static System.Console;
using Franklin.Lib.Exercise;
using static Franklin.Lib.ArgumentReader;

namespace Franklin.Lib
{
    public static class Executer
    {
        public static void Execute(ExerciseMethod method)
        {
            var args = ReadArguments(method);
            var result = method.Invoke(args);
            WriteLine(result);
        }
    }
}