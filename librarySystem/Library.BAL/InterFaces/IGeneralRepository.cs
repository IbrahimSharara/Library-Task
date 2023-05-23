

namespace Library.BLL.InterFaces
{
    public interface IGeneralRepository<T> where T : class
    {
        Task<T> GetByID(int id);
        List<T> GetAll();
        Task<int> Delete(int id);
        Task<int> Add(T entity);
        Task<int> Update(int id, T entity);
    }
}
