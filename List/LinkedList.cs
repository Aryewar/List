using System;
using System.Text;

namespace List
{
    public class LinkedList
    {
        public int Length { get; private set; }

        private Node _head;
        private Node _tail;

        public LinkedList()
        {
            Length = 0;
            _head = null;
            _tail = null;
        }

        public LinkedList(int value)
        {
            Length = 1;
            _head = new Node(value);
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
                _tail.Next = new Node(value);
                _tail = _tail.Next;
            }
            else
            {
                _head = new Node(value);
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
            Node first = new Node(value);
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
            if ((index == Length && Length == 0) || (index >= 0 && index < Length))
            {
                if (index != 0)
                {
                    Node ByIndex = new Node(value);
                    Node current = GetNodeByIndex(index - 1);

                    ByIndex.Next = current.Next;
                    current.Next = ByIndex;

                    Length++;
                }
                else
                {
                    AddFirst(value);
                }
            }
            else
            {
                throw new IndexOutOfRangeException("Index out of range!");
            }
        }

        public void AddByIndex(int index, LinkedList newList)
        {
            if ((index == Length && Length == 0) || (index >= 0 && index < Length))
            {
                if (index != 0)
                {
                    if (newList.Length != 0)
                    {
                        Node current = GetNodeByIndex(index - 1);

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
            if (Length != 0)
            {
                RemoveByIndex(Length - 1);
            }
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
            if ((index == Length && Length == 0) || (index >= 0 && index < Length))
            {
                if (index != 0)
                {
                    if (Length != 1)
                    {
                        Node current = GetNodeByIndex(index - 1);
                        current.Next = current.Next.Next;

                        if (current.Next is null)
                        {
                            _tail = current;
                        }
                    }
                    else
                    {
                        _head = null;
                        _tail = null;
                    }
                    --Length;
                }
                else
                {
                    if (Length != 0)
                    {
                        _head = _head.Next;
                        --Length;
                    }
                }
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void Remove(int nElements)
        {
            if (nElements >= 0)
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
            else
            {
                throw new ArgumentException();
            }
        }

        public void RemoveFirst(int nElements)
        {
            if (nElements >= 0)
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
            else
            {
                throw new ArgumentException();
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
                            Node sectionStart = GetNodeByIndex(index - 1);
                            Node sectionEnd = GetNodeByIndex(index + nElements);

                            sectionStart.Next = sectionEnd;
                            Length -= nElements;
                        }
                        else
                        {
                            Node sectionStart = GetNodeByIndex(index - 1);
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

        public void SortDescending()
        {
            if (!(this is null))
            {
                Node new_root = null;

                while (_head != null)
                {
                    Node node = _head;
                    _head = _head.Next;

                    if (new_root == null || node.Value > new_root.Value)
                    {
                        node.Next = new_root;
                        new_root = node;
                    }
                    else
                    {
                        Node current = new_root;
                        while (current.Next != null && !(node.Value > current.Next.Value))
                        {
                            current = current.Next;
                        }

                        node.Next = current.Next;
                        current.Next = node;
                    }
                }

                _head = new_root;
            }
            else
            {
                throw new NullReferenceException(" List is null!");
            }
        }

        public void SortAscending()
        {
            if (!(this is null))
            {
                Node new_root = null;

                while (_head != null)
                {
                    Node node = _head;
                    _head = _head.Next;

                    if (new_root == null || node.Value < new_root.Value)
                    {
                        node.Next = new_root;
                        new_root = node;
                    }
                    else
                    {
                        Node current = new_root;
                        while (current.Next != null && !(node.Value < current.Next.Value))
                        {
                            current = current.Next;
                        }

                        node.Next = current.Next;
                        current.Next = node;
                    }
                }

                _head = new_root;
            }
            else
            {
                throw new NullReferenceException(" List is null!");
            }
        }

        public void Reverse()
        {
            if (!(this is null))
            {
                if (Length > 1)
                {
                    _tail.Next = _head;
                    Node stepByOne = _head.Next;
                    Node stepBySecond = _head.Next.Next;
                    _head.Next = null;

                    while (!(stepBySecond is null))
                    {
                        if (stepBySecond.Next is null)
                        {
                            _tail = _tail.Next;
                        }

                        stepByOne.Next = _head;
                        _head = stepByOne;
                        stepByOne = stepBySecond;
                        stepBySecond = stepBySecond.Next;
                    };
                }
            }
            else
            {
                throw new NullReferenceException(" List is null!");
            }
        }

        //// MaxI for Svyatoslav
        //// FindMaxIndex for Maksim
        public int GetMaxIndex()
        {
            if (Length != 0 || this is null)
            {
                Node current = _head;
                int maxIndex = 0;
                int maxValue = _head.Value;
                for (int i = 1; i < Length; i++)
                {
                    if (maxValue < current.Next.Value)
                    {
                        maxValue = current.Next.Value;
                        maxIndex = i;
                    }

                    current = current.Next;
                }

                return maxIndex;
            }

            throw new ArgumentException("List is null");
        }

        //// MinI for Svyatoslav
        //// FindMinIndex for Maksim
        public int GetMinIndex()
        {
            if (Length != 0 || this is null)
            {
                Node current = _head;
                int minIndex = 0;
                int minValue = _head.Value;
                for (int i = 1; i < Length; i++)
                {

                    if (minValue > current.Next.Value)
                    {
                        minValue = current.Next.Value;
                        minIndex = i;
                    }

                    current = current.Next;
                }

                return minIndex;
            }

            throw new ArgumentException("List is null");
        }

        // Max for Svyatoslav
        // FindMaxElement for Maksim
        public int GetMaxElement()
        {
            if (Length != 0 || this is null)
            {
                Node current = _head;
                int maxValue = _head.Value;
                for (int i = 1; i < Length; i++)
                {
                    if (maxValue < current.Next.Value)
                    {
                        maxValue = current.Next.Value;
                    }

                    current = current.Next;
                }

                return maxValue;
            }

            throw new ArgumentException("List is null");
        }

        //// Min for Svyatoslav
        //// FindMinElement for Maksim
        public int GetMinElement()
        {
            if (Length != 0 || this is null)
            {
                Node current = _head;
                int minValue = _head.Value;
                for (int i = 1; i < Length; i++)
                {
                    if (minValue > current.Next.Value)
                    {
                        minValue = current.Next.Value;
                    }

                    current = current.Next;
                }

                return minValue;
            }

            throw new ArgumentException("List is null");
        }

        public int GetIndexByValue(int value)
        {
            Node currentNode = _head;

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

        private Node GetNodeByIndex(int index)
        {
            if (index >= 0 || index < Length)
            {
                Node currentNode = _head;

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
            StringBuilder stringBulder = new StringBuilder();
            Node current = _head;

            while (!(current is null))
            {
                stringBulder.Append($"{current.Value} ");
                current = current.Next;
            }

            return stringBulder.ToString().Trim();
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
                    Node currentThis = this._head;
                    Node currentList = list._head;

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
