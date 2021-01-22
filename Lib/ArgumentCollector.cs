using System;
using System.Collections.Generic;
using System.Linq;
using Franklin.Lib.Exercise;
using static System.Console;

namespace Franklin.Lib
{
    public static class ArgumentReader
    {
        public static ExerciseArgument[] ReadArguments(ExerciseMethod method) =>
            method.Parameters.Select(Get).ToArray();

        private static ExerciseArgument Get(ExerciseParameter parameter)
        {
            if (!_typeConverter.ContainsKey(parameter.Type))
            {
                throw new FormatException($"Unable to parse type {parameter.Type.Name}");
            }

            while (true)
            {
                Write($" {parameter.Name} = ");
                try
                {
                    var str = ReadLine();
                    var value = _typeConverter[parameter.Type](str);
                    return new ExerciseArgument(parameter, value);
                }
                catch
                {
                    WriteLine($"Invalid argument. Please enter an argument of type {parameter.Type.Name}.");
                }
            }
        }

        private static Dictionary<Type, Func<string, object>> _typeConverter = new()
        {
            { typeof(string), x => RemoveWrappingQuotes(x) },
            { typeof(int), x => int.Parse(x) },
            { typeof(bool), x => bool.Parse(x) },
            { typeof(long), x => long.Parse(x) },
            { typeof(float), x => float.Parse(x) },
            { typeof(double), x => double.Parse(x) },
            { typeof(decimal), x => decimal.Parse(x) },
        };

        private static string RemoveWrappingQuotes(string input)
        {
            if (string.IsNullOrWhiteSpace(input) || input.Length == 1)
            {
                return input;
            }

            if (input.StartsWith("\"") && input.EndsWith("\""))
            {
                return input.Substring(1, input.Length - 2).Trim();
            }

            return input.Trim();
        }
    }
}