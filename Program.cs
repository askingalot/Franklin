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

            var exerciseMenuItems =
                exercises.Select(e =>
                    new MenuItem(
                        e.Name,
                        () => WriteLine($"You selected {e.Name}")
                    ))
                    .ToList();
            var exerciseMenu = new Menu("Select an Exercise", exerciseMenuItems);
            exerciseMenu.Run();
       }
    }
}
