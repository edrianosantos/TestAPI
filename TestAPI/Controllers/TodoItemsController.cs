using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestAPI.Model;
using TestAPI.Services;

namespace TestAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoItemsController : ControllerBase
    {
        private readonly ITodoItemsService _todoItemsService;

        public TodoItemsController(ITodoItemsService todoItemsService)
        {
            _todoItemsService = todoItemsService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _todoItemsService.GetAll();

            if (result?.Any() == false)
            {
                return NoContent();
            }

            return Ok(result);
        }

        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(long id)
        {
            var result = _todoItemsService.Get(id);

            if(result == null)
            {
                return NotFound("Nenhum resultado.");
            }

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody] TodoItems todoItems)
        {
            if(todoItems == null || todoItems.IsComplete == null || string.IsNullOrEmpty(todoItems.Name))
            {
                return BadRequest("Objeto está vazio.");
            }

            _todoItemsService.Add(todoItems);
            return CreatedAtRoute("Get", new { Id = todoItems.Id }, todoItems);
        }

    }
}