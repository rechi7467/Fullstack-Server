using Microsoft.AspNetCore.Mvc;
using project.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCourses
{
    public class TeacherControllerTest
    {
        [Fact]
        public void GetById_ReturnsOk()
        {
            //Arrange

            //Act
            var controller = new TeacherController();
            var result = controller.GetTeacherById(1);

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
