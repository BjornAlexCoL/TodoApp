using System;
using System.Collections.Generic;
using System.Text;
using TodoApp.Models;

namespace TodoApp.Data
{
    class TodoService
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

                Todo[] newTaskTodo = new Todo[todo.Length + 1];
                todo.CopyTo(newTaskTodo, 0);
                newTaskTodo[todo.Length] = newTodo;
                todo = newTaskTodo;

            return newTodo;
        }
        public void Clear()
        {
            todo = new Todo[0];
        }

        public Todo FindByDoneStatus(bool doneStatus)
        {
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
        }
    }
}
