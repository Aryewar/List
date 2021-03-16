using System;

namespace List
{
    public class ArrayList
    {
        public int Length { get; private set; }

        private int[] _array;

        public ArrayList()
        {
            Length = 0;
            _array = new int[10];
        }

        public ArrayList(int value)
        {
            Length = 1;
            _array = new int[10];
            _array[0] = value;
        }

        public ArrayList(int[] initArray)
        {
            Length = 0;
            _array = new int[initArray.Length];
            for (int i = 0; i < initArray.Length; ++i)
            {
                AddEnd(initArray[i]);
            }
        }

        public void AddEnd(int value)
        {
            if (Length >= _array.Length)
            {
                ReSize(true);
            }
            _array[Length] = value;

            ++Length;
        }

        public void AddInStart(int value)
        {

            if (Length == _array.Length)
            {
                ReSize(true);
            }

            for (int i = Length; i >= 0; --i)
            {
                _array[i + 1] = _array[i];
            }
            _array[0] = value;

            ++Length;
        }

        public void Insert(int index, int value)
        {
            if (index < Length && index >= 0)
            {
                if (Length == _array.Length)
                {
                    ReSize(true);
                }

                for (int i = Length; i >= index; --i)
                {
                    _array[i + 1] = _array[i];
                }

                _array[index] = value;
                ++Length;
            }
            else
            {
                throw new IndexOutOfRangeException("Index Out Of Randge ");
            }
        }

        public int GetValue(int index)
        {
            if (index < Length && index >= 0)
            {
                return _array[index];
            }

            throw new IndexOutOfRangeException("Index Out Of Randge ");
        }

        public void RemoveEnd()
        {
            if (Length < _array.Length / 2)
            {
                ReSize(false);
            }

            --Length;

        }

        public void RemoveFront()
        {
            if (Length < _array.Length / 2)
            {
                ReSize(false);
            }

            for (int i = 0; i < Length; ++i)
            {
                _array[i] = _array[i + 1];
            }

            --Length;
        }

        public void Remove(int index)
        {
            if (Length <= _array.Length / 2)
            {
                ReSize(false);
            }

            for (int i = index; i < Length; ++i)
            {
                _array[i] = _array[i + 1];

            }

            --Length;
        }

        public void RemoveEnd(int nElelements)
        {

            Length -= Length >= nElelements ? nElelements : Length;

            if (Length <= _array.Length / 2)
            {
                ReSize(false);
            }
        }

        public void Remove(int index, int nElelements)
        {

            for (int i = 0; i < Length; ++i)
            {
                _array[i] = _array[i + 1];
            }

            --Length;

        }

        public void RemoveFront(int nElelements)
        {
            Length -= Length >= nElelements ? nElelements : Length;

            for (int i = 0; i < Length; ++i)
            {
                _array[i] = _array[i + nElelements];
            }

            if (Length != 0 && Length <= _array.Length / 2)
            {
                ReSize(false);
            }
        }

        public void RemoveNElementsInsert(int index, int nElelements)
        {
            if (Length - index >= nElelements)
            {
                Length -= nElelements;

                for (int i = index; i < Length; ++i)
                {
                    _array[i] = _array[i + nElelements];
                }

            }
            else
            {
                Length = index;
            }

            if (Length != 0 && Length <= _array.Length / 2)
            {
                ReSize(false);
            }
        }

        public int IndexOf(int value)
        {
            for (int i = 0; i < Length; ++i)
            {
                if (value == _array[i])
                {
                    return i;
                }
            }

            return -1;
        }

        public void ChangeByIndex(int index, int value)
        {
            if (index < Length && index >= 0)
            {

                _array[index] = value;
            }
            else
            {
                throw new IndexOutOfRangeException("Index Out Of Randge ");
            }
        }

        public void ReversArray()
        {
            int swapIndex;
            for (int i = 0; i < Length / 2; ++i)
            {
                swapIndex = Length - i - 1;
                Swap(_array[i], _array[swapIndex]);
            }
        }

        public int MaxI()
        {
            int maxIndexOfElement = 0;
            for (int i = 1; i < Length; ++i)
            {
                if (_array[maxIndexOfElement] < _array[i])
                {
                    maxIndexOfElement = i;
                }
            }

            return maxIndexOfElement;
        }

        public int MinI()
        {
            int minIndexOfElement = 0;

            for (int i = 1; i < Length; ++i)
            {
                if (_array[minIndexOfElement] > _array[i])
                {
                    minIndexOfElement = i;
                }
            }

            return minIndexOfElement;
        }

        public int Max()
        {
            return _array[MaxI()];
        }

        public int Min()
        {
            return _array[MinI()];
        }

        public void RemoveValue(int value)
        {
            Remove(IndexOf(value));
        }

        public void RemoveAllValue(int value)
        {
            int indexOfElements = IndexOf(value);
            while (indexOfElements != -1)
            {
                Remove(indexOfElements);
                indexOfElements = IndexOf(value);
            }
        }

        private void ReSize(bool upDown)
        {
            int newLength = upDown ? (int)(_array.Length * 1.33d + 1) : (int)(_array.Length / 1.33d + 1);
            int[] tempArray = new int[newLength];

            for (int i = 0; i < Length; ++i)
            {
                tempArray[i] = _array[i];
            }

            _array = tempArray;
        }

        private void Swap(int first, int second)
        {
            int temp = first;
            first = second;
            second = first;
        }
    }
}

