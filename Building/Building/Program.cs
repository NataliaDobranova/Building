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