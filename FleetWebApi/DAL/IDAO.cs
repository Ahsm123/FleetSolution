
namespace FleetWebApi.DAL;

public interface IDAO<T>
{
    T? Get(int Id);
    IEnumerable<T> GetAll();

    IEnumerable<T> GetAllNotRented();
    IEnumerable<T> GetAllRented();
    int Insert(T t);
    bool Update(T t);
    bool Delete(int t);

    
}
