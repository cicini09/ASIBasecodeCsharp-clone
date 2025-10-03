using ASI.Basecode.Data.Models;
using ASI.Basecode.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ASI.Basecode.WebApp.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public IActionResult Index()
        {
            List<Book> books = _bookService.ViewBooks() ?? new();
            return View(books);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            var book = _bookService.GetBookId(id);
            if (book == null) return NotFound();
            return View(book);
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            _bookService.AddBook(book);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            _bookService.UpdateBook(book);

            return RedirectToAction("Index");
        }
    }
}
