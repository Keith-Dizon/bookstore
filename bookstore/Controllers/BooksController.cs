using bookstore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace bookstore.Controllers
{
    public class BooksController : Controller
    {
        private static List<Book> books = new List<Book>
        {
            new Book { Id = 1, Title = "Hunger Games", Author = "Eric Portland", Price = 20.99m, PublicationYear = 2004 },
            new Book { Id = 2, Title = "Harry Potter", Author = "JK Rowling", Price = 30.99m, PublicationYear = 2001 },
            new Book { Id = 3, Title = "PisoIpon", Author = "Chinkee Tan", Price = 19.99m, PublicationYear = 2021 }
        };

        // GET: Books/Index
        public IActionResult Index()
        {
            return View(books);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                book.Id = books.Max(b => b.Id) + 1;  // Assign a new unique ID
                books.Add(book);  // Add to the in-memory list
                return RedirectToAction(nameof(Index));  // Redirect to Index to show updated list
            }

            return View(book);  // If the form is invalid, stay on the Create page
        }

        // GET: Books/Edit/1
        public IActionResult Edit(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)
                return NotFound();

            return View(book);
        }

        // POST: Books/Edit/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Book updatedBook)
        {
            if (ModelState.IsValid)
            {
                var book = books.FirstOrDefault(b => b.Id == id);
                if (book != null)
                {
                    book.Title = updatedBook.Title;
                    book.Author = updatedBook.Author;
                    book.Price = updatedBook.Price;
                    book.PublicationYear = updatedBook.PublicationYear;
                    return RedirectToAction(nameof(Index));  // Redirect to Index after update
                }
                return NotFound();
            }

            return View(updatedBook);  // Return to Edit page if validation failed
        }

        // GET: Books/Delete/1
        public IActionResult Delete(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)
                return NotFound();

            return View(book);
        }

        // POST: Books/Delete/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                books.Remove(book);  // Remove from the list
            }
            return RedirectToAction(nameof(Index));  // Redirect to Index after deletion
        }
    }
}
