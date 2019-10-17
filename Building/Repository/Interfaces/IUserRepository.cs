using Db.Model;

namespace Repository.Interfaces
{
    public interface IUserRepository
    {
        User Create(User user);
        User Read(int id);
        User Update(User user);
        bool Delete(int id);
    }
}
