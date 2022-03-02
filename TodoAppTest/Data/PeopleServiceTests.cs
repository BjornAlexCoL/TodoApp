using System;
using System.Collections.Generic;
using System.Text;
using TodoApp.Models;
using TodoApp.Data;

using Xunit;

namespace TodoAppTest.Data
{
    public class PeopleServiceTests
    {
        [Theory]
        [InlineData("Björn", "Larsson", "1\tBjörn Larsson")]
        [InlineData("Nisse", "Hult", "2\tNisse Hult")]
        [InlineData("", "Larsson", "0\t")]
        [InlineData("Björn", "", "0\t")]
        public void AddPerson(string firstName, string lastName, string expected)
        {
            //Assign
            PeopleService personList = new PeopleService();
            //Act
            Person addedPerson = personList.AddPerson(firstName, lastName);
            string result = $"{addedPerson.Id}\t{addedPerson.Name}";

            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("Björn", "Larsson", "1\tBjörn Larsson")]
        [InlineData("Nisse", "Hult", "1\tNisse Hult")]
        [InlineData("", "Larsson", "1\t")]
        [InlineData("Björn", "", "1\t")]
        public void ClearTest(string firstName, string lastName, string expected)
        {
            PeopleService personList = new PeopleService();
            personList.clear();
            Person addedPerson = personList.AddPerson(firstName, lastName);
            string result = $"{addedPerson.Id}\t{addedPerson.Name}";

            Assert.Equal(expected, result);
        }
    }//End Class
}
