﻿using System.Reflection;

namespace _3._Dziedziczenie
{
    internal class Program
    {
        public class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }

            //konstruktor
            public Person(string firstName, string LastName)
            {
                FirstName = firstName;
                this.LastName = LastName;
            }
        }

        public class Author : Person
        {
            public List<Book> BooksList { get; set; }
            public Author(string firstName, string LastName) : base(firstName, LastName)
            {
                BooksList = new List<Book>();
            }
            public void AddBook(Book book)
            {
                BooksList.Add(book);
            }



        }

        public class Book
        {
            public string Tittle { get; set; }
            public int PublicationYear { get; set; }
            public Author Author { get; set; }
            public Book(string tittle, int publicationYear, Author author)
            {
                Tittle = tittle;
                PublicationYear = publicationYear;
                Author = author;
            }
        }

        public class Reader : Person
        {
            public List<Book> BorrowedBooks { get; set; }
            public Reader(string firstName, string LastName) : base(firstName, LastName)
            {
                BorrowedBooks = new List<Book>();
            }

            public void BorrowBook(Book book)
            {
                BorrowedBooks.Add(book);
                Console.WriteLine($"Czytelnik {FirstName} {LastName} wypożyczył książkę {book.Tittle}");
            }
        }

        public class Library
        {
            public List<Book> BooksList { get; set; }
            public List<Reader> ReadersList { get; set; }
            public List<Author> AuthorsList { get; set; }
            public List<Book> BorrowedBooksList { get; set; }

            public Library()
            {
                BooksList = new List<Book>();
                ReadersList = new List<Reader>();
                AuthorsList = new List<Author>();
                BorrowedBooksList = new List<Book>();
            }

            public void AddBook(Book book)
            {
                BooksList.Add(book);
                Console.WriteLine($"Dodano książkę: {book.Tittle}");
            }

            public void AddAuthor(Author author)
            {
                AuthorsList.Add(author);
                Console.WriteLine($"Dodano autora: {author.FirstName} {author.LastName}");
            }
            public void AddReader(Reader reader)
            {
                ReadersList.Add(reader);
                Console.WriteLine($"Dodano czytelnika: {reader.FirstName} {reader.LastName}");
            }

            //metodę umożliwiającą wyporzyczenie ksiąszki przez czytelnika
            public void BorrowBook(Book book, Reader reader)
            {
                if (BooksList.Contains(book))
                {
                    reader.BorrowBook(book);
                    BorrowedBooksList.Add(book);
                    BooksList.Remove(book);
                    Console.WriteLine($"Książka {book.Tittle} została wypożyczona przez {reader.FirstName} {reader.LastName}");
                }
                else
                {
                    Console.WriteLine($"Książka {book.Tittle} nie jest dostępna w bibliotece");
                }
            }

            public void DisplayAuthorsTable()
            {
                Console.WriteLine("Lista autorów:");
                Console.WriteLine("ID\tImię\tNazwisko");
                for (int i = 0; i < AuthorsList.Count; i++)
                {
                    Console.WriteLine($"{i + 1}\t{AuthorsList[i].FirstName}\t{AuthorsList[i].LastName}");
                }

            }

            public void DisplayReadersTable()
            {
                Console.WriteLine("Lista czytelników:");
                Console.WriteLine("ID\tImię\tNazwisko");
                for (int i = 0; i < ReadersList.Count; i++)
                {
                    Console.WriteLine($"{i + 1}\t{ReadersList[i].FirstName}\t{ReadersList[i].LastName}");
                }
            }

            public void DisplayBooksTabe()
            {
                Console.WriteLine("Lista książek:");
                Console.WriteLine("ID\tTytuł\tRok Publikacji");
                for (int i = 0; i < ReadersList.Count; i++)
                {
                    Console.WriteLine($"{i + 1}\t{BooksList[i].Tittle}\t{BooksList[i].PublicationYear}");
                }
            }

            public void DisplayBorrowedBooks()
            {
                Console.WriteLine("Lista pożyczonych książek:");
                Console.WriteLine("ID\tTytuł\tRok Publikacji");
                for (int i = 0; i < BorrowedBooksList.Count; i++)
                {
                    Console.WriteLine($"{i + 1}\t{BorrowedBooksList[i].Tittle}\t{BorrowedBooksList[i].PublicationYear}");
                }

            }
        }

        static void Main(string[] args)
        {
            //Person person = new Person("Jan", "Nowak");

            Author author = new Author("Adam", "Mickiewicz");

            Book book = new Book("Pan Tadeusz", 1834, author);

            author.AddBook(book);

            Reader reader = new Reader("Jan", "Kowalski");
            Library library = new Library();

            bool exit = false;
            while (!exit)
            {
                //Console.Clear();
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Dodaj autora");
                Console.WriteLine("2. Dodaj książkę");
                Console.WriteLine("3. Dodaj czytelnika");
                Console.WriteLine("4. Wypożycz książkę");
                Console.WriteLine("5. Wyświetl wszystkie książki");
                Console.WriteLine("6. Wyświetl wszystkich autorów");
                Console.WriteLine("7. Wyświetl wszystkie wypożyczone książki");
                Console.WriteLine("8. Wyjście");
                Console.Write("Wybierz opcję: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Write("Podaj imię autora:");
                        string authorFirstName = Console.ReadLine();
                        Console.Write("Podaj nazwisko autora:");
                        string authorLastName = Console.ReadLine();
                        library.AddAuthor(new Author(authorFirstName, authorLastName));
                        break;
                    case "2":
                        library.DisplayAuthorsTable();
                        Console.Write("Podaj numer authora:");
                        int authorIndex = int.Parse(Console.ReadLine()) - 1;
                        if (authorIndex >= 0 && authorIndex < library.AuthorsList.Count)
                        {
                            Author selectedAuthor = library.AuthorsList[authorIndex];
                            Console.Write("Podaj tytuł książki:");
                            string bookTitle = Console.ReadLine();
                            Console.Write("Podaj rok publikacji:");
                            int publicationYear = int.Parse(Console.ReadLine());
                            Book newBook = new Book(bookTitle, publicationYear, selectedAuthor);
                            library.AddBook(newBook);
                            selectedAuthor.AddBook(newBook);
                        }
                        else
                        {
                            Console.WriteLine("Nieprawidłowy numer authora");
                        }
                        break;
                    case "3":
                        Console.Write("Podaj imię czytelnika:");
                        string readerFirstName = Console.ReadLine();
                        Console.Write("Podaj nazwisko czytelnika:");
                        string readerLastName = Console.ReadLine();
                        Reader newReader= new Reader(readerFirstName, readerLastName);
                        library.AddReader(newReader);
                        break;
                    case "4":
                        Console.Write("Podaj imię czytelnika:");
                        string borrowerFirstName = Console.ReadLine();
                        Console.Write("Podaj nazwisko czytelnika:");
                        string borrowerLastName = Console.ReadLine();
                        Reader borrower = library.ReadersList.Find(r => r.FirstName == borrowerFirstName && r.LastName == borrowerLastName);
                        if (borrower != null)
                        {
                            Console.Write("Podaj tytuł książki:");
                            string borrowerBookTitle = Console.ReadLine();

                            Book borrowedBook = library.BooksList.Find(b => b.Tittle ==  borrowerBookTitle);
                            if (borrowedBook != null)
                            {
                                library.BorrowBook(borrowedBook, borrower);
                            }
                            else
                            {
                                Console.WriteLine("Książka nie jest dostępna");
                            }

                        }
                        else
                        {
                            Console.WriteLine("Czytelnik nie został znaleziony");
                        }

                        break;
                    case "5":
                        library.DisplayBooksTabe();
                        break;
                    case "6":
                        library.DisplayAuthorsTable();
                        break;
                    case "7":
                        library.DisplayBorrowedBooks();
                        break;
                    case "8":
                        exit = true;
                        break;
                }
            }

            //Console.ReadKey();
        }
    }
}