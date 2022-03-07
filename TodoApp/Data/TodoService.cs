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

        public Todo[] FindByDoneStatus(bool doneStatus)
        {
            List<Todo> foundTodo = new List<Todo>();
                foreach (Todo checkTodo in todo)
                {
                    if (checkTodo.Done == doneStatus)
                    {
                        foundTodo.Add(checkTodo);
                    }
                }
                return foundTodo.ToArray();
        }
 
        public Todo[] FindByAssignee(int personId)
        {
            List<Todo> foundTodo = new List<Todo>();
            foreach (Todo checkTodo in todo)
            {
                if ((checkTodo.assignee.Id == personId))
                {
                    foundTodo.Add(checkTodo);
                }
            }
            return foundTodo.ToArray();
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
        }
        public Todo[] FindByAssignee(Person findPerson)
        { 
            if (findPerson == null)
            {
                return null;
            }
            return FindByAssignee(findPerson.Id);
        }
        public Todo[] FindByUnAssigneeTodoItems()
        {
            List<Todo> foundTodo = new List<Todo>();
            foreach (Todo checkTodo in todo)
            {
                if (checkTodo.assignee==null)
                {
                    foundTodo.Add(checkTodo);
                }
            }
            return foundTodo.ToArray();
        }
    }// End of Class TodoService
}// End NameSpace
