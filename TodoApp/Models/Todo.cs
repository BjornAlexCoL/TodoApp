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
        private Person assignee;

        public Todo(int id, string description)
        {
            if (id < 1)
            {
                throw new ArgumentOutOfRangeException("The ToDo ID should not be less than 1");
            }

            this.id = id;
            this.description = description;
        }
        public int Id
        { get => id; }
        public string Description
        {
            get { return description; }
            set
            {
               if (string.IsNullOrWhiteSpace(value) || value.Length < 2)
                {
                    throw new ArgumentException("Description should not be blank.");
 //                   throw new Exception("Exception throwed");
               }
               description = value;
            }
        }

    }// End Class Todo
}
