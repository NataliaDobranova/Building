using Db.Model;
using Repository.Interfaces;
using System;
using System.Configuration;
using static Building.XmlHelper.XmlHelper;

namespace Building
{
    public class Application
    {
        public IUserRepository UserRepository { get; set; }
        public Application(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }

        public void Run()
        {
            var menuFileName =
              ConfigurationManager.AppSettings["MenuFile"];
            var connectionString =
                ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            var newUser = 
                UserRepository.Create(
                    new User { Name = "ToDelete" }
                    );

            UserRepository.Delete(newUser.Id);

            #region ef
            //using (var context
            //    = new BuildingContext(connectionString))
            //{
            //    var adminUsers =
            //        context.Users
            //        .Where(user => user.Name == "Admin");

            //    foreach (var admin in adminUsers)
            //    {
            //        Console.Write(admin.Id);
            //    }

            //    context.Users.Add(new User() { Name = "Vasya" });

            //    context.SaveChanges();
            //}
            #endregion

            #region adonet example
            ////create a connection based on connectionString
            //using (var connection
            //    = new SqlConnection(connectionString))
            //{
            ////open connection
            //    connection.Open();
            ////initialize query string (@name is a parameter)
            //    string query = 
            //        $"SELECT * FROM dbo.Users " +
            //        $"WHERE Name = @name";
            ////initialize a variable to pass as a parameter value
            //    var param = "Vasya";
            ////initialize query as a SqlCommand object
            //    SqlCommand command =
            //        new SqlCommand(query, connection);
            ////map @name to its value
            //    command.Parameters
            //        .Add(new SqlParameter("@name", param));
            ////execute (with expeted output table)
            //    var reader = command.ExecuteReader();
            ////init dictionary to store a result
            //    Dictionary<int, string> users 
            //        = new Dictionary<int, string>();
            ////while is possible to read - read next row
            //    while (reader.Read())
            //    {
            ////get row element named "Id", convert to int
            //        var id = (int)reader["Id"];
            ////get row element named "Name", convert to string
            //        var name = (string)reader["Name"];
            ////add row to result dictionary
            //        users.Add(id, name);
            //    }
            ////view result
            //    foreach (var user in users)
            //    {
            //       Console.Write(user.Key + " " + user.Value);
            //    }
            //}
            #endregion

            #region menuinit
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
