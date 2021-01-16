using System.Linq;
using System.Reflection;

namespace Franklin.Lib
{
    public class ExerciseMethod
    {
        private readonly MethodInfo _methodInfo;
        public ExerciseMethod(MethodInfo methodInfo)
        {
            _methodInfo = methodInfo;
        }

        public string Name => _methodInfo.Name;
        public string ParameterList =>
            string.Join(", ", _methodInfo.GetParameters()
                .Select(p => $"{TypeName.For(p.ParameterType)} {p.Name}"));
        public string ReturnType => TypeName.For(_methodInfo.ReturnType);

        public override string ToString() =>
            $"{ReturnType} {Name} ({ParameterList})";
    }
}