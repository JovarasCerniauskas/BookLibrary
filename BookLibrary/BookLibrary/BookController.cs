using BookLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    class BookController
    {
        private BookReadWriteController bookReadWriteController;
        public BookController(BookReadWriteController bookReadWriteController)
        {
            this.bookReadWriteController = bookReadWriteController;
        }

        public string AddBook(string name, string isbn, string author, DateTime publicationdate, string language, string category)
        {
            var book = new Book
            {
                Author = author,
                ISBN = isbn,
                Category = category,
                Language = language,
                PublicationDate = publicationdate,
                Name = name
            };
            bookReadWriteController.books.Add(book);
            bookReadWriteController.SaveData();
            return "Books successfully added!";
        }

        public string TakeBook(string isbn, string takenContactName, int borrowDuration)
        {
            var book = bookReadWriteController.books.FirstOrDefault(s => s.ISBN == isbn);
            if(book== null)
            {
                return "We dont have such book";
            }
            if(borrowDuration > 60)
            {
                return "Taking books for longer than two months is not allowed, m'kay";
            }
            if(borrowDuration <= 0)
            {
                return "You can't break laws of time, maan";
            }
            if(bookReadWriteController.books.Count(s=>s.TakenContactName == takenContactName) >= 3)
            {
                return "You are not allowed to take more than three books";
            }
            if (string.IsNullOrEmpty(takenContactName))
            {
                return "Sorry anon, real name please";
            }

            book.TakenContactName = takenContactName;
            book.ReturnDate = DateTime.Now.AddDays(borrowDuration);
            book.Istaken = true;
            book.TakenDate = DateTime.Now;
            bookReadWriteController.SaveData();
            return $"Books usccessfully borrowed, please return the book before {book.ReturnDate.Value.ToString("d")}";

        }

        public string DeleteBook(string isbn)
        {
            var book = bookReadWriteController.books.FirstOrDefault(s => s.ISBN == isbn);
            if(book != null)
            {
                bookReadWriteController.books.Remove(book);
                bookReadWriteController.SaveData();

                return "Book deleted successfully!";
            }
            return "Book not found";
        }

        public string ReturnBook(string isbn)
        {
            var book = bookReadWriteController.books.FirstOrDefault(s => s.ISBN == isbn);
            if(book == null)
            {
                return "We did not lend such book";
            }
            var isLate = DateTime.Now > book.ReturnDate;

            book.Istaken = false;
            book.TakenContactName = "";
            book.ReturnDate = null;
            book.TakenDate = null;

            bookReadWriteController.SaveData();

            return isLate ? "Finally, I thought I would find it on craigslist by now.." : "Thanks you for returning the book, m80";
        }
    }
}
