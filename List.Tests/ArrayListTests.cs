using NUnit.Framework;

//Индексатор, энумератор
namespace List.Tests
{
    public class ArrayListTests
    {
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { }, new int[] { 4 })]
        public void Add_WhenAddOneNumber_ShouldAddOneNumberToEnd(int[] initialValue, int[] expectedValue)
        {
            ArrayList actual = new ArrayList(initialValue);
            ArrayList expected = new ArrayList(expectedValue);

            actual.Add(4);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, 4 }, new int[] {1, 2, 3, 1, 2, 3, 4})]
        public void Add_WhenAddArrayList_ShouldAddArrayList(int[] firstVal, int[] secondVal, int[] expectedValue)
        {
            ArrayList actual = new ArrayList(firstVal);
            ArrayList expected = new ArrayList(expectedValue);
            ArrayList secondList = new ArrayList(secondVal);

            actual.Add(secondList);

            Assert.AreEqual(actual, expected);
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4, 1, 2, 3 })]
        public void AddFirst_WhenAddArrayList_ShouldAddArrayListToFront(int[] firstVal, int[] secondVal, int[] expectedValue)
        {
            ArrayList actual = new ArrayList(firstVal);
            ArrayList expected = new ArrayList(expectedValue);
            ArrayList secondList = new ArrayList(secondVal);

            actual.AddFirst(secondList);

            Assert.AreEqual(actual, expected);
        }

        [TestCase(new int[] { 1, 2, 3 }, 4, new int[] { 4, 1, 2, 3 })]
        public void AddFirst_WhenAddOneNum_ShouldAddOneNumToFront(int[] firstVal, int secondVal, int[] expectedValue)
        {
            ArrayList actual = new ArrayList(firstVal);
            ArrayList expected = new ArrayList(expectedValue);

            actual.AddFirst(secondVal);

            Assert.AreEqual(actual, expected);
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 3, 2, 1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 6, 5, 4, 3, 2, 1 })]
        public void Reverse_WhenList_ShouldReverseList(int[] initialValue, int[] expectedValue)
        {
            ArrayList actual = new ArrayList(initialValue);
            ArrayList expected = new ArrayList(expectedValue);

            actual.Reverse();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, 4 }, 1, new int[] { 1, 2, 1, 2, 3, 4, 3 })]
        public void AddByIndex_WhenAddArrayList_ShouldAddArrayListByIndex(int[] firstVal, int[] secondVal, int index, int[] expectedValue)
        {
            ArrayList actual = new ArrayList(firstVal);
            ArrayList expected = new ArrayList(expectedValue);
            ArrayList secondList = new ArrayList(secondVal);

            actual.AddByIndex(index, secondList);

            Assert.AreEqual(actual, expected);
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 4, 1, 2, 3 })]
        public void AddFirst_WhenAddOneNumber_ShouldAddOneNumberToFront(int[] initialValue, int[] expectedValue)
        {
            ArrayList actual = new ArrayList(initialValue);
            ArrayList expected = new ArrayList(expectedValue);

            actual.AddFirst(4);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 4, 2, 3, 5 }, new int[] { 5, 4, 3, 2, 1 })]
        [TestCase(new int[] { 1, -4, 2, 3, 0 }, new int[] { 3, 2, 1, 0, -4 })]
        [TestCase(new int[] { }, new int[] { })]
        public void SortDescending_WhenUnsortedList_ShouldSortDescending(int[] initialValue, int[] expectedValue)
        {
            ArrayList actual = new ArrayList(initialValue);
            ArrayList expected = new ArrayList(expectedValue);

            actual.SortDescending();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 4, 2, 3, 5 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, -4, 2, 3, 0 }, new int[] { -4, 0, 1, 2, 3 })]
        [TestCase(new int[] { }, new int[] { })]
        public void SortAscending_WhenUnsortedList_ShouldSortAscending(int[] initialValue, int[] expectedValue)
        {
            ArrayList actual = new ArrayList(initialValue);
            ArrayList expected = new ArrayList(expectedValue);

            actual.SortAscending();

            Assert.AreEqual(expected, actual);
        }
    }
}