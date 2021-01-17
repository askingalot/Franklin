using System;
using System.Linq;
using System.Reflection;

namespace Franklin.Lib.Exercise
{
    public record ExerciseParameter(string Name, int Position, Type Type);
    public record ExerciseArgument(ExerciseParameter Parameter, object Value);

    public class ExerciseMethod
    {
        private readonly MethodInfo _methodInfo;
        public ExerciseMethod(MethodInfo methodInfo)
        {
            _methodInfo = methodInfo;
        }

        public object Invoke(params ExerciseArgument[] args) {
            var context = Activator.CreateInstance(_methodInfo.DeclaringType);
            var objArgs = args?.Select(a => a.Value).ToArray();
            return _methodInfo.Invoke(context, objArgs);
        }

        public ExerciseParameter[] Parameters =>
            _methodInfo.GetParameters()
                .Select(p => new ExerciseParameter(p.Name, p.Position, p.ParameterType))
                .ToArray();

        public Type ReturnType => _methodInfo.ReturnType;

        public string Name => _methodInfo.Name;
        public string ParameterList =>
            string.Join(", ", _methodInfo.GetParameters()
                .Select(p => $"{TypeName.For(p.ParameterType)} {p.Name}"));
        public string ReturnTypeName => TypeName.For(_methodInfo.ReturnType);

        public override string ToString() =>
            $"{ReturnTypeName} {Name}({ParameterList})";
    }
}