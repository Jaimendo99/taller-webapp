using taller_mvc.Models;

namespace taller_mvc.Services
{
    public interface IServiceApi
    {
        Task<List<Client>> GetClientList(string name = "", string idNum = "", string email = "", string phone = "" );
        Task<List<Product>> GetProducList(string name = "", string description = "", float? price = null, int? quantity = null);

        Task<bool> Create(Object obj);
        Task<bool> Update(Object obj);
        Task<bool> Delete(string className, int id);

    }
}
