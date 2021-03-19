using System;

namespace List
{
    public class ArrayList
    {
        public int Length { get; private set; }

        private int[] _array;
        private const int zeroIndex = 0;
        private const int shiftByOne = 1;

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
            if (initArray != null)
            {
                Length = initArray.Length;
                _array = new int[(int)(Length * 1.33d + 1)];

                for (int i = 0; i < Length; ++i)
                {
                    _array[i] = initArray[i];
                }
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public void Add(int value)
        {
            Resize(Length);
            _array[Length] = value;
            ++Length;
        }

        public void Add(ArrayList list)
        {
            if (list != null)
            {
                int oldLength = Length;
                Length += list.Length;
                Resize(oldLength);
                for (int i = 0; i < list.Length; ++i)
                {
                    _array[oldLength + i] = list[i];
                }
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public void AddFirst(ArrayList list)
        {
            if (list != null)
            {
                int oldLength = Length;
                Length += list.Length;
                Resize(oldLength);
                ShiftRight(list.Length - 1, list.Length);

                for (int i = 0; i < list.Length; ++i)
                {
                    _array[i] = list[i];
                }
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public void AddFirst(int value)
        {
            ++Length;
            Resize(Length);
            ShiftRight(zeroIndex, shiftByOne);
            _array[zeroIndex] = value;
        }

        public void AddByIndex(int index, int value)
        {
            if (index < Length && index >= 0)
            {
                int countElements = 1;

                Resize(Length);
                ShiftRight(index, countElements);

                _array[index] = value;
                ++Length;
            }
            else
            {
                throw new IndexOutOfRangeException("Index Out Of Randge ");
            }
        }

        public void AddByIndex(int index, ArrayList list)
        {
            if (index > Length && index < 0)
            {
                throw new IndexOutOfRangeException("Index Out Of Randge ");
            }
            if(list == null)
            {
                throw new ArgumentNullException();
            }

            int oldLength = Length;
            Length += list.Length;
            Resize(oldLength);
            ShiftRight(index + list.Length, list.Length);

            for (int i = 0; i < list.Length; ++i)
            {
                _array[i + index + 1] = list[i];
            }
        }

        public void Remove()
        {
            if (Length > 0)
            {
                --Length;
                Resize(Length);
            }
        }

        public void RemoveFirst()
        {
            if (Length > 0)
            {
                ShiftLeft(zeroIndex, shiftByOne);
                --Length;
            }

            Resize(Length);
        }

        public void RemoveByIndex(int index)
        {
            ShiftLeft(index, shiftByOne);

            --Length;
            Resize(Length);
        }

        public void Remove(int nElelements)
        {
            Length -= Length >= nElelements ? nElelements : Length;
            Resize(Length);
        }

        public void RemoveFirst(int nElelements)
        {
            Length -= Length >= nElelements ? nElelements : Length;

            ShiftLeft(zeroIndex, nElelements);

            Resize(Length);
        }

        public void RemoveByIndex(int index, int nElelements)
        {
            if (Length - index >= nElelements)
            {
                Length -= nElelements;
                ShiftLeft(index, nElelements);
            }
            else
            {
                Length = index;
            }
                Resize(Length);
        }

        public int GetIndex(int value)
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

        public void Reverse()
        {
            int swapIndex;
            for (int i = 0; i < Length / 2; ++i)
            {
                swapIndex = Length - i - 1;
                Swap(i, swapIndex);
            }
        }

        public int GetMaxIndex()
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

        public int GetMinIndex()
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

        public int GetMax()
        {
            return _array[GetMaxIndex()];
        }

        public int GetMin()
        {
            return _array[GetMinIndex()];
        }

        public int this[int index]
        {
            get
            {
                return _array[index];
            }

            set
            {
                if (index < Length && index >= 0)
                {
                    _array[index] = value;
                }

                throw new IndexOutOfRangeException("Index Out Of Randge ");
            }
        }

        public void RemoveByValue(int value)
        {
            RemoveByIndex(GetIndex(value));
        }

        public void RemoveAllByValue(int value)
        {
            int indexOfElements = GetIndex(value);
            while (indexOfElements != -1)
            {
                RemoveByIndex(indexOfElements);
                indexOfElements = GetIndex(value);
            }
        }

        public void SortAscending()
        {
            if (_array != null)
            {
                for (int i = 0; i < Length; ++i)
                {
                    int maxIndex = i;
                    for (int j = i; j < Length; ++j)
                    {
                        if (_array[j] < _array[maxIndex])
                        {
                            maxIndex = j;
                        }
                    }

                    Swap(i, maxIndex);
                }
            }
        }

        public void SortDescending()
        {
            if (_array != null)
            {
                for (int i = 0; i < Length; ++i)
                {
                    int maxIndex = i;
                    for (int j = i; j < Length; ++j)
                    {
                        if (_array[j] > _array[maxIndex])
                        {
                            maxIndex = j;
                        }
                    }

                    Swap(i, maxIndex);
                }
            }
        }

        public override string ToString()
        {
            string realValues = String.Empty;

            for(int i = 0; i < Length; ++i)
            {
                realValues += _array[i] + " ";
            }

            return realValues;
        }

        public override bool Equals(object obj)
        {
            ArrayList list = (ArrayList) obj;
            bool isEqual = false;

            if(this.Length == list.Length)
            {
                isEqual = true;

                for (int i = 0; i < Length; ++i)
                {
                    if (this._array[i] != list._array[i])
                    {
                        isEqual = false;
                        break;
                    }
                }
            }

            return isEqual;
        }

        private void Resize(int oldLength)
        {
            if((Length >= _array.Length) || (Length <= _array.Length / 2))
            {
                int newLength = (int)(Length * 1.33d + 1);
                int[] tempArray = new int[newLength];

                for (int i = 0; i < oldLength; ++i)
                {
                    tempArray[i] = _array[i];
                }

                _array = tempArray;
            }
        }

        private void ShiftRight(int index, int nElements)
        {
            for (int i = Length - 1; i > index; i--)
            {
                _array[i] = _array[i - nElements];
            }
        }

        private void ShiftLeft(int index, int nElements)
        {
            for (int i = index; i < Length; i++)
            {
                _array[i] = _array[i + nElements];
            }
        }

        private void Swap(int firstIndex, int secondIndex)
        {
            int temp = _array[firstIndex];
            _array[firstIndex] = _array[secondIndex];
            _array[secondIndex] = temp;
        }


    }
}

