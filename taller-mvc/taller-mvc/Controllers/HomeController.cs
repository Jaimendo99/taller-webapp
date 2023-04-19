using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using taller_mvc.Models;
using taller_mvc.Services;

namespace taller_mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServiceApi _apiService;

        public HomeController(IServiceApi apiService)
        {
            _apiService = apiService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Clients()
        {
            return View( await GetClients());
        }

        public async Task<IActionResult> Products()
        {
            return View(await GetProducts());
        }

        public async Task<List<Client>> GetClients(string name = "", string idNum="", string email="", string phone="")
        {
            List<Client> clientList = await _apiService.GetClientList(name, idNum, email, phone);
            return clientList;
        }

        public async Task<List<Product>> GetProducts(string name="", string description="", float? price=null, int? quantity= null)
        {
            List<Product> productList = await _apiService.GetProducList(name, description, price, quantity);
            return productList;
        }

        public async Task<IActionResult> CreateClient(Client client)
        {
            bool result = await _apiService.Create(client);
            return View(result);
        }

        public async Task<IActionResult> CreateProduct(Product product)
        {
            bool result = await _apiService.Create(product);
            return View(result);
        }

        public async Task<IActionResult> UpdateClient(Client client)
        {
            bool result = await _apiService.Update(client);
            return View(result);
        }

        public async Task<IActionResult> UpdateProduct(Product product)
        {
            bool result = await _apiService.Update(product);
            return View(result);
        }

        public async Task<IActionResult> DeleteClient(int id)
        {
            bool result = await _apiService.Delete("Client", id);
            return View(result);
        }

        public async Task<IActionResult> DeleteProduct(int id)
        {
            bool result = await _apiService.Delete("Product", id);
            return View(result);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}