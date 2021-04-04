using NUnit.Framework;
using System;

namespace List.Tests
{
    class LinkedListTest : BaseTest
    {
        public override void Init(int[] actualArray, int[] expectedArray)
        {
            _actual = LinkedList.Create(actualArray);
            _expected = LinkedList.Create(expectedArray);
        }

        public override void Init(int[] actualArray)
        {
            _actual = LinkedList.Create(actualArray);
        }
    }
}
