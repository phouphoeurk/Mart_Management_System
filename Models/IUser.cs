using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mart_Management_System.Models
{
    public interface IUser
    {
        User? getById(int id);
        User? findByName(String name);
        List<User> getAll();
        bool save(User user);
        bool update(User user);
        bool delete(int id);

        DataTable search(string keyword);
    }
}
