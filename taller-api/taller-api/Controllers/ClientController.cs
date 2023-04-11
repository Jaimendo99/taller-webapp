using DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Permissions;

namespace taller_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private ShopContext _context;

        public ClientController(ShopContext context)
        {
            _context = context;
        }
/*
        [HttpGet("{name?}/{idNum?}/{email?}/{phone?}")]
        public IActionResult Get(string name = "", string idNum = "", string email = "", string phone = "")
        {
            var clients = _context.Clients.ToList();
            if (name != "")
                clients = clients.FindAll(x => x.Name.Equals(name));
            if (idNum != "")
                clients = clients.FindAll(x => x.IdNum.Equals(idNum));
            if (email != "")
                clients = clients.FindAll(x => x.Email.Equals(email));
            if (phone != "")
                clients = clients.FindAll(x => x.Phone.Equals(phone));
            return Ok(clients);
        }
        */
        //same as above but with a query string, make sure query are optional
        [HttpGet]
        public IActionResult Get([FromQuery] string? name = "", string? idNum = "", string? email = "", string? phone = "")
        {
            var clients = _context.Clients.ToList();
            if (name != "")
                clients = clients.FindAll(x => x.Name.Equals(name));
            if (idNum != "")
                clients = clients.FindAll(x => x.IdNum.Equals(idNum));
            if (email != "")
                clients = clients.FindAll(x => x.Email.Equals(email));
            if (phone != "")
                clients = clients.FindAll(x => x.Phone.Equals(phone));
            return Ok(clients);
        }


        [HttpPost]

        public IActionResult Post([FromBody] Client client)
        {
            Client client1 = _context.Clients.ToList().Find(x => x.IdNum.Equals(client.IdNum));

            if (client1 == null)
            {
                _context.Clients.Add(new Client(client.Name, client.IdNum, client.Email, client.Phone));
                _context.SaveChanges();
                return Ok("Client added");

                }
            else
            {
                return BadRequest("Client already exists");
            }

        }


        [HttpDelete]
        public IActionResult Delete([FromQuery] string idNum)
        {
            Client client = _context.Clients.ToList().Find(x => x.IdNum.Equals(idNum));
            if (client != null)
            {
                _context.Clients.Remove(client);
                _context.SaveChanges();
                return Ok("Client deleted");
            }
            else
            {
                return BadRequest("Client not found");
            }
        }


        [HttpPut]
        public IActionResult Put([FromBody] Client client)
        {
            Client client1 = _context.Clients.ToList().Find(x => x.IdNum.Equals(client.IdNum));
            if (client1 != null)
            {
                client1.Name = client.Name;
                client1.Email = client.Email;
                client1.Phone = client.Phone;
                _context.SaveChanges();
                return Ok("Client updated");
            }
            else
            {
                return BadRequest("Client not found");
            }
        }



    }
}

