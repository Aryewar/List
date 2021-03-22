using System;

namespace List
{
    class ArrayList
    {
        public int Length { get; private set; }

        private MyNode _head;
        private MyNode _tail;


        public ArrayList()
        {
            Length = 0;
            _head = null;
            _tail = null;
        }

        public ArrayList(int value)
        {
            Length = 1;
            _head = new MyNode(value);
            _tail = _head;
        }

        public ArrayList(int[] values)
        {
            Length = 0;

            if (values.Length != 0)
            {
                _head = new MyNode(values[0]);
                _tail = _head;
                ++Length;

                for (int i = 1; i < values.Length; ++i)
                {
                    Add(values[i]);
                }
            }
            else
            {
                _head = null;
                _tail = null;
            }


        }

        public void Add(int value)
        {
            _tail.Next = new MyNode(value);
            _tail = _tail.Next;
            ++Length;
        }

        public int this[int index]
        {
            get
            {
                MyNode currentNode = GetNodeByIndex(index);

                return currentNode.Value;
            }

            set
            {
                MyNode currentNode = GetNodeByIndex(index);

                currentNode.Value = value;
            }
        }

        private MyNode GetNodeByIndex(int index)
        {
            MyNode currentNode = _head;

            for(int i = 1; i <= index; ++i)
            {
                currentNode = currentNode.Next;
            }

            return currentNode;
        }
    }
}
