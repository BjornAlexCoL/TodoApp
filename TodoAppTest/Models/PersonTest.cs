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
        [InlineData(1, "Björn", "Larsson", "Björn")]
        [InlineData(1, "", "Larsson", null)]
        [InlineData(2, "Björn", "Larsson", "Björn")]

        public void PersonFirstNameTest(int id, string firstName, string lastName, string expected)
        {
            //Assign
            Person personOne = new Person(id, firstName, lastName);

            //Act
            string resultOne = personOne.FirstName;

            //assert
            Assert.Equal(expected, resultOne);
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

            //Act
            string resultOne = personOne.LastName;

            //assert
            Assert.Equal(expected, resultOne);

        }
        [Theory]
        [InlineData(1, "Björn", "Larsson", "Björn Larsson")]
        [InlineData(1, "Björn", "", " ")]
        [InlineData(1, "", "Larsson",  " ")]
        [InlineData(2, "Nisse", "Hult", "Nisse Hult")]
        public void PersonNameTest(int id,string firstName,string lastName, string expected)
        {
            //Assign
            Person person = new Person(id, firstName, lastName);

            //Act
            string result = person.Name;

            //Assert
            Assert.Equal(expected, result);
        }
    }
}
