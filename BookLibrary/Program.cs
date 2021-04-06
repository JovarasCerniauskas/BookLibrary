using BookLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace BookLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            var bookReadWriteController = new BookReadWriteController();
            var index = 0;
            bookReadWriteController.SaveData();
            var bookController = new BookController(bookReadWriteController);
            while (index != 6)
            {
                Console.WriteLine("Welcome to the Visma library ");
                Console.WriteLine("1. Add a new book to the library!");
                Console.WriteLine("2. Take books from the library!");
                Console.WriteLine("3. Return Borrowed books!");
                Console.WriteLine("4. See the list of library books and filter the list!");
                Console.WriteLine("5. Remove a book from the library");
                Console.WriteLine("6. Leave the library");
                var choise = Console.ReadLine();
                index = Convert.ToInt32(Regex.IsMatch(choise, @"^\d+$") ? choise : "0");


                switch (index)
                {
                    case 1:
                        Addbook(bookController);
                        break;
                    case 2:
                        TakeBook(bookController);
                        break;
                    case 3:
                        ReturnBook(bookController);
                        break;
                    case 4:
                        BookList(bookReadWriteController.books);
                        break;
                    case 5:
                        RemoveBook(bookController);
                        break;
                    default:

                        break;
                }

            }




            }

            private static void RemoveBook(BookController bookController)
            {
                Console.WriteLine("Enter the ISBN of the book you want to remove");
                var isbn = Console.ReadLine();
            Console.WriteLine(bookController.DeleteBook(isbn));
            }

            private static void ReturnBook(BookController bookController)
            {
                Console.WriteLine("Whrite books ISBN ");
                var isbn = Console.ReadLine();
                Console.WriteLine(bookController.ReturnBook(isbn));
            }

            private static void TakeBook(BookController bookController)
            {
                Console.WriteLine("Write the ISBN of the book you want to borrow: ");
                var isbn = Console.ReadLine();
                Console.WriteLine("Enter your name, for accounting porposes:");
                var takenContactName = Console.ReadLine();
                Console.WriteLine("For how long are you planning to keep it? Enter duration in days, please: ");
                var burrowDuration = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(bookController.TakeBook(isbn, takenContactName, burrowDuration));
            }

            private static void Addbook(BookController bookController)
            {
                Console.WriteLine("Please enter the book name: ");
                var name = Console.ReadLine();
                Console.WriteLine("Please enter the authors name: ");
                var author = Console.ReadLine();
                Console.WriteLine("Please enter the ISBN of the book: ");
                var isbn = Console.ReadLine();
                Console.WriteLine("Please enter the publication date of the book: ");
                var publicationdate = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("Please enter the language of the book: ");
                var language = Console.ReadLine();
                Console.WriteLine("Please enter the category of the book: ");
                var category = Console.ReadLine();
            Console.WriteLine(bookController.AddBook(name, isbn, author, publicationdate, language, category));
            }

            public static void BookList(List<Book> books)
            {
            var index = 0;
           
                Console.WriteLine("Welcome to the Visma library ");
                Console.WriteLine("1.Filter the list of books by book name!");
                Console.WriteLine("2. Filter the list of books by by authers name: ");
                Console.WriteLine("3. Filter the list of books by ISBN: ");
                Console.WriteLine("4. Filter the list of books by language: ");
                Console.WriteLine("5. Filter the list of books by Category");
                Console.WriteLine("6. Filter the list by taken books");
                Console.WriteLine("7. Filter the list by available books");
                Console.WriteLine("8. Display list of books without filtering");
                var choise = Console.ReadLine();
                index = Convert.ToInt32(Regex.IsMatch(choise, @"^\d+$") ? choise : "0");


                switch (index)
                {
                    case 1:
                        Console.WriteLine("Enter the book name: ");
                        var name = Console.ReadLine();
                        PrintBookList(books.Where(s=>s.Name.Contains(name)).ToList());
                        break;
                    case 2:
                        Console.WriteLine("Enter the Authors name: ");
                        var author = Console.ReadLine();
                        PrintBookList(books.Where(s => s.Author.Contains(author)).ToList());
                        break;
                    case 3:
                        Console.WriteLine("Enter the  ISBN: ");
                        var isbn = Console.ReadLine();
                        PrintBookList(books.Where(s => s.ISBN.Contains(isbn)).ToList());
                        break;
                    case 4:
                        Console.WriteLine("Enter the book language: ");
                        var language = Console.ReadLine();
                        PrintBookList(books.Where(s => s.Language.Contains(language)).ToList());
                        break;
                    case 5:
                        Console.WriteLine("Enter the book category : ");
                        var category = Console.ReadLine();
                        PrintBookList(books.Where(s => s.Category.Contains(category)).ToList());
                        break;
                    case 6:
                        
                        PrintBookList(books.Where(s => s.Istaken).ToList());
                        break;
                    case 7:
                        PrintBookList(books.Where(s => !s.Istaken).ToList());
                        break;
                    case 8:
                        PrintBookList(books);
                        break;
                    default:

                        break;

            }
        }


        public static void PrintBookList(List<Book> books)
        {
            var index = 0;

            foreach (var book in books)
            {
               
                Console.WriteLine($"{index}. Name: {book.Name}, Author: {book.Author}, ISBN: {book.ISBN}, Language: {book.Language}, PublicationDate: {book.PublicationDate}, Category: {book.Category}, is the book taken: {book.Istaken} ");
                index += 1;
            }
        }
    }
    
}
