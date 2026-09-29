namespace Mart_Management_System.Repositories
{
    public interface IRepository<T>
    {
        List<T> GetAll(string? keyword = null);
        T? GetById(int id);
        bool Create(T entity);
        bool Update(T entity);
        bool SetActive(int id, bool isActive);
    }
}
