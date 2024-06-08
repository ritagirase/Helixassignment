using BookStore_Project.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Reflection.Metadata.BlobBuilder;

namespace BookStore_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpPost]
        public async Task<ActionResult> AddBooks(Book_Model model)
        {
            try
            {
                if (model != null)
                {
                    await _bookRepository.AddAsync(model);

                    return StatusCode(StatusCodes.Status200OK, $"{model.Title} Is Added");
                }
                else
                {
                    return BadRequest("Plz Enter Data");
                }

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error in Retriveing Data From Database");
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetByAllBookList()
        {
            try
            {

                var AllBooksList = await _bookRepository.GetAllAsync();

                if (AllBooksList != null)
                {
                    return Ok(AllBooksList);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                   "Please try again later");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error in Retriveing Data From Database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetByBook(int id)
        {
            try
            {
                var booklist = await _bookRepository.GetByIdAsync(id);

                if (booklist != null)
                {
                    return Ok(booklist);
                }
                else
                {
                    return NotFound($"Book Id = {id} Not Found");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error in Retriveing Data From Database");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateBooks(int id, Book_Model model)
        {
            try
            {
                if (id != model.Id)
                {
                    return NotFound($"Book Id = {id} Not Found");
                }
                else
                {
                    await _bookRepository.UpdateAsync(model);

                    return StatusCode(StatusCodes.Status200OK, $"Book Id = {id} Is Update");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error in Retriveing Data From Database");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteBook(int id)
        {
            try
            {
                var book = await _bookRepository.GetByIdAsync(id);

                if (book != null)
                {
                    await _bookRepository.DeleteAsync(id);

                    return StatusCode(StatusCodes.Status200OK, $"Book Id = {id} Is Delete");
                }
                else
                {
                    return NotFound($"Book Id = {id} Not Found");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error in Retriveing Data From Database");
            }
        }
    }
}
