using Db;
using Db.Model;
using Repository.Interfaces;
using System.Configuration;

namespace Repository.Repositories
{
    public class UserRepository : IUserRepository
    {
        public string ConnectionString
            => ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public User Create(User user)
        {
            using (var context
              = new BuildingContext(ConnectionString))
            {
                var result = context.Users.Add(user);
                context.SaveChanges();
                return result;
            }
        }

        public bool Delete(int id)
        {
            using (var context
               = new BuildingContext(ConnectionString))
            {
                var user = context.Users.Find(id);
                user.IsDeleted = true;
                context.SaveChanges();
                return user.IsDeleted;
            }
        }

        public User Read(int id)
        {
            //using (var context
            //  = new BuildingContext(ConnectionString))
            //{
            //    var result = context.Users.Find(id);
            //    return result;
            //}
            return null;
        }

        public User Update(User user)
        {
            //using (var context
            //  = new BuildingContext(ConnectionString))
            //{
            //    var userToUpdate = context.Users.Find(user.Id);
            //    userToUpdate = user;
            //    context.SaveChanges();
            //    return userToUpdate;
            //}
            return null;
        }
    }
}
