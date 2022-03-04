using System;
using System.Collections.Generic;
using System.Text;
using TodoApp.Models;

namespace TodoApp.Data
{
    public class PeopleService
    {
        private static Person[] people = new Person[0]; //Create People Array

        public int Size() //Return number of Persons in array
        {
            return people.Length;
        }
        public Person[] FindAll() //Return all persons in people array.
        {
            return people;
        }
        public Person FindById(int personId) //Return Person with ID if not found return null
        {
            foreach (Person checkPerson in people)
            {
                if (checkPerson.Id == personId)
                {
                    return checkPerson;
                }
            }
            return null;
        }
        public Person AddPerson(string firstName, string lastName) //Add person to People array if not a valid person return null
        {
            Person newPerson = null;
            if ((!string.IsNullOrWhiteSpace(firstName)) && (!string.IsNullOrWhiteSpace(lastName)))
            {
                newPerson = new Person(PersonSequencer.NextPersonId(), firstName, lastName);
                Array.Resize<Person>(ref people, people.Length + 1);
                people[people.Length - 1] = newPerson;
            }

            return newPerson;
        }

        public void clear() //Flush people array
        {
            people = new Person[0];
        }

    }
}
