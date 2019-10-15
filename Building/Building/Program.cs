using Db;
using System;
using System.Configuration;
using System.Linq;
using static Building.XmlHelper.XmlHelper;

namespace Building
{
    class Program
    {
        private static void Main(string[] args)
        {
            var menuFileName =
                ConfigurationManager.AppSettings["MenuFile"];
            var connectionString =
                ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (var context
                = new BuildingContext(connectionString))
            {
                var adminUsers =
                    context.Users
                    .Where(user => user.Name == "Admin");

                foreach (var admin in adminUsers)
                {
                    Console.Write(admin.Id);
                }

                context.Users.Add(new Db.Model.User() { Name = "Vasya" });
                
                context.SaveChanges();
            }

            //using (var connection
            //    = new SqlConnection(connectionString))
            //{
            //    connection.Open();
            //    var param = "Vasya";
            //    string query = 
            //        $"SELECT * FROM dbo.Users " +
            //        $"WHERE Name = @name";
            //    SqlCommand command =
            //        new SqlCommand(query, connection);
            //    command.Parameters
            //        .Add(new SqlParameter("@name", param));
            //    var reader = command.ExecuteReader();
            //    Dictionary<int, string> users 
            //        = new Dictionary<int, string>();
            //    while (reader.Read())
            //    {
            //        var id = (int)reader["Id"];
            //        var name = (string)reader["Name"];
            //        users.Add(id, name);
            //    }
            //    foreach (var user in users)
            //    {
            //       Console.Write(user.Key + " " + user.Value);
            //    }
            //}

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