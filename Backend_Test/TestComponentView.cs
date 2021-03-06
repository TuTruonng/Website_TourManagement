using CustomerSite.SerVices;
using CustomerSite.ViewComponents;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Moq;
using ShareModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Backend_Test
{
    public class TestComponentView
    {

        [Fact]
        public async Task PostCategory_Success()
        {
            //Arrange View Component
            var httpContext = new DefaultHttpContext();
            var viewContext = new ViewContext();
            viewContext.HttpContext = httpContext;
            var viewComponentContext = new ViewComponentContext();
            viewComponentContext.ViewContext = viewContext;

            //Arrange Mock Client
            var categoryApiClientMock = new Mock<ICategoryApiClient>();
            categoryApiClientMock.Setup(c => c.GetCategories()).Returns(getCategoriesValue());
            var viewComponent = new CategoryMenuViewComponent(categoryApiClientMock.Object);

            //Act - Check final result is viewcomponent
            var result = viewComponent.InvokeAsync();
            var createdAtActionResult = Assert.IsType<Task<IViewComponentResult>>(result);
        }

        private Task<IList<CategoryShare>> getCategoriesValue()
        {
            IList<CategoryShare> categoriesValue = new List<CategoryShare>();
            return Task.FromResult(categoriesValue);
        }
    }


}