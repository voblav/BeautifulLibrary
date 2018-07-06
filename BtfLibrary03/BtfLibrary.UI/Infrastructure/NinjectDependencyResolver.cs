using BtfLibrary.Domain.Abstract;
using BtfLibrary.Domain.Concrete;
using BtfLibrary.Domain.Entities;
using Moq;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BtfLibrary.UI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        private void AddBindings()
        {
            //для привязок
            //Mock<IBookRepository> mock = new Mock<IBookRepository>();
            //mock.Setup(m => m.Books).Returns(new List<Book>
            //{
            //    new Book { Name = "Капиталъ", Author = "Карл Маркс" },
            //    new Book { Name = "Как закалялась сталь", Author = "Николай Островский" },
            //    new Book { Name = "Язык программирования С# и платформа .Net", Author = "Э. Троелсон" }
            //});
            //kernel.Bind<IBookRepository>().ToConstant(mock.Object);
            kernel.Bind<IBookRepository>().To<EFBookRepository>();
        }

        public object GetService(Type ServiceType)
        {
            return kernel.TryGet(ServiceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
    }
}