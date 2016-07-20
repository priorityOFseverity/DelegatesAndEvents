﻿using System;
using EventsRealisation.EventsWork;
using Factory;
using Factory.Factories;
using Model.Models;
using Infrastructure;

namespace DelegatesAndEvents
{
    class Program
    {
        static Program()
        {
            ServiceLocator.RegisterAll();
        }

        static void Main(string[] args)
        {
            var bookFactory = ServiceLocator.Resolver<BookFactory>();


            //Publisher<Book> pubBook = new Publisher<Book>();
            //Publisher<Author> authorPublisher = new Publisher<Author>();
            User testUser = new User("Vladimir", "Pozner");

            Store store = new Store();
            Author a1 = new Author("John", "White");
            Book b1 = bookFactory.CreateNewBook_WithSingleAuthor(a1, "C# for Dumms", new DateTime(2012, 2, 15), "This book is good for beginers");

            var subscribeTheBook = ServiceLocator.Resolver<Subscribe<Author>>();
            subscribeTheBook.Publisher.DataPublisher += store.ExtendStoreLists;

            //Subscribe<Author> authorSubscriber = new Subscribe<Author>(authorPublisher);
            //Subscribe<Book> bookSubscriber = new Subscribe<Book>(pubBook);

            store.BooksInStore.Add(b1);

            //bookSubscriber.Publisher.DataPublisher += store.ExtendStoreLists;
            //authorSubscriber.Publisher.DataPublisher += store.ExtendStoreLists;

            //a1.AddNewBook(b1, pubBook);
            //pubBook.PublishData(b1);
//          authorPublisher.PublishData(a1);

            Console.WriteLine(b1);
            Claim testOrder = new Claim(testUser, b1);         
            Console.ReadLine();
        }
    }
}
