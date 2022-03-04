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
        [InlineData("Björn", "Larsson", true)]
        [InlineData("Nisse", "Hult", true)]
        [InlineData("Kalle", "Duva", true)]
        [InlineData("Olle", "Svensson", true)]
        [InlineData("", "Svensson", false)]
        [InlineData("Olle", "", false)]

        public void AddPersonTest(string firstName, string lastName, bool expected)
        {
            //assign
            PeopleService personList = new PeopleService();

            //Act
            Person result = personList.AddPerson(firstName, lastName);

            //Assert
            Assert.Equal(expected, result != null);

        }
        [Theory]
        [InlineData(1, true)]
        [InlineData(2, true)]
        [InlineData(3, true)]
        [InlineData(4, true)]
        [InlineData(5, false)]
        [InlineData(0, false)]
        public void RemovePersonTest(int personId, bool expected)
        {
            //Assign
            PeopleService personList = new PeopleService();
            Populate(personList);

            //Act
            bool result = personList.RemovePerson(personId);

            //Assert
            Assert.Equal(expected, result);
        }
        [Theory]
        [InlineData(1, 0)]
        [InlineData(2, 1)]
        [InlineData(3, 2)]
        [InlineData(4, 3)]
        [InlineData(5, 4)]
        [InlineData(0, 4)]

        public void GetIndexForPersonIdTest(int personId, int expected)
        {
            //Assign
            PeopleService personList = new PeopleService();
            Populate(personList);

            //Act
            int result = personList.GetIndexForPersonId(personId);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void FindAllTest()
        {
            int expected = 4;
            PeopleService personList = new PeopleService();
            Populate(personList);

            int result = personList.FindAll().Length;
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(0, false)]
        [InlineData(1, true)]
        [InlineData(2, true)]
        [InlineData(3, true)]
        [InlineData(4, true)]
        [InlineData(5, false)]
        public void FindByIDTest(int id, bool expected)
        {
            PeopleService personList = new PeopleService();
            Populate(personList);
            Person result = personList.FindById(id);

            Assert.Equal(expected, (result != null));

        }

        [Fact]
        public void SizeTest()
        {
            int expected = 4;
            PeopleService personList = new PeopleService();
            Populate(personList);
            int result = personList.Size();
            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(4, 4)]
        [InlineData(0, 0)]
        public void ClearTest(int result, int expected)
        {

            PeopleService personList = new PeopleService();
            Populate(personList);
            if (expected == 0)
            {
                personList.clear();
            }

            Assert.Equal(expected, result);
        }

        private void Populate(PeopleService personList) //Clear list, reset personSequencer, Populate personlist
        {
            personList.clear();
            PersonSequencer.Reset();
            personList.AddPerson("Björn", "Larsson");
            personList.AddPerson("Nisse", "Hult");
            personList.AddPerson("", "Svensson");
            personList.AddPerson("Kalle", "Duva");
            personList.AddPerson("Olle", "Svensson");
            personList.AddPerson("Olle", "");

        }
    }//End Class
}
