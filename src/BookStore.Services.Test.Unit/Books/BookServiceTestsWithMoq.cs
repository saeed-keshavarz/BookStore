using BookStore.Infrastructur.Application;
using BookStore.Services.Books;
using BookStore.Services.Books.Contracts;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BookStore.Services.Test.Unit.Books
{
    public class BookServiceTestsWithMoq
    {
        [Fact]
        public void Add_adds_book_properly()
        {
            var dto = new AddBookDto
            {
                Title = "Dummy"
            };
            Mock<BookRepository> repositroy
                = new Mock<BookRepository>();

            Mock<UnitOfWork> unitOfWork =
                new Mock<UnitOfWork>();

            var sut = new BookAppService(repositroy.Object,
                unitOfWork.Object);

            sut.Add(dto);

            repositroy.Verify(_ =>
            _.Add(It.Is<Entities.Book>(_ => _.Title == dto.Title)));

            unitOfWork.Verify(_ => _.Commit());
        }

        [Fact]
        public void Get_get_all_book_properly()
        {
            
        }


        [Fact]
        public void Update_updates_book_properly()
        {
            var dto = new UpdateBookDto
            {
                Title = "EditedDummy",
                Description="Dummy",
                Author="Dummy",
                Pages=100,
            };
        }
    }
}
