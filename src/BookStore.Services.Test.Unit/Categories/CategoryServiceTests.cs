using BookStore.Entities;
using BookStore.Infrastructur.Test;
using BookStore.Persistence.EF;
using BookStore.Services.Categories;
using BookStore.Services.Categories.Contracts;
using FluentAssertions;
using System;

namespace BookStore.Services.Test.Unit.Categories
{
    public class CategoryServiceTests
    {
        private readonly EFDataContext _dataContext;
        public CategoryServiceTests()
        {
            _dataContext = new EFInMemoryDatabase().CreateDataContext<EFDataContext>();
        }


        public void Add_adds_Category_Properly()
        {
            var dto = new AddCategoryDto
            {
                Title = "dummy",
            };

            CategoryService sut = new CategoryAppService();
            sut.Add(dto);
            _dataContext.Categories.Should().Contain(_=>_.Title==dto.Title);
        }
    }

   

    

   

   
}
