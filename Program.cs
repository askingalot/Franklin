using System.Linq;
using static System.Console;
using static Franklin.Lib.SyntaxHighlighter;
using static Franklin.Lib.Executer;

using Franklin.Lib;
using Franklin.Lib.Exercise;

namespace Franklin
{
    class Program
    {
        static void Main(string[] args)
        {
            var exercises = Reflector.GetExerciseClasses();

            var exerciseMenu =
                new Menu("Select an Exercise",
                          exercises.Select(e =>
                              new MenuItem(
                                  e.Name,
                                  () => MenuForExercise(e).Run()))
                              .ToList());

            exerciseMenu.Run();
        }

        static Menu MenuForExercise(ExerciseClass ec) =>
            new Menu(ec.Name,
                     ec.Methods.Select(m =>
                        new MenuItem(
                            Highlight(m.ToString()),
                            () => {
                                Execute(m);
                                ReadKey();
                            }))
                        .ToList());

    }
}
