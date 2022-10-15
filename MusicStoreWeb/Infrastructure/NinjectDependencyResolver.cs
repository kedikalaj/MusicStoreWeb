using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Moq;
using Ninject;
using MusicStore.Domain.Abstract;
using MusicStore.Domain.Entities;
using MusicStore.Domain.Concrete;

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
                new Song { Name = "This fffire", Price = 25 },
                new Song { Name = "Surf board", Price = 179 },
                new Song { Name = "Morbius theme 10h", Price = 999995 }
                });


            kernel.Bind<ISongsRepository>().To<EFSongRepository>();
        }
    }
}