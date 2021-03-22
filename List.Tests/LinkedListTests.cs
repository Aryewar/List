using NUnit.Framework;
using System;

namespace List.Tests
{
    class LinkedListTests
    {
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { }, new int[] { 4 })]
        public void Add_WhenAddOneNumber_ShouldAddOneNumberToEnd(int[] initialValue, int[] expectedValue)
        {
            ArrayList actual = new LinkedList(initialValue);
            ArrayList expected = new LinkedList(expectedValue);

            actual.Add(4);

            Assert.AreEqual(expected, actual);
        }
    }
}
