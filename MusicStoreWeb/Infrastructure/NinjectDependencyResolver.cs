using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Moq;
using Ninject;
using MusicStore.Domain.Abstract;
using MusicStore.Domain.Entities;

namespace MusicStoreWeb.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            Mock<ISongsRepository> mock = new Mock<ISongsRepository>();
            mock.Setup(m => m.Songs).Returns(new List<Song> {
            new Song { Name = "Never Gonna Give You Up", Price = 25 },
            new Song { Name = "This Fffire", Price = 179 },
            new Song { Name = "Morbius Theme 10h", Price = 95 }
            });
            kernel.Bind<ISongsRepository>().ToConstant(mock.Object);
        }

        private static void RegisterServices(IKernel kernel)
        {
            System.Web.Mvc.DependencyResolver.SetResolver(new
            MusicStoreWeb.Infrastructure.NinjectDependencyResolver(kernel));
        }


    }
}