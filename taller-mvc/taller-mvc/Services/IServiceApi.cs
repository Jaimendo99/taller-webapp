using taller_mvc.Models;

namespace taller_mvc.Services
{
    public interface IServiceApi
    {
        Task<List<Client>> GetClientList();
        Task<List<Product>> GetProducList();

        Task<ClientDetails> GetClientDetails(int id);
        Task<ProductDetails> GetProductDetails(int id);


		Task<bool> Create(Object obj);
        Task<bool> Update(Object obj);
        Task<bool> Delete(string className, int id);

    }
}
