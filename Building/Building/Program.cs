using System;
using Building.Menu;

namespace Building
{
    class Program
    {
        private static event EventHandler OnKeyPressed;

        private static void Main(string[] args)
        {
            MenuItem mainMenu = new MenuItem("Main menu");
            var submenu1 = new MenuItem("Submenu1");
            submenu1.Add(new MenuItem("123"), new MenuItem("asd"));
            var submenu2 = new MenuItem("Submenu2");
            submenu2.Add(new MenuItem("dsa"), new MenuItem("gfd"));

            mainMenu.Add(submenu1);
            mainMenu.Add(submenu2);

            Menu.Menu menu = new Menu.Menu(mainMenu);
            OnKeyPressed += menu.ChangeState;
            menu.OnExit += Menu_OnExit;

            while (true)
            {
                Console.Clear();
                Console.Write(menu);
                WaitForUserInput();
            }
        }

        private static void WaitForUserInput()
        {
            var userInput = Console.ReadKey().KeyChar;
            OnKeyPressed?.Invoke(userInput, new EventArgs());
        }

        private static void Menu_OnExit(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}