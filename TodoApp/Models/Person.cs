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

        public Person(int id, string firstName, string lastName) //Create Person if id,firstName and LastName populate it otherwise it's null. 
        {
            if ((!String.IsNullOrWhiteSpace(firstName)) && (!String.IsNullOrWhiteSpace(lastName)) && (!(id <= 0)))
            {
                this.id = id;
                this.firstName = firstName;
                this.lastName = lastName;
            }
        }

        public int Id //Get id
        {
            get => id;
        }
        public string FirstName //Get firstName If valid lastName set it.
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
        public string LastName //Get lastName If valid lastName set it.
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

        public string Name //Get full Name
        {
            get => $"{firstName} {lastName}";
        } 
    }
}
