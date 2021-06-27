using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using OnePunch.Data;
using OnePunch.Models;
using OnePunch.Pages;
using OnePunchUnitTests.OnePunchPageTests;
using Xunit;

namespace OnePunchUnitTests
{
    public class OnePunchIndexRazorPageTests
    {
        private readonly Mock<ILogger<IndexModel>> indexlogger = new();
        private readonly Mock<ApplicationDbContext> mockdbcontext;
        private readonly ClaimsPrincipal claimsPrincipal;
        private readonly Punch testPunch;
        public OnePunchIndexRazorPageTests()
        {
            mockdbcontext = new Mock<ApplicationDbContext>(TestHelpers.TestDbContextOptions());
            claimsPrincipal = new(TestHelpers.GetTestClaims());
            testPunch = TestHelpers.GetTestPunches().FirstOrDefault(p=>p.Id == 1);
        }
        #region Positive Tests
        [Fact]
        public async Task TestIndexGetAsync()
        {
            //Arrange
            using var testdbContext = new ApplicationDbContext(TestHelpers.TestDbContextOptions());
            IndexModel mockIndex = new (indexlogger.Object, testdbContext);
            mockIndex.PageContext = new ();
            mockIndex.PageContext.HttpContext = new DefaultHttpContext()
            {
                User = claimsPrincipal
            };
            testdbContext.Add(testPunch);
            testdbContext.SaveChanges();
            //Act
            IActionResult result = await mockIndex.OnGetAsync() as PageResult;
            //Assert
            Assert.IsType<PageResult>(result);
            
        }

        [Fact]
        public async Task TestIndexGetHasDataAsync()
        {
            //Arrange
            using var testdbContext = new ApplicationDbContext(TestHelpers.TestDbContextOptions());
            IndexModel mockIndex = new (indexlogger.Object, testdbContext);
            mockIndex.PageContext = new();
            mockIndex.PageContext.HttpContext = new DefaultHttpContext()
            {
                User = claimsPrincipal
            };
            testdbContext.Add(testPunch);
            testdbContext.SaveChanges();
            //Act
            IActionResult result = await mockIndex.OnGetAsync();
            //Assert
            Assert.NotEmpty(mockIndex.Punches);

        }
        #endregion Positive Test

        #region Negative Tests

        [Fact]
        public async Task TestIndexGetAsyncRedirectsWhenNotSignedIn()
        {
            //Arrange
            using var testdbContext = new ApplicationDbContext(TestHelpers.TestDbContextOptions());
            IndexModel mockIndex = new(indexlogger.Object, testdbContext);
            mockIndex.PageContext = new();
            mockIndex.PageContext.HttpContext = new DefaultHttpContext()
            {
                User = null
            };
            //Act
            IActionResult result = await mockIndex.OnGetAsync();
            //Assert
            Assert.IsType<RedirectToPageResult>(result);

        }

        [Fact]
        public async Task TestIndexGetRedirectsOnNullReference()
        {
            //Arrange
            IndexModel mockIndex = new(indexlogger.Object, mockdbcontext.Object);
            NullReferenceException testexception = Assert.Throws<NullReferenceException>(() => mockdbcontext.Object.GetLastPunch(string.Empty));
            //Act
            IActionResult result = await mockIndex.OnGetAsync();
            //Assert
            Assert.Contains(testexception.Message, "Null referenced raised please ensure the userid provided is valid");
            Assert.IsType<RedirectToPageResult>(result);

        }
        #endregion Negative Tests
    }
}
