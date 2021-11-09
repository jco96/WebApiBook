using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApiTest.Repositories;
using WebApiTest.Entities;
using System.Threading.Tasks;

namespace WebApiTest.Controllers
{
    [ApiController]
    [Route( "api/Books")]
    public class BooksController : ControllerBase
    {
        private readonly IBooksRepo repository;

        public BooksController(IBooksRepo repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<Book> GetBooks()
        {
            var books = repository.GetBooks().Select(book => book);
            return books;
        }

        [HttpGet ("{id}") ]
        public ActionResult<Book> GetBook(int id)
        {
            var book = repository.GetBook(id);

            if(book is null){
                return NotFound();
            }
            return book;

        }

        [HttpPost]
        public ActionResult<Book> New_Book(Book bookDto){
           
            Book book = new(){
                id= repository.getIndex(),  
                title= bookDto.title,
                description = bookDto.description
            };

            repository.NewBook(book);

            return CreatedAtAction(nameof(GetBook), new {id= book.id}, book);

        }

        [ HttpPut ("{id}") ]       
        public ActionResult <Book> Update_Book(int id, Book bookDto){
            var BookStock = repository.GetBook(id);

            if(BookStock is null ){
                return NotFound();
            }

            Book UpdatedBook = BookStock with{

                title= bookDto.title,
                description= bookDto.description,
                Excerpt=bookDto.Excerpt

            };

            repository.UpdateBook(UpdatedBook);

            return NoContent();

        }
        
        [HttpDelete("{id}")]
        public ActionResult DeleteBook(int id){

            var BookStock = repository.GetBook(id);

            if(BookStock is null ){
                return NotFound();
            
            }

            repository.RemoveBook(id);            

            return NoContent();
        }

        [HttpGet("consumeApi")]
        public async Task<IEnumerable<Book>> ConsumeApi(){

            var url = "https://fakerestapi.azurewebsites.net/api/v1/Books";
         
            using (var Http= new HttpClient() ){
                var response = await Http.GetAsync(url);
                var responseString= await response.Content.ReadAsStringAsync();
                var data= System.Text.Json.JsonSerializer.Deserialize<List<Book>>(responseString);
                return data;
            }
            

        }

    }
}