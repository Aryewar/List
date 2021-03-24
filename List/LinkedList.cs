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
            if (!(values is null))
            {
                Length = 0;

                if (values.Length != 0)
                {
                    for (int i = 0; i < values.Length; ++i)
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
            else
            {
                throw new ArgumentException();
            }
        }

        public void Add(int value)
        {
            if (Length != 0)
            {
                _tail.Next = new MyNode(value);
                _tail = _tail.Next;
            }
            else
            {
                _head = new MyNode(value);
                _tail = _head;
            }

            ++Length;
        }

        public void Add(LinkedList newList)
        {
            if (!(newList is null))
            {
                for (int i = 0; i < newList.Length; ++i)
                {
                    Add(newList[i]);
                }
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public void AddFirst(int value)
        {
            ++Length;
            MyNode first = new MyNode(value);
            first.Next = _head;
            _head = first;
        }

        public void AddFirst(LinkedList newList)
        {
            if (!(newList is null))
            {
                for (int i = newList.Length - 1; i >= 0; --i)
                {
                    AddFirst(newList[i]);
                }
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public void AddByIndex(int index, int value)
        {
            if (index >= 0 || index < Length)
            {
                if (Length != 0)
                {
                    MyNode byIndexNode = new MyNode(value);
                    MyNode currentNode = GetNodeByIndex(index);

                    byIndexNode.Next = currentNode.Next;
                    currentNode.Next = byIndexNode;
                }
                else
                {
                    _head = new MyNode(value);
                    _tail = _head;
                }

                ++Length;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void AddByIndex(int index, LinkedList newList)
        {
            if (index >= 0 || index < Length)
            {
                if (index != 0)
                {
                    if (newList.Length != 0)
                    {
                        MyNode current = GetNodeByIndex(index - 1);

                        newList._tail.Next = current.Next;
                        _tail = current;
                        int newLengthList = newList.Length + Length - index;
                        Length = index;

                        for (int i = 0; i < newLengthList; i++)
                        {
                            Add(newList[i]);
                        }

                        newList._tail.Next = null;
                    }
                }
                else
                {
                    AddFirst(newList);
                }
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void Remove()
        {
            RemoveByIndex(Length - 1);
        }

        public void RemoveFirst()
        {
            if (Length != 0)
            {
                _head = _head.Next;
                --Length;
            }
        }

        public void RemoveByIndex(int index)
        {
            if (Length != 0)
            {
                if (Length > 1)
                {
                    MyNode current = GetNodeByIndex(index - 1);
                    current.Next = null;
                    _tail = current;
                }
                else
                {
                    _head = null;
                    _tail = null;
                }

                --Length;
            }
        }

        public void Remove(int nElements)
        {
            if (Length != 0)
            {
                if (Length - nElements >= 0)
                {
                    Length -= nElements;
                    _tail = GetNodeByIndex(Length - 1);
                    _tail.Next = null;
                }
                else
                {
                    Length = 0;
                    _head = null;
                    _tail = null;
                }
            }
        }

        public void RemoveFirst(int nElements)
        {
            if (Length != 0)
            {
                if (Length - nElements >= 0)
                {
                    _head = GetNodeByIndex(nElements);
                    Length -= nElements;
                }
                else
                {
                    Length = 0;
                    _head = null;
                    _tail = null;
                }
            }
        }

        public void RemoveByIndex(int index, int nElements)
        {
            if ((index >= 0 && index < Length) && nElements >= 0)
            {
                if (Length != 0 || nElements != 0)
                {
                    if (index != 0)
                    {
                        if (Length - index - nElements > 0)
                        {
                            MyNode sectionStart = GetNodeByIndex(index - 1);
                            MyNode sectionEnd = GetNodeByIndex(index + nElements);

                            sectionStart.Next = sectionEnd;
                            Length -= nElements;
                        }
                        else
                        {
                            MyNode sectionStart = GetNodeByIndex(index - 1);
                            sectionStart.Next = null;
                            _tail = sectionStart;
                            Length = index;
                        }
                    }
                    else
                    {
                        RemoveFirst(nElements);
                    }
                }
            }
            else
            {
                throw new ArgumentException("Wrong arguments");
            }
        }

        public void RemoveByValue(int value)
        {
            int index = GetIndexByValue(value);

            if(index != -1)
            {
                RemoveByIndex(index);
            }
        }

        public void RemoveAllByValue(int value)
        {
            int index = GetIndexByValue(value);

            while(index != -1)
            {
                RemoveByIndex(index);
                index = GetIndexByValue(value);
            }
        }

        public int GetIndexByValue(int value)
        {
            MyNode currentNode = _head;

            for(int i = 0; i < Length; ++i)
            {
                if(currentNode.Value == value)
                {
                    return i;
                }

                currentNode = currentNode.Next;
            }

            return -1;
        }

        public int this[int index]
        {
            get
            {
                return GetNodeByIndex(index).Value;
            }

            set
            {
                GetNodeByIndex(index).Value = value;
            }
        }

        private MyNode GetNodeByIndex(int index)
        {
            if (index >= 0 || index < Length)
            {
                MyNode currentNode = _head;

                for (int i = 1; i <= index; ++i)
                {
                    currentNode = currentNode.Next;
                }

                return currentNode;
            }

            throw new IndexOutOfRangeException();
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
            if ((obj is ArrayList) || !(obj is null))
            {
                LinkedList list = (LinkedList)obj;
                bool isEqual = false;

                if (this.Length == list.Length)
                {
                    isEqual = true;
                    MyNode currentThis = this._head;
                    MyNode currentList = list._head;

                    while (!(currentThis is null))
                    {
                        if (currentThis.Value != currentList.Value)
                        {
                            isEqual = false;
                            break;
                        }
                        currentList = currentList.Next;
                        currentThis = currentThis.Next;
                    }
                }

                return isEqual;
            }

            throw new ArgumentException();
        }
    }
}
