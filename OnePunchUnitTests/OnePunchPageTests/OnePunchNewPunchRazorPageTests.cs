using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Moq;
using OnePunch.Data;
using OnePunch.Models;
using OnePunch.Pages;
using Xunit;

namespace OnePunchUnitTests.OnePunchPageTests
{
    public class OnePunchNewPunchRazorPageTests
    {
        private readonly Mock<ILogger<PunchModel>> punchlogger = new();
        private readonly Mock<ApplicationDbContext> mockdbcontext;
        private readonly Mock<RoleManager<IdentityRole>> mockRoleManager = new();

        public OnePunchNewPunchRazorPageTests()
        {
            mockdbcontext = new Mock<ApplicationDbContext>(TestHelpers.TestDbContextOptions());
            mockRoleManager = new Mock<RoleManager<IdentityRole>>();
            
        }
        [Fact]
        public async Task TestGetPunch()
        {
            //Arrange
            PunchModel punchModel = new(punchlogger.Object, mockdbcontext.Object, mockRoleManager.Object);
           
            //Act
            IActionResult result = await punchModel.OnGet() as PageResult;
            //Assert
            Assert.False(true);
        }

        [Fact]
        public void TestPostPunchWillCreateOrUpdate()
        {
            //Arrange
            //Act
            //Assert
            Assert.False(true);
        }
    }
}
