using System;
using System.Linq;
using static System.Reflection.BindingFlags;

namespace Franklin.Lib
{
    public class ExerciseClass
    {
        private readonly Type _exerciseType;
        public ExerciseClass(Type exerciseType)
        {
            _exerciseType = exerciseType;
        }

        public string Name => _exerciseType.Name;

        public ExerciseMethod[] Methods => 
            _exerciseType.GetMethods(DeclaredOnly | Public | Instance)
                .Select(m => new ExerciseMethod(m))
                .ToArray();
    }
}