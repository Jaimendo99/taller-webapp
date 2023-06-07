using Microsoft.AspNetCore.Mvc;
using taller_mvc.Models;
using taller_mvc.Services;

namespace taller_mvc.Controllers
{
    public class ClientController : Controller
    {
        private readonly IServiceApi _apiService;

        public ClientController(IServiceApi apiService)
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


        public async Task<List<Client>> GetClients()
        {
            List<Client> clientList = await _apiService.GetClientList();
            return clientList;
        }


    }
}
