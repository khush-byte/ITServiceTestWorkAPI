using ITServiceTestWorkAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace ITServiceTestWorkAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : Controller
    {
        private readonly List<ClientModel> _clients;

        public ClientController()
        {
            _clients = new List<ClientModel>();
        }

        [HttpGet]
        public IEnumerable<ClientModel> Get()
        {
            return _clients;
        }

        [HttpGet("{id}")]
        public ActionResult<ClientModel> GetById(int id)
        {
            var client = _clients.FirstOrDefault(t => t.Id == id);
            if (client == null)
            {
                return NotFound();
            }

            return client;
        }

        [HttpPost]
        public ActionResult<ClientModel> Create(ClientModel client)
        {
            client.Id = _clients.Count + 1;
            _clients.Add(client);

            return CreatedAtAction(nameof(GetById), new { id = client.Id }, client);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, ClientModel client)
        {
            var existingClient = _clients.FirstOrDefault(t => t.Id == id);
            if (existingClient == null)
            {
                return NotFound();
            }

            existingClient.Name = client.Name;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var client = _clients.FirstOrDefault(t => t.Id == id);
            if (client == null)
            {
                return NotFound();
            }

            _clients.Remove(client);

            return NoContent();
        }
    }
}
