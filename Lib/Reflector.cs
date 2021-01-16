using System;
using System.Linq;
using System.Reflection;

namespace Franklin.Lib
{
    public static class Reflector
    {
        private const string EXERCISE_NAMESPACE = "Exercises";

        public static Type[] GetExerciseClasses() =>
            Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.Namespace.EndsWith(EXERCISE_NAMESPACE))
                .ToArray();
        
    }
}