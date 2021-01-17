using System;
using static System.Console;
using System.Collections.Generic;

namespace Franklin.Lib
{
    public record MenuItem(string Text, Action Action);

    public class Menu
    {
        private const string EXIT = "0";

        private readonly List<MenuItem> _items;
        private readonly string _title;

        public Menu(string title, List<MenuItem> items)
        {
            _title = title;
            _items = items;
        }

        public void Run()
        {
            string selection;
            while (true)
            {
                selection = PrintMenu();
                if (selection == EXIT)
                {
                    return;
                }

                if (int.TryParse(selection, out var index)
                    && 0 < index && index <= _items.Count)
                {
                    _items[index - 1].Action();
                }
                else
                {
                    WriteLine("Invalid Selection");
                }
            }
        }

        private string PrintMenu()
        {
            Clear();
            WriteLine();
            WriteLine(_title);
            for (var i = 1; i <= _items.Count; i++)
            {
                WriteLine($" {i}) {_items[i - 1].Text}");
            }
            WriteLine(" 0) Exit");
            WriteLine();
            Write("> ");

            var result = ReadLine();

            WriteLine();

            return result;
        }
    }
}