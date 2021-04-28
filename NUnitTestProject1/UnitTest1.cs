using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Moq;
using NUnit.Framework;
using WebApplication1;
using WebApplication1.Models;
using WebApplication1.Service;

namespace NUnitTestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var mockDataContext = MockDbContext.GetMockContext();

            var generalViewModelService = new GeneralViewModelService();
            var model = generalViewModelService.GetGeneralViewModel(mockDataContext.Object);

        }
    }
}