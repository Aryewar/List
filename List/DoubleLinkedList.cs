using System;
using System.Collections.Generic;
using System.Text;

namespace List
{
    public class DoubleLinkedList
    {
        private DoubleNode _head;
        private DoubleNode _tail;

        public int Length { get; private set; }
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

        public DoubleLinkedList()
        {
            Length = 0;
            _head = null;
            _tail = null;
        }
        public DoubleLinkedList(int value)
        {
            Length = 1;
            _head = new DoubleNode(value);
            _tail = _head;
        }

        public DoubleLinkedList(int[] values)
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
                throw new ArgumentException(" Array is Null");
            }
        }

        public void Add(int value)
        {
            if (Length != 0)
            {
                DoubleNode current = _tail;
                _tail.Next = new DoubleNode(value);
                _tail = _tail.Next;
                _tail.Previous = current;
            }
            else
            {
                _head = new DoubleNode(value);
                _tail = _head;
            }

            ++Length;
        }

        public void Add(DoubleLinkedList list)
        {
            if (!(list is null))
            {
                DoubleNode current = list._head;
                int value = 0;

                while (!(current is null))
                {
                    value = current.Value;
                    Add(value);
                    current = current.Next;
                }
            }
            else
            {
                throw new ArgumentException(" List is null");
            }
        }
        public void AddFirst(int value)
        {
            DoubleNode first = new DoubleNode(value);

            if (Length != 0)
            {
                first.Next = _head;
                _head.Previous = first;
                _head = first;
            }
            else
            {
                first.Next = _head;
                _head = first;
                _tail = _head;
            }

            ++Length;
        }

        public void AddFirst(DoubleLinkedList list)
        {
            if (!(list is null))
            {
                DoubleNode current = list._tail;
                int value = 0;

                while (!(current is null))
                {
                    value = current.Value;
                    AddFirst(value);
                    current = current.Previous;
                }
            }
            else
            {
                throw new ArgumentException(" List is null");
            }
        }

        public void AddByIndex(int index, int value)
        {
            if ((index == Length && Length == 0) || (index >= 0 && index < Length))
            {
                if (index != 0)
                {
                    DoubleNode ByIndex = new DoubleNode(value);

                    DoubleNode current = GetNodeByIndex(index);

                    InsertNode(ByIndex, current);

                    ++Length;
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

        public void AddByIndex(int index, DoubleLinkedList newList)
        {
            if ((index == Length && Length == 0) || (index >= 0 && index < Length))
            {
                if (index != 0)
                {
                    if (newList.Length != 0)
                    {
                        DoubleNode current = GetNodeByIndex(index);
                        DoubleNode NewList = newList._head;

                        for (int i = 0; i < newList.Length; ++i)
                        {
                            DoubleNode currentNewList = new DoubleNode(NewList.Value);

                            InsertNode(currentNewList, current);

                            NewList = NewList.Next;
                            ++Length;
                        }
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
                if (Length != 1)
                {
                    _tail = _tail.Previous;
                    _tail.Next = null;
                    --Length;
                }
                else
                {
                    _head = null;
                    _tail = null;
                    Length = 0;
                }
            }
        }

        public void RemoveFirst()
        {
            if (Length > 1)
            {
                _head = _head.Next;
                _head.Previous = null;
                --Length;
            }
            else if (Length == 1)
            {
                _head = _head.Next;
                _tail = null;
                --Length;
            }
        }

        public void RemoveByIndex(int index)
        {
            if ((index == Length && Length == 0) || (index >= 0 && index < Length))
            {
                if (index != 0 && index != Length - 1)
                {
                    if (Length != 1)
                    {
                        DoubleNode current = GetNodeByIndex(index - 1);

                        current.Next = current.Next.Next;
                        current.Next.Previous = current;

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
                else if(index == 0)
                {
                    RemoveFirst();
                }
                else
                {
                    Remove();
                }
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void Remove(int count)
        {
            if (count >= 0)
            {
                if (Length != 0 && count != 0)
                {
                    if (Length - count >= 0)
                    {
                        Length -= count;
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
                throw new ArgumentException("Wrong arguments");
            }
        }

        public void RemoveFirst(int count)
        {
            if (count >= 0)
            {
                if (Length != 0 && count != 0)
                {
                    if (Length - count >= 0)
                    {
                        _head = GetNodeByIndex(count);
                        Length -= count;
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
                throw new ArgumentException("Wrong arguments");
            }
        }

        public void RemoveByIndex(int index, int count)
        {
            if ((index >= 0 && index < Length) && count >= 0)
            {
                if (Length != 0 || count != 0)
                {
                    if (index != 0)
                    {
                        if (Length - index - count > 0)
                        {
                            DoubleNode sectionStart = GetNodeByIndex(index - 1);
                            DoubleNode sectionEnd = GetNodeByIndex(index + count);

                            sectionStart.Next = sectionEnd;
                            sectionEnd.Previous = sectionStart;
                            Length -= count;
                        }
                        else
                        {
                            DoubleNode sectionStart = GetNodeByIndex(index - 1);
                            sectionStart.Next = null;
                            _tail = sectionStart;
                            Length = index;
                        }
                    }
                    else
                    {
                        RemoveFirst(count);
                    }
                }
            }
            else
            {
                throw new ArgumentException("Wrong arguments");
            }
        }

        //GetIndexByValue for Maksim
        // indexOf for Svyatoslav
        public int GetIndexByValue(int value)
        {
            DoubleNode currentNode = _head;

            for (int i = 0; i < Length; ++i)
            {
                if (currentNode.Value == value)
                {
                    return i;
                }

                currentNode = currentNode.Next;
            }

            return -1;
        }

        public void RemoveByValue(int value)
        {
            int index = GetIndexByValue(value);

            if (index != -1)
            {
                RemoveByIndex(index);
            }

        }

        public void RemoveAllByValue(int value)
        {
            int index = GetIndexByValue(value);

            while (index != -1)
            {
                RemoveByIndex(index);
                index = GetIndexByValue(value);
            }

        }

        //// MaxI for Svyatoslav
        //// FindMaxIndex for Maksim
        public int GetMaxIndex()
        {
            if (Length != 0 || this is null)
            {
                DoubleNode current = _head;
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
                DoubleNode current = _head;
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
                DoubleNode current = _head;
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
                DoubleNode current = _head;
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

        public void Reverse()
        {
            if (!(this is null))
            {
                if (Length > 1)
                {
                    DoubleNode stepByOne = _head.Next;

                    _head.Previous = stepByOne;
                    _head.Next = null;

                    while (stepByOne != _tail)
                    {
                        DoubleNode tmp = stepByOne.Next;
                        stepByOne.Next = stepByOne.Previous;
                        stepByOne.Previous = tmp;

                        stepByOne = stepByOne.Previous;
                    };

                    stepByOne.Next = stepByOne.Previous;
                    stepByOne.Previous = null;
                    _tail = _head;
                    _head = stepByOne;
                }
            }
        }

        public void Sort(bool isDescending)
        {
            if (!(this is null))
            {
                DoubleNode new_root = null;

                while (_head != null)
                {
                    DoubleNode node = _head;
                    _head = _head.Next;

                    if (new_root == null || (node.Value > new_root.Value && isDescending) || (node.Value < new_root.Value && !isDescending))
                    {
                        node.Next = new_root;
                        node.Previous = null;

                        if (node.Next is null)
                        {
                            _tail = node;
                        }
                        else
                        {
                            node.Next.Previous = node;
                        }

                        new_root = node;
                    }
                    else
                    {
                        DoubleNode current = new_root;

                        while ((current.Next != null && !(node.Value > current.Next.Value) && isDescending) || (current.Next != null && !(node.Value < current.Next.Value) && !isDescending))
                        {
                            current = current.Next;
                        }

                        node.Next = current.Next;

                        if (node.Next is null)
                        {
                            _tail = node;
                        }
                        else
                        {
                            node.Next.Previous = node;
                        }

                        current.Next = node;
                        node.Previous = current;
                    }
                }

                _head = new_root;
            }
        }

        public override string ToString()
        {
            StringBuilder stringBulder = new StringBuilder();
            DoubleNode current = _head;

            while (!(current is null))
            {
                stringBulder.Append($"{current.Value} ");
                current = current.Next;
            }

            return stringBulder.ToString().Trim();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is null) || obj is DoubleLinkedList)
            {
                DoubleLinkedList list = (DoubleLinkedList)obj;
                bool isEqual = false;

                if (this.Length == list.Length)
                {
                    isEqual = true;
                    DoubleNode currentThis = this._head;
                    DoubleNode currentList = list._head;
                    DoubleNode currentPrevThis = this._tail;
                    DoubleNode currentPrevList = list._tail;

                    while (!(currentThis is null))
                    {
                        if (currentThis.Value != currentList.Value || currentPrevThis.Value != currentPrevList.Value)
                        {
                            isEqual = false;
                            break;
                        }

                        currentThis = currentThis.Next;
                        currentList = currentList.Next;
                        currentPrevThis = currentPrevThis.Previous;
                        currentPrevList = currentPrevList.Previous;
                    }
                }

                return isEqual;
            }

            throw new ArgumentException("obj is not LinkedList");
        }

        private void InsertNode(DoubleNode newNode, DoubleNode current)
        {
            newNode.Next = current;
            newNode.Previous = current.Previous;
            current.Previous.Next = newNode;
            current.Previous = newNode;
        }

        private DoubleNode GetNodeByIndex(int index)
        {
            if (index >= 0 || index < Length)
            {
                DoubleNode current;

                if (index <= Length - 1 / 2)
                {
                    current = _head;

                    for (int i = 1; i <= index; ++i)
                    {
                        current = current.Next;
                    }
                }
                else
                {
                    current = _tail;

                    for (int i = Length - 2; i <= index; i--)
                    {
                        current = current.Previous;
                    }
                }

                return current;
            }

            throw new IndexOutOfRangeException("Index out of range");
        }
    }
}
