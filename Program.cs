using System;
using static System.Console;
using Franklin.Lib;
using System.Linq;

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
                            m.ToString(),
                            () => WriteLine($"You selected {m.Name}")))
                        .ToList());

    }
}
