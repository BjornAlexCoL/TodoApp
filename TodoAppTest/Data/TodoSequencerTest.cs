using System;
using System.Collections.Generic;
using System.Text;
using TodoApp.Data;
using Xunit;

namespace TodoAppTest.Data
{
    public class TodoSequencerTest
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void NextTodoIdTest(int expected)
        {
            //Assign
            TodoSequencer.Reset();
            int result = 0;
            //Act           
            for (int i = 0; i < expected; i++)
            {
                result = TodoSequencer.NextTodoId();
            }
            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void resetTodoIdTest()
        {
            //Assign
            int expected = 1;
            TodoSequencer.Reset();
            //Act           
            int result = TodoSequencer.NextTodoId();
            //Assert
            Assert.Equal(expected, result);
        }

    }
}
