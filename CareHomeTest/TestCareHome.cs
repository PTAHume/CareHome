﻿using CareHome.Controllers;
using CareHome.Data;
using CareHome.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Newtonsoft.Json;
using Assert = Xunit.Assert;
using RedirectToActionResult = Microsoft.AspNetCore.Mvc.RedirectToActionResult;
using ViewResult = Microsoft.AspNetCore.Mvc.ViewResult;
namespace CareHomeTest
{

    public class TestCareHome
    {
        private protected DbContextOptions<CareHomeContext> _contextOptions;

        private protected CareHomeContext _context;

        public TestCareHome()
        {
            _contextOptions = new DbContextOptionsBuilder<CareHomeContext>()
                      .UseInMemoryDatabase("CareHomeControllerTest2")
                      .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                      .ConfigureLoggingCacheTime(new TimeSpan(new DateTime().AddMinutes(1).Ticks))
                      .Options;
            _context = new CareHomeContext(_contextOptions);
        }

        [Fact]

        public async Task Get_JobTitles_Returns_JSON_Data()
        {
            //Arrange

            var jobTitles = new List<JobTitles>() { new JobTitles() { Title = "foo", DefaultSalary = 0, Description = "foo", JobTitlesId = 1 } };
            _context.Departments.Add(new Departments() { Name = "foo", Description = "foo", DepartmentId = 1, JobTitles = jobTitles });
            _context.JobTitles.AddRange(jobTitles);
            _context.SaveChanges();
            var controller = new StaffController(_context);
            List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> testList = new() {
                new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Text = string.Empty, Value = "-1", Selected = true },
                new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Text = "foo", Value = "1" }
            };

            //Act
            var response = controller.GetJobList(1);
            string json = JsonConvert.SerializeObject(response.Value);

            //Assert
            Assert.IsAssignableFrom<IEnumerable<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>>(
                  JsonConvert.DeserializeObject<IEnumerable<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>>(json));
            List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> resultList = JsonConvert.DeserializeObject<IEnumerable<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>>(json).ToList();
            resultList.Should().BeEquivalentTo(testList);
        }

        [Fact]
        public async Task Annotations_Enforce_Required_Attributee()
        {
            //Arrange

            DbUpdateConcurrencyException error = null;

            string message = String.Empty;
            _context.Staff.AddRange(new List<Staff>() { new Staff() });

            //Act
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                message = e.Message.ToString();
            };

            //Assert
            Assert.True(message.Contains("Forename", StringComparison.InvariantCultureIgnoreCase)
                && message.Contains("LastName", StringComparison.InvariantCultureIgnoreCase));
        }

        [Fact]
        public async Task Index_ReturnsAViewResult_WithACareHome()
        {
            // Arrange
            _context.Staff.Add(new Staff() { CareHomesId = 1, DOB = new DateTime(), Forename = "foo", LastName = "foo", MiddleNames = "", Salary = 0, StaffId = 1 });

            _context.SaveChanges();
            ViewResult? viewResult = null;
            var controller = new StaffController(_context);

            // Act
            ViewResult result = (ViewResult)await controller.Index(1);

            // Assert
            viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Staff>>(viewResult.ViewData.Model);
            Assert.Equal(1, model.Count());
        }

        [Fact]
        public async Task EditPost_ReturnsARedirect_WhenModelStateIsValid()
        {
            // Arrange
            Qualifications qualifications = new Qualifications()
            {
                QualificationsId = 1,
                AttainmentDate = new DateTime(),
                Grade = "foo",
                InstitutionalName = "foo",
                Name = "foo",
                QualificationType = "foo"
            };

            _context.Qualifications.Add(qualifications);

            _context.SaveChanges();

            var controller = new QualificationsController(_context);

            // Act
            var result = await controller.Edit(1, qualifications);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }

        [Fact]
        public async Task Edit_ReturnsNotFound_GivenInvalidId()
        {
            // Arrange & Act
            var controller = new CareHomesController(_context);
            controller.ModelState.AddModelError("error", "some error");

            // Act
            var result = await controller.Edit(-1);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Create_Returns_InvalidModel()
        {
            // Arrange & Act
            var controller = new StaffController(_context);
            controller.ModelState.AddModelError("error", "some error");

            // Act
            var result = await controller.Create(new Staff());

            // Assert
            Assert.False(controller.ModelState.IsValid);
        }
    }
}
