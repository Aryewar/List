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

        [TestCase(new int[] { 1, 2, 3 }, 2, new int[] { 4, 5, 6 }, new int[] { 1, 2, 4, 5, 6, 3 })]
        [TestCase(new int[] { 1, 2, 3 }, 0, new int[] { 4, 5, 6 }, new int[] { 4, 5, 6, 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3 }, 1, new int[] { 4, 5, 6 }, new int[] { 1, 4, 5, 6, 2, 3 })]
        [TestCase(new int[] { }, 0, new int[] { 4, 5, 6 }, new int[] { 4, 5, 6 })]
        [TestCase(new int[] { 1, 2, 3 }, 0, new int[] { }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3 }, 2, new int[] { }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { }, 0, new int[] { }, new int[] { })]
        [TestCase(new int[] {1 }, 0, new int[] { 1 }, new int[] { 1, 1 })]
        public void AddByIndex_WhenListAndIndexPassed_ThenAddListByIndex(int[] arrayForActualList, int index, int[] arrayForList, int[] arrayForExpectedList)
        {
            LinkedList actual = new LinkedList(arrayForActualList);
            LinkedList expected = new LinkedList(arrayForExpectedList);
            LinkedList list = new LinkedList(arrayForList);

            actual.AddByIndex(index, list);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, 0, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3 }, 2, new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3 }, 3, new int[] { })]
        [TestCase(new int[] { 1, 2, 3 }, 4, new int[] { })]
        [TestCase(new int[] { }, 2, new int[] { })]
        public void Remove_WhenMethodCalled_ThenRemoveNElemetsFromEnd(int[] arrayForActualList, int nElements, int[] arrayForExpectedList)
        {
            LinkedList actual = new LinkedList(arrayForActualList);
            LinkedList expected = new LinkedList(arrayForExpectedList);

            actual.Remove(nElements);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, 0, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3 }, 2, new int[] { 3 })]
        [TestCase(new int[] { 1, 2, 3 }, 3, new int[] { })]
        [TestCase(new int[] { 1, 2, 3 }, 4, new int[] { })]
        [TestCase(new int[] { }, 2, new int[] { })]
        public void RemoveFirst_WhenMethodCalled_ThenRemoveNElemetsFromFront(int[] arrayForActualList, int nElements, int[] arrayForExpectedList)
        {
            LinkedList actual = new LinkedList(arrayForActualList);
            LinkedList expected = new LinkedList(arrayForExpectedList);

            actual.RemoveFirst(nElements);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, 0, 3, new int[] { })]
        [TestCase(new int[] { 1, 2, 3 }, 0, 4, new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 8, 0, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 7, 0, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 7, 1, new int[] { 1, 2, 3, 4, 5, 6, 7, 9 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 7, 2, new int[] { 1, 2, 3, 4, 5, 6, 7 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 7, 10, new int[] { 1, 2, 3, 4, 5, 6, 7 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 8, 10, new int[] { 1, 2, 3, 4, 5, 6, 7, 8 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 8, 8, new int[] { 1, 2, 3, 4, 5, 6, 7, 8 })]
        public void RemoveByIndex_WhenIndexAndNElements_ThenRemoveByIndexNElements(int[] arrayForActualList, int index, int nElements, int[] arrayForExpectedList)
        {
            LinkedList actual = new LinkedList(arrayForActualList);
            LinkedList expected = new LinkedList(arrayForExpectedList);

            actual.RemoveByIndex(index, nElements);

            Assert.AreEqual(expected, actual);
        }
    }
}
