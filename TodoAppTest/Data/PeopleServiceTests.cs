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
        PeopleService personList = new PeopleService();
    
        [Theory]
        [InlineData("Björn", "Larsson", "1\tBjörn Larsson")]
        [InlineData("Nisse", "Hult", "3\tNisse Hult")]
        [InlineData("", "Larsson", "2\t Larsson")]
        [InlineData("Björn", "", "4\tBjörn ")]
        public void AddPersonTest(string firstName, string lastName, string expected)
        {
            //Assign
            //Act
            Person addedPerson = personList.AddPerson(firstName, lastName);
            string result = $"{addedPerson.Id}\t{addedPerson.Name}";

            //Assert
            Assert.Equal(expected, result);
        }




        [Theory]
        [InlineData("Björn", "Larsson", 1)]
        [InlineData("Nisse", "Hult", 2)]
        [InlineData("", "Larsson", 3)]
        [InlineData("Björn", "", 4)]
        public void SizeTest(string firstName, string lastName, int expected)
        {
            //Assign
            //Act
            Person addedPerson = personList.AddPerson(firstName, lastName);
            int result = personList.Size();
            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("Björn", "Larsson", "0\tBjörn Larsson")]
        [InlineData("Nisse", "Hult", "1\tNisse Hult")]
        public void ClearTest(string firstName, string lastName, string expected)
        {

            Person addedPerson = personList.AddPerson(firstName, lastName);
            string result = $"{addedPerson.Id}\t{addedPerson.Name}";

            personList.clear();
            Assert.Equal(expected, result);
        }
    }//End Class
}
