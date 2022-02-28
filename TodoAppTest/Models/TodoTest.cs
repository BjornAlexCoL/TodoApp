using System;
using System.Collections.Generic;
using System.Text;
using TodoApp.Models;
using Xunit;

namespace TodoAppTest.Models
{
    class TodoTest
    {
        public void ToDoConstructorTest()
        {
            //Arrange
            string description = "Create week1 Assignment";
            bool done = false;

            //Act
            Todo result = new Todo(description, done);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(description, result.Description);
        }
    }
}
