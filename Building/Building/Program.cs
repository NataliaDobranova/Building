using System;
using System.Configuration;
using Building.Menu;
using static Building.XmlHelper.XmlHelper;

namespace Building
{
    class Program
    {
        private static void Main(string[] args)
        {
            var menuFileName =
                ConfigurationManager.AppSettings["MenuFile"];
            //var mainMenu = new MenuItem("Main Menu");

            //var rabotniki = new MenuItem("Работники");
            //rabotniki.Add(
            //    new MenuItem("Принять"),
            //    new MenuItem("Уволить"),
            //    new MenuItem("Информация")
            //);

            //mainMenu.Add(rabotniki,
            //    new MenuItem("Отчеты")
            //);

            //var menu = new Menu.Menu(mainMenu);

            //Serialize(menu, menuFileName);
            var menu1 = Deserialize<Menu.Menu>(menuFileName);
            menu1.Init();
            menu1.OnExit += Exit;

            while (true)
            {
                Console.Clear();
                Console.Write(menu1);
                var key = WaitForUserInput();
                menu1.ChangeState(key);
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