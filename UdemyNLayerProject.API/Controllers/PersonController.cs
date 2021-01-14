using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyNLayerProject.Core.Models;
using UdemyNLayerProject.Core.Services;

namespace UdemyNLayerProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IService<Person> _sercive;

        public PersonController(IService<Person> sercive)
        {
            _sercive = sercive;
        }

        
        public async Task<IActionResult> GetAll()
        {
            var people = await _sercive.GetAllAsync();
            return Ok(people);
        }

        [HttpPost]
        public async Task<IActionResult> Save(Person person)
        {
            var addedPerson= await _sercive.AddAsync(person);
            return Created(string.Empty, addedPerson);


        }
    }
}