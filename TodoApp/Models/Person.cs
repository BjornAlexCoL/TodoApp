using System;
using System.Collections.Generic;
using System.Text;

namespace TodoApp.Models
{
    public class Person
    {
        private int id;
        private string firstName;
        private string lastName;

        public Person(int id)
        {
            this.id = id;
        }
        public Person(int id, string firstName, string lastName) : this(id)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public int Id
        {
            get => id;
        }
        public string FirstName
        {
            get => firstName;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    firstName = value;
                }
            }
        }
        public string LastName
        {
            get => lastName;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    lastName = value;
                }
            }
        }

    }
}
