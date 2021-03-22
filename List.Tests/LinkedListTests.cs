using NUnit.Framework;
using System;

namespace List.Tests
{
    class LinkedListTests
    {
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, 5 })]
        [TestCase(new int[] { }, new int[] { 5 })]
        public void Add_WhenAddOneNumber_ShouldAddOneNumberToEnd(int[] initialValue, int[] expectedValue)
        {
            LinkedList actual = new LinkedList(initialValue);
            LinkedList expected = new LinkedList(expectedValue);

            actual.Add(5);

            Assert.AreEqual(expected, actual);
        }
    }
}
