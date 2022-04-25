using BookStore.Entities;
using BookStore.Infrastructur.Application;
using BookStore.Infrastructur.Test;
using BookStore.Persistence.EF;
using BookStore.Persistence.EF.Categories;
using BookStore.Services.Categories;
using BookStore.Services.Categories.Contracts;
using FluentAssertions;
using System;
using Xunit;

namespace BookStore.Services.Test.Unit.Categories
{
    public class CategoryServiceTests
    {
        private readonly EFDataContext _dataContext;
        private readonly UnitOfWork _unitOfWork;
        private readonly CategoryService _sut;
        private readonly CategoryRepository _repository;
        public CategoryServiceTests()
        {
            _dataContext = new EFInMemoryDatabase().CreateDataContext<EFDataContext>();
            _unitOfWork = new EFUnitOfWork(_dataContext);
            _repository = new EFCategoryRepository(_dataContext);
            _sut = new CategoryAppService(_repository,_unitOfWork);
        }

        [Fact]
        public void Add_adds_Category_Properly()
        {
            AddCategoryDto dto = GenerateAddCateGorydto();
            _sut.Add(dto);
            _dataContext.Categories.Should().Contain(_ => _.Title == dto.Title);
        }

        private static AddCategoryDto GenerateAddCateGorydto()
        {
            return new AddCategoryDto
            {
                Title = "dummy",
            };
        }
    }

   

    

   

   
}
