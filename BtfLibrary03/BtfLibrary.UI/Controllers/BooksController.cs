using BtfLibrary.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BtfLibrary.UI.Controllers
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
            return View(repository.Books
                .OrderBy(book => book.IdBook)
                .Skip((page - 1)*pageSize)
                .Take(pageSize));
        }
    }
}