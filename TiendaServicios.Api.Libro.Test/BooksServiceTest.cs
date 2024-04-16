using AutoMapper;
using GenFu;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaServicios.Api.Libro.Application;
using TiendaServicios.Api.Libro.Model;
using TiendaServicios.Api.Libro.Persistence;
using Xunit;

namespace TiendaServicios.Api.Libro.Test
{
    public class BooksServiceTest
    {//ola
        private IEnumerable<MaterialLibrary> GetTestData()
        {
            A.Configure<MaterialLibrary>()
                .Fill(x => x.Title).AsArticleTitle()
                .Fill(x => x.MaterialLibraryId, () => { return Guid.NewGuid(); });

            var lista = A.ListOf<MaterialLibrary>(30);

            lista[0].MaterialLibraryId = Guid.Empty;

            return lista;
        }

        private Mock<ContextLibrary> CreateContext()
        {
            var dataTest = GetTestData().AsQueryable();

            var dbSet = new Mock<DbSet<MaterialLibrary>>();
            dbSet.As<IQueryable<MaterialLibrary>>().Setup(x => x.Provider).Returns(dataTest.Provider);
            dbSet.As<IQueryable<MaterialLibrary>>().Setup(x => x.Expression).Returns(dataTest.Expression);
            dbSet.As<IQueryable<MaterialLibrary>>().Setup(x => x.ElementType).Returns(dataTest.ElementType);
            dbSet.As<IQueryable<MaterialLibrary>>().Setup(x => x.GetEnumerator()).Returns(dataTest.GetEnumerator());

            dbSet.As<IAsyncEnumerable<MaterialLibrary>>().Setup(x => x.GetAsyncEnumerator(new System.Threading.CancellationToken()))
            .Returns(new AsyncEnumerator<MaterialLibrary>(dataTest.GetEnumerator()));

            dbSet.As<IQueryable<MaterialLibrary>>().Setup(x => x.Provider).Returns(new AsyncQueryProvider<MaterialLibrary>(dataTest.Provider));

            var context = new Mock<ContextLibrary>();
            context.Setup(x => x.MaterialLibrary).Returns(dbSet.Object);
            return context;
        }


        public async void GetBookID()
        {
            var mockContext = CreateContext();

            var mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingTest());
            });

            var mapper = mapConfig.CreateMapper();

            var request = new FilterQuery.UnitBook();
            request.BookId = Guid.Empty;

            var handler = new FilterQuery.Handler(mockContext.Object, mapper);

            var book = await handler.Handle(request, new System.Threading.CancellationToken());

            Assert.NotNull(book);
            Assert.True(book.MaterialLibraryId == Guid.Empty);
        }

        [Fact]
        public async void GetBooks()
        {
            System.Diagnostics.Debugger.Launch();

            //que metodo dentro de mi microservice se esta encargando de realizar la consulta de libros de la base de datos??
            
            // 1. EMULAR CONTEXT
            var mockContext = CreateContext();

            // 2.EMULAR MAPPER
            var mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingTest());
            });

            var mapper = mapConfig.CreateMapper();

            //3. Instanciar la clase manejador de ambos mock
            Queries.Handler handler = new Queries.Handler(mockContext.Object, mapper);

            Queries.Execute request = new Queries.Execute();

            var list = await handler.Handle(request, new System.Threading.CancellationToken()); 

            Assert.True(list.Any());
        }

        [Fact]
        public async void SaveBook()
        {
            System.Diagnostics.Debugger.Launch ();

            var options = new DbContextOptionsBuilder<ContextLibrary>()
                .UseInMemoryDatabase(databaseName: "BaseDatosLibro")
                .Options;

            var context = new ContextLibrary(options);

            var request = new New.Execute();
            request.Title = "Libro de Microservice";
            request.AuthorBook = Guid.Empty;
            request.PublicationDate = DateTime.Now;

            var handler = new New.Handler(context);

            var book = await handler.Handle(request, new System.Threading.CancellationToken());

            Assert.True(book != null);
        }
    }
}
