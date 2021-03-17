using NUnit.Framework;

//Индексатор, энумератор
namespace List.Tests
{
    public class ArrayListTests
    {
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, 4, 4 })]
        public void Add_WhenAddOneNumber_ShouldAddOneNumberToEnd(int[] initialValue, int[] expectedValue)
        {
            ArrayList actual = new ArrayList(initialValue);
            ArrayList expected = new ArrayList(expectedValue);

            actual.Add(4);

            Assert.AreEqual(expected, actual);
        }
    }
}