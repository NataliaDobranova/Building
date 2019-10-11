using System;
using System.Configuration;
using static Building.XmlHelper.XmlHelper;

namespace Building
{
    class Program
    {
        private static void Main(string[] args)
        {
            //find a file path in app.config
            var menuFileName = ConfigurationManager.AppSettings["MenuFile"];

            #region old
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
            #endregion

            //read menu from file
            var menu1 = Deserialize<Menu.Menu>(menuFileName);
            //explicitly initialize parent items to make Back/Exit works
            menu1.Init();
            //init OnExit event handler
            menu1.OnExit += Exit;

            //application lifecycle
            while (true)
            {
                Console.Clear();
                Console.Write(menu1);
                var key = WaitForUserInput();
                menu1.ChangeState(key);
            }
        }

        /// <summary>
        /// Waits until user pushes enter key
        /// </summary>
        /// <returns>Input string</returns>
        private static string WaitForUserInput()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// OnExit event handler
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="args">Additional arguments</param>
        private static void Exit(object sender, EventArgs args)
        {
            Environment.Exit(0);
        }

    }
}