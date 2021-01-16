using System;
using System.Linq;
using System.Reflection;

namespace Franklin.Lib
{
    public static class Reflector
    {
        private const string EXERCISE_NAMESPACE = "Exercises";

        public static ExerciseClass[] GetExerciseClasses() =>
            Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.IsClass && t.Namespace.EndsWith(EXERCISE_NAMESPACE))
                .Select(t => new ExerciseClass(t))
                .ToArray();
        
    }
}