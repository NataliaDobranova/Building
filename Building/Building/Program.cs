using System;
using Building.Menu;

namespace Building
{
    class Program
    {
        private static void Main(string[] args)
        {
            var mainMenu = new MenuItem("Main Menu");

            var rabotniki = new MenuItem("Работники");
            rabotniki.Add(
                new MenuItem("Принять"), 
                new MenuItem("Уволить"),
                new MenuItem("Информация")
            );

            mainMenu.Add(rabotniki, 
                new MenuItem("Отчеты")
            );

            var menu = new Menu.Menu(mainMenu);

            menu.OnExit += Exit;

            while (true)
            {
                Console.Clear();
                Console.Write(menu);
                var key = WaitForUserInput();
                menu.ChangeState(key);
            }
        }

        private static string WaitForUserInput()
        {
            return Console.ReadLine();
        }

        private static void Exit(object sender, EventArgs args)
        {
            Environment.Exit(0);
        }

    }
}