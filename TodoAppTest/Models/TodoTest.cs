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
        public void TodoDescriptionTest()
        {
            // Assign
            int id = 1;
            string expected = "Form working group.";
            // Act
            Todo result = new Todo(id, expected);
            // Assert
            Assert.Equal(result.Description, expected);
        }

        [Fact]
        public void BadIDTest()
        {
            // Assign
            int id = 0;
            string desc = "Assign Job";

            // Act
            Assert.Throws<ArgumentException>(() => new Todo(id, desc));
            // Assert
        }

        [Fact]
            public void BadDescriptionTest()
        {
            // Assign
            int id = 1;
            string desc = " ";

            // Act
            Assert.Throws<ArgumentException>(() => new Todo(id, desc));
            // Assert
        }


    }// End of TodoTest Class
}// End of NameSpace
