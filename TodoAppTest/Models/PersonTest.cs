using System;
using System.Collections.Generic;
using System.Text;
using TodoApp.Models;
using Xunit;

namespace TodoAppTest.Models
{
    public class PersonTest
    {
        [Theory]
        [InlineData(1, 1)]
        public void PersonIdTest(int id, int expected)
        {
            //Assign
            Person person = new Person(id);
            //Act
            int result = person.Id;

            //assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1, "Björn", "Larsson", "Björn")]
        [InlineData(1, "", "Larsson", null)]
        [InlineData(2, "Björn", "Larsson", "Björn")]

        public void PersonFirstNameTest(int id, string firstName, string lastName, string expected)
        {
            //Assign
            Person personOne = new Person(id, firstName, lastName);
            Person personTwo = new Person(id);

            //Act
            personTwo.FirstName = firstName;
            string resultOne = personOne.FirstName;
            string resultTwo = personTwo.FirstName;

            //assert
            Assert.Equal(expected, resultOne);
            Assert.Equal(expected, resultTwo);
        }
        [Theory]
        [InlineData(1, "Björn", "Larsson", "Larsson")]
        [InlineData(1, "Björn", "", null)]
        [InlineData(2, "Björn", "Larsson", "Larsson")]

        public void PersonLastNameTest(int id, string firstName, string lastName, string expected)
        {
            //Assign
            //Assign
            Person personOne = new Person(id, firstName, lastName);
            Person personTwo = new Person(id);

            //Act
            personTwo.LastName = lastName;
            string resultOne = personOne.LastName;
            string resultTwo = personTwo.LastName;

            //assert
            Assert.Equal(expected, resultOne);
            Assert.Equal(expected, resultTwo);

        }
    }
}
