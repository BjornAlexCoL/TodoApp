using System;
using System.Collections.Generic;
using System.Text;

namespace TodoApp.Models
{
    public class Todo
    {

        private int id;
        private string description;
        private bool done;
        public Person assignee;

        public string Description
        {
            get { return description; }
            set
            {
               if ((!String.IsNullOrWhiteSpace(description) || description.Length < 2))
               {
                    throw new ArgumentException("Invalid Data found!!!");
               }
               description = value;
            }
        }
        public bool Done
        {
            get { return done; }
            set { done = value; }
        }

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
            }
        }


        public Todo()
        { }

        public Todo(int id)
        {
            if (id < 1 || id == int.MaxValue)
            {
                throw new ArgumentOutOfRangeException("ID setting is out of range!!!");
            }
            this.id = id;
        }
        public Todo(Person assignee)
        {
            this.assignee = assignee;
        }

        public Todo(int id, string description)        
        {
            this.id = id;
            this.description = description;
        }

        public Todo(int id, string description, bool done)
        {
            this.done = done;
            this.id = id;
            this.description = description;
        }
        
        public Todo(int id, string description, bool done, Person person)
        {
            this.done = done;
            this.id = id;
            this.description = description;
            this.assignee = person;
        }

    }// End Class Todo
}
