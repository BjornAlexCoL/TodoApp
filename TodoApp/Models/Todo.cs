using System;
using System.Collections.Generic;
using System.Text;

namespace TodoApp.Models
{
    public class Todo
    {
        static int toDoCounter = 0;

        int taskId;

        private string description;
        private bool done;

        public string Description
        {
            get { return description; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 1)
                {
                    throw new ArgumentException("Description should not be blank.");
                }
                description = value;
            }
        }

        public Todo(string description, bool done)
        {
            this.taskId = ++toDoCounter;
            this.description = description;
            this.done = done;
        }
    }
}
