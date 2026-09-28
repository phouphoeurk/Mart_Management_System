using System.Data;

namespace Mart_Management_System.Models
{
    public interface IUser
    {
        User? FindByUsername(string username);

        User? GetById(int userId);

        List<User> GetAll();

        DataTable Search(string keyword);

        bool Create(User user);

        bool Update(User user, string? passwordHash = null);

        bool SetActive(int userId, bool isActive);
    }
}
