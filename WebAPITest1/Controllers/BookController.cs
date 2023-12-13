using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WebAPITest1.Model;
using WebAPITest1.Model.DTO;
using WebAPITest1.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPITest1.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IRepository<BookDTO, int> bookRepository;

        public BookController(IRepository<BookDTO, int> bookRepository, IMapper mapper)
        {
            this.bookRepository = bookRepository;
        }

        // GET: api/<BookController>
        [HttpGet]
        public async Task<IEnumerable<BookDTO>> Get()
        {
            var books = await bookRepository.GetAll();
            return books;
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var book = await bookRepository.GetById(id);
            return book == null ? NotFound() : Ok(book);
        }

        // POST api/<BookController>
        [HttpPost]
        public async Task Post([FromBody] BookDTO book)
        {
            await bookRepository.Insert(book);
            await bookRepository.Save();
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] BookDTO book)
        {
            await bookRepository.Put(id, book);
            await bookRepository.Save();
            return NoContent();

        }

        // PATCH api/<BookController>/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument book)
        {
            await bookRepository.Patch(id, book);
            await bookRepository.Save();

            return Ok();

        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await bookRepository.Delete(id);
            await bookRepository.Save();
        }
    }
}
