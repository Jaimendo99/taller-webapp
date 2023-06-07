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
            return View(await GetClients());
        }

        public async Task<IActionResult> Products()
        {
            return View(await GetProducts());
        }

        public async Task<List<Client>> GetClients()
        {
            List<Client> clientList = await _apiService.GetClientList();
            return clientList;
        }

        public async Task<IActionResult> ClientDetails(int id)
        {
            return View(await GetClientDetails(id));
        }

        public async Task<Tuple<ClientDetails, List<ProductDetails>>> GetClientDetails(int id)
        {
            ClientDetails clientD =await  _apiService.GetClientDetails(id);
            List<ProductDetails> products = new();
            foreach (var item in clientD.shoppingLists)
            {
                products.Add(await _apiService.GetProductDetails(item.ProductId));
            }
            
            return Tuple.Create(clientD,products);
        }

        public async Task<List<Product>> GetProducts()
        {
            List<Product> productList = await _apiService.GetProducList();
            return productList;
        }

        public async Task<IActionResult> ProductDetails(int id)
        {
			return View(await GetProductDetails(id));
		}

        public async Task<Tuple<ProductDetails, List<ClientDetails>>> GetProductDetails(int id)
        {
            ProductDetails productD = await _apiService.GetProductDetails(id);
			List<ClientDetails> clients = new();
			foreach (var item in productD.shoppingLists)
            {
				clients.Add(await _apiService.GetClientDetails(item.ClientId));
			}
			return Tuple.Create(productD, clients);
        }


		public async Task<IActionResult> CreateClient(Client client)
        {
            bool result = await _apiService.Create(client);
            if (result)
            {
                return RedirectToAction("Clients");
            }
            return BadRequest();
        }

        public async Task<IActionResult> CreateProduct(Product product)
        {
            bool result = await _apiService.Create(product);
            if (result)
            {
                return RedirectToAction("Products");
            }
            return BadRequest();
        }
        
        public async Task<IActionResult> UpdateClient(Client client)
        {
            bool result = await _apiService.Update(client);
            if (result)
            {
                return RedirectToAction("Clients");
            }
            return BadRequest();
        }

        public async Task<IActionResult> UpdateProduct(Product product)
        {
            bool result = await _apiService.Update(product);
            if (result)
            {
                return RedirectToAction("Products");
            }
            return BadRequest();
        }

  
        public async Task<IActionResult> DeleteClient(int id)
        {
            bool result = await _apiService.Delete("Client", id);
            if (result)
            {
                return RedirectToAction("Clients");
            }
            return BadRequest();
        }

        public async Task<IActionResult> DeleteProduct(int id)
        {
            bool result = await _apiService.Delete("Product", id);
            if (result)
            {
                return RedirectToAction("Products");
            }
            return BadRequest();
        }


        


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

