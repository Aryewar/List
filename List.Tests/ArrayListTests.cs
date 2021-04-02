using NUnit.Framework;
using System;

namespace List.Tests
{
    class ArrayListTest : BaseTest
    {
        public override void Init(int[] actualArray, int[] expectedArray)
        {
            _actual = ArrayList.Create(actualArray);
            _expected = ArrayList.Create(expectedArray);
        }

        public override void Init(int[] actualArray)
        {
            _actual = ArrayList.Create(actualArray);
        }
    }
}