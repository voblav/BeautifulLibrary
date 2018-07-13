﻿using Domain.Abstract;
using Lib.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lib.UI.Controllers
{
    public class BooksController : Controller
    {
        private IBookRepository repository;
        public int pageSize = 4;

        public BooksController(IBookRepository repo)
        {
            repository = repo;
        }
        public ViewResult List(int page = 1)
        {
            BooksListViewModel model = new BooksListViewModel
            {
                Books = repository.Books
                .OrderBy(book => book.BookID)
                .Skip((page - 1) * pageSize)
                .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = repository.Books.Count()
                }
            };

            return View(repository.Books
                .OrderBy(book => book.BookID)
                .Skip((page - 1)*pageSize)
                .Take(pageSize));
        }
    }
}