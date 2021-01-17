using System;
using System.Linq;
using System.Reflection;

namespace Franklin.Lib
{
    public record ExerciseParameter(string Name, int Position, Type type);

    public class ExerciseMethod
    {
        private readonly MethodInfo _methodInfo;
        public ExerciseMethod(MethodInfo methodInfo)
        {
            _methodInfo = methodInfo;
        }

        public ExerciseParameter[] Parameters =>
            _methodInfo.GetParameters()
                .Select(p => new ExerciseParameter(p.Name, p.Position, p.ParameterType))
                .ToArray();

        public string Name => _methodInfo.Name;
        public string ParameterList =>
            string.Join(", ", _methodInfo.GetParameters()
                .Select(p => $"{TypeName.For(p.ParameterType)} {p.Name}"));
        public string ReturnType => TypeName.For(_methodInfo.ReturnType);

        public override string ToString() =>
            $"{ReturnType} {Name}({ParameterList})";
    }
}