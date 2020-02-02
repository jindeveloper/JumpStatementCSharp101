using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace JumpStatementCSharp101
{
    [Flags]
    public enum Status : byte
    {
        NotStarted = 0,
        InProgress = 1,
        Done = 2
    }

    public class JumpStatementCSharpUnitTest
    {
        private readonly ITestOutputHelper _output;

        public JumpStatementCSharpUnitTest(ITestOutputHelper output)
        {
            this._output = output;
        }

        [Fact]
        public void Jump_Statement_Break_Inside_A_Switch_Statement()
        {
            Status myStatus = Status.Done;

            switch (myStatus)
            {
                case Status.NotStarted:
                    //do something
                    break;
                case Status.InProgress:
                    //do something
                    break;
                case Status.Done:
                    //do something
                    break;
                default:
                    break;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void Jump_Statement_Break_Test()
        {
            int counter = 0;
            int length = 10;
            int breakWhenEqualsToFive = 5;
            string message = string.Empty;

            for (int i = 0; i < length; i++)
            {
                counter = i;
                message += $"Inside the loop counter = {counter} to {length}.{Environment.NewLine}";
                if (i == breakWhenEqualsToFive)
                {
                    message += $"Breaking out counter at counter = {counter}";
                    break;
                }
            }

            Assert.Equal(breakWhenEqualsToFive, counter);
            this._output.WriteLine(message);
        }

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void Jump_Statement_Continue_Test()
        {
            List<int> evenNumbers = new List<int> { };
            Func<int, bool> isEven = x => x % 2 == 0;
            string message = string.Empty;

            for (int i = 0; i < 10; i++)
            {
                if (isEven(i))
                {
                    evenNumbers.Add(i);
                    message += $"{i} is Even. {Environment.NewLine}";
                }
                else
                {
                    continue;
                }
            }

            Assert.True(evenNumbers.SequenceEqual(new List<int> { 0, 2, 4, 6, 8 }));
            this._output.WriteLine(message);
        }

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void Jump_Statement_Goto_Inside_Switch_Statement()
        {
            var random = new System.Random();

            var values = Enum.GetValues(typeof(Status));

            var myStatus = (Status)values.GetValue(random.Next(values.Length));

            switch (myStatus)
            {
                case Status.NotStarted:
                    goto LabelNotStarted;
                case Status.InProgress:
                    goto LabelInProgress;
                case Status.Done:
                    goto LabelDone;
                default:
                    break;
            }

        LabelNotStarted:
            Assert.True(myStatus == Status.NotStarted);
            this._output.WriteLine("jumped into LabelNotStarted & status not yet started");
            return;
        LabelInProgress:
            Assert.True(myStatus == Status.InProgress);
            this._output.WriteLine("jumped into LablInProgress & status in progress");
            return;
        LabelDone:
            Assert.True(myStatus == Status.Done);
            this._output.WriteLine("jumped into LabelDone & status done");
            return;

        }
    }
}
