using Newtonsoft.Json;
using NuGet.Protocol;
using System;
using System.Net.Http.Headers;
using System.Numerics;
using System.Text;
using taller_mvc.Models;

namespace taller_mvc.Services
{
    public class ApiService: IServiceApi
    {
        private static string _baseUrl = "http://localhost:5018/";


        public ApiService()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
          //_baseUrl = builder.GetSection("ApiSettings/baseUrl").Value;
        }


        public async Task<List<Client>> GetClientList(string name = "", string idNum = "", string email = "", string phone = ""){
            List<Client> clients = new List<Client>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5018/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                
                var response = await client.GetAsync("api/v1/Client");
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
  
                       //convert response into json and than into a list of clients
                       clients = JsonConvert.DeserializeObject<List<Client>>(jsonResponse);                       
                }
                return clients;

            }
        }

        public async Task<List<Product>> GetProducList(string? name = "", string? description = "", float? price = null, int? quantity = null)
        {
            List<Product> products = new List<Product>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5018/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync("api/v1/Product");
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    products = JsonConvert.DeserializeObject<List<Product>>(jsonResponse);
                }
                return products;

            }
        }

        public async Task<bool> Create(object obj)
        {
            bool response = false;
            string className = obj.GetType().Name;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var json = JsonConvert.SerializeObject(obj);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var result = await client.PostAsync($"api/v1/{className}", data);
                if (result.IsSuccessStatusCode)
                {
                    response = true;
                }
                return response;
            }

        }

        public async  Task<bool> Update(object obj)
        { 
            bool response = false;
            string className = obj.GetType().Name;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var json = JsonConvert.SerializeObject(obj);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var result = await client.PutAsync($"api/v1/{className}", data);
                if (result.IsSuccessStatusCode)
                {
                    response = true;
                }
                return response;
            }
        }


        public async Task<bool> Delete(string className, int id)
        {
            bool response = false;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string endPoint = $"api/v1/{className}?idNum={id}";
                var result = await client.DeleteAsync(endPoint);
                if (result.IsSuccessStatusCode)
                {
                    response = true;
                }
                return response;
            }
        }
    }

  



}
