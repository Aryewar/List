using System;
using System.Collections.Generic;
using System.Text;

namespace List
{
    class MyNode
    {
        public int Value { get; set; }
        public MyNode Next { get; set; }

        public MyNode(int value)
        {
            Value = value;
            Next = null;
        }
    }
}
