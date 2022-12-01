using ContactApi.Data.ConDbContext;
using ContactApi.Domain.Models;
using ContactApi.Infrastructure.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContactApp.Api.Controllers
{
    [Route("api/v1/Contract")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        private readonly IRepository<Contact> _contactRepository;      
            
         
        public ContractController(IRepository<Contact> contactRepository)
        {
            _contactRepository = contactRepository;
        }

        // GET: api/<ContractController>
        [HttpGet("GetAllContacts")]
        public async Task<IEnumerable<Contact>> GetAllContacts()
        {
            return await _contactRepository.GetAllAsync();
        }

        // GET api/<ContractController>/5
        [HttpGet("{id}")]
        public async Task<Contact> GetAContact(int id)
        {
            return await _contactRepository.GetById(id);
        }

        // POST api/<ContractController>
        [HttpPost("AddContacts")]
        public async Task<string> AddContacts([FromBody] ContactDTO value)
        {
            _contactRepository.AddContactAsync(value);
            return "Added Successfully";
        }

        // DELETE api/<ContractController>/5
        [HttpDelete("{id}")]
        public async Task<string> Delete(int id)
        {
            _contactRepository.Remove(id);
            return "Deleted Successfully";
        }
    }
}
