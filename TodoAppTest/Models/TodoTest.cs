using System;
using System.Collections.Generic;
using System.Text;
using TodoApp.Models;
using Xunit;

namespace TodoAppTest.Models
{
    public class TodoTest
    {
        [Fact]
        public void ToDoConstructorTest()
        {
            //Arrange
            int id = 1;
            string desc = "Meet on team";
            //Act
            Todo result = new Todo(id, desc);
            //Assert
            Assert.Equal(id, result.Id);
            Assert.Equal(desc, result.Description);
            Assert.NotNull(result);
        }
        [Fact]
        public void BadIdTest()
        {
         //Arrange
            int id = 0;
            string desc = "Organise work.";
         //Act

         //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Todo(id, desc));
    }
    }

}
