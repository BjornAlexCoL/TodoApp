using System;
using System.Collections.Generic;
using System.Text;
using TodoApp.Models;

namespace TodoApp.Data
{
    class PeopleService
    {
        private static Person[] people = new Person[0];

        public int Size()
        {
            return people.Length;
        }
        public Person[] FindAll()
        {
            return people;
        }
        public Person FindById(int personId)
        {
            foreach (Person checkPerson in people)
            {
                if (checkPerson.Id == personId)
                {
                    return checkPerson;
                }
            }
            return new Person(0, "", "");
        }
        public Person AddPerson(string firstName, string lastName)
        {
            Person newPerson = new Person(PersonSequencer.NextPersonId(), firstName, lastName);
            if ((newPerson.Id! > 0))
            {
                Person[] newPeople = new Person[people.Length + 1];
                people.CopyTo(newPeople, 0);
                newPeople[people.Length] = newPerson;
                people = newPeople;
            }

            return newPerson;
        }

        public void clear()
        {
            people = new Person[0];
        }

    }
}
