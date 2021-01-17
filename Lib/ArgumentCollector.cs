using System;
using static System.Console;

namespace Franklin.Lib
{
    public record ExerciseArgument(ExerciseParameter Parameter, object Value);

    public static class ArgumentReader
    {
        public static ExerciseArgument[] GetAll(ExerciseMethod method)
        {

        }

        private static object Get(ExerciseParameter parameter)
        {
            while (true)
            {
                Write($" {parameter.Name} = ");
                var value = ReadLine();


            }
        }
    }
}