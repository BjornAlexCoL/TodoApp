using System;
using System.Collections.Generic;
using System.Text;
using TodoApp.Data;
using Xunit;

namespace TodoAppTest.Data
{
    public class PersonSequencerTest
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void NextPersonIdTest(int expected)
        {
            //Assign
            PersonSequencer.Reset();
            int result = 0;
            //Act           
            for (int loop = 0; loop < expected; loop++)
            {
                result = PersonSequencer.NextPersonId();
            }
            //Assert
            Assert.Equal(expected, result);
        }
        [Theory]
        [InlineData(1)]
        public void resetTest(int expected)
        {
            //Assign
            PersonSequencer.Reset();
            //Act           
            int result = PersonSequencer.NextPersonId();
            //Assert
            Assert.Equal(expected, result);
        }

    }
}
