using CRM_Concepts_Api.Models;
using CRM_Concepts_Api.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CRM_Concepts_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientManager _clientManager;
        public ClientController(IClientManager clientManager)
        {
            _clientManager = clientManager;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Client> clients = await _clientManager.ListAsync();
            return Ok(clients);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            Client client = await _clientManager.GetAsync(id);
            return Ok(client);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<IActionResult> InsertAsync(Client inputClient)
        {
            string? cf = await _clientManager.InsertAsync(inputClient);
            return Created("Client Created", new { cf });
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] Client value)
        {
            bool updated = await _clientManager.UpdateAsync(id, value);
            if (!updated)
                return BadRequest(value);
            return Ok(value);
           
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            bool deleted = await _clientManager.DeleteAsync(id);
            if (!deleted)
                return BadRequest(id);
            return Ok(id);
        }
    }
}
