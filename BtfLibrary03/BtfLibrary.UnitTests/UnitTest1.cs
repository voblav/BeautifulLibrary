using System;
using System.Collections.Generic;
using BtfLibrary.Domain.Abstract;
using BtfLibrary.Domain.Entities;
using BtfLibrary.UI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;
using System.Web.Mvc;
using BtfLibrary.UI.Models;
using BtfLibrary.UI.HtmlHelpers;

namespace BtfLibrary.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Can_Paginate()
        {
            Mock<IBookRepository> mock = new Mock<IBookRepository>();
            mock.Setup(m => m.Books).Returns(new List<Book> {
            new Book{IdBook=1,Name="BookTest1"},
            new Book{IdBook=2,Name="BookTest2"},
            new Book{IdBook=3,Name="BookTest3"},
            new Book{IdBook=4,Name="BookTest4"},
            new Book{IdBook=5,Name="BookTest5"}
            });
            BooksController controller = new BooksController(mock.Object);
            controller.pageSize = 3;

            IEnumerable<Book> result = (IEnumerable<Book>)controller.List(2).Model;

            List<Book> books = result.ToList();
            Assert.IsTrue(books.Count == 2);
            Assert.AreEqual(books[0].Name, "BookTest4");
            Assert.AreEqual(books[1].Name, "BookTest5");
        }

        [TestMethod]
        public void Can_Generate_Page_Links()
        {
            HtmlHelper myHelper = null;
            PagingInfo pagingInfo = new PagingInfo
            {
                CurrentPage = 2,
                TotalItems = 28,
                ItemsPerPage = 10
            };
            Func<int, string> pageUrlDelegate = i => "Page" + i;

            MvcHtmlString result = myHelper.PageLinks(pagingInfo, pageUrlDelegate);

            Assert.AreEqual(@"<a class=""btn btn-default"" href=""Page1"">1</a>"
                            + @"<a class=""btn btn-default btn-primary selected"" href=""Page2"">2</a>"
                            + @"<a class=""btn btn-default"" href=""Page3"">3</a>",
                            result.ToString());

        }
    }
}
