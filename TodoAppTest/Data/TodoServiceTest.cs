using System;
using System.Collections.Generic;
using System.Text;
using TodoApp.Data;
using TodoApp.Models;
using Xunit;
using System.Linq;


namespace TodoAppTest.Data
{
    public class TodoServiceTest
    {
        [Theory]
        [InlineData("Form Group", "1: Form Group")]
        [InlineData("Call Meeting", "2: Call Meeting")]
 
        public void AddTodoTest(string desc, string expected)
        {
            //Assign
            TodoService todoList = new TodoService();
            //Act
            Todo addedlist = todoList.AddTodo(desc);
            string result = $"{addedlist.Id}: {addedlist.Description}";

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TodoClearTest()
        {
            // Assign
            int expected = 0;
            TodoService todoList = new TodoService();
            String[] ListofTodo = new string[] { "Form Group", "Call Meeting" };
            foreach (string desc in ListofTodo)
            {
                Todo addedList = todoList.AddTodo(desc);
            }
            // ACT
                 todoList.Clear();
            int result = todoList.Size();
            //
            Assert.Equal(expected, result);
        }

        [Fact]
        public void FindByDoneStatusTest()
        {
            // Assign
            TodoService todoFind = new TodoService();
            String[] ListofTodo = new string[] { "Form Group", "Call Meeting" };
            foreach (string desc in ListofTodo)
            {
                Todo addedList = todoFind.AddTodo(desc);
            }
            int expected = ListofTodo.Length;
            // Act
            todoFind.FindByDoneStatus(false);
            int result=todoFind.Size();
            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void FindByIDTest()
        {
            //Assign
            //Act

            //Assert
        }
    }
}
