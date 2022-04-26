using BookStore.Entities;
using BookStore.Infrastructur.Application;
using BookStore.Services.Categories;
using BookStore.Services.Categories.Contracts;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BookStore.Services.Test.Unit.Categories
{
    public class CategoryServiceTestsWithMoq
    {
        [Fact]
        public void Add_adds_category_properly()
        {
            var dto = new AddCategoryDto
            {
                Title = "Dummy"
            };
            Mock<CategoryRepository> repositroy
                = new Mock<CategoryRepository>();

            Mock<UnitOfWork> unitOfWork =
                new Mock<UnitOfWork>();

            var sut = new CategoryAppService(repositroy.Object,
                unitOfWork.Object);

            sut.Add(dto);

            repositroy.Verify(_ =>
            _.Add(It.Is<Category>(_ => _.Title == dto.Title)));

            unitOfWork.Verify(_ => _.Commit());
        }


    }
}
