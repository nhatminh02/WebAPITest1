using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using WebAPITest1.Data;
using WebAPITest1.Model;
using WebAPITest1.Model.DTO;

namespace WebAPITest1.Repository
{
    public class BookRepository : IRepository<BookDTO, int>
    {
        private readonly AppDBContext context;
        private readonly IMapper mapper;


        public BookRepository(AppDBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task Delete(int id)
        {
            var book = await context.Books.FindAsync(id);
            if(book != null)
            {
                context.Books.Remove(book);
                //await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<BookDTO>> GetAll()
        {
            var books = await(from book in context.Books
                              join author in context.Authors
                              on book.AuthorId equals author.Id
                              select new Book
                              {
                                  Id = book.Id,
                                  Title = book.Title,
                                  Description = book.Description,
                                  AuthorId = book.AuthorId
                              }).ToArrayAsync();

            return mapper.Map<IEnumerable<BookDTO>>(books);
        }

        public async Task<BookDTO> GetById(int id)
        {
            var book = await context.Books.FindAsync(id);
            return mapper.Map<BookDTO>(book);
        }

        public async Task<BookDTO> Insert(BookDTO entity)
        {
            await context.Books.AddAsync(mapper.Map<Book>(entity));
            return entity;
        }

        public async Task Save()
        {
            await context.SaveChangesAsync();
        }

        public async Task Put(int id, BookDTO entity)
        {
            var book = await context.Books.FindAsync(id);
            if ( book != null ) { 
                book.Title = entity.Title;
                book.Description = entity.Description;
                book.AuthorId = entity.AuthorId;
            }
        }

        public async Task Patch(int id, JsonPatchDocument entity)
        {
            var book = await context.Books.FindAsync(id);
            if ( book != null )
            {
                entity.ApplyTo(book);
            }

        }
    }
}
