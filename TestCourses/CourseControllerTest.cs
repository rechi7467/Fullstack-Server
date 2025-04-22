using Microsoft.AspNetCore.Mvc;
using project.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;


namespace TestCourses
{
    public class CourseControllerTest
    {
        [Fact]
        public void GetById_ReturnsOk()
        {
            //Arrange

            //Act
            var controller = new CourseController();
            var result = controller.GetCourseById(1);

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
