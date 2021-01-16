using System;
using static System.Console;
using Franklin.Lib;

namespace Franklin
{
    class Program
    {
        static void Main(string[] args)
        {
            var exercises = Reflector.GetExerciseClasses();

            foreach (var e in exercises)
            {
                WriteLine(e.Name);
            }
        }
    }
}
