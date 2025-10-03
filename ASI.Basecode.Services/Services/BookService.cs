using ASI.Basecode.Data.Interfaces;
using ASI.Basecode.Data.Models;
using ASI.Basecode.Resources.Views;
using ASI.Basecode.Services.Interfaces;
using Hangfire.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASI.Basecode.Services.Services
{
    public class BookService : IBookService
    {   

        private readonly IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public List<Book> ViewBooks()
        {
            return _bookRepository.ViewBooks();
        }

        public void AddBook(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException();
            }

            var newBook = new Book
            {
                Title = book.Title,
                Description = book.Description,
                Author = book.Author,
                CreatedBy = book.Author,
                CreatedTime = DateTime.Now
            };

            _bookRepository.AddBook(newBook);
        }
        public Book GetBookId(int id)
        {
            return _bookRepository.GetBookId(id);
        }

        public void UpdateBook(Book book)
        {
            _bookRepository.UpdateBook(book);
        }

        public void DeleteBook(int id)
        {
            _bookRepository.DeleteBook(id);
        }
    }
}
