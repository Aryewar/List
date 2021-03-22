using System;

namespace List
{
    public class LinkedList
    {
        public int Length { get; private set; }

        private MyNode _head;
        private MyNode _tail;


        public LinkedList()
        {
            Length = 0;
            _head = null;
            _tail = null;
        }

        public LinkedList(int value)
        {
            Length = 1;
            _head = new MyNode(value);
            _tail = _head;
        }

        public LinkedList(int[] values)
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
            if (Length != 0)
            {
                _tail.Next = new MyNode(value);
                _tail = _tail.Next;
                ++Length;
            }
            else
            {
                Length = 1;
                _head = new MyNode(value);
                _tail = _head;
            }
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

        public override string ToString()
        {
            if (Length != 0)
            {
                MyNode currentNode = _head;
                string s = currentNode.Value + " ";

                while (!(currentNode.Next is null))
                {
                    currentNode = currentNode.Next;
                    s += currentNode.Value + " ";
                }

                return s;
            }
            else
            {
                return String.Empty;
            }
        }

        public override bool Equals(object obj)
        {
            LinkedList list = (LinkedList)obj;

            if (this.Length != list.Length)
            {
                return false;
            }

            MyNode currentThis = this._head;
            MyNode currentList = list._head;

            while (!(currentThis.Next is null))
            {
                if (currentThis.Value != currentList.Value)
                {
                    return false;
                }
                currentList = currentList.Next;
                currentThis = currentThis.Next;
            }

            if (currentThis.Value != currentList.Value)
            {
                return false;
            }

            return true;
        }
    }
}
