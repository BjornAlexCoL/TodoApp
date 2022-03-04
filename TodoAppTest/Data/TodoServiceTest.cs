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
        public void FindByIDTest()
        {
            //Assign
            TodoService todoFind = new TodoService();
            String[] ListofTodoDesc = new string[] { "Form Group", "Call Meeting","Start Assignment"};
            List<Todo> toDoList = new List<Todo>();
            foreach (string desc in ListofTodoDesc)
            {
                toDoList.Add(todoFind.AddTodo(desc));
            }
            //Act
            Todo result = todoFind.FindById(toDoList[1].Id);
            Todo result1 = todoFind.FindById(int.MaxValue);

            //Assert
            Assert.Equal(toDoList[1].Id, result.Id);
            Assert.Equal(toDoList[1].Description, result.Description);
            Assert.Null(result1.assignee);
        }

        [Fact]
        public void FindByDoneStatusTest()
        {
            // Assign
            TodoService todoFind = new TodoService();
            String[] ListofTodoDesc = new string[] { "Form Group", "Call Meeting", "Start Assignment" };
            List<Todo> toDoList = new List<Todo>();
            for (int i = 0; i < ListofTodoDesc.Length; i++)
            {
                toDoList.Add(todoFind.AddTodo(ListofTodoDesc[i]));
            }
// Because count is 3 but list psition begin with 0. So I use minus 2 to inline the position to last 2nd in list
            int last2ndPosition = toDoList.Count - 2;
            toDoList[last2ndPosition].Done = true;
            // Act
            Todo result = todoFind.FindByDoneStatus(true);
            // Assert
            Assert.Contains(toDoList[last2ndPosition].Description, result.Description);
         }

        [Fact]
        public void FindByAssigneeTest()
        {

            //Assign
            TodoService todoFind = new TodoService();
            PeopleService personFind = new PeopleService();
            String[] ListofTodoDesc = new string[] { "Form Group", "Call Meeting", "Start Assignment" };
            String[] ListofPersonsFirst = new string[] { "Louis", "Kelvin", "Antony", "Philip" };
            String[] ListofPersonsLast = new string[] { "Lim", "Howe", "Smith", "Leo" };

            List<Todo> toDoList = new List<Todo>();
            List<Person> personList = new List<Person>();
            for (int i = 0; i < ListofPersonsFirst.Length; i++)
            {
                personList.Add(personFind.AddPerson(ListofPersonsFirst[i], ListofPersonsLast[i]));
            }
            for (int i = 0; i < ListofTodoDesc.Length; i++)
            {
                toDoList.Add(todoFind.AddTodo(ListofTodoDesc[i]));
                toDoList[i].assignee = personList[i];
            }
            // Act
            Todo result = todoFind.FindByAssignee(personList[2].Id);
            // Assert
            Assert.Equal(toDoList[1].assignee, result.assignee);
        }       
        
        [Fact]
        public void FindByAssigneeIDTest()
        {
            //Assign
            TodoService todoFind = new TodoService();
            PeopleService personFind = new PeopleService();
            String[] ListofTodoDesc = new string[] { "Form Group", "Call Meeting", "Start Assignment" };
            String[] ListofPersonsFirst = new string[] { "Louis", "Kelvin", "Antony", "Philip" };
            String[] ListofPersonsLast = new string[] { "Lim", "Howe", "Smith", "Leo" };

            List<Todo> toDoList = new List<Todo>();
            List<Person> personList = new List<Person>();
            for (int i = 0; i < ListofPersonsFirst.Length; i++)
            {
                personList.Add(personFind.AddPerson(ListofPersonsFirst[i], ListofPersonsLast[i]));
            }
            for (int i = 0; i < ListofTodoDesc.Length; i++)
            {
                toDoList.Add(todoFind.AddTodo(ListofTodoDesc[i]));
                toDoList[i].assignee = personList[i];
            }
            // Act
            Todo result = todoFind.FindByAssignee(personList[1].Id);

            // Assert
            Assert.Equal(toDoList[1].assignee, result.assignee);
        }

        [Fact]
        public void FindByUnAssignedTodoItems()
        {
            // Assign
            int expectedCount = 0;
            TodoService todoFind = new TodoService();
            PeopleService personFind = new PeopleService();
            String[] ListofTodoDesc = new string[] { "Form Group", "Call Meeting", "Start Assignment", "WIP Meeting", "Submit Report" };
            String[] ListofPersonsFirst = new string[] { "Louis", "Kelvin", "John", "Kent", "Daniel" };
            String[] ListofPersonsLast = new string[] { "LIM", "HOWE", "DAVE", "SMITH", "SUE" };
/*
  Create one list to store 5 todo items
  Create one list to store All todo assigned items (2 items)
  Create one list of 5 persons
*/
            List<Todo> toDoList = new List<Todo>();
            List<Todo> toDoListAssign = new List<Todo>();
            List<Person> personList = new List<Person>();
            for (int i = 0; i < ListofPersonsFirst.Length; i++)
            {
                personList.Add(personFind.AddPerson(ListofPersonsFirst[i], ListofPersonsLast[i]));
            }
 /*
  * Add to toDOList with reference to ListofTodoDesc (5 items)
  * Assign toDOList[2] to personList[4]
  * Assign toDOList[4] to personList[1]
  */
            for (int i = 0; i < ListofTodoDesc.Length; i++)
            {
                toDoList.Add(todoFind.AddTodo(ListofTodoDesc[i]));
                if (i == 2)
                {
                    toDoList[i].assignee = personList[4];
                    toDoListAssign.Add(toDoList[i]);

                }
                if (i == 4)
                {
                    toDoList[i].assignee = personList[1];
                    toDoListAssign.Add(toDoList[i]);
                }
            }
/*
            for (int i = 0; i < ListofTodoDesc.Length; i++)
            {
                if (toDoList[i].assignee != null && toDoList[i].assignee.Id > 0)
                    toDoListAssign.Add(todoFind.AddTodo(ListofTodoDesc[i]));
            }
*/
            // Act
            expectedCount = toDoList.Count;
            // Remove from toDOList (Total 5 items) if assigned (Two assigned)
            for (int i = 0; i < toDoList.Count; i++)
            {
                if (toDoList[i].assignee != null)
                {
                    toDoList.RemoveAt(i);

                }
            }
            expectedCount = ListofTodoDesc.Length - toDoList.Count;
            int result = toDoListAssign.Count;
            // Assert
            Assert.Null(toDoList[0].assignee);
            Assert.Null(toDoList[1].assignee);
            Assert.Null(toDoList[2].assignee);
            Assert.Equal(expectedCount, result);
        }
    }// End of Class TodoServiceTest

}// End of NameSpace
