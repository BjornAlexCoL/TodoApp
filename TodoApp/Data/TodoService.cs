using System;
using System.Collections.Generic;
using System.Text;
using TodoApp.Models;

namespace TodoApp.Data
{
    public class TodoService
    {
        private static Todo[] todo = new Todo[0];

        public int Size()
        {
            return todo.Length;
        }
        public Todo[] FindAll()
        {
            return todo;
        }

        public Todo FindById(int todoId)
        {
            Todo foundToDo = new Todo();
            foreach (Todo checkTodo in todo)
            {
                if (checkTodo.Id == todoId)
                {
                    foundToDo = checkTodo;
                }
            }
            return foundToDo;
        }

        public Todo AddTodo(string desc)
        {

            Todo newTodo = new Todo(TodoSequencer.NextTodoId(), desc, false);
 //           if ((newTodo.Id! > 0))
 //           {
                Todo[] newTaskTodo = new Todo[todo.Length + 1];
                todo.CopyTo(newTaskTodo, 0);
                newTaskTodo[todo.Length] = newTodo;
                todo = newTaskTodo;
 //           }
            return newTodo;
        }


        public void Clear()
        {
            todo = new Todo[0];
        }

        public Todo FindByDoneStatus(bool doneStatus)
        {
                Todo foundToDo = new Todo();
                foreach (Todo checkTodo in todo)
                {
                    if (checkTodo.Done == doneStatus)
                    {
                        foundToDo = checkTodo;
                    }
                }
                return foundToDo;
        }
 
        public Todo FindByAssignee(int personID)
        {
            Todo foundToDo = new Todo();
            foreach (Todo checkTodo in todo)
            {
                if ((checkTodo.assignee != null) && checkTodo.assignee.Id == personID)
                {
                    foundToDo = checkTodo;
                }
            }
            /*
            Todo foundToDo = new Todo();
            Todo[] checkTodo =  FindAll();

            for (int i=0; i<todo.Length; i++)
            {
                if (checkTodo[i].assignee.Id == personID)
                {
                        foundToDo = checkTodo[i];
                }
            }
            */

            return foundToDo;
        }

        public Todo FindByUnAssigneeTodoItems()
        {
            Todo foundToDo = new Todo();
            foreach (Todo checkTodo in todo)
            {
                if (checkTodo.assignee==null)
                {
                    foundToDo = checkTodo;
                }
            }
            return foundToDo;
        }
    }// End of Class TodoService
}// End NameSpace
